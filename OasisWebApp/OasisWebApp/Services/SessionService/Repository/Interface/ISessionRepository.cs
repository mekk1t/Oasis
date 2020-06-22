using OasisWebApp.Database.Entities;
using OasisWebApp.Interfaces;
using OasisWebApp.Services.SessionService.Repository.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OasisWebApp.Services.SessionService.Repository.Interface
{
    public interface ISessionRepository :
        ICreate<Session>,
        IGet<Session, SessionFilter, int>,
        IFind<Session, SessionFilter>,
        IUpdate<Session>,
        IDelete<int>
    {
    }
}
