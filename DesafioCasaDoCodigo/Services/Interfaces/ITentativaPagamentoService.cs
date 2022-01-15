using DesafioCasaDoCodigo.Dtos;
using DesafioCasaDoCodigo.Models;

namespace DesafioCasaDoCodigo.Services.Interfaces
{
    public interface ITentativaPagamentoService
    {
        public void Executar(Compra compraExistente, NovoPagamentoPaypalDto novaCompraPaypalDto);
    }
}
