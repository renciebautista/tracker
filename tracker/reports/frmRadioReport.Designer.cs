namespace tracker.reports
{
    partial class frmRadioReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRadioReport));
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbRadio = new System.Windows.Forms.ComboBox();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnProcess = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bdgNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvRadio = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ssi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subscriber_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uplink = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.speed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.course = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.max_pos_error = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tracker_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.created_at = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExport = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdgNavigator)).BeginInit();
            this.bdgNavigator.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRadio)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(975, 599);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Clos&e";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbRadio);
            this.groupBox1.Controls.Add(this.dtTo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtFrom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1035, 53);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            // 
            // cmbRadio
            // 
            this.cmbRadio.AllowDrop = true;
            this.cmbRadio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRadio.FormattingEnabled = true;
            this.cmbRadio.Items.AddRange(new object[] {
            "All Radio",
            "Per Radio"});
            this.cmbRadio.Location = new System.Drawing.Point(564, 19);
            this.cmbRadio.Name = "cmbRadio";
            this.cmbRadio.Size = new System.Drawing.Size(121, 21);
            this.cmbRadio.TabIndex = 33;
            this.cmbRadio.SelectedIndexChanged += new System.EventHandler(this.cmbRadio_SelectedIndexChanged);
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(306, 19);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(200, 20);
            this.dtTo.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "To";
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(55, 19);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(200, 20);
            this.dtFrom.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(522, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Radio";
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(12, 599);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 30);
            this.btnProcess.TabIndex = 28;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bdgNavigator);
            this.groupBox3.Location = new System.Drawing.Point(12, 563);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(221, 30);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            // 
            // bdgNavigator
            // 
            this.bdgNavigator.AddNewItem = null;
            this.bdgNavigator.CountItem = this.bindingNavigatorCountItem;
            this.bdgNavigator.DeleteItem = null;
            this.bdgNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bdgNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bdgNavigator.Location = new System.Drawing.Point(3, 2);
            this.bdgNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bdgNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bdgNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bdgNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bdgNavigator.Name = "bdgNavigator";
            this.bdgNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.bdgNavigator.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.bdgNavigator.Size = new System.Drawing.Size(215, 25);
            this.bdgNavigator.TabIndex = 24;
            this.bdgNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvRadio);
            this.groupBox2.Location = new System.Drawing.Point(12, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1038, 491);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            // 
            // dgvRadio
            // 
            this.dgvRadio.AllowUserToAddRows = false;
            this.dgvRadio.AllowUserToDeleteRows = false;
            this.dgvRadio.AllowUserToResizeColumns = false;
            this.dgvRadio.AllowUserToResizeRows = false;
            this.dgvRadio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRadio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRadio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.mcc,
            this.mnc,
            this.ssi,
            this.subscriber_name,
            this.uplink,
            this.speed,
            this.course,
            this.alt,
            this.max_pos_error,
            this.lat,
            this.lng,
            this.tracker_code,
            this.created_at});
            this.dgvRadio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRadio.Location = new System.Drawing.Point(3, 16);
            this.dgvRadio.MultiSelect = false;
            this.dgvRadio.Name = "dgvRadio";
            this.dgvRadio.ReadOnly = true;
            this.dgvRadio.RowHeadersVisible = false;
            this.dgvRadio.RowTemplate.Height = 25;
            this.dgvRadio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRadio.Size = new System.Drawing.Size(1032, 472);
            this.dgvRadio.TabIndex = 22;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // mcc
            // 
            this.mcc.DataPropertyName = "mcc";
            this.mcc.HeaderText = "Mcc";
            this.mcc.Name = "mcc";
            this.mcc.ReadOnly = true;
            // 
            // mnc
            // 
            this.mnc.DataPropertyName = "mnc";
            this.mnc.HeaderText = "Mnc";
            this.mnc.Name = "mnc";
            this.mnc.ReadOnly = true;
            // 
            // ssi
            // 
            this.ssi.DataPropertyName = "ssi";
            this.ssi.HeaderText = "Ssi";
            this.ssi.Name = "ssi";
            this.ssi.ReadOnly = true;
            // 
            // subscriber_name
            // 
            this.subscriber_name.DataPropertyName = "subscriber_name";
            this.subscriber_name.HeaderText = "Subscriber Name";
            this.subscriber_name.Name = "subscriber_name";
            this.subscriber_name.ReadOnly = true;
            // 
            // uplink
            // 
            this.uplink.DataPropertyName = "uplink";
            this.uplink.HeaderText = "Uplink";
            this.uplink.Name = "uplink";
            this.uplink.ReadOnly = true;
            // 
            // speed
            // 
            this.speed.DataPropertyName = "speed";
            this.speed.HeaderText = "Speed";
            this.speed.Name = "speed";
            this.speed.ReadOnly = true;
            // 
            // course
            // 
            this.course.DataPropertyName = "course";
            this.course.HeaderText = "Course";
            this.course.Name = "course";
            this.course.ReadOnly = true;
            // 
            // alt
            // 
            this.alt.DataPropertyName = "alt";
            this.alt.HeaderText = "Altitude";
            this.alt.Name = "alt";
            this.alt.ReadOnly = true;
            // 
            // max_pos_error
            // 
            this.max_pos_error.DataPropertyName = "max_pos_error";
            this.max_pos_error.HeaderText = "Max Pos Error";
            this.max_pos_error.Name = "max_pos_error";
            this.max_pos_error.ReadOnly = true;
            // 
            // lat
            // 
            this.lat.DataPropertyName = "lat";
            this.lat.HeaderText = "Latitude";
            this.lat.Name = "lat";
            this.lat.ReadOnly = true;
            // 
            // lng
            // 
            this.lng.DataPropertyName = "lng";
            this.lng.HeaderText = "Longtitude";
            this.lng.Name = "lng";
            this.lng.ReadOnly = true;
            // 
            // tracker_code
            // 
            this.tracker_code.DataPropertyName = "tracker_code";
            this.tracker_code.HeaderText = "Tracker Code";
            this.tracker_code.Name = "tracker_code";
            this.tracker_code.ReadOnly = true;
            // 
            // created_at
            // 
            this.created_at.DataPropertyName = "created_at";
            this.created_at.HeaderText = "Created At";
            this.created_at.Name = "created_at";
            this.created_at.ReadOnly = true;
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(93, 599);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(95, 30);
            this.btnExport.TabIndex = 35;
            this.btnExport.Text = "Export to CSV";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // frmRadioReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 641);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnProcess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRadioReport";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Radio Log Report";
            this.Load += new System.EventHandler(this.frmRadioReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdgNavigator)).EndInit();
            this.bdgNavigator.ResumeLayout(false);
            this.bdgNavigator.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRadio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.BindingNavigator bdgNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvRadio;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn mcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn mnc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ssi;
        private System.Windows.Forms.DataGridViewTextBoxColumn subscriber_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn uplink;
        private System.Windows.Forms.DataGridViewTextBoxColumn speed;
        private System.Windows.Forms.DataGridViewTextBoxColumn course;
        private System.Windows.Forms.DataGridViewTextBoxColumn alt;
        private System.Windows.Forms.DataGridViewTextBoxColumn max_pos_error;
        private System.Windows.Forms.DataGridViewTextBoxColumn lat;
        private System.Windows.Forms.DataGridViewTextBoxColumn lng;
        private System.Windows.Forms.DataGridViewTextBoxColumn tracker_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn created_at;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ComboBox cmbRadio;
    }
}