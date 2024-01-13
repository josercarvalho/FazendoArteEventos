using Evento.Domain.Entity;

namespace Evento.Domain.Interfaces.Services
{
    public interface IClienteService : IServiceBase<Cliente>
    {
        void AdicionarCliente(Cliente cliente);
        void AtualizarCliente(Cliente cliente);
    }
}
