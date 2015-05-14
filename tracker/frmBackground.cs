using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tracker
{
    public partial class frmBackground : Form
    {

        private string path;
        public frmBackground()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //Create a new instance of openFileDialog
            OpenFileDialog res = new OpenFileDialog();

            //Filter
            res.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";

            //When the user select the file
            if (res.ShowDialog() == DialogResult.OK)
            {
               //Get the file's path
                path = res.FileName;
               //Do something
                pictureBox1.Image = Image.FromFile(path);
                btnApply.Enabled = true;
            }
            res.Dispose();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Wallpaper = path;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void frmBackground_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Wallpaper != null)
            {
                string filepath = Properties.Settings.Default.Wallpaper.ToString();
                if (filepath != "")
                {
                    pictureBox1.Image = Image.FromFile(filepath);
                }
            }
            
        }
    }
}
