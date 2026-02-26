
using System.ComponentModel.DataAnnotations;

namespace UI_MVC.Models
{
    public class LoginViewModel
    {
        [Display(Name = "E-Mail Adress", Prompt = "example@example.com")]
        [EmailAddress]
        [Required]
        public required string Email { get; set; }



        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required]
        public required string Password { get; set; }



        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }


    }
}
