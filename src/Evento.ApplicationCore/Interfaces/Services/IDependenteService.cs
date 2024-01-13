using Evento.Domain.Entity;

namespace Evento.Domain.Interfaces.Services
{
    public interface IDependenteService : IServiceBase<Dependente>
    {
        void AdicionarCrianca(Dependente dependente);
        void AtualizarCrianca(Dependente dependente);
    }
}
