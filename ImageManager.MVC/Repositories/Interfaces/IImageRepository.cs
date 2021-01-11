using ImageManager.MVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ImageManager.MVC.Repositories.Interfaces
{
    public interface IImageRepository
    {
        /// <summary>
        /// Get image by id.
        /// </summary>
        /// <param name="imageId">The image id.</param>
        /// <returns>Image.</returns>
        Task<Image> GetByIdAsync(int imageId);

        /// <summary>
        /// Get all images from database.
        /// </summary>
        /// <returns>All images.</returns>
        IQueryable<Image> GetAll();

        /// <summary>
        /// Delete image by id.
        /// </summary>
        /// <param name="imageId">The image id.</param>
        Task DeleteAsync(int imageId);

        /// <summary>
        /// Create new image.
        /// </summary>
        /// <param name="image">The image for create.</param>
        /// <returns>Created image.</returns>
        Task<Image> CreateAsync(Image image);

        /// <summary>
        /// Update image.
        /// </summary>
        /// <param name="image">The image for update.</param>
        /// <returns>Updated image.</returns>
        Task<Image> UpdateAsync(Image image);
    }
}
