using DesafioCasaDoCodigo.Dtos;
using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Repositories.Interfaces;
using DesafioCasaDoCodigo.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DesafioCasaDoCodigo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalizaCompraController : ControllerBase
    {
        private readonly ICompraRepository _compraRepository;
        private readonly ITentativaPagamentoService _tentativaPagamentoService;

        public FinalizaCompraController(ICompraRepository compraRepository,
            ITentativaPagamentoService tentativaPagamentoService)
        {
            _compraRepository = compraRepository;
            _tentativaPagamentoService = tentativaPagamentoService;
        }

        [HttpPost("pagamento/{compraId:int}")]
        public async Task<IActionResult> Pagamento(int compraId, [FromForm] NovoPagamentoPaypalDto novaCompraPaypalDto)
        {
            try
            {

                Compra compraExistente = await _compraRepository.Obter(compraId);
                _tentativaPagamentoService.Executar(compraExistente, novaCompraPaypalDto);
                return Ok(compraExistente);
            }
            catch(ArgumentException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
