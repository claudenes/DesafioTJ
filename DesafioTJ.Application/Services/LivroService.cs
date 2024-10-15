using AutoMapper;
using DesafioTJ.Application.Dtos;
using DesafioTJ.Application.Interfaces;
using DesafioTJ.Domain.Entities;
using DesafioTJ.Domain.Interfaces;

namespace DesafioTJ.Application.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _repository;
        private readonly IMapper _mapper;

        public LivroService(ILivroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<LivroDto> Create(LivroDto livro)
        {
            return _mapper.Map<LivroDto>(_repository.Create(_mapper.Map<Livro>(livro)));
        }
      
        public async Task<LivroDto> Delete(int Id)
        {
            return _mapper.Map<LivroDto>(_repository.Delete(Id));
        }

        public async Task<IEnumerable<LivroDto>> ListAll()
        {
            return _mapper.Map<IEnumerable<LivroDto>>(_repository.ReadAll());
        }

        public async Task<LivroDto> Read(int Id)
        {
            return _mapper.Map<LivroDto>(_repository.ReadById(Id));
        }

        public async Task<LivroDto> Update(LivroDto livro)
        {
            return _mapper.Map<LivroDto>(_repository.Update(_mapper.Map<Livro>(livro)));
        }
    }
}
