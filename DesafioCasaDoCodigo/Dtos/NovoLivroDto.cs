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
        public double Preco { get; set; }

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
    }
}
