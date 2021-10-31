using System.ComponentModel.DataAnnotations;

namespace DesafioCasaDoCodigo.Models
{
    public class Categoria
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public Categoria(string nome)
        {
            Nome = nome;
        }
    }
}