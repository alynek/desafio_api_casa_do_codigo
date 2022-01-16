using DesafioCasaDoCodigo.Models;
using System.Threading.Tasks;

namespace DesafioCasaDoCodigo.Repositories.Interfaces
{
    public interface ICompraRepository
    {
        void Salva(Compra compra);
        Task<Compra> Obter(int compraId);
    }
}
