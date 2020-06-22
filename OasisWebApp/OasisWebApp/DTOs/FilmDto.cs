using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OasisWebApp.DTOs
{
    public class FilmDto
    {
        public int FilmId { get; set; }
        [Display(Name = "Название")]
        public string Title { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Режиссер")]
        public string Director { get; set; }
        [Display(Name = "Жанр")]
        public string Genre { get; set; }
        [Display(Name = "Продолжительность")]
        public string RunningTime_Hours { get; set; }
        [Display(Name = "Дата выхода")]
        public string ReleaseDate { get; set; }
        public ICollection<SessionDto> Sessions { get; set; }

    }
}
