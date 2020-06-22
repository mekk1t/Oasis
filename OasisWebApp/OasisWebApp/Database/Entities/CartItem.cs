
namespace OasisWebApp.Database.Entities
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public Ticket Ticket { get; set; }
        public string CartId { get; set; }
    }
}
