using ImageManager.MVC.Infrastructure;
using ImageManager.MVC.Models;
using ImageManager.MVC.Services.Interfaces;
using ImageManager.MVC.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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

        private string SaveImageToStore(string base64, int id)
        {
            var str1 = base64.Substring("data:image/png;base64,".Length);
            var imageDirectory = "Images";
            var imageName = $"Edited image {id}.png";
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), imageDirectory, imageName);
            File.Create(imagePath).Close();

            var base64Regex = Regex.Match(base64, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
            var bytes2 = Convert.FromBase64String(base64Regex);
            var bytes = Convert.FromBase64String(base64);
            File.WriteAllBytes(imagePath, bytes);

            return imagePath;
        }

        public async Task<UserImagesViewModel> GetImagesByEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Email == email);
            return await GetImagesForUserAsync(user);
        }

        public async Task AddImageToUserAsync(string email, string imageUrl)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Email == email);
            var urlForSave = imageUrl.Replace(" ", "+");
            var image = new Image
            {
                AppUserId = user.Id,
                Path = urlForSave,
            };

            //await _context.Images.AddAsync(image);
            var img = _context.Images.Add(image).Entity;
            await _context.SaveChangesAsync();
        }
    }
}
