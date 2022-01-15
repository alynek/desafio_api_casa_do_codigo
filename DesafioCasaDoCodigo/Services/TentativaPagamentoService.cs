using DesafioCasaDoCodigo.Dtos;
using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Repositories.Interfaces;
using DesafioCasaDoCodigo.Services.Interfaces;

namespace DesafioCasaDoCodigo.Services
{
    public class TentativaPagamentoService : ITentativaPagamentoService
    {
        private readonly IPagamentoPaypalRepository _pagamentoRepository;
        private readonly IEmailService _email;

        public TentativaPagamentoService(IPagamentoPaypalRepository pagamentoRepository, IEmailService email)
        {
            _pagamentoRepository = pagamentoRepository;
            _email = email;
        }

        public void Executar(Compra compraExistente, NovoPagamentoPaypalDto novaCompraPaypalDto)
        {
            PagamentoPaypal novoPagamento = novaCompraPaypalDto.NovoPagamento(compraExistente);

            ValidaIdTransacaoESalva(novoPagamento);

            if (novoPagamento.Sucesso())
            {
                _email.NotificarCompraParaAdminCdc(novoPagamento);
                _email.NotificarCompradorComNovaCompra(novoPagamento);
            }
            else
            {
                _email.NotificaAdminCdcPagamentoFalhou(novoPagamento);
            }
        }

        public void ValidaIdTransacaoESalva(PagamentoPaypal novoPagamento)
        {
            var idTransacaoJaExiste = _pagamentoRepository.IdTransacaoJaExiste(novoPagamento.IdTransacao);

            if (idTransacaoJaExiste)
            {
                novoPagamento.Status = Enums.EPaypalStatus.falha;
            }
            else
            {
                _pagamentoRepository.Salva(novoPagamento);
            }
        }
    }
}
