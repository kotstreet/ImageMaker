using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

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
        public string FullName { get; set; }

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
