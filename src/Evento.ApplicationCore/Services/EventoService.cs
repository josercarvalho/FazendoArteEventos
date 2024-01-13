using Evento.Domain.Entity;
using Evento.Domain.Interfaces.Repository;
using Evento.Domain.Interfaces.Services;

namespace Evento.Domain.Services
{
    public class EventoService : ServiceBase<Eventos>, IEventoService
    {
        private readonly IEventoRepository _servEvento;
        public EventoService(IEventoRepository repository) : base(repository)
        {
            _servEvento = repository;
        }

        public void AdicionarEvento(Eventos evento)
        {
            bool valido = evento.ValidarPropriedadeString(evento.Nome, "Nome");

            if (valido)
            {
                _servEvento.Adicionar(evento);
            }
        }

        public void AtualizarCrianca(Eventos evento)
        {
            bool valido = evento.ValidarPropriedadeString(evento.Nome, "Nome");

            if (valido)
            {
                _servEvento.Atualizar(evento);
            }
        }
    }
}
