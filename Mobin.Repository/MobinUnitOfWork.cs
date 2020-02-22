using Microsoft.EntityFrameworkCore;
using System;

namespace Mobin.Repository
{
    public interface IMobinUnitOfWork : IDisposable
    {
        CrudRepository<TEntity> Repository<TEntity>() where TEntity : class, new();

        void Save();
    }

    public class MobinUnitOfWork<TDbContext> : IMobinUnitOfWork where TDbContext : DbContext
    {
        private bool disposed = false;
        private DbContext context { get; }

        public MobinUnitOfWork(TDbContext dbContext)
        {
            context = dbContext;
        }

        public CrudRepository<TEntity> Repository<TEntity>() where TEntity : class, new()
        {
            return new CrudRepository<TEntity>(context);
        }

        public virtual void Save()
        {
            if (context.SaveChanges() <= 0)
                throw new Exception("Could not save entity");
        }

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
}
