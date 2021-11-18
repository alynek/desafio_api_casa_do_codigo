using System;

namespace DesafioCasaDoCodigo.Dtos
{
    public class LivroCarrinhoDto : IComparable
    {
        public string Titulo { get; set; }
        public string LinkCapaLivro { get; set; }
        public decimal Preco { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            LivroCarrinhoDto outroLivro = obj as LivroCarrinhoDto;

            if (outroLivro != null)
                return this.Titulo.CompareTo(outroLivro.Titulo);
            else
                throw new ArgumentException("Objeto não é um LivroCarrinhoDto");
        }
    }
}
