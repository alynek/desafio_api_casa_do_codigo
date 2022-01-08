using DesafioCasaDoCodigo.Data;
using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Repositories.Interfaces;

namespace DesafioCasaDoCodigo.Repositories
{
    public class CupomRepository : ICupomRepository
    {
        private readonly DesafioContext _context;

        public CupomRepository(DesafioContext context)
        {
            _context = context;
        }

        public void Salva(Cupom cupom)
        {
            _context.Cupons.Add(cupom);
            _context.SaveChanges();
        }
    }
}
