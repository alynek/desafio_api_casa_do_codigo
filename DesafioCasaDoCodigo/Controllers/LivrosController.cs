using DesafioCasaDoCodigo.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCasaDoCodigo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        [HttpPost]
        public void AdicionaLivro([FromForm] NovoLivroDto novoLivro)
        {
            System.Console.WriteLine("chegou aq");
        }
    }
}
