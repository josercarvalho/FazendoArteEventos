using Evento.Domain.Entity;
using System.Collections.Generic;

namespace Evento.Domain.Interfaces.Repository
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        IEnumerable<Cliente> ListarPorEvento(int evento);
    }
}
