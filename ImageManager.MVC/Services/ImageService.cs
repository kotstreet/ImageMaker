using ImageManager.MVC.Infrastructure;
using ImageManager.MVC.Models;
using ImageManager.MVC.Services.Interfaces;
using ImageManager.MVC.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Web;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImageManager.MVC.Services
{
    public class ImageService : IImageService
    {
        private const string ImageFolder = "wwwroot/Images";
        private const string StartOfUrl = "data:image/jpeg;base64,";
        private const char ReplacedChar = ' ';
        private const char CharForReplace = '+';

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

        private string CreateImage(int imageId, string url)
        {
            var fileName = $"Image_{imageId}.jpeg";
            var filePath = Path.Combine(Environment.CurrentDirectory, ImageFolder, fileName);
            File.Create(fileName).Close();

            var base64 = url
                .Substring(StartOfUrl.Length)
                .Replace(ReplacedChar, CharForReplace);
            var imageBytes = Convert.FromBase64String(base64);
            File.WriteAllBytes(filePath, imageBytes);

            return $"../Images/{fileName}";
        }

        public async Task<UserImagesViewModel> GetImagesByEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Email == email);
            return await GetImagesForUserAsync(user);
        }

        public async Task<UserImagesViewModel> GetImagesByUserIdAsync(string id)
        {
            var user = await _context.Users.FindAsync(id);
            return await GetImagesForUserAsync(user);
        }

        public async Task AddImageToUserAsync(string email, string imageUrl)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user => user.Email == email);
            var urlForSave = imageUrl.Replace(ReplacedChar, CharForReplace);
            var image = new Image
            {
                AppUserId = user.Id,
                Path = urlForSave,
            };

            var img = _context.Images.Add(image).Entity;
            await _context.SaveChangesAsync();

            img.Path = CreateImage(img.Id, imageUrl);
            await _context.SaveChangesAsync();
        }
    }
}
