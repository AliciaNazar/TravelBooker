using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookerEntities
{
    public class Reserva
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdButaca { get; set; }
        public string IdLocalidad { get; set; }
        public DateTime Fecha { get; set; }
        public double Importe { get; set; }

    }
}
