using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace KursRSPO.Classes
{
    class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public ApplicationContext() : base("DefaultConnection")
        {
            Database.SetInitializer<ApplicationContext>(null);
        }

    }
}
