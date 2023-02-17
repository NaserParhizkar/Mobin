using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Mobin.Service
{
    public interface ICrudService { }
    public interface ICrudService<TEntity> : ICrudService
    {
        IQueryable<TEntity> GetAllAsQueryable();
        IEnumerable<TEntity> GetAllAsEnumerable();
        TEntity GetEntityByKey<TKey>(TKey key);

        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete<TKey>(TKey key);

        bool ExistsPropertyValue(Expression<Func<TEntity, bool>> exp);
    }
}