using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Jio.Models
{
    public class JioContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public JioContext() : base("name=JioContext")
        {
        }

        public System.Data.Entity.DbSet<Jio.Models.Restaurant> Restaurants { get; set; }

        public System.Data.Entity.DbSet<Jio.Models.Menu_Item> Menu_Item { get; set; }
    }
}
