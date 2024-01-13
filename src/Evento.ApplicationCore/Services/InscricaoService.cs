using Evento.Domain.Entity;
using Evento.Domain.Interfaces.Repository;
using Evento.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Evento.Domain.Services
{
    public class InscricaoService : ServiceBase<Inscricao>, IInscricaoService
    {
        private readonly IInscricaoRepository _servInscricao;
        public InscricaoService(IInscricaoRepository repository) : base(repository)
        {
            _servInscricao = repository;
        }

        public void AdicionarInscricao(Inscricao inscricao)
        {
            bool valido = inscricao.ValidarPropriedadeString(inscricao.FicouSabendo, "FicouSabendo");

            if (valido)
            {
                _servInscricao.Adicionar(inscricao);
            }
        }

        public void AtualizarInscricao(Inscricao inscricao)
        {
            bool valido = inscricao.ValidarPropriedadeString(inscricao.FicouSabendo, "FicouSabendo");

            if (valido)
            {
                _servInscricao.Atualizar(inscricao);
            }
        }

        public IEnumerable<Inscricao> ListarPorCategoria(int categoria)
        {
            return Buscar(x => x.InscricoesEventos.Equals(categoria));
        }

        public IEnumerable<Inscricao> ListarPorLocal(int local)
        {
            return Buscar(x => x.InscricoesEventos.Equals(local));
        }
    }
}
