using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioCasaDoCodigo.Models
{
    public class Autor
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Url]
        public string LinkGithub { get; set; }

        private DateTime DataCriacao = DateTime.Now;

        public Autor(){}

        public Autor(string nome, string linkGithub)
        {
            this.Nome = nome;
            this.LinkGithub = linkGithub;
        }

        public override string ToString()
        {
            return $"Autor: {Nome}, Link do github: {LinkGithub}, Data da criação: {DataCriacao}";
        }
    }
}