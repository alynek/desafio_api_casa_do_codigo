using DesafioCasaDoCodigo.Data;
using DesafioCasaDoCodigo.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCasaDoCodigo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private DesafioContext _context;

        public AutoresController(DesafioContext context)
        {
            _context = context;
        }

        [Route("autor")]
        [HttpPost]
        public void NovoAutor([FromBody] NovoAutorForm form)
        {
            Autor novoAutor = form.NovoAutor();
            System.Console.WriteLine(novoAutor);
            _context.Autores.Add(novoAutor);
            _context.SaveChanges();
        }
    }
}
