using ImageManager.MVC.Models;
using ImageManager.MVC.Repositories.Interfaces;
using ImageManager.MVC.Services.Interfaces;
using ImageManager.MVC.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
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

        private readonly IImageRepository _imageRepository;
        private readonly IUserRepository _userRepository;
        private readonly INotificationService _notificationService;

        public ImageService(INotificationService notificationService,
            IImageRepository imageRepository,
            IUserRepository userRepository)
        {
            _notificationService = notificationService;
            _imageRepository = imageRepository;
            _userRepository = userRepository;
        }

        private async Task<UserImagesViewModel> GetImagesForUserAsync(AppUser user)
        {
            var imageUrls = await _imageRepository.GetAll()
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

            var base64 = url
                .Substring(StartOfUrl.Length)
                .Replace(ReplacedChar, CharForReplace);
            var imageBytes = Convert.FromBase64String(base64);

            File.WriteAllBytes(filePath, imageBytes);
            return $"../Images/{fileName}";
        }

        public async Task<UserImagesViewModel> GetImagesByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            return await GetImagesForUserAsync(user);
        }

        public async Task<UserImagesViewModel> GetImagesByUserIdAsync(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return await GetImagesForUserAsync(user);
        }

        public async Task AddImageToUserAsync(string email, string imageUrl)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            var urlForSave = imageUrl.Replace(ReplacedChar, CharForReplace);
            var image = new Image
            {
                AppUserId = user.Id,
                Path = urlForSave,
            };

            var createdImage = await _imageRepository.CreateAsync(image);
            createdImage.Path = CreateImage(createdImage.Id, imageUrl);
            await _imageRepository.UpdateAsync(createdImage);

            await _notificationService.AddNotificationsForUserAsync(user.Id, createdImage.Id);
        }
    }
}
