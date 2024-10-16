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
    public class AssuntoServiceTest
    {
        private readonly IAssuntoRepository _repository;
        private readonly IAssuntoService _service;

        public AssuntoServiceTest()
        {
            _repository = Substitute.For<IAssuntoRepository>();
            _service = new AssuntoService(_repository, GenerateFakerMapper.AddMapperConfiguration());
        }
        [Fact]
        public void Constructor()
        {
            var result = new AssuntoService(_repository, GenerateFakerMapper.AddMapperConfiguration());
            result.Should().NotBeNull();

        }
        [Fact]
        public void Create() 
        {
            AssuntoDto AssuntoDto = GenerateFakerAssuntoDto.CreateAssuntoDto();
            Assunto Assunto = GenerateFakerAssuntoDto.CreateAssunto(AssuntoDto);
            List<Assunto> queryAssunto = new();
            _repository.ReadAll().Where(x=>x.Codigo==AssuntoDto.Codigo).Returns(queryAssunto);

            var result = _repository.Create(Assunto).Returns(Assunto);
            var result2 = _service.Create(AssuntoDto);

            result.Should().NotBeNull();
        }
        [Fact]
        public void Read()
        {
            AssuntoDto AssuntoDto = GenerateFakerAssuntoDto.CreateAssuntoDto();
            Assunto Assunto = GenerateFakerAssuntoDto.CreateAssunto(AssuntoDto);
            List<Assunto> queryAssunto = new();
            _repository.ReadAll().Where(x => x.Codigo == AssuntoDto.Codigo).Returns(queryAssunto);

            var result = _repository.ReadById(Assunto.Codigo).Returns(Assunto);
            var result2 = _service.Read(AssuntoDto.Codigo);

            result.Should().NotBeNull();
        }
        [Fact]
        public void Delete()
        {
            AssuntoDto AssuntoDto = GenerateFakerAssuntoDto.CreateAssuntoDto();
            Assunto Assunto = GenerateFakerAssuntoDto.CreateAssunto(AssuntoDto);
            List<Assunto> queryAssunto = new();
            _repository.ReadAll().Where(x => x.Codigo == AssuntoDto.Codigo).Returns(queryAssunto);

            var result = _repository.Delete(Assunto.Codigo).Returns(Assunto);
            var result2 = _service.Delete(AssuntoDto.Codigo);

            result.Should().NotBeNull();
        }
        [Fact]
        public void Update()
        {
            AssuntoDto AssuntoDto = GenerateFakerAssuntoDto.CreateAssuntoDto();
            Assunto Assunto = GenerateFakerAssuntoDto.CreateAssunto(AssuntoDto);
            List<Assunto> queryAssunto = new();
            _repository.ReadAll().Where(x => x.Codigo == AssuntoDto.Codigo).Returns(queryAssunto);

            var result = _repository.Update(Assunto).Returns(Assunto);
            var result2 = _service.Update(AssuntoDto);

            result.Should().NotBeNull();
        }
        [Fact]
        public void ListAll()
        {
            AssuntoDto AssuntoDto = GenerateFakerAssuntoDto.CreateAssuntoDto();
            IEnumerable<Assunto> eAssunto = GenerateFakerAssuntoDto.CreateIEnumerableAssunto(AssuntoDto,1);
            ICollection<Assunto> CAssunto = eAssunto.ToList();

            _repository.ReadAll().Returns(CAssunto);


            var result = _service.ListAll();
            result.Should().NotBeNull();
        }
    }
}
