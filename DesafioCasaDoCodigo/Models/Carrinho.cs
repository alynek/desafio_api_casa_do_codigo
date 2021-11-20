using DesafioCasaDoCodigo.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DesafioCasaDoCodigo.Models
{
    public class Carrinho
    {
        public SortedSet<LivroCarrinhoDto> livros = new SortedSet<LivroCarrinhoDto>();
        public void Adiciona(LivroCarrinhoDto livro)
        {
            bool resultado = livros.Add(livro);

            if (!resultado)
            {
                LivroCarrinhoDto livroExistente = livros.Where(l => l.Equals(livro)).FirstOrDefault();
                livroExistente.IncrementaQuantidade();
            }

        }

        public void Cria(string cookie)
        {
            var options = new JsonSerializerOptions
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString
            };

            var listaLivrosCarrinho = JsonSerializer.Deserialize<List<LivroCarrinhoDto>>(cookie, options);
            foreach (var livro in listaLivrosCarrinho)
            {
                livros.Add(livro);
            }
        }
    }
}
