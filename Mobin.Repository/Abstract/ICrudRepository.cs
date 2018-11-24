using System;
using System.Linq;
using System.Linq.Expressions;

namespace Mobin.Repository
{
    public interface ICrudRepository<TEntity>
    {
        TEntity GetEntityByKey<TKey>(TKey key);
        IQueryable<TEntity> GetAll();

        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);     
        void Delete<TKey>(TKey key);

        bool ExistsPropertyValue(Expression<Func<TEntity, bool>> exp);
    }
}