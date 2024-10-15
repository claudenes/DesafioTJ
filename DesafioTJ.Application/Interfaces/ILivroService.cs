using DesafioTJ.Domain.Entities;

namespace DesafioTJ.Application.Interfaces
{
    public interface ILivroService
    {
        LivroDto Create(LivroDto livro);
        LivroDto Read(int Id);
        LivroDto Update(LivroDto livro);
        LivroDto Delete(int Id);
        IEnumerable<LivroDto> ListAll();

    }
}
