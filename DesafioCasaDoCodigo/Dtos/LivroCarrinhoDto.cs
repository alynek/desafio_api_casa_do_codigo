using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioCasaDoCodigo.Dtos
{
    public class LivroCarrinhoDto : IComparable
    {
        public string Titulo { get; set; }
        public string LinkCapaLivro { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; } = 1;

        [Range(20, double.MaxValue)]
        public decimal Total{ get{return Preco * Quantidade;}}

        public int CompareTo(object obj)
        {
            if (obj is null) return 1;

            LivroCarrinhoDto outroLivro = obj as LivroCarrinhoDto;

            if (outroLivro != null)
                return this.Titulo.CompareTo(outroLivro.Titulo);
            else
                throw new ArgumentException("Objeto não é um LivroCarrinhoDto");
        }

        public void IncrementaQuantidade()
        {
            this.Quantidade++;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;

            if (ReferenceEquals(this, obj)) return false;

            if (obj.GetType() != this.GetType()) return false;

            LivroCarrinhoDto outroLivro = obj as LivroCarrinhoDto;

            return this.Titulo == outroLivro.Titulo 
                    && this.LinkCapaLivro == outroLivro.LinkCapaLivro 
                    && this.Preco == outroLivro.Preco;
        }

        public override int GetHashCode()
        {
            return this.Titulo.GetHashCode()
                ^ this.LinkCapaLivro.GetHashCode()
                ^ this.Preco.GetHashCode();
        }
    }
}
