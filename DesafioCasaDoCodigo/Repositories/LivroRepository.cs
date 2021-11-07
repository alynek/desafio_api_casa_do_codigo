using DesafioCasaDoCodigo.Data;
using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DesafioCasaDoCodigo.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private DesafioContext _context;

        public LivroRepository(DesafioContext context)
        {
            _context = context;
        }

        public List<Livro> ObterTodos()
        {
            return _context.Livros.Include(a => a.Autor).ToList();
        }

        public void Salva(Livro livro)
        {
            _context.Livros.Add(livro);
            _context.SaveChanges();
        }

        public bool TituloExiste(Livro livro)
        {
           return _context.Livros.Any(l => l.Titulo == livro.Titulo);
        }
        
        public bool IsbnExiste(Livro livro)
        {
           return _context.Livros.Any(l => l.Isbn == livro.Isbn);
        }
    }
}
