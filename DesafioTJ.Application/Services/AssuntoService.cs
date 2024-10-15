using AutoMapper;
using DesafioTJ.Application.Interfaces;
using DesafioTJ.Domain.Entities;
using DesafioTJ.Domain.Interfaces;

namespace DesafioTJ.Application.Services
{
    public class AssuntoService : IAssuntoService
    {
        private readonly IAssuntoRepository _repository;
        private readonly IMapper _mapper;

        public AssuntoService(IAssuntoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public AssuntoDto Create(AssuntoDto assunto)
        {
            return _mapper.Map<AssuntoDto>(_repository.Create(_mapper.Map<Assunto>(assunto)));
        }
      
        public AssuntoDto Delete(int Id)
        {
            return _mapper.Map<AssuntoDto>(_repository.Delete(Id));
        }

        public IEnumerable<AssuntoDto> ListAll()
        {
            return _mapper.Map<IEnumerable<AssuntoDto>>(_repository.ReadAll());
        }

        public AssuntoDto Read(int Id)
        {
            return _mapper.Map<AssuntoDto>(_repository.ReadById(Id));
        }

        public AssuntoDto Update(AssuntoDto assunto)
        {
            return _mapper.Map<AssuntoDto>(_repository.Update(_mapper.Map<Assunto>(assunto)));
        }
    }
}
