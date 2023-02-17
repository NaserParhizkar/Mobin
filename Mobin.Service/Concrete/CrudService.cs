using Mobin.Common.Entities;
using Mobin.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Mobin.Service
{
    public abstract class CrudService : ICrudService 
    {
        protected readonly IMobinUnitOfWork mobinUnitOfWork;
        public CrudService(IMobinUnitOfWork unitofwork) => mobinUnitOfWork = unitofwork;
    }

    public abstract class CrudService<TEntity> : CrudService,ICrudService<TEntity>
        where TEntity : MobinBaseEntity
    {
        //public CrudService(IMobinUnitOfWork unitofwork):this(delegate(Type type) { return unitofwork; })
        //{
        //    mobinUnitOfWork = unitofwork;
        //}

        public CrudService(IMobinUnitOfWork unitofwork):base(unitofwork) { }

        public virtual TEntity GetEntityByKey<TKey>(TKey key)
            => mobinUnitOfWork.Repository<TEntity>().GetEntityByKey(key);

        public virtual IQueryable<TEntity> GetAllAsQueryable()
            => mobinUnitOfWork.Repository<TEntity>().GetAll();

        public virtual IEnumerable<TEntity> GetAllAsEnumerable()
            => mobinUnitOfWork.Repository<TEntity>().GetAll().AsEnumerable();

        public virtual TEntity Insert(TEntity entity)
        {
            var insertedEntity = mobinUnitOfWork.Repository<TEntity>().Insert(entity).Entity;
            mobinUnitOfWork.Commit();
            return insertedEntity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            var editedEntity = mobinUnitOfWork.Repository<TEntity>().Update(entity).Entity;
            mobinUnitOfWork.Commit();
            return editedEntity;
        }

        public virtual void Delete(TEntity entity)
        {
            mobinUnitOfWork.Repository<TEntity>().Delete(entity);
            mobinUnitOfWork.Commit();
        }

        public virtual void Delete<TKey>(TKey key)
        {
            mobinUnitOfWork.Repository<TEntity>().Delete(key);
            mobinUnitOfWork.Commit();
        }

        public virtual bool ExistsPropertyValue(Expression<Func<TEntity, bool>> exp)
            => mobinUnitOfWork.Repository<TEntity>().ExistsPropertyValue(exp);
    }
}