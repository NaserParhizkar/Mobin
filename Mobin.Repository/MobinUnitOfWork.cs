using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Mobin.Repository
{
    public interface IMobinUnitOfWork : IDisposable
    {
        CrudRepository<TEntity> Repository<TEntity>() where TEntity: class,new();
    }

    public class MobinUnitOfWork<TDbContext> : IMobinUnitOfWork where TDbContext : DbContext
    {
        public bool disposed = false;
        DbContext context { get; }

        public MobinUnitOfWork(TDbContext dbContext)
        {
            context = dbContext;
        }

        public CrudRepository<TEntity> Repository<TEntity>() where TEntity : class,new()
        {
            return new CrudRepository<TEntity>(context);
        }

        protected virtual void Save()
        {
            context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
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

    public static class FactoryContextGenerator<TDbContext> where TDbContext : DbContext
    {
        //public static MobinUnitOfWork<TDbContext> CreateContext()
        //{
        //    IServiceCollection serviceCollection = new ServiceDescriptor(null, null, new ServiceLifetime());
        //    serviceCollection.AddTransient()
        //}
    }


    //class MyFactory<TDbContext> : Microsoft.EntityFrameworkCore.Design.IDesignTimeDbContextFactory<TDbContext>
    //    where TDbContext : DbContext
    //{
    //    //public TDbContext CreateDbContext(string[] args)
    //    //{
    //    //    Microsoft.EntityFrameworkCore.Internal.DbContextDependencies dbContextDependencies =
    //    //        new Microsoft.EntityFrameworkCore.Internal.DbContextDependencies();


    //    //}
    //}

    class M<T> : Microsoft.EntityFrameworkCore.Infrastructure.ISingletonOptions
    {
        public void Initialize(IDbContextOptions options)
        {
            
        }

        public void Validate(IDbContextOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
