using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
namespace Assignment40_PartII
{

    public class NorthWindContext : DbContext
    {
        public NorthWindContext()
            : base(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Amanda\Downloads\northwind_sqlserver\NORTHWND.MDF;Integrated Security=True;Connect Timeout=30")
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    } 
}
