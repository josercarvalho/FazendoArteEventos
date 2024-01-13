using Evento.Domain.Interfaces.Repository;
using Evento.Infra.Data;

namespace Evento.Infra.Repository
{
    public class CategoriaRepository : RepositoryBase<Domain.Entity.Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(Contexto dbContext) : base(dbContext)
        {
        }
    }
}
