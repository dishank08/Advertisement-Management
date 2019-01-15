using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineAdvertisingPortal.Models
{
    public class Ratings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RatingId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public int Businessid { get; set; }

        [Required]
        public double Rate { get; set; }

    }
}

            