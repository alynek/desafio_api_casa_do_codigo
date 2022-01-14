using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Repositories.Interfaces;
using DesafioCasaDoCodigo.Utility;
using System;
using System.Collections.Generic;
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
#nullable enable
        public string? CodigoCupom { get; set; }
#nullable disable

        public Compra NovaCompra(HashSet<ItemCompra> itensCompra, ICupomRepository _cupomRepository)
        {
            Compra compra = new Compra(Email, Documento, Endereco, itensCompra);

            if (!(string.IsNullOrEmpty(this.Complemento))) compra.Complemento = this.Complemento;
           
            if (!(string.IsNullOrEmpty(this.CodigoCupom))) {

                var cupom =_cupomRepository.ObterPorCodigo(this.CodigoCupom);
                if (cupom is null) throw new ArgumentException("Esse cupom não existe");
                if (!cupom.EhValido()) throw new ArgumentException("Esse cupom Expirou");

                compra.Cupom = cupom;
            }

            return compra;
        }
    }
}
