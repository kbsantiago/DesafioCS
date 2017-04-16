using Autenticacao.Domain.Interfaces.Repositories;
using Autenticacao.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Autenticacao.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        protected readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

        public void Delete(TEntity obj)
        {
            _repository.Delete(obj);
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> expresssion)
        {
            return _repository.Find(expresssion);
        }

        public TEntity Get(Func<TEntity, bool> expresssion)
        {
            return _repository.Get(expresssion);
        }
        public void Dispose()
        {
            //_repository.Dispose();
        }

    }
}
