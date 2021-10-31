using DesafioCasaDoCodigo.Models;

namespace DesafioCasaDoCodigo.Repositories.Interfaces
{
    public interface ILivroRepository
    {
        void Salva(Livro livro);
        bool TituloExiste(Livro livro);
        bool IsbnExiste(Livro livro);
    }
}
