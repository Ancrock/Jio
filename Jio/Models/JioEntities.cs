using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Jio.Models
{
    public class JioEntities : DbContext
    {
        public DbSet<Restaurant> restaurants { get; set; }
        public DbSet<Menu_Item> menu_item { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        //public DbSet<UserProfileEdit> UserProfileEdit { get; set; }
    }
}