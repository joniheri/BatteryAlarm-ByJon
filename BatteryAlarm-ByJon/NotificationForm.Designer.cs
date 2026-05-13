namespace BatteryAlarm_ByJon
{
    partial class NotificationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblMessage = new Label();
            btnSnooze = new Button();
            btnStop = new Button();
            picIcon = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picIcon).BeginInit();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMessage.Location = new Point(53, 12);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(224, 35);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "Battery is already %";
            lblMessage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnSnooze
            // 
            btnSnooze.Location = new Point(12, 59);
            btnSnooze.Name = "btnSnooze";
            btnSnooze.Size = new Size(125, 39);
            btnSnooze.TabIndex = 1;
            btnSnooze.Text = "Jeda";
            btnSnooze.UseVisualStyleBackColor = true;
            btnSnooze.Click += btnSnooze_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(152, 59);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(125, 39);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // picIcon
            // 
            picIcon.Location = new Point(12, 12);
            picIcon.Name = "picIcon";
            picIcon.Size = new Size(35, 35);
            picIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            picIcon.TabIndex = 3;
            picIcon.TabStop = false;
            // 
            // NotificationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(289, 111);
            Controls.Add(picIcon);
            Controls.Add(btnStop);
            Controls.Add(btnSnooze);
            Controls.Add(lblMessage);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "NotificationForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            Text = "Battery Alarm";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)picIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblMessage;
        private Button btnSnooze;
        private Button btnStop;
        private PictureBox picIcon;
    }
}