using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tracker.reports
{
    public partial class frmSelection : Form
    {
        private DataTable dtSource;
        DataTable table1;
        DataTable table2;
        DataTable table3;
        public DataTable SourceDataSource
        {
            set { dtSource = value; }
        }


        public DataTable SelectedDataSource
        {
           get 
           { 
              return table2;
           }
           set 
           {
              table3 = value;
           }

        }
        public frmSelection()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            single_move_right();
        }

        private void frmSelection_Load(object sender, EventArgs e)
        {
            table1 = dtSource;
            table2 = table1.Clone();

            listBox1.DisplayMember = "value";
            listBox1.DataSource = table1;

            listBox2.DisplayMember = "value";
            listBox2.DataSource = table2;

            if ((table3 != null) && (table3.Rows.Count > 0))
            {
                foreach (DataRow r1 in table3.Rows)
                {
                    var foundValue = table1.Select("value = '" + r1["value"].ToString() + "'");
                    if (foundValue.Length != 0)
                    {
                        table2.ImportRow(r1);
                    }
                }

                foreach (DataRow r1 in table1.Rows)
                {
                    var foundValue = table3.Select("value = '" + r1["value"].ToString() + "'");
                    if (foundValue.Length != 0)
                    {
                        r1.Delete();
                    }
                }
                table1.AcceptChanges();
                table2.AcceptChanges();
            }
            
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            single_move_right();
        }

        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            single_move_left();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataRow r1 in table1.Rows)
            {
                table2.ImportRow(r1);
                r1.Delete();
            }
            table1.AcceptChanges();
            table2.AcceptChanges();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DataRow r1 in table2.Rows)
            {
                table1.ImportRow(r1);
                r1.Delete();
            }
            table1.AcceptChanges();
            table2.AcceptChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            single_move_left();
        }

        private void single_move_left()
        {
            if (listBox2.SelectedIndex != -1)
            {
                DataRowView data = listBox2.SelectedItem as DataRowView;
                foreach (DataRow r1 in table2.Rows)
                {
                    if (r1["value"].ToString() == data["value"].ToString())
                    {
                        table1.ImportRow(r1);
                        r1.Delete();
                    }
                }
                table1.AcceptChanges();
                table2.AcceptChanges();
            }
        }

        private void single_move_right()
        {
            if (listBox1.SelectedIndex != -1)
            {

                DataRowView data = listBox1.SelectedItem as DataRowView;

                foreach (DataRow r1 in table1.Rows)
                {
                    if (r1["value"].ToString() == data["value"].ToString())
                    {
                        table2.ImportRow(r1);
                        r1.Delete();
                    }
                }
                table1.AcceptChanges();
                table2.AcceptChanges();

            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
