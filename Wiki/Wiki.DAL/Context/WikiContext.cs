using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.DAL.Entities;

namespace Wiki.DAL.Context
{
    public class WikiContext : DbContext
    {
        public WikiContext(string connectionString) : base(connectionString)
        {
            
        }

        public WikiContext()
        {
            
        }

        public DbSet<Record> Records { set; get; }
    }
}
