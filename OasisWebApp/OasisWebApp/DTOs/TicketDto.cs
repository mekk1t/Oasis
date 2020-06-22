using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OasisWebApp.DTOs
{
    public class TicketDto
    {
        public int TicketId { get; set; }
        public int Price { get; set; }
        public int Row { get; set; }
        public int Place { get; set; }
    }
}
