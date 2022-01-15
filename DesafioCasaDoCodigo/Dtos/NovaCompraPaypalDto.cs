using DesafioCasaDoCodigo.Enums;
using System.ComponentModel.DataAnnotations;

namespace DesafioCasaDoCodigo.Dtos
{
    public class NovaCompraPaypalDto
    {
        [Required]
        public string IdTransacao { get; set; }

        [Required]
        public EPaypalStatus Status { get; set; }

    }
}