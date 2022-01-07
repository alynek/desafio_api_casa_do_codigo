using DesafioCasaDoCodigo.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioCasaDoCodigo.Dtos
{
    public class NovoCupomDto
    {
        [Required]
        public string Codigo { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [Required]
        public DateTime Expiracao { get; set; }

        [Range(0.0, 0.25)]
        public decimal Desconto { get; set; }

        public Cupom novoCupom()
        {
            return new Cupom(Codigo, Expiracao, Desconto);
        }
    }
}
