using AutoMapper;
using DesafioCasaDoCodigo.Dtos;
using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Repositories.Interfaces;
using DesafioCasaDoCodigo.Utility;
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
        public const string CookieName = "carrinho";
        private Cookies _cookies;

        public LivrosController(IUploader uploader, ILivroRepository livroRepository,
            IAutorRepository autorRepository, IMapper mapper,
            Cookies cookies)
        {
            _uploader = uploader;
            _livroRepository = livroRepository;
            _autorRepository = autorRepository;
            _mapper = mapper;
            _cookies = cookies;
        }

        [HttpPost]
        public IActionResult CriaLivro([FromForm] NovoLivroDto novoLivro)
        {
            Livro livro = novoLivro.NovoLivro(_autorRepository, _uploader);

            if (_livroRepository.TituloExiste(livro)) return BadRequest("Já existe um livro com esse título");

            if (_livroRepository.IsbnExiste(livro)) return BadRequest("Já existe um livro com esse isbn");

            _livroRepository.Salva(livro);

            return CreatedAtAction(nameof(CriaLivro), livro);
        }

        [HttpGet("/{livroId:int}")]
        public IActionResult DetalhesLivro(int livroId)
        {
            var livro = _livroRepository.ObterPorId(livroId);

            if (livro is null) return NotFound();

            var livroDetalheDto = _mapper.Map<LivroDetalheDto>(livro);
            livroDetalheDto.SumarioHtml = Markdown.ToHtml(livro.Sumario);

            return Ok(_mapper.Map<LivroDetalheDto>(livro));
        }

        [HttpPost("carrinho/{livroId:int}")]
        public IActionResult AdicionaLivroCarrinho(int livroId)
        {

            Carrinho carrinho = new Carrinho();

            if (Request.Cookies.ContainsKey(CookieName))
            {
                string cookie = Request.Cookies[CookieName];

                carrinho.Cria(cookie);
            }

            carrinho.Adiciona(_mapper.Map<LivroCarrinhoDto>(_livroRepository.ObterPorId(livroId)));

            _cookies.JsonSerialize(CookieName, Response, carrinho);

            return CreatedAtAction(nameof(AdicionaLivroCarrinho), carrinho.livros);
        }
    }
}
