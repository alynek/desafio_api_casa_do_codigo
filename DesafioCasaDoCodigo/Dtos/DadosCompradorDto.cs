using DesafioCasaDoCodigo.Utility;
using System.ComponentModel.DataAnnotations;

namespace DesafioCasaDoCodigo.Dtos
{
    public class DadosCompradorDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Nome { get; set; }

        [Required]
        [CpfCnpj(ErrorMessage = "O campo Documento é inválido")]
        public string Documento { get; set; }

        [Required]
        public string Endereco { get; set; }
        public string Complemento { get; set; }
    }
}
