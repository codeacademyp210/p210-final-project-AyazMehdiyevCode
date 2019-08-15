using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace _56_Xeber.Areas.Admin.Models
{
    public class XeberContext : DbContext
    {
        public XeberContext() : base("name=XeberDB") { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<User> Users { get; set; }

    }
}