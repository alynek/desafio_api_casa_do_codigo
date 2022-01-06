using DesafioCasaDoCodigo.Data;
using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Repositories.Interfaces;

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
    }
}
