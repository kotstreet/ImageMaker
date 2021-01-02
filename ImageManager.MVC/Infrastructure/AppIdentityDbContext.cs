using ImageManager.MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ImageManager.MVC.Infrastructure
{
    /// <summary>
    /// Database context for the app that implement identity logic.
    /// </summary>
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {        
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
               : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// It's a purchaice history set.
        /// </summary>
        public DbSet<Image> Images { get; set; }
    }
}
