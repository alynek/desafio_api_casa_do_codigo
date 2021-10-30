using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Repositories.Interfaces;
using DesafioCasaDoCodigo.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCasaDoCodigo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private ICategoriaRepository _categoriaRepository;

        public CategoriasController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpPost]
        public IActionResult AdicionaCategoria([FromBody] NovaCategoriaDto novaCategoria)
        {
            Categoria categoria = new Categoria(novaCategoria.Nome);

            if (_categoriaRepository.CategoriaExiste(categoria)) return BadRequest("Já existe uma categoria com esse nome");

            _categoriaRepository.Salva(categoria);
            return CreatedAtAction(nameof(AdicionaCategoria), categoria);
        }
    }
}
