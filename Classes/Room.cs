using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursRSPO.Classes
{
    [Table("Rooms")]
    class Room
    {
        public static int roomId;
        [Key]
        public int id { get; set; }

        public int user_id { get; set; }

        public string name;
        public string Name
        {
            get => name;
            set
            {
                if (value.Length > 3)
                    name = value;
                else
                {
                    throw new ArgumentException("value > 3");
                }
            }
        }

        public int usersLimit;
        public int UsersLimit
        {
            get => usersLimit;
            set
            {
                if (value >= 1 && value <= 20)
                    usersLimit = value;
                else
                {
                    throw new ArgumentException("value >= 1 && value <=20");
                }
            }
        }

        public Room(){}

        public Room(int userId, string name, int userLimit)
        {
            UsersLimit = userLimit;
            Name = name;
            this.user_id = userId;
        }

    }
}
