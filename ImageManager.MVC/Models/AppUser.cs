using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageManager.MVC.Models
{
    /// <summary>
    /// Custom User for image manager.
    /// </summary>
    public class AppUser : IdentityUser
    {
        /// <summary>
        /// User fullname.
        /// </summary>
        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        /// <summary>
        /// User first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// User last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Is user active on site.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// All user images.
        /// </summary>
        public List<Image> Images { get; set; }
    }
}
