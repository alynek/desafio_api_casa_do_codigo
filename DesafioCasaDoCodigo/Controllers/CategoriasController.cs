using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Repositories.Interfaces;
using DesafioCasaDoCodigo.ViewModels;
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

        [Route("categorias")]
        [HttpPost]
        public IActionResult CriaCategoria([FromBody] NovaCategoriaForm form)
        {
            Categoria novaCategoria = new Categoria(form.Nome);

            if (_categoriaRepository.CategoriaExiste(novaCategoria)) return BadRequest("Já existe uma categoria com esse nome");
            _categoriaRepository.Save(novaCategoria);
            return CreatedAtAction(nameof(CriaCategoria), novaCategoria);
        }
    }
}
