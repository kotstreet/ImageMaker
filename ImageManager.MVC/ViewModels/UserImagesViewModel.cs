using System.Collections.Generic;

namespace ImageManager.MVC.ViewModels
{
    public class UserImagesViewModel
    {
        /// <summary>
        /// User email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User fullname.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// List of user image urls.
        /// </summary>
        public List<string> ImageUrls { get; set; }
    }
}
