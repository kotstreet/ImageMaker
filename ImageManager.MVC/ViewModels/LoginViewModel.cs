using ImageManager.MVC.Constants;
using System.ComponentModel.DataAnnotations;

namespace ImageManager.MVC.ViewModels
{
    public class LoginViewModel
    {
        /// <summary>
        /// User email.
        /// </summary>
        [Required(ErrorMessage = ViewModelAttributeMessages.EmailRequired)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = ViewModelAttributeMessages.ItIsNotEmail)]
        public string Email { get; set; }

        /// <summary>
        /// User password.
        /// </summary>
        [Required(ErrorMessage = ViewModelAttributeMessages.PasswordRequired)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
