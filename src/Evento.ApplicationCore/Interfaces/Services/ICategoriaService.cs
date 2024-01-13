using Evento.Domain.Entity;

namespace Evento.Domain.Interfaces.Services
{
    public interface ICategoriaService : IServiceBase<Categoria>
    {
        void AdicionarCategoria(Categoria categoria);
        void AtualizarCategoria(Categoria categoria);
    }
}
