using DesafioCasaDoCodigo.Data;
using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Repositories.Interfaces;
using System.Linq;

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

        public Cupom ObterPorCodigo(string codigoCupom)
        {
            return _context.Cupons.FirstOrDefault(c => c.Codigo == codigoCupom);
        }
    }
}
