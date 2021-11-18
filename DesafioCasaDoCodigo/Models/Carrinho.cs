using DesafioCasaDoCodigo.Dtos;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DesafioCasaDoCodigo.Models
{
    public class Carrinho
    {
        public SortedSet<LivroCarrinhoDto> livros = new SortedSet<LivroCarrinhoDto>();
        public void Adiciona(LivroCarrinhoDto livro)
        {
            livros.Add(livro);
        }

        public void Cria(string cookie)
        {
            var listaLivrosCarrinho = JsonConvert.DeserializeObject<List<LivroCarrinhoDto>>(cookie);
            foreach (var livro in listaLivrosCarrinho)
            {
                livros.Add(livro);
            }
        }
    }
}
