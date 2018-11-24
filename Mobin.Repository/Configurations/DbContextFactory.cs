using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;


namespace Repository.Configurations
{
    internal class DbContextFactory<TContext> : IDesignTimeDbContextFactory<TContext> where TContext : DbContext, new()
    {
        private DbContext context = null;
        //internal DbContextFactory()
        //{
        //    context = new TContext();
        //    this.context.Configuration.LazyLoadingEnabled = false;
        //    this.context.Configuration.ProxyCreationEnabled = false;
        //}

        internal DbContextFactory(DbContextOptions dbContextOptions)
        {
            if (typeof (TContext) == typeof (DbContext))
                context = new DbContext(dbContextOptions);
            else
                context = new TContext();
        }

        public TContext CreateDbContext(string[] args)
        {
            return context as TContext;
        }
    }
}
