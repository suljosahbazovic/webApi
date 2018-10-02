using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using webApi.Models;

namespace webApi.Data
{
    public class MyContext : DbContext
    {
        public MyContext() : base("name=MyConnectionString")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Tag> Tags { get; set; }

    }
}