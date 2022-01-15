using DesafioCasaDoCodigo.Data;
using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Repositories.Interfaces;

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
    }
}
