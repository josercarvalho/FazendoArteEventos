using Evento.Domain.Entity;
using Evento.Domain.Interfaces.Repository;
using Evento.Infra.Data;
using System.Collections.Generic;

namespace Evento.Infra.Repository
{
    public class InscricaoRepository : RepositoryBase<Inscricao>, IInscricaoRepository
    {
        public InscricaoRepository(Contexto dbContext) : base(dbContext)
        {
        }

        //public IEnumerable<Inscricao> ListarPorCategoria(string categoria)  
        //{
        //    return Buscar(x => x.Categoria.Equals(categoria));
        //}

        public IEnumerable<Inscricao> ListarPorEvento(string evento)
        {
            return Buscar(x => x.Eventos.Equals(evento));
        }

        public IEnumerable<Inscricao> ListarPorTipoPagamento(int tipo)
        {
            return Buscar(x => x.Periodo.Equals(tipo));
        }
    }
}
