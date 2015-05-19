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
    public partial class frmRadioList : DockContent
    {
        bool myGridView_DoCheck = false;
        public frmRadioList()
        {
            InitializeComponent();
        }
        private void loadGrid()
        {
            dgvRadios.AutoGenerateColumns = false;
            DataTable dt = MysqlHelper.ExecuteDataTable("SELECT * from radios " +
                "WHERE id NOT IN (SELECT radio_id FROM train_radios ) " +
                "AND radios.active = 1");

            dt.Columns.Add("chk", typeof(System.Boolean));
            var list = Properties.Settings.Default.Radios.Cast<string>().ToList();
            foreach (DataRow dr in dt.Rows)
            {
                if (list.Contains(dr["id"].ToString()))
                {
                    dr["chk"] = true;   // or set it to some other value
                }

            }
            dgvRadios.DataSource = dt;
        }
        private void frmRadioList_Load(object sender, EventArgs e)
        {
            loadGrid();
        }

        private void dgvRadios_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (!myGridView_DoCheck)
            {
                myGridView_DoCheck = true;
                dgvRadios.EndEdit();
                // do something here

                List<string> list = selected();
                StringCollection sc = new StringCollection();
                sc.AddRange(list.ToArray());
                Properties.Settings.Default.Radios = sc;
                Properties.Settings.Default.Save();
            }
            else
                myGridView_DoCheck = false;
        }

        private List<string> selected()
        {
            List<string> list = new List<string>();
            for (int i = 0; i <= dgvRadios.RowCount - 1; i++)
            {
                //string a = dgvTrains.Rows[i].Cells["chk"].Value.ToString();
                if (dgvRadios.Rows[i].Cells["chk"].Value.ToString() == "True")
                {
                    list.Add(dgvRadios.Rows[i].Cells[0].Value.ToString());
                }
            }
            return list;
        }

    }
}
