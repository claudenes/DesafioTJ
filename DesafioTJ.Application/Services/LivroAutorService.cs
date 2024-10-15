using AutoMapper;
using DesafioTJ.Application.Interfaces;
using DesafioTJ.Domain.Entities;
using DesafioTJ.Domain.Interfaces;

namespace DesafioTJ.Application.Services
{
    public class LivroAutorService : ILivroAutorService
    {
        private readonly ILivroAutorRepository _repository;
        private readonly IMapper _mapper;

        public LivroAutorService(ILivroAutorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public LivroAutorDto Create(LivroAutorDto livroAutor)
        {
            return _mapper.Map<LivroAutorDto>(_repository.Create(_mapper.Map<LivroAutor>(livroAutor)));
        }
      
        public LivroAutorDto Delete(int Id)
        {
            return _mapper.Map<LivroAutorDto>(_repository.Delete(Id));
        }

        public IEnumerable<LivroAutorDto> ListAll()
        {
            return _mapper.Map<IEnumerable<LivroAutorDto>>(_repository.ReadAll());
        }

        public LivroAutorDto Read(int Id)
        {
            return _mapper.Map<LivroAutorDto>(_repository.ReadById(Id));
        }

        public LivroAutorDto Update(LivroAutorDto livroAutor)
        {
            return _mapper.Map<LivroAutorDto>(_repository.Update(_mapper.Map<LivroAutor>(livroAutor)));
        }
    }
}
