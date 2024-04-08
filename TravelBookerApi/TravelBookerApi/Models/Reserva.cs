using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookerApi.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        [ForeignKey("Butaca")]
        public int IdButaca { get; set; }
        [ForeignKey("Localidad")]
        public string IdLocalidad { get; set; }
        [Required]
        public DateTime FechaYHora { get; set; }
        [Required]
        public double Importe { get; set; }

    }
}
