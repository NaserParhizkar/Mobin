using Mobin.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Mobin.ExpressionJsonSerializer;
using Mobin.Common;

namespace Mobin.Service
{
    public class CrudService<TEntity> : ICrudService<TEntity> where TEntity : class, new()
    {
        protected readonly IMobinUnitOfWork mobinUnitOfWork;

        public CrudService(IMobinUnitOfWork unitofwork)
        {
            mobinUnitOfWork = unitofwork;
        }

        public virtual TEntity GetEntityByKey<TKey>(TKey key)
        {
            return mobinUnitOfWork.Repository<TEntity>().GetEntityByKey(key);
        }

        public virtual IQueryable<TEntity> GetAllAsQueryable()
        {
            return mobinUnitOfWork.Repository<TEntity>().GetAll();
        }

        public virtual IEnumerable<TEntity> GetAllAsEnumerable()
        {
            return mobinUnitOfWork.Repository<TEntity>().GetAll().AsEnumerable();
        }

        public virtual void Insert(TEntity entity)
        {
            mobinUnitOfWork.Repository<TEntity>().Insert(entity);
        }

        public virtual void Update(TEntity entity)
        {
            mobinUnitOfWork.Repository<TEntity>().Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            mobinUnitOfWork.Repository<TEntity>().Delete(entity);
        }

        public virtual void Delete<TKey>(TKey key)
        {
            mobinUnitOfWork.Repository<TEntity>().Delete(key);
        }

        public virtual bool ExistsPropertyValue(Expression<Func<TEntity, bool>> exp)
        {
            return mobinUnitOfWork.Repository<TEntity>().ExistsPropertyValue(exp);
        }
    }
}