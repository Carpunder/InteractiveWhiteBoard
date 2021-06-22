using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursRSPO.Classes
{
    [Table("Notes")]
    class Note
    {
        [Key]
        public int id { get; set; }
        public DateTime date { get; set; }
        public int user_id { get; set; }

        public string title;
        public string Title
        {
            get => title;
            set
            {
                if (value.Length > 3)
                    title = value;
                else
                {
                    throw new ArgumentException("value > 3");
                }
            }
        }

        public string content;
        public string Content
        {
            get => content;
            set
            {
                if (value.Length > 3)
                    content = value;
                else
                {
                    throw new ArgumentException("value > 3");
                }
            }
        }

        public Note(){}

        public Note(int user_id, string title, string content)
        {
            this.user_id = user_id;
            Title = title;
            Content = content;
            date = DateTime.UtcNow;
        }

    }
}
