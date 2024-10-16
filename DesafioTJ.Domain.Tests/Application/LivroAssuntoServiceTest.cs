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
    public class LivroAssuntoServiceTest
    {
        private readonly ILivroAssuntoRepository _repository;
        private readonly ILivroAssuntoService _service;

        public LivroAssuntoServiceTest()
        {
            _repository = Substitute.For<ILivroAssuntoRepository>();
            _service = new LivroAssuntoService(_repository, GenerateFakerMapper.AddMapperConfiguration());
        }
        [Fact]
        public void Constructor()
        {
            var result = new LivroAssuntoService(_repository, GenerateFakerMapper.AddMapperConfiguration());
            result.Should().NotBeNull();

        }
        [Fact]
        public void Create() 
        {
            LivroAssuntoDto LivroAssuntoDto = GenerateFakerLivroAssuntoDto.CreateLivroAssuntoDto();
            LivroAssunto LivroAssunto = GenerateFakerLivroAssuntoDto.CreateLivroAssunto(LivroAssuntoDto);
            List<LivroAssunto> queryLivroAssunto = new();
            _repository.ReadAll().Where(x=>x.Codigo_Livro==LivroAssuntoDto.Codigo_Livro).Returns(queryLivroAssunto);

            var result = _repository.Create(LivroAssunto).Returns(LivroAssunto);
            var result2 = _service.Create(LivroAssuntoDto);

            result.Should().NotBeNull();
        }
        [Fact]
        public void Read()
        {
            LivroAssuntoDto LivroAssuntoDto = GenerateFakerLivroAssuntoDto.CreateLivroAssuntoDto();
            LivroAssunto LivroAssunto = GenerateFakerLivroAssuntoDto.CreateLivroAssunto(LivroAssuntoDto);
            List<LivroAssunto> queryLivroAssunto = new();
            _repository.ReadAll().Where(x => x.Codigo_Livro == LivroAssuntoDto.Codigo_Livro).Returns(queryLivroAssunto);

            var result = _repository.ReadById(LivroAssunto.Codigo_Livro).Returns(LivroAssunto);
            var result2 = _service.Read(LivroAssuntoDto.Codigo_Livro);

            result.Should().NotBeNull();
        }
        [Fact]
        public void Delete()
        {
            LivroAssuntoDto LivroAssuntoDto = GenerateFakerLivroAssuntoDto.CreateLivroAssuntoDto();
            LivroAssunto LivroAssunto = GenerateFakerLivroAssuntoDto.CreateLivroAssunto(LivroAssuntoDto);
            List<LivroAssunto> queryLivroAssunto = new();
            _repository.ReadAll().Where(x => x.Codigo_Livro == LivroAssuntoDto.Codigo_Livro).Returns(queryLivroAssunto);

            var result = _repository.Delete(LivroAssunto.Codigo_Livro).Returns(LivroAssunto);
            var result2 = _service.Delete(LivroAssuntoDto.Codigo_Livro);

            result.Should().NotBeNull();
        }
        [Fact]
        public void Update()
        {
            LivroAssuntoDto LivroAssuntoDto = GenerateFakerLivroAssuntoDto.CreateLivroAssuntoDto();
            LivroAssunto LivroAssunto = GenerateFakerLivroAssuntoDto.CreateLivroAssunto(LivroAssuntoDto);
            List<LivroAssunto> queryLivroAssunto = new();
            _repository.ReadAll().Where(x => x.Codigo_Livro == LivroAssuntoDto.Codigo_Livro).Returns(queryLivroAssunto);

            var result = _repository.Update(LivroAssunto).Returns(LivroAssunto);
            var result2 = _service.Update(LivroAssuntoDto);

            result.Should().NotBeNull();
        }
        [Fact]
        public void ListAll()
        {
            LivroAssuntoDto LivroAssuntoDto = GenerateFakerLivroAssuntoDto.CreateLivroAssuntoDto();
            IEnumerable<LivroAssunto> eLivroAssunto = GenerateFakerLivroAssuntoDto.CreateIEnumerableLivroAssunto(LivroAssuntoDto,1);
            ICollection<LivroAssunto> CLivroAssunto = eLivroAssunto.ToList();

            _repository.ReadAll().Returns(CLivroAssunto);


            var result = _service.ListAll();
            result.Should().NotBeNull();
        }
    }
}
