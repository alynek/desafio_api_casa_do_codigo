using DesafioCasaDoCodigo.Models;

namespace DesafioCasaDoCodigo.Repositories.Interfaces
{
    public interface IPagamentoPaypalRepository
    {
        void Salva(PagamentoPaypal pagamento);
        bool IdTransacaoJaExiste(string idTransacao);
    }
}
