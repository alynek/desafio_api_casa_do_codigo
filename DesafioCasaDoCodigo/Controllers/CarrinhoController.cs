using AutoMapper;
using DesafioCasaDoCodigo.Dtos;
using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Repositories.Interfaces;
using DesafioCasaDoCodigo.Utility;
using Microsoft.AspNetCore.Mvc;

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

        public void Atualiza()
        {

        }
    }
}
