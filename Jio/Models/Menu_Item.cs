using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jio.Models
{
    public class Menu_Item
    {

        public int Menu_ItemID { get; set; }
        public int RestaurantID { get; set; }

        [Required(ErrorMessage = "An Item Name is required")]
        [StringLength(160)]
        public string Item_Name { get; set; }

        [Required(ErrorMessage = "An Description for the item is required")]
        [StringLength(250)]
        public string description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100.00,
          ErrorMessage = "Price must be between 0.01 and 100.00")]
        public decimal price { get; set; }

        [DisplayName("Album Art URL")]
        [StringLength(1024)]
        public string AlbumArtUrl { get; set; }

        public Restaurant restaurant { get; set; }
        //public virtual ICollection<Restaurant> restaurant { get; set; }

    }
}