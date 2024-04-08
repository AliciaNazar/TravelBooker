using Microsoft.AspNetCore.Mvc;
using TravelBookerApi.Data;
using TravelBookerApi.Models;
using TravelBookerApi.Models.Dto;

namespace TravelBookerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly AppDbContext _context;
        private ResponseDto _response;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
            _response = new ResponseDto();
        }

        [HttpGet("GetUsuarios")]
        public ResponseDto GetUsuarios()
        {
            try
            {
                IEnumerable<Usuario> usuarios = _context.Usuarios.ToList();
                _response.Data = usuarios;
            }
            catch(Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }

        [HttpGet("GetUsuarioById/{id}")]
        public ResponseDto GetUsuarioById(int id)
        {
            try
            {
                var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);
                _response.Data = usuario;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje =ex.Message;
            }
            return _response;
        }

        [HttpGet("GetUsuarioByDni/{dni}")]
        public ResponseDto GetUsuarioByDni(string dni)
        {
            try
            {
                var usuario = _context.Usuarios.FirstOrDefault(u => u.Dni == dni);
                _response.Data = usuario;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }

        [HttpPost("PostUsuario")]
        public ResponseDto PostUsuario([FromBody] Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                _response.Data = usuario;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }
        [HttpPut("PutUsuario")]
        public ResponseDto PutUsuario([FromBody] Usuario usuario)
        {
            try
            {
                _context.Usuarios.Update(usuario);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }

        [HttpDelete("DeleteUsuario/{id}")]
        public ResponseDto DeleteUsuario(int id)
        {
            try
            {
                var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);
                _context.Remove(usuario);
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
