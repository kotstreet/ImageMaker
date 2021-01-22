using System.Collections.Generic;

namespace ImageManager.MVC.Models
{
    public class Image
    {
        /// <summary>
        /// Image id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Path of the image.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// User that have the image id.
        /// </summary>
        public string AppUserId { get; set; }

        /// <summary>
        /// User that have the image id.
        /// </summary>
        public AppUser AppUser { get; set; }

        /// <summary>
        /// Notices with the image.
        /// </summary>
        public List<Notice> Notices { get; set; }
    }
}
