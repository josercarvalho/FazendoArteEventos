using Evento.Domain.Entity;
using System.Collections.Generic;

namespace Evento.Domain.Interfaces.Repository
{
    public interface IDependenteRepository : IRepositoryBase<Dependente>
    {
        IEnumerable<Dependente> ListarPorCliente(int dependente);
    }
}
