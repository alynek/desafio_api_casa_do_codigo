using DesafioCasaDoCodigo.Enums;
using DesafioCasaDoCodigo.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioCasaDoCodigo.Dtos
{
    public class NovoPagamentoPaypalDto
    {
        [Required]
        public string IdTransacao { get; set; }

        [Required]
        public EPaypalStatus Status { get; set; }

        public PagamentoPaypal NovoPagamento(Compra compraExistente)
        {
            return new PagamentoPaypal(IdTransacao, Status, compraExistente);
        }
    }
}