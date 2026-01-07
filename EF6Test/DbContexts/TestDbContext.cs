using EF6Test.Entitys;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6Test.DbContexts
{
    public class TestDbContext : DbContext
    {
        public TestDbContext() : base("name=WindowAuthConnection")
        {
        }

        public DbSet<DbModels> Products { get; set; }
    }
}
