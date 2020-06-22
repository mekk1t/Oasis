using OasisWebApp.CinemaService.Repository.Filters;
using OasisWebApp.DTOs;
using OasisWebApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OasisWebApp.CinemaService.Services.Interface
{
    public interface ICinemaService :
        ICreate<CinemaDto>,
        IGet<CinemaDto, CinemaFilter, int>,
        IFind<CinemaDto, CinemaFilter>,
        IUpdate<CinemaDto>,
        IDelete<int>
    {
    }
}
