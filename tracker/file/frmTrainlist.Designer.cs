namespace tracker.file
{
    partial class frmTrainlist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrainlist));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dgvTrains = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.train_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.train_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrains)).BeginInit();
            this.SuspendLayout();
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
            // dgvTrains
            // 
            this.dgvTrains.AllowUserToAddRows = false;
            this.dgvTrains.AllowUserToDeleteRows = false;
            this.dgvTrains.AllowUserToResizeColumns = false;
            this.dgvTrains.AllowUserToResizeRows = false;
            this.dgvTrains.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrains.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.chk,
            this.train_code,
            this.train_desc});
            this.dgvTrains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTrains.Location = new System.Drawing.Point(0, 0);
            this.dgvTrains.MultiSelect = false;
            this.dgvTrains.Name = "dgvTrains";
            this.dgvTrains.RowHeadersVisible = false;
            this.dgvTrains.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTrains.Size = new System.Drawing.Size(284, 447);
            this.dgvTrains.TabIndex = 2;
            this.dgvTrains.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvTrains_CurrentCellDirtyStateChanged);
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
            // train_code
            // 
            this.train_code.DataPropertyName = "train_code";
            this.train_code.HeaderText = "Code";
            this.train_code.Name = "train_code";
            this.train_code.ReadOnly = true;
            // 
            // train_desc
            // 
            this.train_desc.DataPropertyName = "train_desc";
            this.train_desc.HeaderText = "Description";
            this.train_desc.Name = "train_desc";
            this.train_desc.ReadOnly = true;
            this.train_desc.Width = 200;
            // 
            // frmTrainlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 447);
            this.Controls.Add(this.dgvTrains);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmTrainlist";
            this.Text = "Train List";
            this.Load += new System.EventHandler(this.frmTrainlist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrains)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView dgvTrains;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn train_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn train_desc;
    }
}