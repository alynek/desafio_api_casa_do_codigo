using DesafioCasaDoCodigo.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace DesafioCasaDoCodigo.Utility
{
    public class Cookies
    {
        public void JsonSerialize(string cookieName, HttpResponse response, Carrinho carrinho)
        {
            var cookie = JsonSerializer.Serialize(carrinho.livros);

            var options = new CookieOptions()
            {
                Path = "/",
                HttpOnly = true
            };

            response.Cookies.Append(cookieName, cookie, options);
        }
    }
}
