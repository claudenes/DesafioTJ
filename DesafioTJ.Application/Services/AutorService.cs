using AutoMapper;
using DesafioTJ.Application.Interfaces;
using DesafioTJ.Domain.Entities;
using DesafioTJ.Domain.Interfaces;

namespace DesafioTJ.Application.Services
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _repository;
        private readonly IMapper _mapper;

        public AutorService(IAutorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public AutorDto Create(AutorDto autor)
        {
            return _mapper.Map<AutorDto>(_repository.Create(_mapper.Map<Autor>(autor)));
        }
      
        public AutorDto Delete(int Id)
        {
            return _mapper.Map<AutorDto>(_repository.Delete(Id));
        }

        public IEnumerable<AutorDto> ListAll()
        {
            return _mapper.Map<IEnumerable<AutorDto>>(_repository.ReadAll());
        }

        public AutorDto Read(int Id)
        {
            return _mapper.Map<AutorDto>(_repository.ReadById(Id));
        }

        public AutorDto Update(AutorDto autor)
        {
            return _mapper.Map<AutorDto>(_repository.Update(_mapper.Map<Autor>(autor)));
        }
    }
}
