using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MysqlEF6.Helpers
{
    public partial class MyDbContext : System.Data.Entity.DbContext
    {
        public MyDbContext() : base(nameOrConnectionString: "MyContext") { }

        public DbSet<Persons> People { get; set; }
    }

}