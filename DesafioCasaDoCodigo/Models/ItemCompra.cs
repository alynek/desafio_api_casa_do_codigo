using System.ComponentModel.DataAnnotations;

namespace DesafioCasaDoCodigo.Models
{
    public class ItemCompra
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public Livro Livro { get; set; }
        public int Quantidade { get; set; }

        [Required]
        [Range(20, double.MaxValue)]
        public decimal Preco { get; set; }

        [Required]
        [Range(20, double.MaxValue)]
        public decimal Total { get; set; }

        public string Titulo { get; set; }

        public ItemCompra() { }
        public ItemCompra(Livro livro, int quantidade, decimal preco, decimal total, string titulo)
        {
            Livro = livro;
            Quantidade = quantidade;
            Preco = preco;
            Total = total;
            Titulo = titulo;
        }

        public override int GetHashCode()
        {
            return  this.Quantidade.GetHashCode()
                ^ this.Preco.GetHashCode()
                ^ this.Titulo.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;

            if (ReferenceEquals(this, obj)) return false;

            if (obj.GetType() != this.GetType()) return false;

            ItemCompra outroItem = obj as ItemCompra;
            return this.Titulo == outroItem.Titulo;
        }
    }
}