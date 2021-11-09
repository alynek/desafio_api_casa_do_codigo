using DesafioCasaDoCodigo.Models;

namespace DesafioCasaDoCodigo.Dtos
{
    public class LivroDetalheDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string LinkCapaLivro { get; set; }
        public decimal Preco { get; set; }
        public Autor Autor { get; set; }
        public string Conteudo { get; set; }
        public string Sumario { get; set; }
        public int NumeroPaginas { get; set; }
        public string Isbn { get; set; }
    }
}
