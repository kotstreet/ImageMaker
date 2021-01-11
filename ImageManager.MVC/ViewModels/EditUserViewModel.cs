using ImageManager.MVC.Constants;
using System.ComponentModel.DataAnnotations;

namespace ImageManager.MVC.ViewModels
{
    public class EditUserViewModel
    {
        /// <summary>
        /// User id.
        /// </summary>
        public string Id { get; set; }

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
        /// Has user an Admin role.
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Has user a User role.
        /// </summary>
        public bool IsUser { get; set; }
    }
}
