using System;
using System.Collections.Generic;

namespace OasisWebApp.Database.Entities
{
    public class Film
    {
        public int FilmId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public int RunningTime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<CinemaFilm> CinemasLink { get; set; }
        public ICollection<Session> Sessions { get; set; }
    }
}
