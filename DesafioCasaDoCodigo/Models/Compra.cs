using DesafioCasaDoCodigo.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioCasaDoCodigo.Models
{
    public class Compra
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Email { get; set; }

        [CpfCnpj]
        public string Documento { get; set; }
        public string Endereco { get; set; }

        [MinLength(1)]
        [NotMapped]
        public HashSet<ItemCompra> Itens { get; set; }

        public DateTime DataCriacao { get; set; }

        public Compra() { }

        public Compra(string email, string documento, string endereco, HashSet<ItemCompra> itensCompra)
        {
            Email = email;
            Documento = documento;
            Endereco = endereco;

            Itens = new HashSet<ItemCompra>();
            foreach (var item in itensCompra)
            {
                Itens.Add(item);
            }

            DataCriacao = DateTime.Now;
        }
    }
}