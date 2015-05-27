using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tracker
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private int Authenticated(string username, string password)
        {
            DataTable dt = MysqlHelper.ExecuteDataTable("SELECT * FROM users WHERE username = @username AND pwd = @pwd",
               new MySqlParameter("@username", username),
               new MySqlParameter("@pwd", security.GenerateHash(password)));

            if (dt.Rows.Count > 0)
            {
                if (!(bool)dt.Rows[0]["active"])
                {
                    return -1;
                }
                else
                {
                    userdetails.ID = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                    userdetails.Username = dt.Rows[0]["username"].ToString();
                    userdetails.GroupId = Convert.ToInt32(dt.Rows[0]["group_id"].ToString());
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (MysqlHelper.TestConnection())
            {
                DataTable dt = MysqlHelper.ExecuteDataTable("SELECT * FROM users ");
                if (dt.Rows.Count > 0)
                {
                    int rtnType = Authenticated(txtUsername.Text.Trim().ToLower(), txtPassword.Text.Trim());

                    switch (rtnType)
                    {
                        case -1:
                            MessageBox.Show("User access is disabled.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtUsername.Text = "";
                            txtPassword.Text = "";
                            txtUsername.Focus();
                            break;
                        case 0:
                            MessageBox.Show("Invalid username or password.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtUsername.Text = "";
                            txtPassword.Text = "";
                            txtUsername.Focus();
                            break;
                        case 1:
                            this.DialogResult = DialogResult.OK;
                            break;
                    }
                }
                else
                {
                    if ((txtUsername.Text == "admin") && (txtPassword.Text == "password"))
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid login credentials.", "Log On", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtPassword.Text = "";
                        txtUsername.Focus();
                    }
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.Text = "10-20 Tracker";
            lblVersion.Text = String.Format("Version {0}", AssemblyVersion);
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this, new EventArgs());
            }
        }
    }
}
