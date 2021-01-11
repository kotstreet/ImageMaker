using ImageManager.MVC.Infrastructure;
using ImageManager.MVC.Models;
using ImageManager.MVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ImageManager.MVC.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppIdentityDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public UserRepository(AppIdentityDbContext context,
            UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<AppUser> CreateAsync(AppUser appUser, string password)
        {
            var identityresult = await _userManager.CreateAsync(appUser, password);
            return identityresult.Succeeded ? await _userManager.FindByEmailAsync(appUser.Email) : null;
        }

        public async Task DeleteAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.DeleteAsync(user);
        }

        public IQueryable<AppUser> GetAll()
        {
            return _context.Users.AsNoTracking();
        }

        public Task<AppUser> GetByEmailAsync(string email)
        {
            return _userManager.FindByEmailAsync(email);
        }

        public Task<AppUser> GetByIdAsync(string userId)
        {
            return _userManager.FindByIdAsync(userId);
        }

        public async Task<AppUser> UpdateAsync(AppUser appUser)
        {
            var identityresult = await _userManager.UpdateAsync(appUser);
            return identityresult.Succeeded ? await _userManager.FindByIdAsync(appUser.Id) : null;
        }
    }
}
