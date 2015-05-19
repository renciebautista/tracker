namespace tracker.file
{
    partial class frmRadioList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRadioList));
            this.dgvRadios = new System.Windows.Forms.DataGridView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ssi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRadios)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRadios
            // 
            this.dgvRadios.AllowUserToAddRows = false;
            this.dgvRadios.AllowUserToDeleteRows = false;
            this.dgvRadios.AllowUserToResizeColumns = false;
            this.dgvRadios.AllowUserToResizeRows = false;
            this.dgvRadios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRadios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.chk,
            this.mcc,
            this.mnc,
            this.ssi});
            this.dgvRadios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRadios.Location = new System.Drawing.Point(0, 0);
            this.dgvRadios.MultiSelect = false;
            this.dgvRadios.Name = "dgvRadios";
            this.dgvRadios.RowHeadersVisible = false;
            this.dgvRadios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRadios.Size = new System.Drawing.Size(284, 447);
            this.dgvRadios.TabIndex = 3;
            this.dgvRadios.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvRadios_CurrentCellDirtyStateChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // chk
            // 
            this.chk.DataPropertyName = "chk";
            this.chk.HeaderText = "";
            this.chk.Name = "chk";
            this.chk.Width = 20;
            // 
            // mcc
            // 
            this.mcc.DataPropertyName = "mcc";
            this.mcc.HeaderText = "Mcc";
            this.mcc.Name = "mcc";
            this.mcc.ReadOnly = true;
            this.mcc.Width = 50;
            // 
            // mnc
            // 
            this.mnc.DataPropertyName = "mnc";
            this.mnc.HeaderText = "Mnc";
            this.mnc.Name = "mnc";
            this.mnc.ReadOnly = true;
            this.mnc.Width = 50;
            // 
            // ssi
            // 
            this.ssi.DataPropertyName = "ssi";
            this.ssi.HeaderText = "Ssi";
            this.ssi.Name = "ssi";
            this.ssi.ReadOnly = true;
            this.ssi.Width = 200;
            // 
            // frmRadioList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 447);
            this.Controls.Add(this.dgvRadios);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmRadioList";
            this.Text = "Radio List";
            this.Load += new System.EventHandler(this.frmRadioList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRadios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRadios;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn mcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn mnc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ssi;
    }
}