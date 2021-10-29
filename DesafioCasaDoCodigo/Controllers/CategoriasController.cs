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
        public void CriaCategoria([FromBody] NovaCategoriaForm form)
        {
            Categoria novaCategoria = new Categoria(form.Nome);
            _categoriaRepository.Save(novaCategoria);
        }
    }
}
