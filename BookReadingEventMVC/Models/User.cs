using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookReadingEventMVC.Models
{
    public class User
    {
        public int User_Id { get; set; }
        [Required]
        [Display(Name ="First Name")]
        [MaxLength(50)]
        public string First_Name { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(50)]
        public string Last_Name { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Must Contain at least 5 character")]
        [RegularExpression("((?=.*[@#$%]).{5,20})", ErrorMessage = "Must Contain atleast one special character")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}