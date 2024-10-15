using DesafioTJ.Application.Dtos;
using DesafioTJ.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTJ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _service;
        public AutorController(IAutorService service)
        {
            _service = service;
        }
        [HttpGet]
        public Object ListAll()
        {
            return _service.ListAll();
        }
        [HttpPost]
        public Object Create([FromBody] AutorDto autorDto)
        {
            return _service.Create(autorDto);
        }
        [HttpPut]
        public Object Update([FromBody] AutorDto autorDto)
        {
            return _service.Update(autorDto);
        }
        [HttpDelete]
        public Object Delete(int Id)
        {
            return _service.Delete(Id);
        }
    }
}
