using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Services.Interfaces;
using System;

namespace DesafioCasaDoCodigo.Services
{
    public class EmailService : IEmailService
    {
        public void NotificarCompraParaAdminCdc(PagamentoPaypal novoPagamento)
        {
            Console.WriteLine("Mandar email para o admin da casa do código");
            Console.WriteLine(novoPagamento.Compra);
            Console.WriteLine(novoPagamento);
        }

        public void NotificarCompradorComNovaCompra(PagamentoPaypal novoPagamento)
        {
            Console.WriteLine("Mandar email para comprador da casa do código");
            Console.WriteLine(novoPagamento.Compra);
            Console.WriteLine(novoPagamento);
        }
        
        public void NotificarCompraParaAdminCdcPagamentoFalhou(PagamentoPaypal novoPagamento)
        {
            Console.WriteLine("Mandar email para admin da casa do código dizendo que a compra falhou");
            Console.WriteLine(novoPagamento);
        }
    }
}
