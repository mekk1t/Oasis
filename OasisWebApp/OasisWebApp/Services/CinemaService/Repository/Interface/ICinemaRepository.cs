using OasisWebApp.CinemaService.Repository.Filters;
using OasisWebApp.Database.Entities;
using OasisWebApp.Interfaces;

namespace OasisWebApp.CinemaService.Repository.Interface
{
    public interface ICinemaRepository:

        ICreate<Cinema>,
        IGet<Cinema, CinemaFilter, int>,
        IFind<Cinema, CinemaFilter>,
        IUpdate<Cinema>,
        IDelete<int>      
    {
    }
}
