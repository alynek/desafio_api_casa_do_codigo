using DesafioCasaDoCodigo.Models;

namespace DesafioCasaDoCodigo.Dtos
{
    public class LivroLeituraDto
    {
        public string Titulo { get; set; }
        public int Id { get; set; }
        public Autor Autor { get; set; }
    }
}
