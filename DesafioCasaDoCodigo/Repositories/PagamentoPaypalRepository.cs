using DesafioCasaDoCodigo.Data;
using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Repositories.Interfaces;
using System.Linq;

namespace DesafioCasaDoCodigo.Repositories
{
    public class PagamentoPaypalRepository : IPagamentoPaypalRepository
    {
        private readonly DesafioContext _context;

        public PagamentoPaypalRepository(DesafioContext context)
        {
            _context = context;
        }
        public void Salva(PagamentoPaypal pagamento)
        {
            _context.PagamentosPaypal.Add(pagamento);
            _context.SaveChanges();
        }

        public bool IdTransacaoJaExiste(string idTransacao)
        {
            return _context.PagamentosPaypal.Any(t => t.IdTransacao.Equals(idTransacao));
        }
    }
}
