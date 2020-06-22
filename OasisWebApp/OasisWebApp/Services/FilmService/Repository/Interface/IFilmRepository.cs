using OasisWebApp.Database.Entities;
using OasisWebApp.Interfaces;
using OasisWebApp.Services.FilmService.Repository.Filters;

namespace OasisWebApp.Services.FilmService.Repository.Interface
{
    public interface IFilmRepository :
        ICreate<Film>,
        IGet<Film, FilmFilter, int>,
        IFind<Film, FilmFilter>,
        IUpdate<Film>,
        IDelete<int>
    {
    }
}
