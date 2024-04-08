using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookerApi.Models
{
    public class Butaca
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TipoButaca { get; set; }
        [ForeignKey("Colectivo")]
        public int IdColectivo { get; set; }
    }
}
