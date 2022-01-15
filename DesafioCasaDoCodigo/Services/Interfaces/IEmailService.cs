using DesafioCasaDoCodigo.Models;

namespace DesafioCasaDoCodigo.Services.Interfaces
{
    public interface IEmailService
    {
        void NotificarCompraParaAdminCdc(PagamentoPaypal novoPagamento);

        void NotificarCompradorComNovaCompra(PagamentoPaypal novoPagamento);

        void NotificarCompraParaAdminCdcPagamentoFalhou(PagamentoPaypal novoPagamento);
    }
}
