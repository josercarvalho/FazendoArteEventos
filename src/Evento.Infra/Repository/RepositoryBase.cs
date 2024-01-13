using Evento.Domain.Interfaces.Repository;
using Evento.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Evento.Infra.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T>, IDisposable where T : class
    {
        protected readonly Contexto _dbContext;

        public RepositoryBase(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual T Adicionar(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public virtual void Atualizar(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public IEnumerable<T> Buscar(Expression<Func<T, bool>> predicado)
        {
            return _dbContext.Set<T>().Where(predicado).AsEnumerable();
        }

        public virtual T ObterPorId(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> ObterTodos()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }

        public void Remover(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
