using DesafioTJ.Application.Dtos;
using DesafioTJ.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTJ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssuntoController : ControllerBase
    {
        private readonly IAssuntoService _service;
        public AssuntoController(IAssuntoService service)
        {
            _service = service;
        }
        [HttpGet]
        public Object ListAll()
        {
            return _service.ListAll();
        }
        [HttpPost]
        public Object Create([FromBody] AssuntoDto assuntoDto)
        {
            return _service.Create(assuntoDto);
        }
        [HttpPut]
        public Object Update([FromBody] AssuntoDto assuntoDto)
        {
            return _service.Update(assuntoDto);
        }
        [HttpDelete]
        public Object Delete(int Id)
        {
            return _service.Delete(Id);
        }
    }
}
