using DesafioTJ.Application.Dtos;

namespace DesafioTJ.Application.Interfaces
{
    public interface IAutorService
    {
        Task<AutorDto> Create(AutorDto autor);
        Task<AutorDto> Read(int Id);
        Task<AutorDto> Update(AutorDto autor);
        Task<AutorDto> Delete(int Id);
        Task<IEnumerable<AutorDto>> ListAll();

    }
}
