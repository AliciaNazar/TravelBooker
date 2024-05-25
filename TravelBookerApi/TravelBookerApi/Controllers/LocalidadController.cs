using Microsoft.AspNetCore.Mvc;
using TravelBookerApi.Data;
using TravelBookerApi.Models;
using TravelBookerApi.Models.Dto;

namespace TravelBookerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadController : Controller
    {
        private readonly AppDbContext _context;
        private ResponseDto _response;

        public LocalidadController(AppDbContext context)
        {
            _context = context;
            _response = new ResponseDto();
        }

        [HttpGet("GetLocalidades")]
        public ResponseDto GetLocalidades()
        {
            try
            {
                IEnumerable<Localidad> localidades = _context.Localidades.ToList();
                _response.Data = localidades;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }

        [HttpGet("GetLocalidadById/{id}")]
        public ResponseDto GetLocalidadById(string id)
        {
            try
            {
                var localidad = _context.Localidades.FirstOrDefault(l => l.Id == id);
                _response.Data = localidad;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }

        [HttpGet("GetLocalidadByName/{name}")]
        public ResponseDto GetLocalidadesByName(string name)
        {
            try
            {
                var localidad = _context.Localidades.FirstOrDefault(l => l.NombreLocalidad == name);
                _response.Data = localidad;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }

        [HttpPost("PostLocalidad")]
        public ResponseDto PostUsuario([FromBody] Localidad localidad)
        {
            try
            {
                _context.Localidades.Add(localidad);
                _context.SaveChanges();
                _response.Data = localidad;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }
        [HttpPut("PutLocalidad")]
        public ResponseDto PutLocalidad([FromBody] Localidad localidad)
        {
            try
            {
                _context.Localidades.Update(localidad);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }

        [HttpDelete("DeleteLocalidad/{id}")]
        public ResponseDto DeleteLocalidad(string id)
        {
            try
            {
                var localidad = _context.Localidades.FirstOrDefault(l => l.Id == id);
                _context.Remove(localidad);
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

