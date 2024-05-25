using System.ComponentModel.DataAnnotations;

namespace TravelBookerApi.Models
{
    public class Colectivo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Matricula { get; set; }
        [Required]
        public int TotalButacas {  get; set; }
        [Required]
        public bool Completo { get; set; } = false;
    }
}
