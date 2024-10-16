using AutoMapper;
using DesafioTJ.Application.Dtos;
using DesafioTJ.Domain.Entities;

namespace DesafioTJ.Domain.Tests.Common
{
    public class GenerateFakerMapper
    {
        public static IMapper AddMapperConfiguration()
        {
            var autoMapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Assunto, AssuntoDto>().ReverseMap();
                cfg.CreateMap<Autor, AutorDto>().ReverseMap();
                cfg.CreateMap<Livro, LivroDto>().ReverseMap();
                cfg.CreateMap<LivroAssunto, LivroAssuntoDto>().ReverseMap();
                cfg.CreateMap<LivroAutor, LivroAutorDto>().ReverseMap();

            });
            IMapper mapper = new Mapper(autoMapperConfig);
            return mapper;
        }
    }
}
