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
        private FormMode form_mode;
        private int train_id;
        public enum FormMode
        {
            Add, Edit
        };
        public int TrainId
        {
            set { train_id = value; }
            get { return train_id; }
        }

        public frmAddTrain(FormMode mode)
        {
            InitializeComponent();
            form_mode = mode;
            
        }

        private void frmAddTrain_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(train_id.ToString());
            if (form_mode == FormMode.Add)
            {
                btnSave.Text = "&Save";
                this.Text = "Add Train - Radio Assignment";
                table1 = MysqlHelper.ExecuteDataTable("SELECT * FROM radios where active = 1 AND radios.id NOT IN (SELECT radio_id FROM train_radios)");
                table2 = table1.Clone();

                listBox1.ValueMember = "id";
                listBox1.DisplayMember = "ssi";
                listBox1.DataSource = table1;

                listBox2.ValueMember = "id";
                listBox2.DisplayMember = "ssi";
                listBox2.DataSource = table2;

                cmbTrain.ValueMember = "id";
                cmbTrain.DisplayMember = "train_desc";
                cmbTrain.DataSource = MysqlHelper.ExecuteDataTable("SELECT * FROM trains where active = 1 AND trains.id NOT IN (SELECT distinct(train_id) FROM train_radios)");
            }
            else
            {
                btnSave.Text = "&Update";
                this.Text = "Edit Train - Radio Assignment";

                table1 = MysqlHelper.ExecuteDataTable("SELECT * FROM radios where active = 1 AND radios.id NOT IN (SELECT radio_id FROM train_radios)");
                table2 = MysqlHelper.ExecuteDataTable("SELECT * FROM radios where active = 1 AND radios.id IN (SELECT radio_id FROM train_radios WHERE train_id = '" + train_id + "')");

                listBox1.ValueMember = "id";
                listBox1.DisplayMember = "ssi";
                listBox1.DataSource = table1;

                listBox2.ValueMember = "id";
                listBox2.DisplayMember = "ssi";
                listBox2.DataSource = table2;


                cmbTrain.ValueMember = "id";
                cmbTrain.DisplayMember = "train_desc";
                cmbTrain.DataSource = MysqlHelper.ExecuteDataTable("SELECT * FROM trains " +
                    "WHERE active = 1 " +
                    "AND trains.id NOT IN (SELECT distinct(train_id) FROM train_radios WHERE train_id != '" + train_id + "')");
                cmbTrain.SelectedValue = train_id;
            }
                
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
                if (btnSave.Text == "&Update")
                {
                    MysqlHelper.ExecuteNonQuery("DELETE FROM train_radios WHERE id IN (SELECT cid FROM (SELECT id as cid FROM train_radios WHERE train_id = '" + this.train_id + "') as c)");
                }

                int train_id = int.Parse(cmbTrain.SelectedValue.ToString());

                for (int i = 0; i < listBox2.Items.Count; ++i)
                {
                    DataRowView radio = listBox2.Items[i] as DataRowView;
                    int radio_id = int.Parse(radio["id"].ToString());
                    if (i == 0)
                    {

                        addAssignment(train_id, radio_id, true);
                    }
                    else
                    {
                        addAssignment(train_id, radio_id, false);
                    }   
                }

                this.Close();
          
            }
        }

        private int addAssignment(int train_id, int radio_id, bool head)
        {
            return MysqlHelper.ExecuteNonQuery("INSERT INTO train_radios (train_id, radio_id, head) VALUES(@train_id, @radio_id, @head)",
                new MySqlParameter("@train_id", train_id),
                new MySqlParameter("@radio_id", radio_id),
                new MySqlParameter("@head", head));
        }
    }
}
