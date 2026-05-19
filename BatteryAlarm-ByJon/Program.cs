using BatteryAlarm_ByJon.Models;
using BatteryAlarm_ByJon.Services;

namespace BatteryAlarm_ByJon
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            BatteryService batteryService = new BatteryService();

            NotificationService notificationService = new NotificationService();

            BatterySettings batterySettings = new BatterySettings();

            StartupService startupService = new StartupService();

            SettingsService settingsService = new SettingsService();

            Application.Run(
                new MainForm(
                    batteryService,
                    notificationService,
                    batterySettings,
                    startupService,
                    settingsService
                )
            );
        }
    }
}