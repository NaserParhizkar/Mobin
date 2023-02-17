using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Mobin.Common.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Mobin.Repository
{
    public class CrudRepository<TEntity> : ICrudRepository<TEntity> 
        where TEntity : MobinBaseEntity
    {
        private DbContext context;
        private DbSet<TEntity> dbset;

        protected internal CrudRepository(DbContext dbContext)
        {
            context = dbContext;
            dbset = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll() => dbset.AsQueryable();
        public virtual TEntity GetEntityByKey<TKey>(TKey key) => dbset.Find(key);

        public virtual EntityEntry<TEntity> Insert(TEntity entity) => dbset.Add(entity);

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

        public virtual bool ExistsPropertyValue(Expression<Func<TEntity, bool>> exp)
            => (this.dbset.FirstOrDefault(exp) != null);
    }
}