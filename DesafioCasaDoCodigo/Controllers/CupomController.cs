using DesafioCasaDoCodigo.Dtos;
using DesafioCasaDoCodigo.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCasaDoCodigo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CupomController : ControllerBase
    {
        [HttpPost]
        public string AplicaCupom(NovoCupomDto novoCupomDto)
        {
            Cupom cupom = novoCupomDto.novoCupom();
            return "criado";
        }
    }
}
