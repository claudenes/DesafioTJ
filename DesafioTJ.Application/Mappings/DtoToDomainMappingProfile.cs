using AutoMapper;
using DesafioTJ.Domain.Entities;

namespace DesafioTJ.Application.Mappings
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile() 
        {
            CreateMap<AssuntoDto, Assunto>().ReverseMap();
            CreateMap<AutorDto, Autor>().ReverseMap();
            CreateMap<LivroAssuntoDto, LivroAssunto>().ReverseMap();
            CreateMap<LivroAutorDto, LivroAutor>().ReverseMap();
            CreateMap<LivroDto, Livro>().ReverseMap();

        }
    }
}
