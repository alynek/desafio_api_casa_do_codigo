using DesafioCasaDoCodigo.Dtos;
using DesafioCasaDoCodigo.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCasaDoCodigo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalizaCompraController : ControllerBase
    {
        
        [HttpPost("pagamento/{idCompra:int}")]
        public void Pagamento(int idCompra, [FromForm] NovaCompraPaypalDto novaCompraPaypalDto)
        {
           
        }
    }
}
