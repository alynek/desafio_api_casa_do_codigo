using DesafioCasaDoCodigo.Dtos;
using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Services.Interfaces;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DesafioCasaDoCodigo.Services
{
    public class EmailService : IEmailService
    {
        public async void NotificarCompraParaAdminCdc(PagamentoPaypal novoPagamento)
        {
            await EnviaEmailAsync(new EmailDto
            {
                To = "admin@gmail.com",
                Subject = "Notificação de nova compra",
                Body = "Mandar email para o admin da casa do código, id da transação: " + novoPagamento.IdTransacao +
            "itens da compra: " + novoPagamento.Compra.Itens
            });
        }

        public async void NotificarCompradorComNovaCompra(PagamentoPaypal novoPagamento)
        {
            await EnviaEmailAsync(new EmailDto
            {
                To = novoPagamento.Compra.Email,
                Subject = "Notificação de nova compra",
                Body = "Mandar email para o admin da casa do código, itens da compra:" + novoPagamento.Compra.Itens 
            });
        }
        
        public async void NotificaAdminCdcPagamentoFalhou(PagamentoPaypal novoPagamento)
        {
            await EnviaEmailAsync(new EmailDto
            {
                To = "admin@gmail.com",
                Subject = "Notificação de nova compra",
                Body = "Mandar email para o admin da casa do código, pagamento falhou, id da transação: " + novoPagamento.IdTransacao
            });
        }

        public async Task EnviaEmailAsync(EmailDto emailDto)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            try
            {
                message.From = new MailAddress("casadocodigo@email.com", "casadocodigo");
                message.To.Add(emailDto.To);
                message.Subject = emailDto.Subject;

                message.IsBodyHtml = false;
                message.Body = emailDto.Body;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("casadocodigo@email.com", "123");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                await smtp.SendMailAsync(message);
                emailDto.Status = Enums.EStatusEmail.Enviado;
            }
            catch (Exception e)
            {
                emailDto.Status = Enums.EStatusEmail.Erro;
                throw;
            }
        }
    }
}
