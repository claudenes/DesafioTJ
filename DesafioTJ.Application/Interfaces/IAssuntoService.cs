using DesafioTJ.Application.Dtos;

namespace DesafioTJ.Application.Interfaces
{
    public interface IAssuntoService
    {
        Task<AssuntoDto> Create(AssuntoDto assunto);
        Task<AssuntoDto> Read(int Id);
        Task<AssuntoDto> Update(AssuntoDto assunto);
        Task<AssuntoDto> Delete(int Id);
        Task<IEnumerable<AssuntoDto>> ListAll();

    }
}
