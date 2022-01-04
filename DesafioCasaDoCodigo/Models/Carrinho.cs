using DesafioCasaDoCodigo.Dtos;
using DesafioCasaDoCodigo.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace DesafioCasaDoCodigo.Models
{
    public class Carrinho
    {
        public SortedSet<LivroCarrinhoDto> livros = new SortedSet<LivroCarrinhoDto>();
        public void Adiciona(LivroCarrinhoDto livro)
        {
            bool resultado = livros.Add(livro);

            if (!resultado)
            {
                LivroCarrinhoDto livroExistente = livros.Where(l => l.Equals(livro)).FirstOrDefault();
                livroExistente.IncrementaQuantidade();
            }

        }

        public void Cria(string cookie)
        {
            var options = new JsonSerializerOptions
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString
            };

            var listaLivrosCarrinho = JsonSerializer.Deserialize<List<LivroCarrinhoDto>>(cookie, options);
            foreach (var livro in listaLivrosCarrinho)
            {
                livros.Add(livro);
            }
        }

        public void Atualiza(LivroCarrinhoDto livro, [Range(1, int.MaxValue)] int novaQuantidade)
        {
            Assert.True(novaQuantidade > 0, "A quantidade de atualização tem que ser maior que zero");
            LivroCarrinhoDto possivelItem = livros.Where(l => l.Equals(livro)).FirstOrDefault();

            Assert.True(possivelItem != null, "Você não deveria atualizar um livro que não foi colocado no carrinho");
            possivelItem.AtualizaQuantidade(novaQuantidade);
        }

        //public HashSet<ItemCompra> GeraItensCompra(ILivroRepository _livroRepository)
        //{
        //    return 
        //}
    }
}
