using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jio.Models
{
    public class Restaurant
    {

        public int RestaurantID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public double Contact { get; set; }
        public String address { get; set; }
        public virtual ICollection<Menu_Item> menu_item { get; set; }
    }
}