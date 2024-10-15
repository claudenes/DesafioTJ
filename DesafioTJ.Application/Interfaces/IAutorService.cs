using DesafioTJ.Domain.Entities;

namespace DesafioTJ.Application.Interfaces
{
    public interface IAutorService
    {
        AutorDto Create(AutorDto autor);
        AutorDto Read(int Id);
        AutorDto Update(AutorDto autor);
        AutorDto Delete(int Id);
        IEnumerable<AutorDto> ListAll();

    }
}
