using DesafioCasaDoCodigo.Models;
using System.Collections.Generic;

namespace DesafioCasaDoCodigo.Repositories.Interfaces
{
    public interface ILivroRepository
    {
        Livro ObterPorId(int livroId);
        List<Livro> ObterTodos();
        void Salva(Livro livro);
        bool TituloExiste(Livro livro);
        bool IsbnExiste(Livro livro);
    }
}
