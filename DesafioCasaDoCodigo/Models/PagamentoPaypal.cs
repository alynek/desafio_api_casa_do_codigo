using DesafioCasaDoCodigo.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioCasaDoCodigo.Models
{
    public class PagamentoPaypal
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string IdTransacao { get; set; }

        [Required]
        public EPaypalStatus Status { get; set; }

        [Required]
        public Compra Compra { get; set; }
        public int CompraId { get; set; }

        public PagamentoPaypal(){}
        public PagamentoPaypal(string idTransacao, EPaypalStatus status, Compra compraExistente)
        {
            IdTransacao = idTransacao;
            Status = status;
            Compra = compraExistente;
        }

        public bool Sucesso()
        {
            return EPaypalStatus.sucesso.Equals(Status);
        }

        public override string ToString()
        {
            return "PagamentoPaypal [id=" + Id + ", idTransacao=" + IdTransacao + ", Status=" + Status + "]";
        }
    }
}