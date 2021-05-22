using System;
using System.ComponentModel.DataAnnotations;

namespace myPennyFarthing.Models
{
    public class UserRegistrationViewModel
    {
        [Required(ErrorMessage = "Email Is Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords Must Match")]
        [Required(ErrorMessage = "Verification Password Is Required")]
        public string VerificationPassword { get; set; }
    }
}
