using DesafioCasaDoCodigo.Dtos;
using System.Collections.Generic;
using System.Text;

namespace DesafioCasaDoCodigo.Models
{
    public class Carrinho
    {
        public List<LivroCarrinhoDto> livros = new List<LivroCarrinhoDto>();
        public void Adiciona(LivroCarrinhoDto livro)
        {
            livros.Add(livro);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder("Carrinho: [livros=");

            foreach (var livro in livros)
            {
                builder.Append(livro + ",");
            }

            builder.Append("]");
            return builder.ToString();
        }
    }
}
