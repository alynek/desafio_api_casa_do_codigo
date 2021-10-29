using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Repositories.Interfaces;
using DesafioCasaDoCodigo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCasaDoCodigo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private IAutorRepository _autorRepository;

        public AutoresController(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        [Route("autor")]
        [HttpPost]
        public void NovoAutor([FromBody] NovoAutorForm form)
        {
            Autor novoAutor = form.NovoAutor();
            _autorRepository.Save(novoAutor);
        }
    }
}
