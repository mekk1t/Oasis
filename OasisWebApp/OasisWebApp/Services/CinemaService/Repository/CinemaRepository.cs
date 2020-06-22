using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OasisWebApp.CinemaService.Repository.Filters;
using OasisWebApp.CinemaService.Repository.Interface;
using OasisWebApp.Database;
using OasisWebApp.Database.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OasisWebApp.CinemaService.Repository
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly OasisCinemaDbContext dbContext;

        public CinemaRepository(
            [FromServices] OasisCinemaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<Cinema> CreateAsync(Cinema cinema)
        {
            EntityEntry<Cinema> result = dbContext.Cinemas.Add(cinema);
            dbContext.SaveChanges();
            return Task.FromResult(result.Entity);
        }

        public Task DeleteAsync(int ID)
        {
            var cinema = dbContext.Cinemas.Single(c => c.CinemaId == ID);
            dbContext.Remove(cinema);
            dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Cinema>> FindAsync(CinemaFilter filter = null)
        {
            IEnumerable<Cinema> cinemas = null;
            if (filter != null)
            {
                cinemas = dbContext.Cinemas
                            .AsNoTracking()
                            .Where(c =>
                                   c.Address.MetroStation == filter.MetroStation &&
                                   c.Name == filter.Name)
                            .AsEnumerable();
            }
            if (filter == null)
            {
                cinemas = dbContext.Cinemas
                            .AsNoTracking()
                            .AsEnumerable();

            }
            return Task.FromResult(cinemas);
        }

        public Task<Cinema> GetAsync(int ID, CinemaFilter filter = null)
        {
            Cinema cinema = null;
            if (filter != null)
            {
                cinema = dbContext.Cinemas
                                .Include(c => c.Address)
                                .Single(c =>
                                        c.Address.MetroStation == filter.MetroStation &&
                                        c.Name == filter.Name);
            }
            if (filter == null)
            {
                cinema = dbContext.Cinemas
                            .Include(c => c.FilmsLink)
                                .ThenInclude(c => c.Film)
                            .Include(c => c.Address)
                            .Single(c => c.CinemaId == ID);
            }
            return Task.FromResult(cinema);

        }

        public async Task<Cinema> UpdateAsync(Cinema cinema)
        {
           // TODO создает новую строку, видимо из-за доп. связей в таблицах
            var result = dbContext.Cinemas.Update(cinema); 
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
