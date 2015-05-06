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

            txtLimit.Text = Properties.Settings.Default.Limit.ToString();

            txtLat.Text = Properties.Settings.Default.Lat.ToString();
            txtLng.Text = Properties.Settings.Default.Lng.ToString();
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
                txtLimit.Enabled = true;
                txtLat.Enabled = true;
                txtLng.Enabled = true;
            }
            else
            {
                Properties.Settings.Default.MapProvider = cmbMapType.SelectedIndex;
                Properties.Settings.Default.Limit = Convert.ToInt32( txtLimit.Text.ToString());
                Properties.Settings.Default.Lat = Convert.ToDouble(txtLat.Text.ToString());
                Properties.Settings.Default.Lng = Convert.ToDouble(txtLng.Text.ToString());
                Properties.Settings.Default.Save();

                cmbMapType.Enabled = false;
                txtLimit.Enabled = false;
                btnEdit.Text = "&Edit";
                btnClose.Enabled = true;
                txtLat.Enabled = false;
                txtLng.Enabled = false;

                MessageBox.Show("Settings is successfully updated!", "Map Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
        }

        private void txtLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

    }
}
