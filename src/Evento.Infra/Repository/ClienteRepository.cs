using Evento.Domain.Entity;
using Evento.Domain.Interfaces.Repository;
using Evento.Infra.Data;
using System.Collections.Generic;

namespace Evento.Infra.Repository
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(Contexto dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Cliente> ListarPorEvento(int evento)
        {
            return Buscar(x => x.Inscricoes.Equals(evento));
        }
    }
}
