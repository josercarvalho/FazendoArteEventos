using Evento.Domain.Interfaces.Repository;
using Evento.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Evento.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity>, IDisposable where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;
        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public TEntity Adicionar(TEntity entity)
        {
            return _repository.Adicionar(entity);
        }

        public void Atualizar(TEntity entity)
        {
            _repository.Atualizar(entity);
        }

        public IEnumerable<TEntity> Buscar(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicado)
        {
            return _repository.Buscar(predicado);
        }

        public TEntity ObterPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public void Remover(TEntity entity)
        {
            _repository.Remover(entity);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
