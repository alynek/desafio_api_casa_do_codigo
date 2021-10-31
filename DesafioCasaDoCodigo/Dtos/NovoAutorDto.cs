using DesafioCasaDoCodigo.Models;
using System.ComponentModel.DataAnnotations;

namespace DesafioCasaDoCodigo.Dtos
{
    public class NovoAutorDto
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        [Url]
        public string LinkGithub { get; set; }

        public Autor NovoAutor()
        {
            return new Autor(Nome, LinkGithub);
        }
    }
}