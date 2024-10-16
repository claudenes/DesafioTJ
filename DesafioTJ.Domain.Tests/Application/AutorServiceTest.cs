using DesafioTJ.Application.Dtos;
using DesafioTJ.Application.Interfaces;
using DesafioTJ.Application.Services;
using DesafioTJ.Domain.Entities;
using DesafioTJ.Domain.Interfaces;
using DesafioTJ.Domain.Tests.Common;
using DesafioTJ.Domain.Tests.Domain;
using FluentAssertions;
using FluentValidation;
using NSubstitute;
using Xunit;

namespace DesafioTJ.Domain.Tests.Application
{
    public class AutorServiceTest
    {
        private readonly IAutorRepository _repository;
        private readonly IAutorService _service;

        public AutorServiceTest()
        {
            _repository = Substitute.For<IAutorRepository>();
            _service = new AutorService(_repository, GenerateFakerMapper.AddMapperConfiguration());
        }
        [Fact]
        public void Constructor()
        {
            var result = new AutorService(_repository, GenerateFakerMapper.AddMapperConfiguration());
            result.Should().NotBeNull();

        }
        [Fact]
        public void Create() 
        {
            AutorDto AutorDto = GenerateFakerAutorDto.CreateAutorDto();
            Autor Autor = GenerateFakerAutorDto.CreateAutor(AutorDto);
            List<Autor> queryAutor = new();
            _repository.ReadAll().Where(x=>x.Codigo==AutorDto.Codigo).Returns(queryAutor);

            var result = _repository.Create(Autor).Returns(Autor);
            var result2 = _service.Create(AutorDto);

            result.Should().NotBeNull();
        }
        [Fact]
        public void Read()
        {
            AutorDto AutorDto = GenerateFakerAutorDto.CreateAutorDto();
            Autor Autor = GenerateFakerAutorDto.CreateAutor(AutorDto);
            List<Autor> queryAutor = new();
            _repository.ReadAll().Where(x => x.Codigo == AutorDto.Codigo).Returns(queryAutor);

            var result = _repository.ReadById(Autor.Codigo).Returns(Autor);
            var result2 = _service.Read(AutorDto.Codigo);

            result.Should().NotBeNull();
        }
        [Fact]
        public void Delete()
        {
            AutorDto AutorDto = GenerateFakerAutorDto.CreateAutorDto();
            Autor Autor = GenerateFakerAutorDto.CreateAutor(AutorDto);
            List<Autor> queryAutor = new();
            _repository.ReadAll().Where(x => x.Codigo == AutorDto.Codigo).Returns(queryAutor);

            var result = _repository.Delete(Autor.Codigo).Returns(Autor);
            var result2 = _service.Delete(AutorDto.Codigo);

            result.Should().NotBeNull();
        }
        [Fact]
        public void Update()
        {
            AutorDto AutorDto = GenerateFakerAutorDto.CreateAutorDto();
            Autor Autor = GenerateFakerAutorDto.CreateAutor(AutorDto);
            List<Autor> queryAutor = new();
            _repository.ReadAll().Where(x => x.Codigo == AutorDto.Codigo).Returns(queryAutor);

            var result = _repository.Update(Autor).Returns(Autor);
            var result2 = _service.Update(AutorDto);

            result.Should().NotBeNull();
        }
        [Fact]
        public void ListAll()
        {
            AutorDto AutorDto = GenerateFakerAutorDto.CreateAutorDto();
            IEnumerable<Autor> eAutor = GenerateFakerAutorDto.CreateIEnumerableAutor(AutorDto,1);
            ICollection<Autor> CAutor = eAutor.ToList();

            _repository.ReadAll().Returns(CAutor);


            var result = _service.ListAll();
            result.Should().NotBeNull();
        }
    }
}
