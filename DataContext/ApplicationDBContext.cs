using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using bankingMvcTestApp.Models;

namespace bankingMvcTestApp.DataContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext():base(nameOrConnectionString: "myconnection")
        { 
        }

        public virtual DbSet<CustomerClass> customerObject { get; set; }
        public virtual DbSet<LoginClass> loginObject { get; set; }
    }
}