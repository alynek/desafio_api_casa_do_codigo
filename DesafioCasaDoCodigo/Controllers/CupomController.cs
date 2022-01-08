using DesafioCasaDoCodigo.Dtos;
using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCasaDoCodigo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CupomController : ControllerBase
    {
        private readonly ICupomRepository _cupomRepository;

        public CupomController(ICupomRepository cupomRepository)
        {
            _cupomRepository = cupomRepository;
        }

        [HttpPost]
        public string AplicaCupom(NovoCupomDto novoCupomDto)
        {
            Cupom cupom = novoCupomDto.novoCupom();
            _cupomRepository.Salva(cupom);
            return "criado";
        }
    }
}
