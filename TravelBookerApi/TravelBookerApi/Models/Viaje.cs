using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookerApi.Models
{
    public class Viaje
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string IdLocalidadOrigen { get; set; }
        [Required]
        public string IdLocalidadDestino { get; set; }

        [Required]
        public DateTime FechaYHora { get; set; }
        [Required]
        public int Precio { get; set; }
        [Required]
        public int[] ButacasReservadas { get; set; }    

        [ForeignKey("Colectivo")]
        public int IdColectivo { get; set; }

    }
}
