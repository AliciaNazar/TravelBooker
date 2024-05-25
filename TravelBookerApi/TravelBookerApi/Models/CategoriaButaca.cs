using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TravelBookerApi.Models
{
    public class CategoriaButaca
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Categoria { get; set; }
        [Required]
        public int Precio {  get; set; }

    }
}
