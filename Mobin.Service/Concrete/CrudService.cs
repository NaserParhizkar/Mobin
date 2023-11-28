using Mobin.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Mobin.Service
{
    public class CrudService<TEntity> : ICrudService<TEntity> where TEntity : class, new()
    {
        protected readonly IMobinUnitOfWork mobinUnitOfWork;

        //public CrudService(IMobinUnitOfWork unitofwork):this(delegate(Type type) { return unitofwork; })
        //{
        //    mobinUnitOfWork = unitofwork;
        //}

        public CrudService(Func<Type, IMobinUnitOfWork> unitofwork)
        {
            mobinUnitOfWork = unitofwork(typeof(TEntity));
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

        public virtual TEntity Insert(TEntity entity)
        {
            return mobinUnitOfWork.Repository<TEntity>().Insert(entity).Entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            return mobinUnitOfWork.Repository<TEntity>().Update(entity).Entity;
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