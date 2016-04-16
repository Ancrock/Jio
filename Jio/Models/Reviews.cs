using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jio.Models
{
    public class Reviews
    {
        public int ReviewsID { get; set; }
        public int RestaurantID { get; set; }

        [Required(ErrorMessage = "A Name is required")]
        [StringLength(160)]
        public string UserName { get; set; }


        [Required(ErrorMessage = "A Review is required")]
        [StringLength(160)]
        public string Review { get; set; }

        [Required(ErrorMessage = "A Recommendation is required")]
        [StringLength(160)]
        public string Recommendation { get; set; }

        public Restaurant restaurant { get; set; }

    }
}