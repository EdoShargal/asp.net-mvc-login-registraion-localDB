using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace MvcLoginRegistration.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage ="First Name is required!.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required!.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required!.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is required!.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required!.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage ="Plese confirm your password.")]
        public string ConfirmPassword { get; set; }
    }
}