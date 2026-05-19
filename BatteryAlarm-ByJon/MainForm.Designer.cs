namespace BatteryAlarm_ByJon
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            batteryTimer = new System.Windows.Forms.Timer(components);
            progressBattery = new ProgressBar();
            lblBatteryPercent = new Label();
            lblChargingStatus = new Label();
            notifyBattery = new NotifyIcon(components);
            label1 = new Label();
            label2 = new Label();
            numLowBattery = new NumericUpDown();
            numFullBattery = new NumericUpDown();
            btnSaveSettings = new Button();
            chkRunBackground = new CheckBox();
            chkRunStartup = new CheckBox();
            notifyTray = new NotifyIcon(components);
            contextMenuStrip = new ContextMenuStrip(components);
            mnuOpen = new ToolStripMenuItem();
            mnuExit = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)numLowBattery).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numFullBattery).BeginInit();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(199, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Battery Status";
            // 
            // batteryTimer
            // 
            batteryTimer.Interval = 3000;
            batteryTimer.Tick += batteryTimer_Tick;
            // 
            // progressBattery
            // 
            progressBattery.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBattery.Location = new Point(12, 150);
            progressBattery.Name = "progressBattery";
            progressBattery.Size = new Size(400, 10);
            progressBattery.TabIndex = 1;
            // 
            // lblBatteryPercent
            // 
            lblBatteryPercent.Font = new Font("Segoe UI", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBatteryPercent.Location = new Point(12, 50);
            lblBatteryPercent.Name = "lblBatteryPercent";
            lblBatteryPercent.Size = new Size(199, 62);
            lblBatteryPercent.TabIndex = 2;
            lblBatteryPercent.Text = "0%";
            // 
            // lblChargingStatus
            // 
            lblChargingStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblChargingStatus.Location = new Point(12, 112);
            lblChargingStatus.Name = "lblChargingStatus";
            lblChargingStatus.Size = new Size(199, 35);
            lblChargingStatus.TabIndex = 3;
            lblChargingStatus.Text = "Charging Status";
            // 
            // notifyBattery
            // 
            notifyBattery.Text = "Battery Alarm";
            notifyBattery.Visible = true;
            // 
            // label1
            // 
            label1.Location = new Point(12, 176);
            label1.Name = "label1";
            label1.Size = new Size(121, 25);
            label1.TabIndex = 4;
            label1.Text = "Low Battery (%)";
            // 
            // label2
            // 
            label2.Location = new Point(12, 209);
            label2.Name = "label2";
            label2.Size = new Size(121, 20);
            label2.TabIndex = 5;
            label2.Text = "Full Battery (%)";
            // 
            // numLowBattery
            // 
            numLowBattery.Location = new Point(139, 174);
            numLowBattery.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numLowBattery.Name = "numLowBattery";
            numLowBattery.Size = new Size(72, 27);
            numLowBattery.TabIndex = 6;
            numLowBattery.Value = new decimal(new int[] { 10, 0, 0, 0 });
            numLowBattery.ValueChanged += numLowBattery_ValueChanged;
            numLowBattery.KeyUp += numLowBattery_KeyUp;
            // 
            // numFullBattery
            // 
            numFullBattery.Location = new Point(139, 207);
            numFullBattery.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numFullBattery.Name = "numFullBattery";
            numFullBattery.Size = new Size(72, 27);
            numFullBattery.TabIndex = 7;
            numFullBattery.Value = new decimal(new int[] { 80, 0, 0, 0 });
            numFullBattery.ValueChanged += numFullBattery_ValueChanged;
            numFullBattery.KeyUp += numFullBattery_KeyUp;
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Cursor = Cursors.Hand;
            btnSaveSettings.Location = new Point(12, 240);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(400, 58);
            btnSaveSettings.TabIndex = 8;
            btnSaveSettings.Text = "Save Settings";
            btnSaveSettings.UseVisualStyleBackColor = true;
            btnSaveSettings.Click += btnSaveSettings_Click;
            // 
            // chkRunBackground
            // 
            chkRunBackground.AutoSize = true;
            chkRunBackground.Location = new Point(255, 175);
            chkRunBackground.Name = "chkRunBackground";
            chkRunBackground.Size = new Size(155, 24);
            chkRunBackground.TabIndex = 9;
            chkRunBackground.Text = "Run in background";
            chkRunBackground.UseVisualStyleBackColor = true;
            chkRunBackground.CheckedChanged += chkRunBackground_CheckedChanged;
            // 
            // chkRunStartup
            // 
            chkRunStartup.AutoSize = true;
            chkRunStartup.Location = new Point(255, 205);
            chkRunStartup.Name = "chkRunStartup";
            chkRunStartup.Size = new Size(123, 24);
            chkRunStartup.TabIndex = 10;
            chkRunStartup.Text = "Run at startup";
            chkRunStartup.UseVisualStyleBackColor = true;
            chkRunStartup.CheckedChanged += chkRunStartup_CheckedChanged;
            // 
            // notifyTray
            // 
            notifyTray.ContextMenuStrip = contextMenuStrip;
            notifyTray.Text = "Battery Alarm";
            notifyTray.Visible = true;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new Size(20, 20);
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { mnuOpen, mnuExit });
            contextMenuStrip.Name = "contextMenuStrip1";
            contextMenuStrip.Size = new Size(115, 52);
            // 
            // mnuOpen
            // 
            mnuOpen.Name = "mnuOpen";
            mnuOpen.Size = new Size(114, 24);
            mnuOpen.Text = "Open";
            mnuOpen.Click += mnuOpen_Click;
            // 
            // mnuExit
            // 
            mnuExit.Name = "mnuExit";
            mnuExit.Size = new Size(114, 24);
            mnuExit.Text = "Exit";
            mnuExit.Click += mnuExit_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 314);
            Controls.Add(chkRunStartup);
            Controls.Add(chkRunBackground);
            Controls.Add(btnSaveSettings);
            Controls.Add(numFullBattery);
            Controls.Add(numLowBattery);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblChargingStatus);
            Controls.Add(lblBatteryPercent);
            Controls.Add(progressBattery);
            Controls.Add(lblTitle);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Battery Alarm";
            FormClosing += MainForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)numLowBattery).EndInit();
            ((System.ComponentModel.ISupportInitialize)numFullBattery).EndInit();
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private System.Windows.Forms.Timer batteryTimer;
        private ProgressBar progressBattery;
        private Label lblBatteryPercent;
        private Label lblChargingStatus;
        private NotifyIcon notifyBattery;
        private Label label1;
        private Label label2;
        private NumericUpDown numLowBattery;
        private NumericUpDown numFullBattery;
        private Button btnSaveSettings;
        private CheckBox chkRunBackground;
        private CheckBox chkRunStartup;
        private NotifyIcon notifyTray;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem mnuOpen;
        private ToolStripMenuItem mnuExit;
    }
}
