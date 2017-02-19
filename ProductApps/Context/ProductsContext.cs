using ProductApps.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductsApps.Context
{
    public class ProductsContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
         
    }
}