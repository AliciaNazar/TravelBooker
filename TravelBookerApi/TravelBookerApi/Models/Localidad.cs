using System.ComponentModel.DataAnnotations;

namespace TravelBookerApi.Models
{
    public class Localidad
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string NombreLocalidad { get; set; }

    }
}
