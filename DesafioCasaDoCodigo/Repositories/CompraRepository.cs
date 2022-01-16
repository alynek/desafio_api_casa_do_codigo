using DesafioCasaDoCodigo.Data;
using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DesafioCasaDoCodigo.Repositories
{
    public class CompraRepository : ICompraRepository
    {
        private DesafioContext _context;

        public CompraRepository(DesafioContext context)
        {
            _context = context;
        }

        public void Salva(Compra compra)
        {
            _context.Compras.Add(compra);
            _context.SaveChanges();
        }

        public async Task<Compra> Obter(int compraId)
        {
            return await _context.Compras
                .Include(c => c.PagamentoPaypal)
                .FirstOrDefaultAsync(c => c.Id == compraId);
        }
    }
}
