using Microsoft.EntityFrameworkCore;
using OasisWebApp.Database.Entities;

namespace OasisWebApp.Database
{
    public class OasisCinemaDbContext : DbContext
    {
        public OasisCinemaDbContext()
        {
            Database.EnsureCreated();
        }

        public OasisCinemaDbContext(DbContextOptions<OasisCinemaDbContext> options)
            : base(options)
        {
        }

        #region DbSet Entities

        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItem> CartItems { get; set; }


        #endregion

        protected override void
            OnModelCreating(ModelBuilder modelBuilder)    
        {                                                 
            modelBuilder.Entity<CinemaFilm>()             
                .HasKey(x => new { x.CinemaId, x.FilmId});
        }

    }
}
