using DesafioCasaDoCodigo.Dtos;
using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Repositories.Interfaces;
using DesafioCasaDoCodigo.Utility.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCasaDoCodigo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private IUploader _uploader;
        private ILivroRepository _livroRepository;
        private IAutorRepository _autorRepository;

        public LivrosController(IUploader uploader, ILivroRepository livroRepository,
            IAutorRepository autorRepository)
        {
            _uploader = uploader;
            _livroRepository = livroRepository;
            _autorRepository = autorRepository;
        }

        [HttpPost]
        public IActionResult AdicionaLivro([FromForm] NovoLivroDto novoLivro)
        {
            Livro livro = novoLivro.NovoLivro(_autorRepository, _uploader);

            if (_livroRepository.TituloExiste(livro)) return BadRequest("Já existe um livro com esse título");

            if (_livroRepository.IsbnExiste(livro)) return BadRequest("Já existe um livro com esse isbn");

            _livroRepository.Salva(livro);

            return CreatedAtAction(nameof(AdicionaLivro), livro);
        }
    }
}
