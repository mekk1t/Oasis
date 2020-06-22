using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OasisWebApp.Database;

namespace OasisWebApp.Extensions
{
    public static class DbContextExtension
    {
        public static IServiceCollection AddDatabase(
            this IServiceCollection services, IConfiguration Configuration)
        {            
            services.AddDbContext<OasisCinemaDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SQLConnection")));

            return services;
        }
    }
}
