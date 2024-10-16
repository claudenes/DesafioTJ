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
    public class LivroServiceTest
    {
        private readonly ILivroRepository _repository;
        private readonly ILivroService _service;

        public LivroServiceTest()
        {
            _repository = Substitute.For<ILivroRepository>();
            _service = new LivroService(_repository, GenerateFakerMapper.AddMapperConfiguration());
        }
        [Fact]
        public void Constructor()
        {
            var result = new LivroService(_repository, GenerateFakerMapper.AddMapperConfiguration());
            result.Should().NotBeNull();

        }
        [Fact]
        public void Create() 
        {
            LivroDto LivroDto = GenerateFakerLivroDto.CreateLivroDto();
            Livro Livro = GenerateFakerLivroDto.CreateLivro(LivroDto);
            List<Livro> queryLivro = new();
            _repository.ReadAll().Where(x=>x.Codigo==LivroDto.Codigo).Returns(queryLivro);

            var result = _repository.Create(Livro).Returns(Livro);
            var result2 = _service.Create(LivroDto);

            result.Should().NotBeNull();
        }
        [Fact]
        public void Read()
        {
            LivroDto LivroDto = GenerateFakerLivroDto.CreateLivroDto();
            Livro Livro = GenerateFakerLivroDto.CreateLivro(LivroDto);
            List<Livro> queryLivro = new();
            _repository.ReadAll().Where(x => x.Codigo == LivroDto.Codigo).Returns(queryLivro);

            var result = _repository.ReadById(Livro.Codigo).Returns(Livro);
            var result2 = _service.Read(LivroDto.Codigo);

            result.Should().NotBeNull();
        }
        [Fact]
        public void Delete()
        {
            LivroDto LivroDto = GenerateFakerLivroDto.CreateLivroDto();
            Livro Livro = GenerateFakerLivroDto.CreateLivro(LivroDto);
            List<Livro> queryLivro = new();
            _repository.ReadAll().Where(x => x.Codigo == LivroDto.Codigo).Returns(queryLivro);

            var result = _repository.Delete(Livro.Codigo).Returns(Livro);
            var result2 = _service.Delete(LivroDto.Codigo);

            result.Should().NotBeNull();
        }
        [Fact]
        public void Update()
        {
            LivroDto LivroDto = GenerateFakerLivroDto.CreateLivroDto();
            Livro Livro = GenerateFakerLivroDto.CreateLivro(LivroDto);
            List<Livro> queryLivro = new();
            _repository.ReadAll().Where(x => x.Codigo == LivroDto.Codigo).Returns(queryLivro);

            var result = _repository.Update(Livro).Returns(Livro);
            var result2 = _service.Update(LivroDto);

            result.Should().NotBeNull();
        }
        [Fact]
        public void ListAll()
        {
            LivroDto LivroDto = GenerateFakerLivroDto.CreateLivroDto();
            IEnumerable<Livro> eLivro = GenerateFakerLivroDto.CreateIEnumerableLivro(LivroDto,1);
            ICollection<Livro> CLivro = eLivro.ToList();

            _repository.ReadAll().Returns(CLivro);


            var result = _service.ListAll();
            result.Should().NotBeNull();
        }
    }
}
