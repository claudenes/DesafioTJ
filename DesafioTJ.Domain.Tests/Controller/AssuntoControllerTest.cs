using DesafioTJ.API.Controllers;
using DesafioTJ.Application.Dtos;
using DesafioTJ.Application.Interfaces;
using DesafioTJ.Domain.Tests.Domain;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace DesafioTJ.Domain.Tests.Controller
{
    public class AssuntoControllerTest
    {
        private readonly IAssuntoService _service;
        private readonly AssuntoController _controller;
        public AssuntoControllerTest()
        {
            _service = Substitute.For<IAssuntoService>();
            _controller = new AssuntoController(_service);
        }
        [Fact]
        public void Constructor()
        {
            var result = new AssuntoController(_service);
            AssuntoDto dto = GenerateFakerAssuntoDto.CreateAssuntoDto();
            result.Should().NotBeNull();
        }
        [Fact]
        public void ListAll()
        {
            AssuntoDto dto = GenerateFakerAssuntoDto.CreateAssuntoDto();
            var result = _controller.ListAll();
            result.Should().NotBeNull();
        }
        
        [Fact]
        public void Update()
        {
            AssuntoDto dto = GenerateFakerAssuntoDto.CreateAssuntoDto();
            var result = _controller.Update(dto);
        }    
    }
}
