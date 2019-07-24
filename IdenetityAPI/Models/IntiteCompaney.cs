using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdenetityAPI.Models
{
    public class IntiteCompaney:IdentityDbContext
    {
        public IntiteCompaney():base(@"Data Source=DESKTOP-9HH57Q0\MSSQLSEVEREX;Initial Catalog=WebMobileId;Integrated Security=True")
        {

        }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> products { get; set; }

        public virtual DbSet<category> categories { get; set; }

        //Role
        //User
    }
}