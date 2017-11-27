using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Linq;
using System.Web;

namespace CoffeeShop.Models
{
    public class UserInfo
    {
        private string name;
        private string email;
        private string password;

        //public UserInfo() : this("", "", "")
        //{

        //}

        public UserInfo()
        {

        }

        public UserInfo(string name, string email, string password)
        {
            this.name = name;
            this.email = email;
            this.password = password;
        }

        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(20, MinimumLength = 4)]
        //[RegularExpression("^[a-zA-Z0-9_\\-\\.] +)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\$")]
        public string Email
        {
            set { email = value; }
            get { return email; }
        }

        [Required]
        [DataType(DataType.Password)]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}