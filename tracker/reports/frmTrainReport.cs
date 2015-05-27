using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tracker.reports
{
    public partial class frmTrainReport : Form
    {
        BindingSource bs = new BindingSource();
        DataTable dt = new DataTable();
        DataTable selected;
        public frmTrainReport()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (MysqlHelper.TestConnection())
            {
                dgvTrain.DataSource = null;
                dgvTrain.Rows.Clear();
                dgvTrain.AutoGenerateColumns = false;
                if ((selected != null) && (selected.Rows.Count > 0))
                {
                    var filter = string.Join(",", selected.AsEnumerable()
                                     .Select(x => x["value"].ToString())
                                     .ToArray());

                    dt = MysqlHelper.ExecuteDataTable("SELECT * FROM logs WHERE train_desc IN (" + filter + ") AND date(created_at) BETWEEN '" + dtFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtTo.Value.ToString("yyyy-MM-dd") + "'");
                }
                else
                {
                    dt = MysqlHelper.ExecuteDataTable("SELECT * FROM logs WHERE date(created_at) BETWEEN '" + dtFrom.Value.ToString("yyyy-MM-dd") + "' and '" + dtTo.Value.ToString("yyyy-MM-dd") + "'");
                }

                bs.DataSource = dt;
                bdgNavigator.BindingSource = bs;
                dgvTrain.DataSource = bs;
                btnAnimate.Enabled = false;
                if (dt.Rows.Count > 0)
                {
                    btnExport.Enabled = true;
                    btnExport.Enabled = true;
                    if ((selected != null) && (selected.Rows.Count == 1))
                    {
                        btnAnimate.Enabled = true;
                    }
                    MessageBox.Show(dt.Rows.Count.ToString() + " records found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    btnExport.Enabled = false;
                    MessageBox.Show("No record found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                Application.Exit();
            }
            

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // Prepare a dummy string, thos would appear in the dialog
            string dummyFileName = "Train Log";

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

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            dtTo.MinDate = dtFrom.Value;
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            dtFrom.MaxDate = dtTo.Value;
        }

        private void frmTrainReport_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> test = new Dictionary<string, string>();
            test.Add("1", "All Train");
            test.Add("2", "Per Train");
            cmbTrain.DataSource = new BindingSource(test, null);
            cmbTrain.DisplayMember = "Value";
            cmbTrain.ValueMember = "Key";

            cmbTrain.SelectedIndex = 0;


            dtFrom.MaxDate = DateTime.Now;
            dtTo.MaxDate = DateTime.Now;
        }

        private void cmbTrain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MysqlHelper.TestConnection())
            {
                switch (cmbTrain.SelectedIndex)
                {
                    case 1:  // ..... some code here...
                        frmSelection select = new frmSelection();
                        select.SourceDataSource = MysqlHelper.ExecuteDataTable("SELECT train_desc as value FROM logs GROUP BY train_desc");
                        select.SelectedDataSource = selected;
                        select.FormHeader = this.Text;
                        select.ShowDialog();
                        selected = select.SelectedDataSource;
                        break;
                    default: // ..... some code here...
                        if ((selected != null) && (selected.Rows.Count > 0))
                        {
                            selected.Clear();
                        }

                        break;
                }
            }
            else
            {
                Application.Exit();
            }
            
        }

        private void btnAnimate_Click(object sender, EventArgs e)
        {
            using (frmAnimation animate = new frmAnimation())
            {
                animate.DataSource = dt;
                animate.Header = selected.Rows[0]["value"].ToString() + " - Train Logs Animation";
                animate.Id = "train_code";
                animate.Name = "train_desc";
                animate.ShowDialog();
            }
        }
    }
}
