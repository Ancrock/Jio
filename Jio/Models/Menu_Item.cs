using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jio.Models
{
    public class Menu_Item
    {

        public int Menu_ItemID { get; set; }
        public int RestaurantID { get; set; }
        public string Item_Name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public Restaurant restaurant { get; set; }
        //public virtual ICollection<Restaurant> restaurant { get; set; }

    }
}