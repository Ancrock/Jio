using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Jio.Models
{
    public class Feedback
    {
        public int FeedbackID { get; set; }

        [Required(ErrorMessage = "A satisfaction level is required")]
        public int Satisfaction { get; set; }

        [Required(ErrorMessage = "A Feedback is required")]
        [StringLength(160)]
        public string Suggestions { get; set; }
    }
}