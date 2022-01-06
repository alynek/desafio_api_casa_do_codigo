using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Utility;
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

        public Compra NovaCompra(HashSet<ItemCompra> itensCompra)
        {
            Compra compra = new Compra(Email, Documento, Endereco, itensCompra);

            if (!(string.IsNullOrEmpty(this.Complemento))) compra.Complemento = this.Complemento;

            return compra;
        }
    }
}
