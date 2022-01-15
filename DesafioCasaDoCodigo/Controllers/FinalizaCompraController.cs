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
        private readonly IPagamentoPaypalRepository _pagamentoRepository;
        private readonly IEmailService _email;

        public FinalizaCompraController(ICompraRepository compraRepository,
            IPagamentoPaypalRepository pagamentoRepository, IEmailService email)
        {
            _compraRepository = compraRepository;
            _pagamentoRepository = pagamentoRepository;
            _email = email;
        }

        [HttpPost("pagamento/{compraId:int}")]
        public void Pagamento(int compraId, [FromForm] NovoPagamentoPaypalDto novaCompraPaypalDto)
        {
            Compra compraExistente = _compraRepository.Obter(compraId);
            PagamentoPaypal novoPagamento = novaCompraPaypalDto.NovoPagamento(compraExistente);
            _pagamentoRepository.Salva(novoPagamento);

            if (novoPagamento.Sucesso())
            {
                _email.NotificarCompraParaAdminCdc(novoPagamento);
                _email.NotificarCompradorComNovaCompra(novoPagamento);
            }
            else
            {
                _email.NotificarCompraParaAdminCdcPagamentoFalhou(novoPagamento);
            }
        }
    }
}
