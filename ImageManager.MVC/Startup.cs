using ImageManager.MVC.Constants;
using ImageManager.MVC.Filters;
using ImageManager.MVC.Infrastructure;
using ImageManager.MVC.Models;
using ImageManager.MVC.Repositories;
using ImageManager.MVC.Repositories.Helpers;
using ImageManager.MVC.Repositories.Interfaces;
using ImageManager.MVC.Services;
using ImageManager.MVC.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace ImageManager.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(ConnectionStrings.DefaultConnection)));

            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<ISubscriptionService, SubscriptionService>();
            services.AddTransient<INotificationService, NotificationService>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IImageRepository, ImageRepository>();
            services.AddTransient<ISubscriptionRepository, SubscriptionRepository>();
            services.AddTransient<INotificationRepository, NotificationRepository>();
            services.AddTransient<IUserRoleDataHelper, UserRoleDataHelper>();

            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<AppIdentityDbContext>();




            services.AddLocalization(options => options.ResourcesPath = LocalizationSettings.ResourcesFolder);
            services.AddControllersWithViews()
                .AddDataAnnotationsLocalization()
                .AddViewLocalization();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo(LocalizationSettings.EnglishCulture),
                    new CultureInfo(LocalizationSettings.RussianCulture)
                };

                var defaultCulture = Configuration[LocalizationSettings.DefaultCulture];
                options.DefaultRequestCulture = new RequestCulture(defaultCulture);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
        }

        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRequestLocalization();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            IdentityDbInit.SeedDataAsync(userManager, roleManager, Configuration).Wait();
            logger.LogInformation("SeedDataAsync finished withiut errors.");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
