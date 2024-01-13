using Evento.Domain.Entity;
using Evento.Domain.Interfaces.Repository;
using Evento.Infra.Data;
using System.Collections.Generic;

namespace Evento.Infra.Repository
{
    public class DependenteRepository : RepositoryBase<Dependente>, IDependenteRepository
    {
        public DependenteRepository(Contexto dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Dependente> ListarPorCliente(int dependente)
        {
            return Buscar(x => x.DependenteId.Equals(dependente));
        }
    }
}
