using System;
using System.Collections.Generic;

namespace OasisWebApp.Database.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime CompletedOn { get; set; }
        public int UserId { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
