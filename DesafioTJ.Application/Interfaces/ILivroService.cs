using DesafioTJ.Application.Dtos;

namespace DesafioTJ.Application.Interfaces
{
    public interface ILivroService
    {
        Task<LivroDto> Create(LivroDto livro);
        Task<LivroDto> Read(int Id);
        Task<LivroDto> Update(LivroDto livro);
        Task<LivroDto> Delete(int Id);
        Task<IEnumerable<LivroDto>> ListAll();

    }
}
