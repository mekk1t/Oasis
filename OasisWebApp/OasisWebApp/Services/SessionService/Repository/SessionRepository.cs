using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OasisWebApp.Database;
using OasisWebApp.Database.Entities;
using OasisWebApp.Services.SessionService.Repository.Filter;
using OasisWebApp.Services.SessionService.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OasisWebApp.Services.SessionService.Repository
{
    public class SessionRepository : ISessionRepository
    {
        private readonly OasisCinemaDbContext dbContext;

        public SessionRepository(
            [FromServices] OasisCinemaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<Session> CreateAsync(Session entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Session>> FindAsync(SessionFilter filter = null)
        {
            if (filter != null)
            {
                var sessions = dbContext.Sessions
                                        .AsNoTracking()
                                        .Include(s => s.Cinema)
                                        .Include(s => s.Film)
                                        .Where(s => s.SessionDate == filter.SessionDate && 
                                                    s.Cinema.Name == filter.CinemaName &&
                                                    s.Film.Title == filter.FilmName)
                                        .AsEnumerable();
                return Task.FromResult(sessions);
            }
            else
            {
                var sessions = dbContext.Sessions
                                        .AsNoTracking()
                                        .AsEnumerable();
                return Task.FromResult(sessions);
            }
        }

        public Task<Session> GetAsync(int id, SessionFilter filter = null)
        {
            var session = dbContext.Sessions
                .Include(s => s.Tickets)
                .SingleOrDefault(s => s.SessionId == id);
            return Task.FromResult(session);
        }

        public Task<Session> UpdateAsync(Session entity)
        {
            throw new NotImplementedException();
        }
    }
}
