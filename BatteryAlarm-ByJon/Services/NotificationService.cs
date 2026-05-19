using BatteryAlarm_ByJon.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BatteryAlarm_ByJon.Services
{
    public class NotificationService
    {
        private bool notificationVisible = false;

        private bool notificationStopped = false;

        private DateTime snoozeUntil = DateTime.MinValue;

        private NotificationForm? activeNotificationForm;

        public void ResetNotification()
        {
            notificationStopped = false;

            snoozeUntil = DateTime.MinValue;
        }

        public void CloseNotification()
        {
            activeNotificationForm?.Close();
        }

        public bool CanShowNotification()
        {
            if (notificationStopped)
                return false;

            if (notificationVisible)
                return false;

            if (DateTime.Now < snoozeUntil)
                return false;

            return true;
        }

        public void ShowNotification(
            string title,
            string message,
            ToolTipIcon iconType)
        {
            notificationVisible = true;

            NotificationForm form = new NotificationForm(title, message, iconType);

            activeNotificationForm = form;

            form.FormClosed += (s, e) =>
            {
                notificationVisible = false;

                if (form.IsStopped)
                {
                    notificationStopped = true;

                    return;
                }

                snoozeUntil = DateTime.Now.AddMinutes(1);
            };

            form.Show();
        }
    }

}
