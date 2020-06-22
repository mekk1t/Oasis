using System;
using System.Collections.Generic;

namespace OasisWebApp.Database.Entities
{
    public class Cinema
    {
        public int CinemaId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public ICollection<Session> Sessions { get; set; }
        public ICollection<CinemaFilm> FilmsLink { get; set; }
    }
}
