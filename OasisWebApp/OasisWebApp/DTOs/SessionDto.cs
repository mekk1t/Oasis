using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OasisWebApp.DTOs
{
    public class SessionDto
    {
        public int SessionId { get; set; }
        [Display(Name = "Дата")]
        public DateTime SessionDate { get; set; }
        [Display(Name = "Начало сеанса")]
        public TimeSpan StartTime { get; set; }
        public FilmDto Film { get; set; }
        public CinemaDto Cinema { get; set; }       
        public ICollection<TicketDto> Tickets { get; set; }
    }
}
