using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tracker.maintenance
{
    public partial class frmInitDb : Form
    {
        public frmInitDb()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            if (chkListPossibleValues.CheckedItems.Count > 0)
            {

                txtRemarks.Text = "";
                btnInit.Enabled = false;
                btnClose.Enabled = false;
                txtRemarks.AppendText("Initializing database ....." + Environment.NewLine);

                foreach (string item in this.chkListPossibleValues.CheckedItems)
                {
                    if (item.ToString() == "Initialize Masterfiles")
                    {
                        txtRemarks.AppendText("Reseting Train Radio ....." + Environment.NewLine);
                        MysqlHelper.ExecuteNonQuery("TRUNCATE TABLE train_radios");
                        txtRemarks.AppendText("Reseting Train Radio done ....." + Environment.NewLine);
                        txtRemarks.AppendText("Reseting Radio ....." + Environment.NewLine);
                        MysqlHelper.ExecuteNonQuery("TRUNCATE TABLE radios");
                        txtRemarks.AppendText("Reseting Radio done ....." + Environment.NewLine);
                        txtRemarks.AppendText("Reseting Train ....." + Environment.NewLine);
                        MysqlHelper.ExecuteNonQuery("TRUNCATE TABLE trains");
                        txtRemarks.AppendText("Reseting Train done ....." + Environment.NewLine);
                    }

                    if (item.ToString() == "Initialize Train Logs")
                    {
                        txtRemarks.AppendText("Reseting Train Logs ....." + Environment.NewLine);
                        MysqlHelper.ExecuteNonQuery("TRUNCATE TABLE logs");
                        txtRemarks.AppendText("Reseting Train Logs done ....." + Environment.NewLine);
                    }
                    //txtRemarks.AppendText(item.ToString() + Environment.NewLine);
                }

                btnInit.Enabled = true;
                btnClose.Enabled = true;
            }
            else
            {
                MessageBox.Show("Select an activity to do.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


    }
}
