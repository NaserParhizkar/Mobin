﻿using Microsoft.EntityFrameworkCore;
using Mobin.Common.Entities;
using System;

namespace Mobin.Repository
{
    public interface IMobinUnitOfWork : IDisposable
    {
        CrudRepository<TEntity> Repository<TEntity>() where TEntity : MobinBaseEntity;

        int Commit();
    }

    public interface IMobinUnitOfWork<TDbContext> : IMobinUnitOfWork
        where TDbContext : DbContext
    {
        //TDbContext Context { get; }
    }

    public abstract class MobinUnitOfWork<TDbContext> : IMobinUnitOfWork<TDbContext>, IMobinUnitOfWork where TDbContext : DbContext
    {
        private bool disposed = false;
        private DbContext context { get; }

        protected MobinUnitOfWork(TDbContext dbContext) => context = dbContext;

        public virtual int Commit() => context.SaveChanges();

        public CrudRepository<TEntity> Repository<TEntity>() 
            where TEntity : MobinBaseEntity => new CrudRepository<TEntity>(context);

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                    context.Dispose();
            disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }


    //public interface IRepository<T> : IDisposable where T : class
    //{
    //    IQueryable<T> Query(string sql, params object[] parameters);

    //    T Search(params object[] keyValues);

    //    T Single(Expression<Func<T, bool>> predicate = null,
    //        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
    //        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
    //        bool disableTracking = true);

    //    void Add(T entity);
    //    void Add(params T[] entities);
    //    void Add(IEnumerable<T> entities);


    //    void Delete(T entity);
    //    void Delete(object id);
    //    void Delete(params T[] entities);
    //    void Delete(IEnumerable<T> entities);


    //    void Update(T entity);
    //    void Update(params T[] entities);
    //    void Update(IEnumerable<T> entities);
    //}



}
