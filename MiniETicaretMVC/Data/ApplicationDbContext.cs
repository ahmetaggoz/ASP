using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MiniETicaretMVC.Models;

namespace MiniETicaretMVC.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection") { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}