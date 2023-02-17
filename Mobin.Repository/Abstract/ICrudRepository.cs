using Microsoft.EntityFrameworkCore.ChangeTracking;
using Mobin.Common.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Mobin.Repository
{
    public interface ICrudRepository<TEntity> 
        where TEntity : MobinBaseEntity
    {
        TEntity GetEntityByKey<TKey>(TKey key);
        IQueryable<TEntity> GetAll();

        EntityEntry<TEntity> Insert(TEntity entity);
        EntityEntry<TEntity> Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete<TKey>(TKey key);

        bool ExistsPropertyValue(Expression<Func<TEntity, bool>> exp);
    }
}