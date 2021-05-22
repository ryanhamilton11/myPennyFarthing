using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myPennyFarthing.Models
{
    [Table("User", Schema = "myPennyFarthing")]
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email Is Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }
    }
}
