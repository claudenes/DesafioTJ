using AutoMapper;
using DesafioTJ.Application.Dtos;
using DesafioTJ.Application.Interfaces;
using DesafioTJ.Domain.Entities;
using DesafioTJ.Domain.Interfaces;

namespace DesafioTJ.Application.Services
{
    public class LivroAssuntoService : ILivroAssuntoService
    {
        private readonly ILivroAssuntoRepository _repository;
        private readonly IMapper _mapper;

        public LivroAssuntoService(ILivroAssuntoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public LivroAssuntoDto Create(LivroAssuntoDto livroAssunto)
        {
            return _mapper.Map<LivroAssuntoDto>(_repository.Create(_mapper.Map<LivroAssunto>(livroAssunto)));
        }
      
        public LivroAssuntoDto Delete(int Id)
        {
            return _mapper.Map<LivroAssuntoDto>(_repository.Delete(Id));
        }

        public IEnumerable<LivroAssuntoDto> ListAll()
        {
            return _mapper.Map<IEnumerable<LivroAssuntoDto>>(_repository.ReadAll());
        }

        public LivroAssuntoDto Read(int Id)
        {
            return _mapper.Map<LivroAssuntoDto>(_repository.ReadById(Id));
        }

        public LivroAssuntoDto Update(LivroAssuntoDto livroAssunto)
        {
            return _mapper.Map<LivroAssuntoDto>(_repository.Update(_mapper.Map<LivroAssunto>(livroAssunto)));
        }
    }
}
