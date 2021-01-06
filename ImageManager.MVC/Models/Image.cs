using System;

namespace ImageManager.MVC.Models
{
    public class Image
    {
        /// <summary>
        /// Image id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User that have the image id.
        /// </summary>
        public string AppUserId { get; set; }

        /// <summary>
        /// User that have the image id.
        /// </summary>
        public AppUser AppUser { get; set; }

        /// <summary>
        /// Path of the image.
        /// </summary>
        public string Path { get; set; }
    }
}
