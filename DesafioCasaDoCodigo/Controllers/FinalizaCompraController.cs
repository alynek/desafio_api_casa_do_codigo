using DesafioCasaDoCodigo.Dtos;
using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Repositories.Interfaces;
using DesafioCasaDoCodigo.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public void Pagamento(int compraId, [FromForm] NovoPagamentoPaypalDto novaCompraPaypalDto)
        {
            Compra compraExistente = _compraRepository.Obter(compraId);
            _tentativaPagamentoService.Executar(compraExistente, novaCompraPaypalDto);
        }
    }
}
