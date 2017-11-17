using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeShop.Models
{
    public class UserInfo
    {
        private string email;
        private string password;

        public UserInfo()
        {

        }

        public UserInfo(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        public string GetEmail
        {
            set { email = value; }
            get { return email; }
        }

        public string GetPassword
        {
            get { return password; }
            set { password = value; }
        }
    }
}