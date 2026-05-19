namespace BatteryAlarm_ByJon.Models
{
    public class BatterySettings
    {
        public int LowBatteryThreshold { get; set; } = 20;

        public int FullBatteryThreshold { get; set; } = 80;
    }
}
