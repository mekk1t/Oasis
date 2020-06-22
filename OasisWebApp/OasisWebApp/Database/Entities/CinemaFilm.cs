namespace OasisWebApp.Database.Entities
{
    public class CinemaFilm
    {
        public int CinemaId { get; set; }
        public int FilmId { get; set; }
        public Cinema Cinema { get; set; }
        public Film Film { get; set; }
    }
}
