using ImageManager.MVC.Models;
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
        /// It's an image editing history set.
        /// </summary>
        public DbSet<Image> Images { get; set; }

        /// <summary>
        /// It's all admins subscriptions.
        /// </summary>
        public DbSet<Subscription> Subscriptions { get; set; }

        /// <summary>
        /// It's all notice.
        /// </summary>
        public DbSet<Notice> Notices { get; set; }
    }
}
