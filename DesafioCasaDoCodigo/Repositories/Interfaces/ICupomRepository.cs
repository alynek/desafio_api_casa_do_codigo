using DesafioCasaDoCodigo.Models;

namespace DesafioCasaDoCodigo.Repositories.Interfaces
{
    public interface ICupomRepository
    {
        void Salva(Cupom cupom);
        Cupom ObterPorCodigo(string codigoCupom);
    }
}
