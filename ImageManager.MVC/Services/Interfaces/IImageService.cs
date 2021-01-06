using ImageManager.MVC.ViewModels;
using System.Threading.Tasks;

namespace ImageManager.MVC.Services.Interfaces
{
    public interface IImageService
    {
        /// <summary>
        /// Create image by image url and add one to user with the email.
        /// </summary>
        /// <param name="email">The user email.</param>
        /// <param name="imageUrl">Image url.</param>
        Task AddImageToUserAsync(string email, string imageUrl);

        /// <summary>
        /// Get image urls with user info by user email.
        /// </summary>
        /// <param name="email">The user email.</param>
        /// <returns>UserImagesViewModel.</returns>
        Task<UserImagesViewModel> GetImagesByEmailAsync(string email);
    }
}
