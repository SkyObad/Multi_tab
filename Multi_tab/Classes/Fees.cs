using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Multi_tab.Classes
{
    class Fees
    {
        private int pay_id;
        private string reg_no;
        private string student_name;
        private string level_id;
        private string paid_amt;
        private string balance;

        public int Pay_id
        {
            get
            {
                return pay_id;
            }
            set
            {
                pay_id = value;
            }
        }
        public string Reg_no
        {
            get
            {
                return reg_no;
            }
            set
            {
                reg_no = value;
            }
        }
        public string Student_name
        {
            get
            {
                return student_name;
            }
            set
            {
                student_name = value;
            }
        }
        public string Level_id
        {
            get
            {
                return level_id;
            }
            set
            {
                level_id = value;
            }
        }
        public string Paid_amt
        {
            get
            {
                return paid_amt;
            }
            set
            {
                paid_amt = value;
            }
        }
        public string Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
            }
        }
    }
}
