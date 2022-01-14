using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DesafioCasaDoCodigo.Models
{
    public class Livro
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int AutorId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Subtitulo { get; set; }

        [Range(20, double.MaxValue)]
        public decimal Preco { get; set; }

        [Required]
        public string Conteudo { get; set; }

        [Required]
        public string Sumario { get; set; }

        [Range(100, int.MaxValue)]
        public int NumeroPaginas { get; set; }

        [Required]
        public string Isbn { get; set; }

        [Required]
        [Url]
        public string LinkCapaLivro { get; set; }

        [Required]
        public Autor Autor { get; set; }
        public ICollection<ItemCompra> Itens { get; set; }

        public Livro() { }

        public Livro(string titulo, string subtitulo, decimal preco, string conteudo,
            string sumario, int numeroPaginas, string isbn, string linkCapaLivro, Autor autor)
        {
            Titulo = titulo;
            Subtitulo = subtitulo;
            Preco = preco;
            Conteudo = conteudo;
            Sumario = sumario;
            NumeroPaginas = numeroPaginas;
            Isbn = isbn;
            LinkCapaLivro = linkCapaLivro;
            Autor = autor;
        }
    }
}
