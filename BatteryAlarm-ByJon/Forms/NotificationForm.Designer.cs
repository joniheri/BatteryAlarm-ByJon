namespace BatteryAlarm_ByJon.Forms
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
            picIcon = new PictureBox();
            btnStop = new Button();
            btnSnooze = new Button();
            lblMessage = new Label();
            ((System.ComponentModel.ISupportInitialize)picIcon).BeginInit();
            SuspendLayout();
            // 
            // picIcon
            // 
            picIcon.Location = new Point(12, 12);
            picIcon.Name = "picIcon";
            picIcon.Size = new Size(35, 35);
            picIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            picIcon.TabIndex = 7;
            picIcon.TabStop = false;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(152, 59);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(125, 39);
            btnStop.TabIndex = 6;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click_1;
            // 
            // btnSnooze
            // 
            btnSnooze.Location = new Point(12, 59);
            btnSnooze.Name = "btnSnooze";
            btnSnooze.Size = new Size(125, 39);
            btnSnooze.TabIndex = 5;
            btnSnooze.Text = "Jeda";
            btnSnooze.UseVisualStyleBackColor = true;
            btnSnooze.Click += btnSnooze_Click_1;
            // 
            // lblMessage
            // 
            lblMessage.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMessage.Location = new Point(53, 12);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(224, 35);
            lblMessage.TabIndex = 4;
            lblMessage.Text = "Battery is already %";
            lblMessage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // NotificationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(307, 117);
            Controls.Add(picIcon);
            Controls.Add(btnStop);
            Controls.Add(btnSnooze);
            Controls.Add(lblMessage);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "NotificationForm";
            StartPosition = FormStartPosition.Manual;
            Text = "Battery Alarm";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)picIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picIcon;
        private Button btnStop;
        private Button btnSnooze;
        private Label lblMessage;
    }
}