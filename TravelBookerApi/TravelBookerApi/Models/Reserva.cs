using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookerApi.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        public string ApellidoUsuario { get; set; }
        [Required]
        public string DniUsuario { get; set;}
        [Required]
        public bool MayorDeEdad {  get; set; }

        [ForeignKey("Butaca")]
        public int IdButaca { get; set; }
        [ForeignKey("Viaje")]
        public int IdViaje { get; set; }
        [Required]
        public int PrecioTotal { get; set; }

    }
}
