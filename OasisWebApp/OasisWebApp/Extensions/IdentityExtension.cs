using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OasisWebApp.Database;

namespace OasisWebApp.Extensions
{
    public static class IdentityExtension
    {
        public static IServiceCollection IdentitySettings(
            this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(config =>
            {
                config.Password.RequireDigit = false;
                config.Password.RequiredLength = 4;
                config.Password.RequireLowercase = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;

                config.SignIn.RequireConfirmedAccount = false;
            })
                    .AddDefaultTokenProviders()
                    .AddEntityFrameworkStores<OasisUsersDbContext>();
            
            services.AddDbContext<OasisUsersDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));

            return services;

        }

        public static IServiceCollection CookieSettings(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "Identity.Cookie";
                config.LoginPath = "/Account/Login";
            });

            return services;
        }

    }
}
