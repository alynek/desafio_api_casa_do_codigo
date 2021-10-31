using Microsoft.AspNetCore.Http;

namespace DesafioCasaDoCodigo.Utility.Interfaces
{
    public interface IUploader
    {
        string Upload(IFormFile file);
    }
}
