using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineAdvertisingPortal.Models
{
    public class BusinessDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Businessname is Required!")]
        public string Businessname { get; set; }

        [Required(ErrorMessage = "Ownername is Required!")]
        public string Ownername { get; set; }

        [Required(ErrorMessage = "Description is Required!")]
        public string Description { get; set; }

        [Required]
        public string Category { get; set; }

        [Required(ErrorMessage = "Address is Required!")]
        public string Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Mobile no. is Required!")]
        public string Mobile { get; set; }

        public virtual ICollection<Ratings> Ratings { get; set; } = new HashSet<Ratings>();

        [DisplayName("Upload File")]
        public string Imagepath { get; set; }

        public double Overall{ get; set; }

        [NotMapped]
        public HttpPostedFileBase Imagefile { get; set; }

    }   
        
    
}