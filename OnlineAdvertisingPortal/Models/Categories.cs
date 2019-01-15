using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineAdvertisingPortal.Models
{
    [Table("Categories")]
    public class Categories
    {
        [Key]
        public string Categoryname { get; set; }

        public string CategoryPath { get; set; }

        [NotMapped]
        public HttpPostedFileBase Imagefile { get; set; }

    }
}