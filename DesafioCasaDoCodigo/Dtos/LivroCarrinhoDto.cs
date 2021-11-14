using DesafioCasaDoCodigo.Models;

namespace DesafioCasaDoCodigo.Dtos
{
    public class LivroCarrinhoDto
    {
        public string Titulo { get; set; }
        public string LinkCapaLivro { get; set; }
        public decimal Preco { get; set; }

        public override string ToString()
        {
            return $"[titulo= {Titulo}, preço= {Preco}, capa do livro= {LinkCapaLivro}]";
        }
    }
}
