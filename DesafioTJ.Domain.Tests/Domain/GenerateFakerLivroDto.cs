using Bogus;
using DesafioTJ.Application.Dtos;
using DesafioTJ.Domain.Entities;

namespace DesafioTJ.Domain.Tests.Domain
{
    internal class GenerateFakerLivroDto
    {
        private static Faker<LivroDto> CreateLivroDtoFaker()
        {
            return new Faker<LivroDto>().StrictMode(true)
            .RuleFor(x => x.Codigo, f => f.Random.Int())
            .RuleFor(x => x.Titulo, f => f.Name.FirstName())
            .RuleFor(x => x.Editora, f => f.Name.FirstName())
            .RuleFor(x => x.Edicao, f => f.Random.Int())
            .RuleFor(x => x.AnoPublicacao, f => f.Name.FirstName());
        }
        private static Faker<Livro> CreateLivroFaker(LivroDto livro)
        {
            return new Faker<Livro>().StrictMode(true)
            .RuleFor(x => x.Codigo, f => livro.Codigo)
            .RuleFor(x => x.Titulo, f => livro.Titulo)
            .RuleFor(x => x.Editora, f => livro.Editora)
            .RuleFor(x => x.Edicao, f => livro.Edicao)
            .RuleFor(x => x.AnoPublicacao, f => livro.AnoPublicacao);
        }
        public static LivroDto CreateLivroDto()
        {
            return CreateLivroDtoFaker().Generate(); 
        }
        public static Livro CreateLivro(LivroDto livro)
        {
            return CreateLivroFaker(livro).Generate();
        }
        public static IEnumerable<Livro> CreateIEnumerableLivro(LivroDto livro, int count)
        {
            return CreateLivroFaker(livro).Generate(count);
        }
    }
}
