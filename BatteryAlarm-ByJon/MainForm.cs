using System.Drawing;

namespace BatteryAlarm_ByJon
{
    public partial class MainForm : Form
    {
        private int lowBatteryThreshold = 20;
        private int fullBatteryThreshold = 80;


        private bool notificationVisible = false;
        private bool notificationStopped = false;
        private bool previousChargingState = false;

        private DateTime snoozeUntil = DateTime.MinValue;

        private NotificationForm? activeNotificationForm;

        public MainForm()
        {
            InitializeComponent();

            notifyBattery.Icon = SystemIcons.Information;

            btnSaveSettings.Enabled = false;

            LoadBatteryInformation();

            batteryTimer.Start();
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
            // Charger baru saja dicolok
            if (!previousChargingState && isCharging)
            {
                notificationStopped = false;

                snoozeUntil = DateTime.MinValue;
            }

            // Charger dicabut
            if (previousChargingState && !isCharging)
            {
                activeNotificationForm?.Close();
            }

            previousChargingState = isCharging;
        }

        private void CheckBatteryNotification(int batteryPercent)
        {
            if (notificationStopped)
                return;

            if (notificationVisible)
                return;

            if (DateTime.Now < snoozeUntil)
                return;

            // Battery Low
            if (batteryPercent <= lowBatteryThreshold)
            {
                ShowCustomNotification(
                    "Battery Low",
                    $"Battery is at {batteryPercent}%",
                    ToolTipIcon.Warning
                );

                return;
            }

            // Battery Full
            if (batteryPercent >= fullBatteryThreshold)
            {
                ShowCustomNotification(
                    "Battery Full",
                    $"Battery is already {batteryPercent}%",
                    ToolTipIcon.Info
                );

                return;
            }
        }

        private void ShowCustomNotification(string title, string message, ToolTipIcon iconType)
        {
            notificationVisible = true;

            NotificationForm form = new NotificationForm(
                title,
                message,
                iconType
            );

            activeNotificationForm = form;

            form.FormClosed += (s, e) =>
            {
                notificationVisible = false;

                // Klik Stop
                if (form.IsStopped)
                {
                    notificationStopped = true;
                    return;
                }

                // Klik Jeda atau X
                snoozeUntil = DateTime.Now.AddMinutes(1);
            };

            form.Show();

        }

        private void CheckSettingsChanged()
        {
            bool isChanged =
                lowBatteryThreshold != (int)numLowBattery.Value
                ||
                fullBatteryThreshold != (int)numFullBattery.Value;

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

            lowBatteryThreshold = lowValue;
            fullBatteryThreshold = fullValue;
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
