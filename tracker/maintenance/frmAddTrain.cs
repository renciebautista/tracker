using MySql.Data.MySqlClient;
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
    public partial class frmAddTrain : Form
    {
        DataTable table1;
        DataTable table2;
        public frmAddTrain()
        {
            InitializeComponent();
            table1 = MysqlHelper.ExecuteDataTable("SELECT * FROM radios where active = 1 AND radios.id NOT IN (SELECT radio_id_1 as radio FROM train_radios union SELECT radio_id_2 as radio FROM train_radios)");
            table2 = table1.Clone();

            listBox1.ValueMember = "id";
            listBox1.DisplayMember = "ssi";
            listBox1.DataSource = table1;

            listBox2.ValueMember = "id";
            listBox2.DisplayMember = "ssi";
            listBox2.DataSource = table2;

            cmbTrain.ValueMember = "id";
            cmbTrain.DisplayMember = "train_desc";
            cmbTrain.DataSource = MysqlHelper.ExecuteDataTable("SELECT * FROM trains where active = 1 AND trains.id NOT IN (SELECT train_id FROM train_radios)");
        }

        private void frmAddTrain_Load(object sender, EventArgs e)
        {
            
                
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                
                if (listBox2.Items.Count == 2)
                {
                    MessageBox.Show("Only 2 radio is allowed.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DataRowView data = listBox1.SelectedItem as DataRowView;
                    int id = int.Parse(data["id"].ToString());

                    foreach (DataRow r1 in table1.Rows)
                    {
                        if (int.Parse(r1["id"].ToString()) == id)
                        {
                            table2.ImportRow(r1);
                            r1.Delete();
                        }
                    }
                    table1.AcceptChanges();
                    table2.AcceptChanges();
                }
                
            }
        }


        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataRowView data = listBox2.SelectedItem as DataRowView;
            int id = int.Parse(data["id"].ToString());

            foreach (DataRow r1 in table2.Rows)
            {
                if (int.Parse(r1["id"].ToString()) == id)
                {
                    table1.ImportRow(r1);
                    r1.Delete();
                }
            }
            table1.AcceptChanges();
            table2.AcceptChanges();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count != 2)
            {
                MessageBox.Show("Please select a radio.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRowView radio1 = listBox2.Items[0] as DataRowView;
                DataRowView radio2 = listBox2.Items[1] as DataRowView;

                int train_id = int.Parse(cmbTrain.SelectedValue.ToString());
                int radio_1 = int.Parse(radio1["id"].ToString());
                int radio_2 = int.Parse(radio2["id"].ToString());
                if (addAssignment(train_id,radio_1,radio_2) == 1)
                {
                    this.Close();
                }
                else
                {

                }
            }
        }

        private int addAssignment(int train_id, int radio_id_1, int radio_id_2)
        {
            return MysqlHelper.ExecuteNonQuery("INSERT INTO train_radios (train_id, radio_id_1, radio_id_2, head_id) VALUES(@train_id, @radio_id_1, @radio_id_2, @head_id)",
                new MySqlParameter("@train_id", train_id),
                new MySqlParameter("@radio_id_1", radio_id_1),
                new MySqlParameter("@radio_id_2", radio_id_2),
                new MySqlParameter("@head_id", radio_id_1));
        }
    }
}
