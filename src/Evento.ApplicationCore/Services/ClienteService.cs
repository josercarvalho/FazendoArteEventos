using Evento.Domain.Entity;
using Evento.Domain.Interfaces.Repository;
using Evento.Domain.Interfaces.Services;

namespace Evento.Domain.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        private readonly IClienteRepository _servCliente;
        public ClienteService(IClienteRepository repository) : base(repository)
        {
            _servCliente = repository;
        }

        public void AdicionarCliente(Cliente cliente)
        {
            bool valido = cliente.ValidarPropriedadeString(cliente.Nome, "Nome");

            if (valido)
            {
                _servCliente.Adicionar(cliente);
            }
        }

        public void AtualizarCliente(Cliente cliente)
        {
            bool valido = cliente.ValidarPropriedadeString(cliente.Nome, "Nome");

            if (valido)
            {
                _servCliente.Atualizar(cliente);
            }
        }
    }
}
