using Evento.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.Aplication.Interfaces
{
    public interface ICategoriaApp : IGerenciaApp<Categoria>
    {
        IList<Categoria> ListarCategoriasPorEvento(int evento);

        void AdicionarCategoria(Categoria categoria);
        void AtualizarCategoria(Categoria categoria);
    }
}
