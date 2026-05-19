using Microsoft.Win32;

namespace BatteryAlarm_ByJon.Services
{
    public class StartupService
    {
        private const string AppName = "BatteryAlarm";

        public void SetStartup(bool enable)
        {
            RegistryKey? key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);

            if (enable)
            {
                key?.SetValue(
                    AppName,
                    Application.ExecutablePath);
            }
            else
            {
                key?.DeleteValue(AppName, false);
            }
        }

        public bool IsStartupEnabled()
        {
            RegistryKey? key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");

            return key?.GetValue(AppName) != null;
        }
    }
}
