using AutoMapper;
using DesafioCasaDoCodigo.Dtos;
using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Repositories.Interfaces;
using DesafioCasaDoCodigo.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DesafioCasaDoCodigo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrinhoController : ControllerBase
    {
        private ILivroRepository _livroRepository;
        private ICompraRepository _compraRepository;
        private ICupomRepository _cupomRepository;
        private IMapper _mapper;
        private Cookies _cookies;
        public const string CookieName = "carrinho";

        public CarrinhoController(ILivroRepository livroRepository, ICompraRepository compraRepository, ICupomRepository cupomRepository,
            IMapper mapper, Cookies cookies)
        {
            _livroRepository = livroRepository;
            _compraRepository = compraRepository;
            _cupomRepository = cupomRepository;
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

            try
            {
                Compra novaCompra = compradorDto.NovaCompra(itensCompra, _cupomRepository);
                _compraRepository.Salva(novaCompra);

                return CreatedAtAction(nameof(Finaliza), novaCompra);
            }
            catch(ArgumentException e)
            {
                return NotFound(e.Message);
            } 
        }
    }
}
