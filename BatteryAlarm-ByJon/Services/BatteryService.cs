using System.Windows.Forms;

namespace BatteryAlarm_ByJon.Services
{
    public class BatteryService
    {
        public int GetBatteryPercentage()
        {
            PowerStatus power = SystemInformation.PowerStatus;

            int batteryPercent = (int)(power.BatteryLifePercent * 100);

            batteryPercent = Math.Max(0, Math.Min(100, batteryPercent));

            return batteryPercent;
        }

        public bool IsCharging()
        {
            PowerStatus power = SystemInformation.PowerStatus;

            return power.PowerLineStatus == PowerLineStatus.Online;
        }
    }
}
