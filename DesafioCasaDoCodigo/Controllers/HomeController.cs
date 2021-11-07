using AutoMapper;
using DesafioCasaDoCodigo.Dtos;
using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DesafioCasaDoCodigo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private ILivroRepository _livroRepository;
        private IMapper _mapper;

        public HomeController(ILivroRepository livroRepository, IMapper mapper)
        {
            _livroRepository = livroRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            List<Livro> livros = _livroRepository.ObterTodos();

            if(livros == null)
            {
                return NotFound();
            }

            var livroDto = _mapper.Map<List<Livro>, List<LivroLeituraDto>>(livros);
            return Ok(livroDto);
        }
    }
}
