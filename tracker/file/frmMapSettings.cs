using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tracker.file
{
    public partial class frmMapSettings : Form
    {
        public frmMapSettings()
        {
            InitializeComponent();

            cmbMapType.ValueMember = "Name";
            cmbMapType.DataSource = GMapProviders.List;
            int id = (int)Properties.Settings.Default.MapProvider;
            cmbMapType.SelectedIndex = id;
        }

        private void frmMapSettings_Load(object sender, EventArgs e)
        {
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "&Edit")
            {
                btnEdit.Text = "&Update";
                cmbMapType.Enabled = true;
                btnClose.Enabled = false;
            }
            else
            {
                Properties.Settings.Default.MapProvider = cmbMapType.SelectedIndex;
                Properties.Settings.Default.Save();

                cmbMapType.Enabled = false;
                btnEdit.Text = "&Edit";
                btnClose.Enabled = true;

                MessageBox.Show("Settings is successfully updated!", "Map Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
        }

    }
}
