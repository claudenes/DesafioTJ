using DesafioTJ.Domain.Entities;
using DesafioTJ.Domain.Interfaces;
using DesafioTJ.Infra.Data.Context;
using DesafioTJ.Infra.Data.Repositories;

namespace Ambev.Infra.Data.Repositories
{
    public class LivroRepository : ResourceRepository<Livro>, ILivroRepository
    {
        public LivroRepository(ApplicationDbContext context) : base(context) { }
    }
}
