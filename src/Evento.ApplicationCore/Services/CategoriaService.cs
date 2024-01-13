using Evento.Domain.Entity;
using Evento.Domain.Interfaces.Repository;

namespace Evento.Domain.Services
{
    public class CategoriaService : ServiceBase<Categoria>, Interfaces.Services.ICategoriaService
    {
        private readonly ICategoriaRepository _servCategoria;
        public CategoriaService(ICategoriaRepository repository) : base(repository)
        {
            _servCategoria = repository;
        }

        public void AdicionarCategoria(Categoria categoria)
        {
            bool valido = categoria.ValidarPropriedadeString(categoria.Descricao, "Descricao");

            if (valido)
            {
                _servCategoria.Adicionar(categoria);
            }
        }

        public void AtualizarCategoria(Categoria categoria)
        {
            bool valido = categoria.ValidarPropriedadeString(categoria.Descricao, "Descricao");

            if (valido)
            {
                _servCategoria.Atualizar(categoria);
            }
        }
    }
}
