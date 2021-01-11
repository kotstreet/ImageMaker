using ImageManager.MVC.Infrastructure;
using ImageManager.MVC.Models;
using ImageManager.MVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ImageManager.MVC.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly AppIdentityDbContext _context;

        public ImageRepository(AppIdentityDbContext context)
        {
            _context = context;
        }

        public async Task<Image> CreateAsync(Image image)
        {
            var createdImage = _context.Images.Add(image);
            await _context.SaveChangesAsync();
            return createdImage.Entity;
        }

        public async Task DeleteAsync(int imageId)
        {
            var image = await GetByIdAsync(imageId);
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Image> GetAll()
        {
            return _context.Images.AsNoTracking();
        }

        public async Task<Image> GetByIdAsync(int imageId)
        {
            return await _context.Images.FindAsync(imageId);
        }

        public async Task<Image> UpdateAsync(Image image)
        {
            var imageFromDb = await GetByIdAsync(image.Id);
            imageFromDb.AppUserId = image.AppUserId;
            imageFromDb.Path = image.Path;

            await _context.SaveChangesAsync();
            return await GetByIdAsync(image.Id);
        }
    }
}
