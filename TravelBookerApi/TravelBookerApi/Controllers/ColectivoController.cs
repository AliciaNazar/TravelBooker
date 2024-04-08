using Microsoft.AspNetCore.Mvc;
using TravelBookerApi.Data;
using TravelBookerApi.Models;
using TravelBookerApi.Models.Dto;

namespace TravelBookerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColectivoController : Controller
    {
        private readonly AppDbContext _context;
        private ResponseDto _response;

        public ColectivoController(AppDbContext context)
        {
            _context = context;
            _response = new ResponseDto();
        }

        [HttpGet("GetColectivos")]
        public ResponseDto GetColectivos()
        {
            try
            {
                IEnumerable<Colectivo> colectivos = _context.Colectivos.ToList();
                _response.Data = colectivos;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }

        [HttpGet("GetColectivoById/{id}")]
        public ResponseDto GetColectivoById(int id)
        {
            try
            {
                var colectivo = _context.Colectivos.FirstOrDefault(c => c.Id == id);
                _response.Data = colectivo;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }

        [HttpGet("GetColectivoByMatricula/{matricula}")]
        public ResponseDto GetColectivoByMatricula(string matricula)
        {
            try
            {
                var colectivo = _context.Colectivos.FirstOrDefault(c => c.Matricula == matricula);
                _response.Data = colectivo;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }

        [HttpPost("PostColectivo")]
        public ResponseDto PostColectivo([FromBody] Colectivo colectivo)
        {
            try
            {
                _context.Colectivos.Add(colectivo);
                _context.SaveChanges();
                _response.Data = colectivo;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }
        [HttpPut("PutColectivo")]
        public ResponseDto PutColectivo([FromBody] Colectivo colectivo)
        {
            try
            {
                _context.Colectivos.Update(colectivo);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }

        [HttpDelete("DeleteColectivo/{id}")]
        public ResponseDto DeleteColectivo(int id)
        {
            try
            {
                var colectivo = _context.Colectivos.FirstOrDefault(c => c.Id == id);
                _context.Remove(colectivo);
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

