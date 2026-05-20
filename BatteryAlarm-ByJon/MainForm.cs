using BatteryAlarm_ByJon.Models;
using BatteryAlarm_ByJon.Services;

namespace BatteryAlarm_ByJon
{
    public partial class MainForm : Form
    {

        private bool previousChargingState = false;

        private readonly BatteryService batteryService;

        private readonly NotificationService notificationService;

        private readonly BatterySettings batterySettings;

        private readonly StartupService startupService;

        private readonly SettingsService settingsService;

        private readonly TrayService trayService;

        private bool isRealExit = false;

        public MainForm(
            BatteryService batteryService,
            NotificationService notificationService,
            BatterySettings batterySettings,
            StartupService startupService,
            SettingsService settingsService
         )
        {

            InitializeComponent();

            this.batteryService = batteryService;
            this.notificationService = notificationService;
            this.batterySettings = batterySettings;
            this.startupService = startupService;
            this.settingsService = settingsService;

            trayService = new TrayService(notifyTray);

            notifyTray.Text = "Battery Alarm";

            notifyTray.Visible = true;

            notifyTray.DoubleClick += notifyTray_DoubleClick;

            notifyTray.Icon = SystemIcons.Information;

            notifyTray.Visible = false;


            chkRunBackground.Checked = settingsService.RunInBackground;

            chkRunStartup.Checked = settingsService.RunAtStartup;

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
            int batteryPercent = batteryService.GetBatteryPercentage();

            bool isCharging = batteryService.IsCharging();

            lblBatteryPercent.Text = $"{batteryPercent}%";

            progressBattery.Value = batteryPercent;

            lblChargingStatus.Text = isCharging ? "Charging" : "Not Charging";

            HandleChargingStateChange(isCharging);

            if (isCharging)
            {
                CheckBatteryNotification(
                    batteryPercent);
            }
        }

        private void HandleChargingStateChange(bool isCharging)
        {
            if (!batteryService.ChargingStateChanged(previousChargingState, isCharging))
            {
                return;
            }

            // Charger baru dicolok
            if (isCharging)
            {
                notificationService.ResetNotification();
            }

            // Charger dicabut
            else
            {
                notificationService.CloseNotification();
            }

            previousChargingState = isCharging;
        }

        private void CheckBatteryNotification(int batteryPercent)
        {
            if (!notificationService.CanShowNotification())
                return;

            if (batteryService.IsLowBattery(batteryPercent, batterySettings.LowBatteryThreshold))
            {
                notificationService.ShowNotification("Battery Low", $"Battery is at {batteryPercent}%", ToolTipIcon.Warning);

                return;
            }

            if (batteryService.IsFullBattery(batteryPercent, batterySettings.FullBatteryThreshold))
            {
                notificationService.ShowNotification("Battery Full", $"Battery is already {batteryPercent}%", ToolTipIcon.Info);
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

        private void notifyTray_DoubleClick(object? sender, EventArgs e)
        {
            this.Show();

            this.WindowState = FormWindowState.Normal;

            this.BringToFront();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            batterySettings.LowBatteryThreshold = (int)numLowBattery.Value;

            batterySettings.FullBatteryThreshold = (int)numFullBattery.Value;

            if (!batterySettings.IsValid())
            {
                MessageBox.Show("Low Battery must be smaller than Full Battery!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

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

                this.Hide();

                trayService.ShowBackgroundMessage();
            }
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            this.Show();

            this.WindowState = FormWindowState.Normal;

            this.BringToFront();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            isRealExit = true;

            notifyTray.Visible = false;

            Application.Exit();
        }

        private void chkRunBackground_CheckedChanged(object sender, EventArgs e)
        {
            settingsService.RunInBackground = chkRunBackground.Checked;

        }

        private void chkRunStartup_CheckedChanged(object sender, EventArgs e)
        {

            startupService.SetStartup(chkRunStartup.Checked);

            settingsService.RunAtStartup = chkRunStartup.Checked;

        }
    }
}
