using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Mobin.Repository
{
    public class CrudRepository<TEntity> : ICrudRepository<TEntity> where TEntity : class, new()
    {
        private DbContext context;
        private DbSet<TEntity> dbset;

        protected internal CrudRepository(DbContext dbContext)
        {
            context = dbContext;
            dbset = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return dbset.AsQueryable();
        }

        public virtual EntityEntry<TEntity> Insert(TEntity entity)
        {
            var entityEntry = dbset.Add(entity);
            context.Entry(entity).State = EntityState.Added;
            return entityEntry;
        }

        public virtual EntityEntry<TEntity> Update(TEntity entity)
        {
            var entityEntry = dbset.Update(entity);
            context.Entry(entity).State = EntityState.Modified;
            return entityEntry;
        }

        public virtual void Delete(TEntity entity)
        {
            dbset.Remove(entity);
            context.Entry(entity).State = EntityState.Deleted;
        }

        public virtual void Delete<TKey>(TKey key)
        {
            var entity = dbset.Find(key);
            dbset.Remove(entity);
        }

        public virtual TEntity GetEntityByKey<TKey>(TKey key)
        {
            return dbset.Find(key);
        }

        public virtual bool ExistsPropertyValue(Expression<Func<TEntity, bool>> exp)
        {
            return (this.dbset.FirstOrDefault(exp) != null);
        }
    }
}