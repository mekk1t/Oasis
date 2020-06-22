using System;
using System.Collections.Generic;

namespace OasisWebApp.Database.Entities
{
    public class Session
    {
        public int SessionId { get; set; }
        public DateTime SessionDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; }
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }
        public ICollection<Ticket> Tickets { get; set; }

    }
}
