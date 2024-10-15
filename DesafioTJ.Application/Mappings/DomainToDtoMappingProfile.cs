using AutoMapper;
using DesafioTJ.Domain.Entities;

namespace DesafioTJ.Application.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile() 
        { 
            CreateMap<Assunto, AssuntoDto>().ReverseMap();
            CreateMap<Autor, AutorDto>().ReverseMap();
            CreateMap<LivroAssunto, LivroAssuntoDto>().ReverseMap();
            CreateMap<LivroAutor, LivroAutorDto>().ReverseMap();
            CreateMap<Livro, LivroDto>().ReverseMap();
        }
    }
}
