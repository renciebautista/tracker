using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
namespace tracker.file
{
    public partial class frmTrainlist : DockContent
    {
        BindingSource bs = new BindingSource();
        bool myGridView_DoCheck = false;
        public frmTrainlist()
        {
            InitializeComponent();
        }

        private void loadGrid()
        {
            dgvTrains.AutoGenerateColumns = false;
            DataTable dt = MysqlHelper.ExecuteDataTable("SELECT trains.id, train_code, train_desc" +
                " FROM train_radios " +
                " INNER JOIN trains on train_radios.train_id = trains.id" +
                " WHERE train_radios.head = 1");

            dt.Columns.Add("chk", typeof(System.Boolean));
            var list = Properties.Settings.Default.Trains.Cast<string>().ToList();
            foreach (DataRow dr in dt.Rows)
            {
                if (list.Contains(dr["id"].ToString()))
                {
                    dr["chk"] = true;   // or set it to some other value
                }
                
            }
            dgvTrains.DataSource = dt;
        }

        private void frmTrainlist_Load(object sender, EventArgs e)
        {
            loadGrid();

           
           
        }

        private void dgvTrains_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (!myGridView_DoCheck)
            {
                myGridView_DoCheck = true;
                dgvTrains.EndEdit();
                // do something here

                List<string> list = selected();
                StringCollection sc = new StringCollection();
                sc.AddRange(list.ToArray());
                Properties.Settings.Default.Trains = sc;
                Properties.Settings.Default.Save();
            }
            else
                myGridView_DoCheck = false;
        }

        private List<string> selected()
        {
            List<string> list = new List<string>();
            for (int i = 0; i <= dgvTrains.RowCount - 1; i++)
            {
               //string a = dgvTrains.Rows[i].Cells["chk"].Value.ToString();
               if (dgvTrains.Rows[i].Cells["chk"].Value.ToString() == "True")
               {
                   list.Add(dgvTrains.Rows[i].Cells[0].Value.ToString());
               }
            }
            return list;
        }


    }
}
