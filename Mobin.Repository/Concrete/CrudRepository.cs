using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Mobin.Repository
{
    public class CrudRepository<TEntity> : ICrudRepository<TEntity> where TEntity : class,new()
    {
        internal DbContext context;
        internal DbSet<TEntity> dbset;

        protected internal CrudRepository(DbContext dbContext)
        {
            context = dbContext;
            dbset = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return dbset.AsQueryable();   
        }

        public virtual void Insert(TEntity entity)
        {
            dbset.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            dbset.Update(entity);
            context.Entry(entity).State = EntityState.Modified;
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
            return  dbset.Find(key);
        }

        public virtual bool ExistsPropertyValue(Expression<Func<TEntity, bool>> exp)
        {
            return (this.dbset.FirstOrDefault(exp) != null);
        }
    }
}