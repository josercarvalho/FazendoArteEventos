using Evento.Domain.Entity;
using Evento.Domain.Interfaces.Repository;
using Evento.Domain.Interfaces.Services;

namespace Evento.Domain.Services
{
    public class DependenteService : ServiceBase<Dependente>, IDependenteService
    {
        private readonly IDependenteRepository _servCrianca;
        public DependenteService(IDependenteRepository repository) : base(repository)
        {
            _servCrianca = repository;
        }

        public void AdicionarCrianca(Dependente crianca)
        {
            bool valido = crianca.ValidarPropriedadeString(crianca.Nome, "Nome");

            if (valido)
            {
                _servCrianca.Adicionar(crianca);
            }
        }
        
        public void AtualizarCrianca(Dependente crianca)
        {
            bool valido = crianca.ValidarPropriedadeString(crianca.Nome, "Nome");

            if (valido)
            {
                _servCrianca.Atualizar(crianca);
            }
        }

    }
}
