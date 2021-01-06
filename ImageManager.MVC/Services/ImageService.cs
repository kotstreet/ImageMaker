using ImageManager.MVC.Infrastructure;
using ImageManager.MVC.Models;
using ImageManager.MVC.Services.Interfaces;
using ImageManager.MVC.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ImageManager.MVC.Services
{
    public class ImageService : IImageService
    {
        private readonly AppIdentityDbContext _context;

        public ImageService(AppIdentityDbContext context)
        {
            _context = context;
        }

        private async Task<UserImagesViewModel> GetImagesForUserAsync(AppUser user)
        {
            var imageUrls = await _context.Images
                .Where(img => img.AppUserId == user.Id)
                .OrderByDescending(img => img.Id)
                .Select(img => img.Path)
                .ToListAsync();

            return new UserImagesViewModel
            {
                FullName = user.FullName,
                Email = user.Email,
                ImageUrls = imageUrls,
            };
        }

        public async Task<UserImagesViewModel> GetImagesByEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Email == email);
            return await GetImagesForUserAsync(user);
        }

        public async Task AddImageToUserAsync(string email, string imageUrl)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Email == email);
            var image = new Image
            {
                Path = imageUrl,
                AppUserId = user.Id,
            };

            //await _context.Images.AddAsync(image);
            var img = _context.Images.Add(image);
            await _context.SaveChangesAsync();
        }
    }
}
