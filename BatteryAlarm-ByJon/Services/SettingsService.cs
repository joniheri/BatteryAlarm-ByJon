namespace BatteryAlarm_ByJon.Services
{
    public class SettingsService
    {
        public bool RunInBackground
        {
            get => Properties.Settings.Default.RunInBackground;

            set
            {
                Properties.Settings.Default.RunInBackground = value;
                Properties.Settings.Default.Save();
            }
        }

        public bool RunAtStartup
        {
            get => Properties.Settings.Default.RunAtStartup;

            set
            {
                Properties.Settings.Default.RunAtStartup = value;
                Properties.Settings.Default.Save();
            }
        }
    }

}
