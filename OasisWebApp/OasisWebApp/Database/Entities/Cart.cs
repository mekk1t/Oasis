using System.Collections.Generic;

namespace OasisWebApp.Database.Entities
{
    public class Cart
    {
        public string CartId { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
