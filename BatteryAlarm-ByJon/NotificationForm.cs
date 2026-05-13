using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BatteryAlarm_ByJon
{
    public partial class NotificationForm : Form
    {
        public bool IsSnoozed { get; private set; } = false;

        public bool IsStopped { get; private set; } = false;

        public NotificationForm(string title, string message, ToolTipIcon iconType)
        {
            InitializeComponent();

            this.Text = title;

            lblMessage.Text = message;

            SetNotificationIcon(iconType);

            PositionForm();

        }

        private void PositionForm()
        {
            Rectangle workingArea = Screen.PrimaryScreen?.WorkingArea ?? Screen.AllScreens[0].WorkingArea;

            this.Location = new Point(
                workingArea.Width - this.Width - 10,
                workingArea.Height - this.Height - 10
            );
        }

        private void SetNotificationIcon(ToolTipIcon iconType)
        {
            Icon icon;

            switch (iconType)
            {
                case ToolTipIcon.Warning:
                    icon = SystemIcons.Warning;
                    break;

                case ToolTipIcon.Error:
                    icon = SystemIcons.Error;
                    break;

                default:
                    icon = SystemIcons.Information;
                    break;
            }

            picIcon.Image = icon.ToBitmap();
        }

        private void btnSnooze_Click(object sender, EventArgs e)
        {
            IsSnoozed = true;

            this.Close();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            IsStopped = true;

            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!IsStopped)
            {
                IsSnoozed = true;
            }

            base.OnFormClosing(e);
        }
    }
}
