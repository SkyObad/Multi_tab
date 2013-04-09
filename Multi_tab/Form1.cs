using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Multi_tab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
              this.Text = "STUDENTS' RECORDS KEEPING SYSTEM";
              MySqlConnection _save = new MySqlConnection("server=localhost;User Id=root;database=school_management_system;Persist Security Info=True; password=mysql");
              
              
        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            //creating a connection interface btn the form and the database.


            

            //getting data from the form to the database using the insert cmd.
            

            Save_button.ForeColor = Color.Blue;
           // Save_button.BackColor = Color.BurlyWood;
            if (name_textBox1.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Student's Name");
            }
            if (Reg_no_textBox2.Text.Length == 0)
            {
                MessageBox.Show("Enter Registration Number:");
            }
 
            DataGridViewRow _row = new DataGridViewRow();
            DataGridViewTextBoxCell student = new DataGridViewTextBoxCell();
            student.Value = name_textBox1.Text;
            student.Tag = null;
            _row.Cells.Add(student);
            DataGridViewTextBoxCell _reg = new DataGridViewTextBoxCell();
            _reg.Value = Reg_no_textBox2.Text;
            _reg.Tag = null;
            _row.Cells.Add(_reg);
            DataGridViewTextBoxCell date = new DataGridViewTextBoxCell();
            date.Value = dateTimePicker1.Text;
            date.Tag = null;
            _row.Cells.Add(date);
            DataGridViewTextBoxCell sex = new DataGridViewTextBoxCell();
            if (Male.Checked)
            {
                sex.Value = "Male";
            }
            else 
            {
                sex.Value = "Female";
            }
            sex.Tag = null;
            _row.Cells.Add(sex);
            DataGridViewTextBoxCell class1 = new DataGridViewTextBoxCell();
            class1.Value = class_comboBox3.Text;
            class1.Tag = null;
            _row.Cells.Add(class1);
            DataGridViewTextBoxCell contact = new DataGridViewTextBoxCell();
            contact.Value = Contact_textBox3.Text;
            contact.Tag = null;
            _row.Cells.Add(contact);
            DataGridViewTextBoxCell _address = new DataGridViewTextBoxCell();
            _address.Value = address_textBox5.Text;
            _address.Tag = null;
            _row.Cells.Add(_address);
            dataGridView1.Rows.Add(_row);
            
        
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            
                Cancel_button.ForeColor = Color.Blue;
                MessageBox.Show("Cannot delete entry!");
            
            
        }

        private void Add_New_Click(object sender, EventArgs e)
        {
            Add_New.ForeColor = Color.Blue;
            //DataGridViewRow _rows = dataGridView1.CurrentRow;
            //dataGridView1.Rows.Add(_rows);
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Save_button1.ForeColor = Color.Blue;
            if (Reg_notextBox12.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Students Reg_Number!");
            }
            DataGridViewRow _fees = new DataGridViewRow();
            DataGridViewTextBoxCell reg = new DataGridViewTextBoxCell();
            reg.Value = Reg_notextBox12.Text;
            reg.Tag = null;
            _fees.Cells.Add(reg);
            DataGridViewTextBoxCell _Class = new DataGridViewTextBoxCell();
            _Class.Value = Class_comboBox2.Text;
            _Class.Tag = null;
            _fees.Cells.Add(_Class);
            DataGridViewTextBoxCell _term = new DataGridViewTextBoxCell();
            _term.Value = Term_comboBox1.Text;
            _term.Tag = null;
            _fees.Cells.Add(_term);
            DataGridViewTextBoxCell _amt = new DataGridViewTextBoxCell();
            _amt.Value = actual_paidcomboBox4.Text;
            _amt.Tag = null;
            _fees.Cells.Add(_amt);
            DataGridViewTextBoxCell _paid = new DataGridViewTextBoxCell();
            _paid.Value = amt_paid_textBox16.Text;
            _paid.Tag = null;
            _fees.Cells.Add(_paid);
            DataGridViewTextBoxCell _bal = new DataGridViewTextBoxCell();
            _bal.Value = Fees_bltextBox1.Text;
            _bal.Tag = null;
            _fees.Cells.Add(_bal);
            DataGridViewTextBoxCell _date = new DataGridViewTextBoxCell();
            _date.Value = dateTimePicker3.Text;
            _date.Tag = null;
            _fees.Cells.Add(_date);
            dataGridView2.Rows.Add(_fees); 

            


        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void Delete_button_Click(object sender, EventArgs e)
        {
            Delete_button.ForeColor = Color.Blue; 
            DataGridViewRow row = dataGridView1.CurrentRow;
            dataGridView1.Rows.Remove(row);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reset_button2.ForeColor = Color.Blue;
            DataGridViewRow reset = dataGridView2.CurrentRow;
            dataGridView2.Rows.Remove(reset);
        }

        private void Picture_button_Click(object sender, EventArgs e)
        {
            //pictureBox2.Image = Image.FromFile("C:\Users\Pictures\Grand\Ob_grand.jpg");
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void amt_paidcomboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

    }
}
