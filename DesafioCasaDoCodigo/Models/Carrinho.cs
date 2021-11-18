using DesafioCasaDoCodigo.Dtos;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

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
            var listaLivrosCarrinho = JsonConvert.DeserializeObject<List<LivroCarrinhoDto>>(cookie);
            foreach (var livro in listaLivrosCarrinho)
            {
                livros.Add(livro);
            }
        }
    }
}
