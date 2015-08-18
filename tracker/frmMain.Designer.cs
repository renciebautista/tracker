namespace tracker
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.monitoringToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.maintenanceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.radioMaintenanceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.trainMaintenanceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.trainRadioAssignmentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.userMaintenanceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.radioServeMaintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.radioLogsReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainLogsReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHelpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.monitoringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monitoringToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radioMaintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainMaintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainRadioAssignmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userMaintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ver = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusIp = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusTnx = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monitoringToolStripMenuItem2,
            this.maintenanceToolStripMenuItem1,
            this.reportsToolStripMenuItem1,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem1,
            this.aboutToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(779, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // monitoringToolStripMenuItem2
            // 
            this.monitoringToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapToolStripMenuItem,
            this.relogToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.monitoringToolStripMenuItem2.Name = "monitoringToolStripMenuItem2";
            this.monitoringToolStripMenuItem2.Size = new System.Drawing.Size(79, 20);
            this.monitoringToolStripMenuItem2.Text = "Monitoring";
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.mapToolStripMenuItem.Text = "Map View";
            this.mapToolStripMenuItem.Click += new System.EventHandler(this.monitoringToolStripMenuItem1_Click);
            // 
            // relogToolStripMenuItem
            // 
            this.relogToolStripMenuItem.Name = "relogToolStripMenuItem";
            this.relogToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.relogToolStripMenuItem.Text = "Relog";
            this.relogToolStripMenuItem.Click += new System.EventHandler(this.relogToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // maintenanceToolStripMenuItem1
            // 
            this.maintenanceToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.radioMaintenanceToolStripMenuItem1,
            this.trainMaintenanceToolStripMenuItem1,
            this.trainRadioAssignmentToolStripMenuItem1,
            this.userMaintenanceToolStripMenuItem1,
            this.radioServeMaintenanceToolStripMenuItem});
            this.maintenanceToolStripMenuItem1.Name = "maintenanceToolStripMenuItem1";
            this.maintenanceToolStripMenuItem1.Size = new System.Drawing.Size(88, 20);
            this.maintenanceToolStripMenuItem1.Text = "Maintenance";
            // 
            // radioMaintenanceToolStripMenuItem1
            // 
            this.radioMaintenanceToolStripMenuItem1.Name = "radioMaintenanceToolStripMenuItem1";
            this.radioMaintenanceToolStripMenuItem1.Size = new System.Drawing.Size(211, 22);
            this.radioMaintenanceToolStripMenuItem1.Text = "Radio Maintenance";
            this.radioMaintenanceToolStripMenuItem1.Click += new System.EventHandler(this.radioMaintenanceToolStripMenuItem_Click);
            // 
            // trainMaintenanceToolStripMenuItem1
            // 
            this.trainMaintenanceToolStripMenuItem1.Name = "trainMaintenanceToolStripMenuItem1";
            this.trainMaintenanceToolStripMenuItem1.Size = new System.Drawing.Size(211, 22);
            this.trainMaintenanceToolStripMenuItem1.Text = "Train Maintenance";
            this.trainMaintenanceToolStripMenuItem1.Click += new System.EventHandler(this.trainMaintenanceToolStripMenuItem_Click);
            // 
            // trainRadioAssignmentToolStripMenuItem1
            // 
            this.trainRadioAssignmentToolStripMenuItem1.Name = "trainRadioAssignmentToolStripMenuItem1";
            this.trainRadioAssignmentToolStripMenuItem1.Size = new System.Drawing.Size(211, 22);
            this.trainRadioAssignmentToolStripMenuItem1.Text = "Train / Radio Assignment";
            this.trainRadioAssignmentToolStripMenuItem1.Click += new System.EventHandler(this.trainRadioAssignmentToolStripMenuItem_Click);
            // 
            // userMaintenanceToolStripMenuItem1
            // 
            this.userMaintenanceToolStripMenuItem1.Name = "userMaintenanceToolStripMenuItem1";
            this.userMaintenanceToolStripMenuItem1.Size = new System.Drawing.Size(211, 22);
            this.userMaintenanceToolStripMenuItem1.Text = "User Maintenance";
            this.userMaintenanceToolStripMenuItem1.Click += new System.EventHandler(this.userMaintenanceToolStripMenuItem_Click);
            // 
            // radioServeMaintenanceToolStripMenuItem
            // 
            this.radioServeMaintenanceToolStripMenuItem.Name = "radioServeMaintenanceToolStripMenuItem";
            this.radioServeMaintenanceToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.radioServeMaintenanceToolStripMenuItem.Text = "Radio Server Maintenance";
            this.radioServeMaintenanceToolStripMenuItem.Click += new System.EventHandler(this.radioServeMaintenanceToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem1
            // 
            this.reportsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.radioLogsReportToolStripMenuItem,
            this.trainLogsReportToolStripMenuItem});
            this.reportsToolStripMenuItem1.Name = "reportsToolStripMenuItem1";
            this.reportsToolStripMenuItem1.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem1.Text = "Reports";
            // 
            // radioLogsReportToolStripMenuItem
            // 
            this.radioLogsReportToolStripMenuItem.Name = "radioLogsReportToolStripMenuItem";
            this.radioLogsReportToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.radioLogsReportToolStripMenuItem.Text = "Radio Logs Report";
            this.radioLogsReportToolStripMenuItem.Click += new System.EventHandler(this.radioLogsReportToolStripMenuItem_Click);
            // 
            // trainLogsReportToolStripMenuItem
            // 
            this.trainLogsReportToolStripMenuItem.Name = "trainLogsReportToolStripMenuItem";
            this.trainLogsReportToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.trainLogsReportToolStripMenuItem.Text = "Train Logs Report";
            this.trainLogsReportToolStripMenuItem.Click += new System.EventHandler(this.trainLogsReportToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backgroundToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // backgroundToolStripMenuItem
            // 
            this.backgroundToolStripMenuItem.Name = "backgroundToolStripMenuItem";
            this.backgroundToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.backgroundToolStripMenuItem.Text = "Background";
            this.backgroundToolStripMenuItem.Click += new System.EventHandler(this.backgroundToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelpToolStripMenuItem1});
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // viewHelpToolStripMenuItem1
            // 
            this.viewHelpToolStripMenuItem1.Name = "viewHelpToolStripMenuItem1";
            this.viewHelpToolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
            this.viewHelpToolStripMenuItem1.Text = "View Help";
            this.viewHelpToolStripMenuItem1.Click += new System.EventHandler(this.viewHelpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // monitoringToolStripMenuItem
            // 
            this.monitoringToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monitoringToolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.monitoringToolStripMenuItem.Name = "monitoringToolStripMenuItem";
            this.monitoringToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.monitoringToolStripMenuItem.Text = "Monitoring";
            // 
            // monitoringToolStripMenuItem1
            // 
            this.monitoringToolStripMenuItem1.Name = "monitoringToolStripMenuItem1";
            this.monitoringToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.monitoringToolStripMenuItem1.Text = "Map View";
            this.monitoringToolStripMenuItem1.Click += new System.EventHandler(this.monitoringToolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // maintenanceToolStripMenuItem
            // 
            this.maintenanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.radioMaintenanceToolStripMenuItem,
            this.trainMaintenanceToolStripMenuItem,
            this.trainRadioAssignmentToolStripMenuItem,
            this.userMaintenanceToolStripMenuItem});
            this.maintenanceToolStripMenuItem.Name = "maintenanceToolStripMenuItem";
            this.maintenanceToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.maintenanceToolStripMenuItem.Text = "&Maintenance";
            // 
            // radioMaintenanceToolStripMenuItem
            // 
            this.radioMaintenanceToolStripMenuItem.Name = "radioMaintenanceToolStripMenuItem";
            this.radioMaintenanceToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.radioMaintenanceToolStripMenuItem.Text = "Radio Maintenance";
            this.radioMaintenanceToolStripMenuItem.Click += new System.EventHandler(this.radioMaintenanceToolStripMenuItem_Click);
            // 
            // trainMaintenanceToolStripMenuItem
            // 
            this.trainMaintenanceToolStripMenuItem.Name = "trainMaintenanceToolStripMenuItem";
            this.trainMaintenanceToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.trainMaintenanceToolStripMenuItem.Text = "Train Maintenance";
            this.trainMaintenanceToolStripMenuItem.Click += new System.EventHandler(this.trainMaintenanceToolStripMenuItem_Click);
            // 
            // trainRadioAssignmentToolStripMenuItem
            // 
            this.trainRadioAssignmentToolStripMenuItem.Name = "trainRadioAssignmentToolStripMenuItem";
            this.trainRadioAssignmentToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.trainRadioAssignmentToolStripMenuItem.Text = "Train / Radio Assignment";
            this.trainRadioAssignmentToolStripMenuItem.Click += new System.EventHandler(this.trainRadioAssignmentToolStripMenuItem_Click);
            // 
            // userMaintenanceToolStripMenuItem
            // 
            this.userMaintenanceToolStripMenuItem.Name = "userMaintenanceToolStripMenuItem";
            this.userMaintenanceToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.userMaintenanceToolStripMenuItem.Text = "User Maintenance";
            this.userMaintenanceToolStripMenuItem.Click += new System.EventHandler(this.userMaintenanceToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelpToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // viewHelpToolStripMenuItem
            // 
            this.viewHelpToolStripMenuItem.Name = "viewHelpToolStripMenuItem";
            this.viewHelpToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.viewHelpToolStripMenuItem.Text = "View Help";
            this.viewHelpToolStripMenuItem.Click += new System.EventHandler(this.viewHelpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "10-20 Tracker";
            this.notifyIcon1.Visible = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ver,
            this.statusVersion,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.statusIp,
            this.statusTnx});
            this.statusStrip1.Location = new System.Drawing.Point(0, 497);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(779, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ver
            // 
            this.ver.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.ver.Name = "ver";
            this.ver.Size = new System.Drawing.Size(54, 17);
            this.ver.Text = "Version :";
            // 
            // statusVersion
            // 
            this.statusVersion.Name = "statusVersion";
            this.statusVersion.Size = new System.Drawing.Size(45, 17);
            this.statusVersion.Text = "version";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(487, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(37, 17);
            this.toolStripStatusLabel2.Text = "TNX :";
            // 
            // statusIp
            // 
            this.statusIp.Name = "statusIp";
            this.statusIp.Size = new System.Drawing.Size(17, 17);
            this.statusIp.Text = "ip";
            // 
            // statusTnx
            // 
            this.statusTnx.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.statusTnx.ForeColor = System.Drawing.Color.Red;
            this.statusTnx.Name = "statusTnx";
            this.statusTnx.Size = new System.Drawing.Size(124, 17);
            this.statusTnx.Text = "Server is not running";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(779, 495);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 519);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "10-20 Tracker";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem maintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radioMaintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainMaintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainRadioAssignmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monitoringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monitoringToolStripMenuItem1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userMaintenanceToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem monitoringToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem maintenanceToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewHelpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem radioMaintenanceToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem trainMaintenanceToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem trainRadioAssignmentToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem userMaintenanceToolStripMenuItem1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem trainLogsReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radioLogsReportToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusIp;
        private System.Windows.Forms.ToolStripStatusLabel statusVersion;
        private System.Windows.Forms.ToolStripStatusLabel ver;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel statusTnx;
        private System.Windows.Forms.ToolStripMenuItem radioServeMaintenanceToolStripMenuItem;
    }
}

