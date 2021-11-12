using AutoMapper;
using DesafioCasaDoCodigo.Dtos;
using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Repositories.Interfaces;
using DesafioCasaDoCodigo.Utility.Interfaces;
using Markdig;
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
        private IMapper _mapper;

        public LivrosController(IUploader uploader, ILivroRepository livroRepository,
            IAutorRepository autorRepository, IMapper mapper)
        {
            _uploader = uploader;
            _livroRepository = livroRepository;
            _autorRepository = autorRepository;
            _mapper = mapper;
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

        [HttpGet("/{livroId:int}")]
        public IActionResult DetalhesLivro(int livroId)
        {
            var livro = _livroRepository.ObterPorId(livroId);

            if (livro is null) return NotFound();

            var livroDetalheDto = _mapper.Map<LivroDetalheDTO>(livro);
            livroDetalheDto.SumarioHtml = Markdown.ToHtml(livro.Sumario);

            return Ok(_mapper.Map<LivroDetalheDTO>(livro));
        }
    }
}
