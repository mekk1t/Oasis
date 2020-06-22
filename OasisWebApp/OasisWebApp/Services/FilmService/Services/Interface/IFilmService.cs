using OasisWebApp.DTOs;
using OasisWebApp.Interfaces;
using OasisWebApp.Services.FilmService.Repository.Filters;


namespace OasisWebApp.Services.FilmService.Services.Interface
{
    public interface IFilmService :
        IGet<FilmDto, FilmFilter, int>,
        IFind<FilmDto, FilmFilter>,
        IDelete<int>,
        ICreate<FilmDto>
    {
    }
}
