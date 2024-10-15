using DesafioTJ.Domain.Entities;

namespace DesafioTJ.Application.Interfaces
{
    public interface ILivroAutorService
    {
        LivroAutorDto Create(LivroAutorDto livroautor);
        LivroAutorDto Read(int Id);
        LivroAutorDto Update(LivroAutorDto livroautor);
        LivroAutorDto Delete(int Id);
        IEnumerable<LivroAutorDto> ListAll();

    }
}
