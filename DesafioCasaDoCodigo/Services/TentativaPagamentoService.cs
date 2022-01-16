using DesafioCasaDoCodigo.Dtos;
using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Repositories.Interfaces;
using DesafioCasaDoCodigo.Services.Interfaces;
using System;

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

            var idTransacaoJaExiste = _pagamentoRepository.IdTransacaoJaExiste(novoPagamento.IdTransacao);

            if (idTransacaoJaExiste) throw new ArgumentException("O Id " + novoPagamento.IdTransacao + " já foi processado");

            if (compraExistente.FoiPagaComSucesso()) {
                throw new ArgumentException("A compra de Id " + compraExistente.Id + " já foi processada com sucesso");
            }

            _pagamentoRepository.Salva(novoPagamento);

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
    }
}
