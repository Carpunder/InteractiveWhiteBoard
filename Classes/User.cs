using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KursRSPO.Classes
{
    [Table("Users")]
    public class User
    {
        public static int userId;
        [Key]
        public int id { get; set; }

        public string login;
        public string Login
        {
            get => login;
            set
            {
                if (value.Length > 3)
                    login = value;
                else
                {
                    throw new ArgumentException("value > 3");
                }
            }
        }

        public string password;
        public string Password
        {
            get => password;
            set
            {
                if (value == null)
                    password = "1111";
                if (value.Length > 3)
                    password = value;
                else
                {
                    throw new ArgumentException("value > 3");
                }
            }
        }


        public User(){}

        public User(string login, string password)
        {
            Login= login;
            Password = password;
        }

    }
}