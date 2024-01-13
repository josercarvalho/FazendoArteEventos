using Evento.Domain.Entity;

namespace Evento.Domain.Interfaces.Services
{
    public interface IEventoService : IServiceBase<Eventos>
    {
        void AdicionarEvento(Eventos evento);
        void AtualizarCrianca(Eventos evento);
    }
}
