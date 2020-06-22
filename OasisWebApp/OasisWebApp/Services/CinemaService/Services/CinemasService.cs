using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OasisWebApp.CinemaService.Repository.Interface;
using OasisWebApp.DTOs;
using OasisWebApp.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OasisWebApp.CinemaService.Services.Interface;
using OasisWebApp.CinemaService.Repository.Filters;

namespace OasisWebApp.CinemaService.Services
{
    public class CinemasService : ICinemaService
    {
        private readonly ICinemaRepository cinemaRepository;
        private readonly IMapper mapper;

        public CinemasService(
            [FromServices] ICinemaRepository cinemaRepository,
            [FromServices] IMapper mapper)
        {
            this.cinemaRepository = cinemaRepository;
            this.mapper = mapper;
        }

        public async Task<CinemaDto> CreateAsync(CinemaDto cinema)
        {
            var result = await cinemaRepository.CreateAsync(mapper.Map<Cinema>(cinema));
            var resultDto = mapper.Map<CinemaDto>(result);
            return resultDto;
        }

        public async Task DeleteAsync(int CinemaId)
        {
            await cinemaRepository.DeleteAsync(CinemaId);
        }

        public async Task<IEnumerable<CinemaDto>> FindAsync(CinemaFilter filter = null)
        {
            var cinemas = await cinemaRepository.FindAsync();

            var result = mapper.Map<IEnumerable<CinemaDto>>(cinemas);
            return result;
        }

        public async Task<CinemaDto> GetAsync(int id, CinemaFilter filter = null)
        {
            var cinema = await cinemaRepository.GetAsync(id);
            var result = mapper.Map<CinemaDto>(cinema);
            return result;
        }

        public async Task<CinemaDto> UpdateAsync(CinemaDto cinema)
        {
            var source = await cinemaRepository.GetAsync(cinema.CinemaId);
            if (source == null)
            {
                throw new NullReferenceException();
            }
            var target = mapper.Map<Cinema>(cinema);
            var result = await cinemaRepository.UpdateAsync(target);
            var resultDto = mapper.Map<CinemaDto>(result);
            return resultDto;

        }
    }
}
