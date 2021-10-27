using DesafioCasaDoCodigo.Data;
using DesafioCasaDoCodigo.Models;

namespace DesafioCasaDoCodigo.Repositories
{
    public class AutorRepository : IAutorRepository
    {
        private DesafioContext _context;

        public AutorRepository(DesafioContext context)
        {
            _context = context;
        }
        public void Save(Autor autor)
        {
            _context.Autores.Add(autor);
            _context.SaveChanges();
        }
    }
}
