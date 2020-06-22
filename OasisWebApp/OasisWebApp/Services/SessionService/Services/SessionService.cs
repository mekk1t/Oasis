using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OasisWebApp.DTOs;
using OasisWebApp.Services.SessionService.Repository.Filter;
using OasisWebApp.Services.SessionService.Repository.Interface;
using OasisWebApp.Services.SessionService.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OasisWebApp.Services.SessionService.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository sessionRepository;
        private readonly IMapper mapper;
        public SessionService(
            [FromServices] ISessionRepository sessionRepository,
            [FromServices] IMapper mapper)
        {
            this.sessionRepository = sessionRepository;
            this.mapper = mapper;
        }
        public Task<SessionDto> CreateAsync(SessionDto entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SessionDto>> FindAsync(SessionFilter filter = null)
        {
            var sessions = await sessionRepository.FindAsync(filter);
            var sessionsDto = mapper.Map<IEnumerable<SessionDto>>(sessions);
            return sessionsDto;
        }

        public async Task<SessionDto> GetAsync(int id, SessionFilter filter = null)
        {
            var session = await sessionRepository.GetAsync(id);
            var sessionDto = mapper.Map<SessionDto>(session);
            return sessionDto;
        }

        public Task<SessionDto> UpdateAsync(SessionDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
