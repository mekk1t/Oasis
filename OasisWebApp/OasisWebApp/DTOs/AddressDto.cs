using System.ComponentModel.DataAnnotations;

namespace OasisWebApp.DTOs
{
    public class AddressDto
    {
        [Display(Name = "Местонахождение")]
        public string Address { get; set; }
        [Display(Name ="Станция метро")]
        public string MetroStation { get; set; }
        [Display (Name = "Район")]
        public string District { get; set; }
    }
}
