using AutoMapper;
using DesafioCasaDoCodigo.Dtos;
using DesafioCasaDoCodigo.Models;

namespace DesafioCasaDoCodigo.Profiles
{
    public class LivroProfile : Profile
    {
        public LivroProfile()
        {
            CreateMap<Livro, LivroLeituraDto>();
        }
    }
}
