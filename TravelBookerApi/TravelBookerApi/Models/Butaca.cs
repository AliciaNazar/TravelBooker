using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBookerApi.Models
{
    public class Butaca
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CategoriaButaca")]
        public int IdCategoria { get; set; }
    }
}
