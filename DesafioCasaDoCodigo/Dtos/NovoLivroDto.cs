using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Repositories.Interfaces;
using DesafioCasaDoCodigo.Utility.Interfaces;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DesafioCasaDoCodigo.Dtos
{
    public class NovoLivroDto
    {
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
        [DataType(DataType.Upload)]
        public IFormFile Capa { get; set; }

        [Required]
        public int AutorId { get; set; }

        public Livro NovoLivro(IAutorRepository autorRepository, IUploader uploader)
        {
            Autor autor = autorRepository.ObterPorid(AutorId);
            string linkCapaLivro = uploader.Upload(Capa);

            return new Livro(Titulo, Subtitulo, Preco, Conteudo, Sumario, NumeroPaginas, Isbn, linkCapaLivro, autor);
        }
    }
}
