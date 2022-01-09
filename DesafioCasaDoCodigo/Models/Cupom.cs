using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace DesafioCasaDoCodigo.Models
{
    public class Cupom
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Codigo { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [Required]
        public DateTime Expiracao { get; set; }

        [Range(0.0, 0.25)]
        public decimal Desconto { get; set; }

        public ICollection<Compra> Compras { get; set; }

        public Cupom(string codigo, DateTime expiracao, decimal desconto)
        {
            Assert.True(desconto.CompareTo(new decimal(0.25)) <= 0, "Desconto foi maior que 0.25!");
            Codigo = codigo;
            Expiracao = expiracao;
            Desconto = desconto;
        }

        public bool EhValido()
        {
            return Expiracao.CompareTo(DateTime.Now) >= 0;
        }
    }
}