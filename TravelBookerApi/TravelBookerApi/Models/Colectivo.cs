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
        public int CantButacasSimples { get; set; }
        [Required]
        public int CantButacasPremium { get; set; }
    }
}
