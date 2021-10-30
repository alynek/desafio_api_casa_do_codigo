using DesafioCasaDoCodigo.Data;
using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Repositories.Interfaces;
using System.Linq;

namespace DesafioCasaDoCodigo.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
         
        private DesafioContext _context;

        public CategoriaRepository(DesafioContext context)
        {
            _context = context;
        }

        public bool CategoriaExiste(Categoria categoria)
        {
            return _context.Categorias.Any(c => c.Nome == categoria.Nome);
        }

        public void Salva(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }
    }
}
