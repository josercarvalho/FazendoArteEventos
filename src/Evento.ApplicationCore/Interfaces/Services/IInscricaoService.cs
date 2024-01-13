using Evento.Domain.Entity;
using System.Collections.Generic;

namespace Evento.Domain.Interfaces.Services
{
    public interface IInscricaoService : IServiceBase<Inscricao>
    {
        void AdicionarInscricao(Inscricao inscricao);
        void AtualizarInscricao(Inscricao inscricao);

        IEnumerable<Inscricao> ListarPorLocal(int local);
        IEnumerable<Inscricao> ListarPorCategoria(int categoria);
    }
}
