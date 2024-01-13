using Evento.Domain.Entity;
using System.Collections.Generic;

namespace Evento.Domain.Interfaces.Repository
{
    public interface IInscricaoRepository : IRepositoryBase<Inscricao>
    {
        //IEnumerable<Inscricao> ListarPorCategoria(string categoria);

        IEnumerable<Inscricao> ListarPorEvento(string evento);

        IEnumerable<Inscricao> ListarPorTipoPagamento(int tipo);
    }
}
