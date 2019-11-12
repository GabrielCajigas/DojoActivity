using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Belt.Models;

namespace Belt.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Name should be a minimum of 2 characters")]

        public string name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [MinLength(8, ErrorMessage = "passwords should be a minimum of 8 characters")]

        [RegularExpression(@"^(?=.*\d)(?=.*[a-zA-Z])(?=.*[\W_]).{3,}$", ErrorMessage = "Enter at least 1 letter and 1 number and 1 special character")]
        public string password { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Passwords do not match")]
        public string verifypassword { get; set; }





    }

    public class OldUser
    {
        [Required]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string EmailO { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PasswordO { get; set; }
    }
}