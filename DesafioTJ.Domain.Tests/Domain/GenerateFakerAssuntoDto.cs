using Bogus;
using DesafioTJ.Application.Dtos;
using DesafioTJ.Domain.Entities;

namespace DesafioTJ.Domain.Tests.Domain
{
    internal class GenerateFakerAssuntoDto
    {
        private static Faker<AssuntoDto> CreateAssuntoDtoFaker()
        {
            return new Faker<AssuntoDto>().StrictMode(true)
            .RuleFor(x => x.Codigo, f => f.Random.Int())
            .RuleFor(x => x.Descricao, f => f.Name.FirstName());
        }
        private static Faker<Assunto> CreateAssuntoFaker(AssuntoDto assunto)
        {
            return new Faker<Assunto>().StrictMode(true)
            .RuleFor(x => x.Codigo, f => assunto.Codigo)
            .RuleFor(x => x.Descricao, f => assunto.Descricao);
        }
        public static AssuntoDto CreateAssuntoDto()
        {
            return CreateAssuntoDtoFaker().Generate(); 
        }
        public static Assunto CreateAssunto(AssuntoDto assunto)
        {
            return CreateAssuntoFaker(assunto).Generate();
        }
        public static IEnumerable<Assunto> CreateIEnumerableAssunto(AssuntoDto assunto, int count)
        {
            return CreateAssuntoFaker(assunto).Generate(count);
        }
    }
}
