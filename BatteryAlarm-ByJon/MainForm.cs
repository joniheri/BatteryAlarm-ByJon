using System.Drawing;
using Microsoft.Win32;
using BatteryAlarm_ByJon.Models;
using BatteryAlarm_ByJon.Services;
using BatteryAlarm_ByJon.Forms;

namespace BatteryAlarm_ByJon
{
    public partial class MainForm : Form
    {

        private bool previousChargingState = false;

        private readonly BatteryService batteryService;

        private readonly NotificationService notificationService;

        private readonly BatterySettings batterySettings;

        private bool isRealExit = false;

        public MainForm()
        {

            InitializeComponent();

            chkRunBackground.Checked = Properties.Settings.Default.RunInBackground;

            chkRunStartup.Checked = Properties.Settings.Default.RunAtStartup;

            notifyTray.Icon = SystemIcons.Information;

            notifyTray.Visible = false;

            batteryService = new BatteryService();

            notificationService = new NotificationService();

            batterySettings = new BatterySettings();

            notifyBattery.Icon = SystemIcons.Information;

            btnSaveSettings.Enabled = false;

            InitializeSettings();

            LoadBatteryInformation();

            batteryTimer.Start();

        }

        private void InitializeSettings()
        {
            numLowBattery.Value = batterySettings.LowBatteryThreshold;

            numFullBattery.Value = batterySettings.FullBatteryThreshold;
        }

        private void LoadBatteryInformation()
        {
            PowerStatus power = SystemInformation.PowerStatus;

            int batteryPercent = (int)(power.BatteryLifePercent * 100);

            batteryPercent = Math.Max(0, Math.Min(100, batteryPercent));

            lblBatteryPercent.Text = batteryPercent + "%";

            progressBattery.Value = batteryPercent;

            bool isCharging = power.PowerLineStatus == PowerLineStatus.Online;

            if (isCharging)
            {
                lblChargingStatus.Text = "Charging";
            }
            else
            {
                lblChargingStatus.Text = "Not Charging";
            }

            HandleChargingStateChange(isCharging);

            if (isCharging)
            {
                CheckBatteryNotification(batteryPercent);
            }

        }

        private void HandleChargingStateChange(bool isCharging)
        {
            // Charger baru dicolok
            if (!previousChargingState && isCharging)
            {
                notificationService.ResetNotification();
            }

            // Charger dicabut
            if (previousChargingState && !isCharging)
            {
                notificationService.CloseNotification();
            }

            previousChargingState = isCharging;
        }

        private void CheckBatteryNotification(int batteryPercent)
        {
            if (!notificationService.CanShowNotification())
                return;

            // Battery Low
            if (batteryPercent <= batterySettings.LowBatteryThreshold)
            {
                notificationService.ShowNotification("Battery Low", $"Battery is at {batteryPercent}%", ToolTipIcon.Warning);

                return;
            }

            // Battery Full
            if (batteryPercent >= batterySettings.FullBatteryThreshold)
            {
                notificationService.ShowNotification("Battery Full", $"Battery is already {batteryPercent}%", ToolTipIcon.Info);

                return;
            }
        }

        private void CheckSettingsChanged()
        {
            bool isChanged = batterySettings.LowBatteryThreshold != (int)numLowBattery.Value || batterySettings.FullBatteryThreshold != (int)numFullBattery.Value;

            btnSaveSettings.Enabled = isChanged;
        }

        private void SetStartup(bool enable)
        {
            string appName = "BatteryAlarm";

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);

            if (enable)
            {
                key?.SetValue(
                    appName,
                    Application.ExecutablePath
                );
            }
            else
            {
                key?.DeleteValue(
                    appName,
                    false
                );
            }
        }

        private void batteryTimer_Tick(object sender, EventArgs e)
        {
            LoadBatteryInformation();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            int lowValue = (int)numLowBattery.Value;
            int fullValue = (int)numFullBattery.Value;

            if (lowValue >= fullValue)
            {
                MessageBox.Show("Low Battery must be smaller than Full Battery!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            batterySettings.LowBatteryThreshold = lowValue;
            batterySettings.FullBatteryThreshold = fullValue;
            btnSaveSettings.Enabled = false;

            MessageBox.Show("Settings saved successfully!", "Battery Alarm", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void numLowBattery_ValueChanged(object sender, EventArgs e)
        {
            CheckSettingsChanged();
        }

        private void numFullBattery_ValueChanged(object sender, EventArgs e)
        {
            CheckSettingsChanged();
        }

        private void numLowBattery_KeyUp(object sender, KeyEventArgs e)
        {
            CheckSettingsChanged();
        }

        private void numFullBattery_KeyUp(object sender, KeyEventArgs e)
        {
            CheckSettingsChanged();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (chkRunBackground.Checked && !isRealExit)
            {
                e.Cancel = true;

                notifyTray.Visible = true;

                this.Hide();

                notifyTray.ShowBalloonTip(3000, "Battery Alarm", "Program running in background", ToolTipIcon.Info);
            }
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            this.Show();

            this.WindowState = FormWindowState.Normal;

            notifyTray.Visible = false;
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            isRealExit = true;

            notifyTray.Visible = false;

            Application.Exit();
        }

        private void chkRunBackground_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.RunInBackground = chkRunBackground.Checked;

            Properties.Settings.Default.Save();
        }

        private void chkRunStartup_CheckedChanged(object sender, EventArgs e)
        {
            SetStartup(chkRunStartup.Checked);

            Properties.Settings.Default.RunAtStartup = chkRunStartup.Checked;

            Properties.Settings.Default.Save();
        }
    }
}
