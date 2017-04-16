using System;
using Autenticacao.Application.Interfaces;
using Autenticacao.Domain.Interfaces.Services;

namespace Autenticacao.Application
{
    public class AppServiceBase<TEntity> : IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Add(TEntity obj)
        {
            _serviceBase.Add(obj);
        }

        public void Delete(TEntity obj)
        {
            _serviceBase.Delete(obj);
        }

        public System.Collections.Generic.IEnumerable<TEntity> Find(Func<TEntity, bool> expr)
        {
            return _serviceBase.Find(expr);
        }

        public TEntity Get(Func<TEntity, bool> expr)
        {
            return _serviceBase.Get(expr);
        }

        public System.Collections.Generic.IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public void Update(TEntity obj)
        {
            _serviceBase.Update(obj);
        }
    }
}
