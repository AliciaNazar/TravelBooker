using Microsoft.AspNetCore.Mvc;
using TravelBookerApi.Data;
using TravelBookerApi.Models.Dto;
using TravelBookerApi.Models;

namespace TravelBookerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaButacaController : Controller
    {
        private readonly AppDbContext _context;
        private ResponseDto _response;

        public CategoriaButacaController(AppDbContext context)
        {
            _context = context;
            _response = new ResponseDto();
        }

        [HttpGet("GetCategoriasButacas")]
        public ResponseDto GetCategoriasButacas()
        {
            try
            {
                IEnumerable<CategoriaButaca> categoriasButacas = _context.CategoriasButacas.ToList();
                _response.Data = categoriasButacas;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }

        [HttpGet("GetCategoriaButacaById/{id}")]
        public ResponseDto GetCategoriaButacaById(int id)
        {
            try
            {
                var categoriaButaca = _context.CategoriasButacas.FirstOrDefault(cb => cb.Id == id);
                _response.Data = categoriaButaca;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }


        [HttpPost("PostCategoriaButaca")]
        public ResponseDto PostCategoriaButaca([FromBody] CategoriaButaca categoriaButaca)
        {
            try
            {
                _context.CategoriasButacas.Add(categoriaButaca);
                _context.SaveChanges();
                _response.Data = categoriaButaca;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }
        [HttpPut("PutCategoriaButaca")]
        public ResponseDto PutCategoriaButaca([FromBody] CategoriaButaca categoriaButaca)
        {
            try
            {
                _context.CategoriasButacas.Update(categoriaButaca);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Mensaje = ex.Message;
            }
            return _response;
        }

        [HttpDelete("DeleteCategoriaButaca/{id}")]
        public ResponseDto DeleteCategoriaButaca(int id)
        {
            try
            {
                var categoriaButaca = _context.CategoriasButacas.FirstOrDefault(cb => cb.Id == id);
                _context.Remove(categoriaButaca);
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
