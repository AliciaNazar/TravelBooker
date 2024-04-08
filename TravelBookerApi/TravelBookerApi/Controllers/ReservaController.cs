using Microsoft.AspNetCore.Mvc;
using TravelBookerApi.Data;
using TravelBookerApi.Models;
using TravelBookerApi.Models.Dto;

namespace TravelBookerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : Controller
    {
        private readonly AppDbContext _context;
        private ResponseDto _response;

        public ReservaController(AppDbContext context)
        {
            _context = context;
            _response = new ResponseDto();
        }

        [HttpGet("GetReservas")]
        public ResponseDto GetReservas()
        {
            try
            {
                IEnumerable<Reserva> reservas = _context.Reservas.ToList();
                _response.Data = reservas;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }

        [HttpGet("GetReservaById/{id}")]
        public ResponseDto GetReservaById(int id)
        {
            try
            {
                var reserva = _context.Colectivos.FirstOrDefault(r => r.Id == id);
                _response.Data = reserva;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }


        [HttpPost("PostReserva")]
        public ResponseDto PostReserva([FromBody] Reserva reserva)
        {
            try
            {
                _context.Reservas.Add(reserva);
                _context.SaveChanges();
                _response.Data = reserva;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }
        [HttpPut("PutReserva")]
        public ResponseDto PutReserva([FromBody] Reserva reserva)
        {
            try
            {
                _context.Reservas.Update(reserva);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }

        [HttpDelete("DeleteReserva/{id}")]
        public ResponseDto DeleteReserva(int id)
        {
            try
            {
                var reserva = _context.Reservas.FirstOrDefault(r => r.Id == id);
                _context.Remove(reserva);
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
