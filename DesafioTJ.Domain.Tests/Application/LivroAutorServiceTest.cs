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
    public class LivroAutorServiceTest
    {
        private readonly ILivroAutorRepository _repository;
        private readonly ILivroAutorService _service;

        public LivroAutorServiceTest()
        {
            _repository = Substitute.For<ILivroAutorRepository>();
            _service = new LivroAutorService(_repository, GenerateFakerMapper.AddMapperConfiguration());
        }
        [Fact]
        public void Constructor()
        {
            var result = new LivroAutorService(_repository, GenerateFakerMapper.AddMapperConfiguration());
            result.Should().NotBeNull();

        }
        [Fact]
        public void Create() 
        {
            LivroAutorDto LivroAutorDto = GenerateFakerLivroAutorDto.CreateLivroAutorDto();
            LivroAutor LivroAutor = GenerateFakerLivroAutorDto.CreateLivroAutor(LivroAutorDto);
            List<LivroAutor> queryLivroAutor = new();
            _repository.ReadAll().Where(x=>x.Codigo_Livro==LivroAutorDto.Codigo_Livro).Returns(queryLivroAutor);

            var result = _repository.Create(LivroAutor).Returns(LivroAutor);
            var result2 = _service.Create(LivroAutorDto);

            result.Should().NotBeNull();
        }
        [Fact]
        public void Read()
        {
            LivroAutorDto LivroAutorDto = GenerateFakerLivroAutorDto.CreateLivroAutorDto();
            LivroAutor LivroAutor = GenerateFakerLivroAutorDto.CreateLivroAutor(LivroAutorDto);
            List<LivroAutor> queryLivroAutor = new();
            _repository.ReadAll().Where(x => x.Codigo_Livro == LivroAutorDto.Codigo_Livro).Returns(queryLivroAutor);

            var result = _repository.ReadById(LivroAutor.Codigo_Livro).Returns(LivroAutor);
            var result2 = _service.Read(LivroAutorDto.Codigo_Livro);

            result.Should().NotBeNull();
        }
        [Fact]
        public void Delete()
        {
            LivroAutorDto LivroAutorDto = GenerateFakerLivroAutorDto.CreateLivroAutorDto();
            LivroAutor LivroAutor = GenerateFakerLivroAutorDto.CreateLivroAutor(LivroAutorDto);
            List<LivroAutor> queryLivroAutor = new();
            _repository.ReadAll().Where(x => x.Codigo_Livro == LivroAutorDto.Codigo_Livro).Returns(queryLivroAutor);

            var result = _repository.Delete(LivroAutor.Codigo_Livro).Returns(LivroAutor);
            var result2 = _service.Delete(LivroAutorDto.Codigo_Livro);

            result.Should().NotBeNull();
        }
        [Fact]
        public void Update()
        {
            LivroAutorDto LivroAutorDto = GenerateFakerLivroAutorDto.CreateLivroAutorDto();
            LivroAutor LivroAutor = GenerateFakerLivroAutorDto.CreateLivroAutor(LivroAutorDto);
            List<LivroAutor> queryLivroAutor = new();
            _repository.ReadAll().Where(x => x.Codigo_Livro == LivroAutorDto.Codigo_Livro).Returns(queryLivroAutor);

            var result = _repository.Update(LivroAutor).Returns(LivroAutor);
            var result2 = _service.Update(LivroAutorDto);

            result.Should().NotBeNull();
        }
        [Fact]
        public void ListAll()
        {
            LivroAutorDto LivroAutorDto = GenerateFakerLivroAutorDto.CreateLivroAutorDto();
            IEnumerable<LivroAutor> eLivroAutor = GenerateFakerLivroAutorDto.CreateIEnumerableLivroAutor(LivroAutorDto,1);
            ICollection<LivroAutor> CLivroAutor = eLivroAutor.ToList();

            _repository.ReadAll().Returns(CLivroAutor);


            var result = _service.ListAll();
            result.Should().NotBeNull();
        }
    }
}
