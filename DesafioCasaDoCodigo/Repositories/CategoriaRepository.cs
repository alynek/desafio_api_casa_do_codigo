using DesafioCasaDoCodigo.Data;
using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Repositories.Interfaces;

namespace DesafioCasaDoCodigo.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {

        private DesafioContext _context;

        public CategoriaRepository(DesafioContext context)
        {
            _context = context;
        }
        public void Save(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }
    }
}
