using Evento.Aplication.Interfaces;
using Evento.Domain.Entity;
using Evento.Domain.Interfaces.Repository;
using Evento.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Evento.Aplication.App
{
    public class CategoriaApp : ICategoriaApp
    {
        private readonly ICategoriaRepository _appCategoria;
        private readonly ICategoriaService _srvCategoria;

        public CategoriaApp(ICategoriaRepository appCategoria, ICategoriaService srvCategoria)
        {
            _appCategoria = appCategoria;
            _srvCategoria = srvCategoria;
        }

        public Categoria Adicionar(Categoria entity)
        {
            _srvCategoria.Adicionar(entity);
            return entity;
        }        

        public void Atualizar(Categoria entity)
        {
            throw new NotImplementedException();
        }        

        public IEnumerable<Categoria> Buscar(Expression<Func<Categoria, bool>> predicado)
        {
            throw new NotImplementedException();
        }

        

        

        public Categoria ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categoria> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Categoria entity)
        {
            throw new NotImplementedException();
        }

        #region Customizados 
        public IList<Categoria> ListarCategoriasPorEvento(int evento)
        {
            throw new NotImplementedException();
        }

        public void AdicionarCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public void AtualizarCategoria(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        #endregion

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
