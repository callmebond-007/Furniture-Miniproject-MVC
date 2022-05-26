using System.ComponentModel.DataAnnotations;

namespace Furniture_Management_MVC.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is mandatory")]

        [Display(Name = "User Name")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is mandatory")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
