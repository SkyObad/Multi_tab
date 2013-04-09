using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents;
using MySql.Data.MySqlClient;

namespace Multi_tab.Login_form
{
    public partial class Login : DevComponents.DotNetBar.Office2007Form
    {
        public Login()
        {
            InitializeComponent();
        }
        MySqlConnection Myconnection = null;
        private void Login_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'school_registrationDataSet.login_tb' table. You can move, or remove it, as needed.

            //this.reg_tbTableAdapter.Fill(this.school_registrationDataSet.reg_tb);
            this.Office2007ColorTable = DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.Black;
            this.Tag = 0;
            Myconnection = new MySqlConnection("server=localhost;User Id=root;database=school_registration;Persist Security Info=True; password=mysql");
            try
            {
                Myconnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtPwd.Clear();
            txtUsername.Clear();
            btnLogin.Enabled = false;
            txtUsername.Focus();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string password = txtPwd.Text;
            string username = txtUsername.Text;
            string str = "Select * from Login_tb where user_name = '"+ username +"'";
            MySqlCommand selectCommand = new MySqlCommand(str,Myconnection);
            MySqlDataReader dr  = selectCommand.ExecuteReader();
            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    if (username == Convert.ToString(dr["user_name"]))
                    {
                        if (password == Convert.ToString(dr["password"]))
                        {
                            this.Tag = 1;
                            this.Close();
                        }
                        else
                        {
                            this.Tag = 0;
                            DevComponents.DotNetBar.MessageBoxEx.Show("Please Enter The Correct Password", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPwd.Clear();
                            txtUsername.Clear();
                            txtUsername.Focus();
                        }

                    }
                    else
                    {
                        DevComponents.DotNetBar.MessageBoxEx.Show("Please Enter The Correct User Name", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPwd.Clear();
                        txtUsername.Clear();
                        txtUsername.Focus();
                        this.Tag = 0;
                    }
                }

            }
            else
            {
                DevComponents.DotNetBar.MessageBoxEx.Show("Please Enter The Correct User Name", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPwd.Clear();
                txtUsername.Clear();
                txtUsername.Focus();
                this.Tag = 0;
            }
            dr.Close();
            
            

           
            
            

        }
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim().Length == 0) 
            {
                btnLogin.Enabled = false;
                return;
            }
            if (txtUsername.Text.Trim().Length != 0 && txtPwd.Text.Trim().Length != 0)
            {
                btnLogin.Enabled = true;
            }
            else
            { btnLogin.Enabled = false; }


        }
        private void txtPwd_TextChanged(object sender, EventArgs e)
        {
            if (txtPwd.Text.Trim().Length == 0) 
            {
                btnLogin.Enabled = false;
                return;
            }
            if (txtUsername.Text.Trim().Length != 0 && txtPwd.Text.Trim().Length != 0)
            {
                btnLogin.Enabled = true;
            }
            else
            { btnLogin.Enabled = false; }
        }
        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }

        }
    }
}
