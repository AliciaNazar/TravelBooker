using Microsoft.AspNetCore.Mvc;
using TravelBookerApi.Data;
using TravelBookerApi.Models;
using TravelBookerApi.Models.Dto;

namespace TravelBookerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ButacaController : Controller
    {
        private readonly AppDbContext _context;
        private ResponseDto _response;

        public ButacaController(AppDbContext context)
        {
            _context = context;
            _response = new ResponseDto();
        }

        [HttpGet("GetButacas")]
        public ResponseDto GetButacas()
        {
            try
            {
                IEnumerable<Butaca> butacas = _context.Butacas.ToList();
                _response.Data = butacas;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }

        [HttpGet("GetButacasById/{id}")]
        public ResponseDto GetButacasById(int id)
        {
            try
            {
                var butaca = _context.Butacas.FirstOrDefault(b => b.Id == id);
                _response.Data = butaca;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }


        [HttpPost("PostButaca")]
        public ResponseDto PostButaca([FromBody] Butaca butaca)
        {
            try
            {
                _context.Butacas.Add(butaca);
                _context.SaveChanges();
                _response.Data = butaca;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }
        [HttpPut("PutButaca")]
        public ResponseDto PutButaca([FromBody] Butaca  butaca)
        {
            try
            {
                _context.Butacas.Update(butaca);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }

        [HttpDelete("DeleteButaca/{id}")]
        public ResponseDto DeleteButaca(int id)
        {
            try
            {
                var butaca = _context.Butacas.FirstOrDefault(b => b.Id == id);
                _context.Remove(butaca);
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
