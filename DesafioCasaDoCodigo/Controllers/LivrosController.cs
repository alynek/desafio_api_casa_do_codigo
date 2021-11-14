using AutoMapper;
using DesafioCasaDoCodigo.Dtos;
using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Repositories.Interfaces;
using DesafioCasaDoCodigo.Utility.Interfaces;
using Markdig;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

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

        public LivrosController(IUploader uploader, ILivroRepository livroRepository,
            IAutorRepository autorRepository, IMapper mapper)
        {
            _uploader = uploader;
            _livroRepository = livroRepository;
            _autorRepository = autorRepository;
            _mapper = mapper;
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
        public string AdicionaLivroCarrinho(int livroId)
        {
            string cookie;
            Carrinho carrinho = new Carrinho();

            if (Request.Cookies.ContainsKey(CookieName))
            {
                cookie = Request.Cookies[CookieName];
                
                var listaLivrosCarrinho = JsonConvert.DeserializeObject<List<LivroCarrinhoDto>>(cookie);
                carrinho.livros.AddRange(listaLivrosCarrinho);
            }

            LivroCarrinhoDto livroCarrinhoDto = _mapper.Map<LivroCarrinhoDto>(_livroRepository.ObterPorId(livroId));
            carrinho.Adiciona(livroCarrinhoDto);

            cookie = System.Text.Json.JsonSerializer.Serialize(carrinho.livros);

            var options = new CookieOptions()
            {
                Path = "/",
                HttpOnly = true
            };
            Response.Cookies.Append(CookieName, cookie, options);
            return carrinho.ToString();
        }
    }
}
