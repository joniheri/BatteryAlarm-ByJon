using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace BatteryAlarm_ByJon.Services
{
    public class TrayService
    {
        private readonly NotifyIcon notifyTray;

        public TrayService(NotifyIcon notifyIcon)
        {
            notifyTray = notifyIcon;

            notifyTray.Icon = SystemIcons.Information;
        }

        public void ShowBackgroundMessage()
        {
            notifyTray.Visible = true;

            notifyTray.ShowBalloonTip(3000, "Battery Alarm", "Program running in background", ToolTipIcon.Info);
        }
    }

}
