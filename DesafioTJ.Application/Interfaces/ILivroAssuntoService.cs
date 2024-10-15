using DesafioTJ.Application.Dtos;

namespace DesafioTJ.Application.Interfaces
{
    public interface ILivroAssuntoService
    {
        LivroAssuntoDto Create(LivroAssuntoDto livroAssunto);
        LivroAssuntoDto Read(int Id);
        LivroAssuntoDto Update(LivroAssuntoDto livroAssunto);
        LivroAssuntoDto Delete(int Id);
        IEnumerable<LivroAssuntoDto> ListAll();

    }
}
