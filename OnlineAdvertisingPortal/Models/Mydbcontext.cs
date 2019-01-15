using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineAdvertisingPortal.Models
{
    public class Mydbcontext : DbContext
    {
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<BusinessDetails> BusinessDetails { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Ratings> Ratings { get; set; }
    }
}