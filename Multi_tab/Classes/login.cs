using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Multi_tab.Classes
{
    class login
    {
        private string user_name;
        private string password;

        public string User_name
        {
            get
            {
                return user_name;
            }
            set
            {
                user_name = value;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
    }
}
