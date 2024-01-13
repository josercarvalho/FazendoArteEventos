using Evento.Domain.Entity;
using Evento.Domain.Interfaces.Repository;
using Evento.Infra.Data;

namespace Evento.Infra.Repository
{
    public class EventoRepository : RepositoryBase<Eventos>, IEventoRepository
    {
        public EventoRepository(Contexto dbContext) : base(dbContext)
        {
        }
    }
}
