using Bogus;
using DesafioTJ.Application.Dtos;
using DesafioTJ.Domain.Entities;

namespace DesafioTJ.Domain.Tests.Domain
{
    internal class GenerateFakerAutorDto
    {
        private static Faker<AutorDto> CreateAutorDtoFaker()
        {
            return new Faker<AutorDto>().StrictMode(true)
            .RuleFor(x => x.Codigo, f => f.Random.Int())
            .RuleFor(x => x.Nome, f => f.Name.FirstName());
        }
        private static Faker<Autor> CreateAutorFaker(AutorDto autor)
        {
            return new Faker<Autor>().StrictMode(true)
            .RuleFor(x => x.Codigo, f => autor.Codigo)
            .RuleFor(x => x.Nome, f => autor.Nome);
        }
        public static AutorDto CreateAutorDto()
        {
            return CreateAutorDtoFaker().Generate(); 
        }
        public static Autor CreateAutor(AutorDto autor)
        {
            return CreateAutorFaker(autor).Generate();
        }
        public static IEnumerable<Autor> CreateIEnumerableAutor(AutorDto autor, int count)
        {
            return CreateAutorFaker(autor).Generate(count);
        }
    }
}
