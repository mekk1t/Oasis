namespace OasisWebApp.Database.Entities
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int Price { get; set; }
        public int Row { get; set; }
        public int Place { get; set; }
        public int SessionId { get; set; }
        public int? OrderId { get; set; }
    }
}
