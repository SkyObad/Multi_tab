using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Multi_tab.Classes
{
    class reg
    {
        private string reg_no;
        private string student_name;
        private int gender_id;
        private string DOB;
        private string _class;
        private string address;
        private byte picture;
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
        public int Gender_id
        {
            get
            {
                return gender_id;
            }
            set
            {
                gender_id = value;
            }
        }
        public string Dob
        {
            get
            {
                return DOB;
            }
            set
            {
                DOB = value;
            }
        }
        public string Class 
        {
            get
            {
                return _class;
            }
            set
            {
                _class = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public byte Picture
        {
            get
            {
                return picture;
            }
            set
            {
                picture = value;
            }
        }

        
    }
}
