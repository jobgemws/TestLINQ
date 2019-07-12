using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TestLINQ
{
    public class UserContext : DbContext
    {
        public UserContext()
            : base("DbConnection")
        {
            Database.SetInitializer<UserContext>(null);
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Ref> Ref { get; set; }
    }
}