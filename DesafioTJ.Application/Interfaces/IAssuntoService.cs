using DesafioTJ.Domain.Entities;

namespace Ambev.Application.Interfaces
{
    public interface IAssuntoService
    {
        AssuntoDto Create(AssuntoDto assunto);
        AssuntoDto Read(int Id);
        AssuntoDto Update(AssuntoDto assunto);
        AssuntoDto Delete(int Id);
        IEnumerable<AssuntoDto> ListAll();

    }
}
