using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Mobin.Service
{
    public interface ICrudService<TEntity> 
    {
        IQueryable<TEntity> GetAllAsQueryable();
        IEnumerable<TEntity> GetAllAsEnumerable();

        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);     
        void Delete<TKey>(TKey key);

        TEntity GetEntityByKey<TKey>(TKey key);

        bool ExistsPropertyValue(Expression<Func<TEntity, bool>> exp);
    }
}