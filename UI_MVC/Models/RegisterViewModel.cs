
using System.ComponentModel.DataAnnotations;

namespace UI_MVC.Models
{
    public class RegisterViewModel
    {

        [Display(Name = "E-Mail Adress", Prompt = "example@example.com")]
        [EmailAddress]
        [Required]
        public required string Email { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required]
        public required string Password { get; set; }



        [Display(Name = "Password Confirm")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Required]
        public required string ConfirmPassword { get; set; }
    }
}
