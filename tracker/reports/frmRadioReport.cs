using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tracker.reports
{
    public partial class frmRadioReport : Form
    {
        BindingSource bs = new BindingSource();
        DataTable dt = new DataTable();
        public frmRadioReport()
        {
            InitializeComponent();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            dgvRadio.AutoGenerateColumns = false;
            dt = MysqlHelper.ExecuteDataTable("SELECT * FROM radio_logs");
            bs.DataSource = dt;
            bdgNavigator.BindingSource = bs;
            dgvRadio.DataSource = bs;
            if (dt.Rows.Count > 0)
            {
                btnExport.Enabled = true;
            }
            else
            {
                btnExport.Enabled = false;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // Prepare a dummy string, thos would appear in the dialog
            string dummyFileName = "Radio Log";

            SaveFileDialog sf = new SaveFileDialog();
            sf.DefaultExt = ".csv";
            // Feed the dummy name to the save dialog
            sf.FileName = dummyFileName;

            if (sf.ShowDialog() == DialogResult.OK)
            {
                // Now here's our save folder
                // string savePath = Path.GetDirectoryName(sf.FileName);
                csvUtility.ToCSV(dt, sf.FileName);
                MessageBox.Show("Report successfully exported.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(sf.FileName);
                // Do whatever
            }
        }
    }
}
