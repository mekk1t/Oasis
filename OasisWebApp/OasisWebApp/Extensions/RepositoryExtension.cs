using Microsoft.Extensions.DependencyInjection;
using OasisWebApp.CinemaService.Repository;
using OasisWebApp.CinemaService.Repository.Interface;
using OasisWebApp.Services.FilmService.Repository;
using OasisWebApp.Services.FilmService.Repository.Interface;
using OasisWebApp.Services.SessionService.Repository;
using OasisWebApp.Services.SessionService.Repository.Interface;

namespace OasisWebApp.Extensions
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepositories(
            this IServiceCollection services)
        {
            services.AddScoped<ICinemaRepository, CinemaRepository>();
            services.AddScoped<IFilmRepository, FilmRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            return services;
        }
    }
}
