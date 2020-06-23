using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OasisWebApp.DTOs
{
    public class CartDto
    {
        public string CartId { get; set; }
        [Display(Name = "Билеты")]
        public ICollection<CartItemDto> CartItems { get; set; }
        public int Total { get; set; }
    }
}
