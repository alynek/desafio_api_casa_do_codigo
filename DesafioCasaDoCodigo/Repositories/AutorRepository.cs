using DesafioCasaDoCodigo.Data;
using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Repositories.Interfaces;
using System.Linq;

namespace DesafioCasaDoCodigo.Repositories
{
    public class AutorRepository : IAutorRepository
    {
        private DesafioContext _context;

        public AutorRepository(DesafioContext context)
        {
            _context = context;
        }

        public Autor ObterPorid(int id)
        {
            return _context.Autores.FirstOrDefault(a => a.Id == id);
        }

        public void Salva(Autor autor)
        {
            _context.Autores.Add(autor);
            _context.SaveChanges();
        }
    }
}
