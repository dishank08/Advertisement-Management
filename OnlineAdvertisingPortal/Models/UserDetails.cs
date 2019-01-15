using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineAdvertisingPortal.Models
{
    public class UserDetails
    {
        [Key]
        [Required(ErrorMessage = "Username is Required!")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Firstname is Required!")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Lastname is Required!")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Email is Required!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Please, Confirm your Password!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }

}