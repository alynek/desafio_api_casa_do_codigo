﻿using DesafioCasaDoCodigo.Models;
using DesafioCasaDoCodigo.Repositories.Interfaces;
using DesafioCasaDoCodigo.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCasaDoCodigo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private IAutorRepository _autorRepository;

        public AutoresController(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        [HttpPost]
        public void AdicionaAutor([FromBody] NovoAutorDto novoAutor)
        {
            Autor autor = novoAutor.NovoAutor();
            _autorRepository.Save(autor);
        }
    }
}
