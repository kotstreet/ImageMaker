using ImageManager.MVC.Constants;
using System.ComponentModel.DataAnnotations;

namespace ImageManager.MVC.ViewModels
{
    public class RegisterViewModel
    {
        /// <summary>
        /// User email.
        /// </summary>
        [Required(ErrorMessage = ViewModelAttributeMessages.EmailRequired)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = ViewModelAttributeMessages.ItIsNotEmail)]
        public string Email { get; set; }

        /// <summary>
        /// User first name.
        /// </summary>
        [DataType(DataType.Text)]
        [Required(ErrorMessage = ViewModelAttributeMessages.FirstNameRequired)]
        public string FirstName { get; set; }

        /// <summary>
        /// User last name.
        /// </summary>
        [DataType(DataType.Text)]
        [Required(ErrorMessage = ViewModelAttributeMessages.LastNameRequired)]
        public string LastName { get; set; }

        /// <summary>
        /// User password.
        /// </summary>
        [DataType(DataType.Password)]
        [Required(ErrorMessage = ViewModelAttributeMessages.PasswordRequired)]
        public string Password { get; set; }

        /// <summary>
        /// Confirmation user password.
        /// </summary>
        [Compare(ViewModelAttributeMessages.PasswordField, ErrorMessage = ViewModelAttributeMessages.PasswordsAreNotEquals)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = ViewModelAttributeMessages.ConfirmRequired)]
        public string ConfirmPassword { get; set; }
    }
}
