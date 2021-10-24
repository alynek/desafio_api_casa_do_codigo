using Microsoft.AspNetCore.Mvc;

namespace DesafioCasaDoCodigo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        [Route("autor")]
        [HttpPost]
        public void NovoAutor([FromBody] NovoAutorForm form)
        {
            System.Console.WriteLine("deu certo");
        }
    }
}
