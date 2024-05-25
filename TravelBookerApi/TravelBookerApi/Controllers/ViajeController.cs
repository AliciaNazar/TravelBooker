using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelBookerApi.Data;
using TravelBookerApi.Models;
using TravelBookerApi.Models.Dto;


namespace TravelBookerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajeController : Controller
    {
        private readonly AppDbContext _context;
        private ResponseDto _response;
        public ViajeController(AppDbContext context)
        {
            _context = context;
            _response = new ResponseDto();
        }


        [HttpGet("GetViajes")]
        public ResponseDto GetViajes()
        {
            try
            {
                IEnumerable<Viaje> viajes = _context.Viajes.ToList();
                _response.Data = viajes;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }


        [HttpGet("GetViajeById/{id}")]
        public ResponseDto GetViajeById(int id)
        {
            try
            {
                var viaje = _context.Viajes.FirstOrDefault(v => v.Id == id);
                _response.Data = viaje;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }


        [HttpGet("GetButacas/{id}/butacas")]
        public IActionResult ObtenerButacas(int id)
        {
            var viaje = _context.Viajes.FirstOrDefault(v => v.Id == id);

            if (viaje == null)
            {
                return NotFound();
            }

            var butacasReservadas = viaje.ButacasReservadas.ToArray();

            return Ok(butacasReservadas);
        }

        [HttpGet("GetViajesByLocalidades/{origen}/{destino}")]
        public ResponseDto GetViajesByLocalidades(string origen,string destino)
        {
            try {
                var localidadOrigen = _context.Localidades.FirstOrDefault(l => l.NombreLocalidad == origen);
                var localidadDestino = _context.Localidades.FirstOrDefault(l => l.NombreLocalidad == destino);

                if (localidadOrigen == null || localidadDestino == null)
                {
                    // Si alguna de las localidades no existe, retornar un mensaje de error
                    _response.Success = false;
                    _response.Mensaje = "Una o ambas localidades especificadas no existen.";
                    return _response;
                }

                // Buscar los viajes que coincidan con las localidades encontradas por nombre
                var viajes = _context.Viajes.Where(v => v.IdLocalidadOrigen == localidadOrigen.Id && v.IdLocalidadDestino == localidadDestino.Id).ToList();

                if (viajes.Count == 0)
                {
                    _response.Success = false;
                    _response.Mensaje = "No se encontraron viajes para las localidades especificadas.";
                    return _response;
                }

                _response.Data = viajes;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }

            return _response;
        }



        [HttpGet("GetViajesByLocalidadesYFecha/{origen}/{destino}/{fecha}")]
        public ResponseDto GetViajesByLocalidadesYFecha(string origen, string destino, DateTime fecha)
        {
            try
            {
                var localidadOrigen = _context.Localidades.FirstOrDefault(l => l.NombreLocalidad == origen);
                var localidadDestino = _context.Localidades.FirstOrDefault(l => l.NombreLocalidad == destino);

                if (localidadOrigen == null || localidadDestino == null)
                {
                    _response.Success = false;
                    _response.Mensaje = "Una o ambas localidades especificadas no existen.";
                    return _response;
                }

                // Buscar los viajes que coincidan con las localidades encontradas por nombre y fecha
                var viajes = _context.Viajes.Where(v => v.IdLocalidadOrigen == localidadOrigen.Id &&
                                                        v.IdLocalidadDestino == localidadDestino.Id &&
                                                        v.FechaYHora.Date == fecha.Date).ToList();

                if (viajes.Count == 0)
                {
                    _response.Success = false;
                    _response.Mensaje = "No se encontraron viajes para las localidades y fecha especificadas.";
                    return _response;
                }

                _response.Data = viajes;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }

            return _response;
        }




        [HttpPost("PostViaje")]
        public ResponseDto PostViaje([FromBody] Viaje viaje)
        {
            try
            {
                _context.Viajes.Add(viaje);
                _context.SaveChanges();
                _response.Data = viaje;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }

        [HttpPost("{idViaje}/AgregarButaca")]
        public ActionResult<ResponseDto> AgregarButacaReservada(int idViaje, int numeroButaca)
        {
            try
            {
                var viaje = _context.Viajes.FirstOrDefault(v => v.Id == idViaje);
                var butacas = viaje.ButacasReservadas != null ? viaje.ButacasReservadas.ToList() : new List<int>();
                butacas.Add(numeroButaca);
                viaje.ButacasReservadas = butacas.ToArray();
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.Success=false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }

        [HttpPut("PutViaje")]
        public ResponseDto PutViaje([FromBody] Viaje viaje)
        {
            try
            {
                _context.Viajes.Update(viaje);
                _context.SaveChanges();
                Console.WriteLine("del lado de c#: ",viaje.ToString());
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }
        [HttpPut("viajes/{id}/{fecha}/butacas")]
        public IActionResult ActualizarButacas(int id, [FromBody] int[] butacasReservadas, string fecha)
        {

            DateTime fechaConvertida;
            if (!DateTime.TryParse(fecha, out fechaConvertida))
            {
                return BadRequest("Formato de fecha inválido");
            }

            // Obtener el viaje de la base de datos
            var viaje = _context.Viajes.FirstOrDefault(v => v.Id == id);
            if (viaje == null)
            {
                return NotFound();
            }

            // Actualizar las butacas reservadas y la fecha del viaje
            viaje.ButacasReservadas = butacasReservadas;
            viaje.FechaYHora = fechaConvertida;

            // Guardar los cambios en la base de datos
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Manejar cualquier error de actualización de la base de datos
                return StatusCode(500, "Error al actualizar la base de datos: " + ex.Message);
            }

            return Ok();
        }

        [HttpPut("viajes/{id}/butacas")]
        public IActionResult ActualizarButacasDelViaje(int id, [FromBody] int[] butacasReservadas)
        {
            var viaje = _context.Viajes.FirstOrDefault(v => v.Id == id);
            if (viaje == null)
            {
                
                return NotFound();
            }
            viaje.ButacasReservadas = butacasReservadas;

            _context.SaveChanges();

            return Ok(); 
        }


        [HttpDelete("DeleteViaje/{id}")]
        public ResponseDto DeleteViaje(int id)
        {
            try
            {
                var viaje = _context.Viajes.FirstOrDefault(v => v.Id == id);
                _context.Remove(viaje);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }
    }
}
