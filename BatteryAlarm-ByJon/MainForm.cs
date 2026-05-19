using System.Drawing;

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

        public MainForm()
        {

            InitializeComponent();

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
                notificationService.ShowNotification(
                    "Battery Low",
                    $"Battery is at {batteryPercent}%",
                    ToolTipIcon.Warning
                );

                return;
            }

            // Battery Full
            if (batteryPercent >= batterySettings.FullBatteryThreshold)
            {
                notificationService.ShowNotification(
                    "Battery Full",
                    $"Battery is already {batteryPercent}%",
                    ToolTipIcon.Info
                );

                return;
            }
        }

        private void CheckSettingsChanged()
        {
            bool isChanged = batterySettings.LowBatteryThreshold != (int)numLowBattery.Value || batterySettings.FullBatteryThreshold != (int)numFullBattery.Value;

            btnSaveSettings.Enabled = isChanged;
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
                MessageBox.Show(
                    "Low Battery must be smaller than Full Battery!",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

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
    }
}
