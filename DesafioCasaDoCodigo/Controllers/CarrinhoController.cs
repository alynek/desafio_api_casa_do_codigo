using AutoMapper;
using DesafioCasaDoCodigo.Dtos;
using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Repositories.Interfaces;
using DesafioCasaDoCodigo.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DesafioCasaDoCodigo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private ILivroRepository _livroRepository;
        private IMapper _mapper;
        private Cookies _cookies;
        public const string CookieName = "carrinho";

        public CarrinhoController(ILivroRepository livroRepository, IMapper mapper,
            Cookies cookies)
        {
            _livroRepository = livroRepository;
            _mapper = mapper;
            _cookies = cookies;
        }

        [HttpPost("{livroId:int}")]
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

        [HttpPut("{livroId:int}")]
        public IActionResult Atualiza(int livroId, [FromQuery] int novaQuantidade)
        {
            Carrinho carrinho = new Carrinho();
            carrinho.Cria(Request.Cookies[CookieName]);

            LivroCarrinhoDto livroDto = _mapper.Map<LivroCarrinhoDto>(_livroRepository.ObterPorId(livroId));
            carrinho.Atualiza(livroDto, novaQuantidade);
            _cookies.JsonSerialize(CookieName, Response, carrinho);
            return Ok(carrinho.livros);
        }

        [HttpPost("finaliza")]
        public IActionResult Finaliza([FromForm] DadosCompradorDto compradorDto)
        {
            Carrinho carrinho = new Carrinho();
            carrinho.Cria(Request.Cookies[CookieName]);

            HashSet<ItemCompra> itensCompra = carrinho.GeraItensCompra(_livroRepository);

            return CreatedAtAction(nameof(Finaliza), itensCompra);
        }
    }
}
