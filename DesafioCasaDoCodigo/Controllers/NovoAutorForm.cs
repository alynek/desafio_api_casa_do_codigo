using System.ComponentModel.DataAnnotations;

namespace DesafioCasaDoCodigo.Controllers
{
    public class NovoAutorForm
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        [Url]
        public string LinkGithub { get; set; }
    }
}