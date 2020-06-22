using OasisWebApp.Database.Entities;
using OasisWebApp.DTOs;
using OasisWebApp.Interfaces;
using OasisWebApp.Services.SessionService.Repository.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OasisWebApp.Services.SessionService.Services.Interface
{
    public interface ISessionService :
        ICreate<SessionDto>,
        IGet<SessionDto, SessionFilter, int>,
        IFind<SessionDto, SessionFilter>,
        IUpdate<SessionDto>,
        IDelete<int>
    {
    }
}
