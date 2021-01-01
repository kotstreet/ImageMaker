using ImageManager.MVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ImageManager.MVC.Infrastructure
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {        
        public AppIdentityDbContext(string connectionString)
               : base(CreateContextOptions(connectionString))
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// It's a purchaice history set.
        /// </summary>
        public DbSet<Image> Images { get; set; }
        
        private static DbContextOptions<AppIdentityDbContext> CreateContextOptions(string connection)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppIdentityDbContext>();
            return optionsBuilder
                    .UseSqlServer(connection)
                    .Options;
        }

        ////protected override void OnModelCreating(ModelBuilder modelBuilder)
        ////{
        ////    modelBuilder.Entity<AppUser>().HasData(
        ////        new AppUser[]
        ////        {
        ////        new AppUser { Name="Tom", Age=23},
        ////        new AppUser { FullName="Alice", Age=26},
        ////        });
        ////}
    }
}
