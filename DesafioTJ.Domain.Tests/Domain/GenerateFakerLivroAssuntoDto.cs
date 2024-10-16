using Bogus;
using DesafioTJ.Application.Dtos;
using DesafioTJ.Domain.Entities;

namespace DesafioTJ.Domain.Tests.Domain
{
    internal class GenerateFakerLivroAssuntoDto
    {
        private static Faker<LivroAssuntoDto> CreateLivroAssuntoDtoFaker()
        {
            return new Faker<LivroAssuntoDto>().StrictMode(true)
            .RuleFor(x => x.Codigo_Livro, f => f.Random.Int())
            .RuleFor(x => x.Codigo_Assunto, f => f.Random.Int());
        }
        private static Faker<LivroAssunto> CreateLivroAssuntoFaker(LivroAssuntoDto livroAssunto)
        {
            return new Faker<LivroAssunto>().StrictMode(true)
            .RuleFor(x => x.Codigo_Livro, f => livroAssunto.Codigo_Livro)
            .RuleFor(x => x.Codigo_Assunto, f => livroAssunto.Codigo_Assunto);
        }
        public static LivroAssuntoDto CreateLivroAssuntoDto()
        {
            return CreateLivroAssuntoDtoFaker().Generate(); 
        }
        public static LivroAssunto CreateLivroAssunto(LivroAssuntoDto livroAssunto)
        {
            return CreateLivroAssuntoFaker(livroAssunto).Generate();
        }
        public static IEnumerable<LivroAssunto> CreateIEnumerableLivroAssunto(LivroAssuntoDto livroAssunto, int count)
        {
            return CreateLivroAssuntoFaker(livroAssunto).Generate(count);
        }
    }
}
