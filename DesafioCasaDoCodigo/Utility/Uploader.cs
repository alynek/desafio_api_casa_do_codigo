using DesafioCasaDoCodigo.Utility.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DesafioCasaDoCodigo.Utility
{
    public class Uploader : IUploader
    {
        public string Upload(IFormFile file)
        {
            System.Console.WriteLine("enviando arquivo");
            return "http://s3.amazon.bucket/" + file.FileName;
        }
    }
}
