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

namespace Multi_tab.School_form
{
    public partial class Student_reg : DevComponents.DotNetBar.Office2007Form
    {
        public Student_reg()
        {
            InitializeComponent();
        }
        List<Classes.reg> STUDENT_COLLECATION = new List<Multi_tab.Classes.reg>();
        List<Classes.Fees> FEES_COLLECTION = new List<Multi_tab.Classes.Fees>();
        private void Student_reg_Load(object sender, EventArgs e)
        {

            this.Office2007ColorTable = DevComponents.DotNetBar.Rendering.eOffice2007ColorScheme.Black;
            Login_form.Login fm = new Multi_tab.Login_form.Login();
            fm.ShowDialog();
            if (Convert.ToInt16(fm.Tag) == 0) { this.Close(); }
            load_Collection();
            load_grid();
            cbx_level.Items.Clear();
            Classes.Level A_level = new Multi_tab.Classes.Level();
            A_level.Level_Fees = "600000";
            A_level.Level_id = 1;
            A_level.Level_Name = "A Level";
            cbx_level.Items.Add(A_level);
            Classes.Level O_level = new Multi_tab.Classes.Level();
            O_level.Level_Fees = "450000";
            O_level.Level_id = 2;
            O_level.Level_Name = "O Level";
            cbx_level.Items.Add(O_level);

            cbxClass.Items.Clear();
           
            for (int X = 1; X <= 6; X++)
            {
                cbxClass.Items.Add("Form "  + X);
            }

            cbxClass1.Items.Clear();
            for (int Y = 1; Y <= 6; Y++)
            {
                cbxClass1.Items.Add("Form " + Y);
            }

            cbxGender.Items.Clear();
            cbxGender.Items.Add("Male");
            cbxGender.Items.Add("Female");
            tabControl1.SelectedTabIndex = 0;



        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            #region MyRegion
            if (cbx_level.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please Select Level of Study!!");
            }
            if (cbxClass.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please Select a Class!!");
            }
            if (cbxStudent.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please Select student Name!!");
            }
            if (txtPaid.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please Enter the Amount Paid!!");
            } 
            #endregion
            Classes.Fees pay_obj = new Multi_tab.Classes.Fees();
            pay_obj.Student_name = cbxStudent.Text;
            pay_obj.Level_id = cbxClass.Text;
            pay_obj.Paid_amt = txtPaid.Text;

            MySqlCommand pay = null;
            string _str = "insert into fees_tb (reg_no,student_name,level_id,paid_amt,balance) value"+
                "('"+
                //pay_obj.Reg_no +"','"+
                pay_obj.Student_name+"',"+
                pay_obj.Level_id+"',"+
                pay_obj.Paid_amt+"',"+

                ")";
            MySqlConnection conn1 = new MySqlConnection("server=localhost;User Id=root;database=school_registration;Persist Security Info=True; password=mysql");
            try
            {
                conn1.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            pay = new MySqlCommand(_str,conn1);
            //pay.EndExecuteNonQuery(pay_obj);
            FEES_COLLECTION.Add(pay_obj);
            DevComponents.DotNetBar.MessageBoxEx.Show("Fees Record Has Been Saved", "System Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn1.Close();
            load_grid2();
            //
            string fname = cbxStudent.Text;
            string classname = cbxClass.Text;
            string levelid = cbx_level.Text;
            string amtpaid = txtPaid.Text;
        }
        public void load_newCollection()
        {
            MySqlConnection conn1 = new MySqlConnection("server=localhost;User Id=root;database=school_registration;Persist Security Info=True; password=mysql");
            try
            {
                conn1.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            string selCmd1 = "Select * from fees_tb";
            MySqlCommand selectCommand = new MySqlCommand(selCmd1, conn1);
            MySqlDataReader dr = selectCommand.ExecuteReader();
            if (dr == null) { return; }
            Classes.Fees pay_obj = null;
            while (dr.Read())
            {
                pay_obj = new Multi_tab.Classes.Fees();
                pay_obj.Student_name = dr["student_name"].ToString();
                pay_obj.Reg_no = dr["reg_no"].ToString();
                pay_obj.Paid_amt = dr["paid_amt"].ToString();
                pay_obj.Level_id = dr["level_id"].ToString();
                pay_obj.Balance = dr["balance"].ToString();
                FEES_COLLECTION.Add(pay_obj);
            }
            conn1.Close();
            
 
        }
        public void load_grid2()
        {

            DgFees.Rows.Clear();
            DataGridViewRow n_row = null;
            DataGridViewTextBoxCell n_ecel ;
            foreach (Classes.Fees obj in FEES_COLLECTION)
            {
                n_row = new DataGridViewRow();
                n_row.Tag = obj;
                //name
                n_ecel = new DataGridViewTextBoxCell();
                n_ecel.Value = obj.Student_name.ToString();
                n_row.Cells.Add(n_ecel);
                n_ecel.Dispose();

                //level_id
                n_ecel = new DataGridViewTextBoxCell();
                n_ecel.Value = obj.Level_id.ToString();
                n_row.Cells.Add(n_ecel);
                n_ecel.Dispose();

                //paid_amt
                n_ecel = new DataGridViewTextBoxCell();
                n_ecel.Value = obj.Paid_amt.ToString();
                n_row.Cells.Add(n_ecel);
                n_ecel.Dispose();

                DgFees.Rows.Add(n_row);
            }
            
         }


        private void buttonX2_Click(object sender, EventArgs e)
        {
            
            
        
            #region MyRegion
            if (txtName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please Enter Student's Name!!");
                return;
            }
            if (txtReg.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please Fill in Student's Registration Number!!");
                return;
            }
            if (cbxGender.Text.Trim().Length == 0)
            {
                MessageBox.Show("Select Gender!!");
                return;
            }
            if (Bdate.Text.Trim().Length == 0)
            {
                MessageBox.Show("Intert Date of Birth!!");
                return;
            }
            if (cbxClass1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please Fill in Class!!");
                return;
            } 
            #endregion
            //TODO: Data binding
            Classes.reg student_obj = new Multi_tab.Classes.reg();
            student_obj.Student_name = txtName.Text;
            student_obj.Reg_no = txtReg.Text;
            student_obj.Gender_id = cbxGender.SelectedIndex;
            student_obj.Dob = Bdate.Text;
            student_obj.Class = cbxClass1.Text;
            if (txtAddress.Text.Trim().Length != 0)
            {
                student_obj.Address = txtAddress.Text;
            }
            else { student_obj.Address = "na"; }
            MySqlCommand cmd = null;
            string str = "insert into reg_tb (reg_no,student_name,gender_id,DOB,class,address) value"+
                "('"+
                student_obj.Reg_no +"','"+
                student_obj.Student_name+"',"+
                student_obj.Gender_id + ",'"+
                student_obj.Dob+"','"+
                student_obj.Class +"','"+
                student_obj.Address 
                +"')";
            MySqlConnection conn = new MySqlConnection("server=localhost;User Id=root;database=school_registration;Persist Security Info=True; password=mysql");
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            cmd = new MySqlCommand(str, conn);
            cmd.ExecuteNonQuery();
            STUDENT_COLLECATION.Add(student_obj);
            DevComponents.DotNetBar.MessageBoxEx.Show("Record Has Been Saved", "System Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
            load_grid();
            //Select statement:
            string stname = txtName.Text;
            string streg = txtReg.Text;
            string stgender = cbxGender.Text;
            string stbdate = Bdate.Text;
            string stclass = cbxClass1.Text;
            string staddress = txtAddress.Text;
           
           
        }
        public void load_Collection()
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;User Id=root;database=school_registration;Persist Security Info=True; password=mysql");
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            string selCmd = "Select * from reg_tb";
            MySqlCommand selectCommand = new MySqlCommand(selCmd, conn);
            MySqlDataReader dr = selectCommand.ExecuteReader();
            if (dr == null) { return; }
            Classes.reg stud_obj =null;
            while (dr.Read())
            {
                stud_obj = new Multi_tab.Classes.reg();
                stud_obj.Student_name = dr["student_name"].ToString();
                stud_obj.Reg_no = dr["reg_no"].ToString();
                stud_obj.Gender_id = Convert.ToInt32(dr["gender_id"]);
                stud_obj.Dob = dr["DOB"].ToString();
                stud_obj.Class = dr["class"].ToString();
                stud_obj.Address = dr["address"].ToString();
                STUDENT_COLLECATION.Add(stud_obj);
            }
            conn.Close();

        }
        //TODO: Creating Grid Loader. To retrieve data from the database and display it in the data gridview.
        public void load_grid()
        {

            #region MyRegion
            DgReg.Rows.Clear();
            DataGridViewRow row = null;
            DataGridViewTextBoxCell ecel;
            foreach (Classes.reg obj in STUDENT_COLLECATION)
            {
                row = new DataGridViewRow();
                row.Tag = obj;
                //name
                ecel = new DataGridViewTextBoxCell();
                ecel.Value = obj.Student_name.ToString();
                row.Cells.Add(ecel);
                ecel.Dispose();

                //reg no
                ecel = new DataGridViewTextBoxCell();
                ecel.Value = obj.Reg_no.ToString();
                row.Cells.Add(ecel);
                ecel.Dispose();

                //gender
                ecel = new DataGridViewTextBoxCell();
                if (obj.Gender_id== 0)
                {
                    ecel.Value = "MALE";
                }
                else
                {
                    ecel.Value = "FEMALE";
                }
                row.Cells.Add(ecel);
                ecel.Dispose();

                //date of birth
                ecel = new DataGridViewTextBoxCell();
                ecel.Value = obj.Dob.ToString();
                row.Cells.Add(ecel);
                ecel.Dispose();

                //class
                ecel = new DataGridViewTextBoxCell();
                ecel.Value = obj.Class.ToString();
                row.Cells.Add(ecel);
                ecel.Dispose();

                //address
                ecel = new DataGridViewTextBoxCell();
                ecel.Value = obj.Address.ToString();
                row.Cells.Add(ecel);
                ecel.Dispose();

                DgReg.Rows.Add(row);

                txtName.Clear();
                txtReg.Clear();
                txtAddress.Clear();
                cbxClass1.SelectedIndex = -1;
                cbxGender.SelectedIndex = -1;
                Bdate.Value = DateTime.Today;
            #endregion
                

            }

          

        }
        //TODO: Inserting a Comma after every 3 figures from the write!! Money Format.
        private string to_money(string str)
        {
            int count = 0;
            string outputString = null;
            string fstr = null;
            for (int x = str.Length -1; x >= 0; x--)
            {
                count += 1;
                outputString += str[x];
                if (count == 3 && x != 0)
                {
                    outputString += ',';
                    count = 0;
                }
                

            }
            for (int x = outputString.Length - 1; x >= 0; x--)
            {
                fstr += outputString[x];
            }
            return fstr;
        }
        private void cbx_level_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_level.SelectedIndex == -1) { return; }
            Classes.Level obj = (Classes.Level)cbx_level.SelectedItem;
            if (obj == null) { return; }
            lbl_fees.Text = to_money(obj.Level_Fees.ToString());
        }
        private void buttonX4_Click(object sender, EventArgs e)
        {
            cbx_level.SelectedIndex = -1;
            cbxClass.SelectedIndex = -1;
            cbxStudent.SelectedIndex = -1;

            txtPaid.Clear();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtReg.Clear();
            txtAddress.Clear();
            cbxClass1.SelectedIndex = -1;
            cbxGender.SelectedIndex = -1;
            //Bdate.Value = null;
            
            
        }

        private void DgReg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void txtReg_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void cbxStudent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBtn_Click(object sender, EventArgs e)
        {
            //StPic.ImageLocation = new Bitmap();
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Select an Image";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.StPic.Image = new Bitmap(dlg.OpenFile());
            }
            dlg.Dispose();
        }

        private void StPic_Click(object sender, EventArgs e)
        {

        }

        private void cbxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        
    }
}
