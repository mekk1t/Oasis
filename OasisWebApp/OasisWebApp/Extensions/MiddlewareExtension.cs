using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OasisWebApp.Database;

namespace OasisWebApp.Extensions
{
    public static class MiddlewareExtension
    {
        /// <summary>
        /// Applies all pending migrations to the database.
        /// If it does not exist, EF Core creates the database.
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseMigrations(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();
            using var usersDbContext = serviceScope.ServiceProvider.GetService<OasisUsersDbContext>();
            using var mainDbContext = serviceScope.ServiceProvider.GetService<OasisCinemaDbContext>();
            usersDbContext.Database.Migrate();
            mainDbContext.Database.Migrate();

            return app;
        }
    }
}
