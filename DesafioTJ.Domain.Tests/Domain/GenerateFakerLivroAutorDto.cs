using Bogus;
using DesafioTJ.Application.Dtos;
using DesafioTJ.Domain.Entities;

namespace DesafioTJ.Domain.Tests.Domain
{
    internal class GenerateFakerLivroAutorDto
    {
        private static Faker<LivroAutorDto> CreateLivroAutorDtoFaker()
        {
            return new Faker<LivroAutorDto>().StrictMode(true)
            .RuleFor(x => x.Codigo_Livro, f => f.Random.Int())
            .RuleFor(x => x.Codigo_Autor, f => f.Random.Int());
        }
        private static Faker<LivroAutor> CreateLivroAutorFaker(LivroAutorDto livroAutor)
        {
            return new Faker<LivroAutor>().StrictMode(true)
            .RuleFor(x => x.Codigo_Livro, f => livroAutor.Codigo_Livro)
            .RuleFor(x => x.Codigo_Autor, f => livroAutor.Codigo_Autor);
        }
        public static LivroAutorDto CreateLivroAutorDto()
        {
            return CreateLivroAutorDtoFaker().Generate(); 
        }
        public static LivroAutor CreateLivroAutor(LivroAutorDto autor)
        {
            return CreateLivroAutorFaker(autor).Generate();
        }
        public static IEnumerable<LivroAutor> CreateIEnumerableLivroAutor(LivroAutorDto autor, int count)
        {
            return CreateLivroAutorFaker(autor).Generate(count);
        }
    }
}
