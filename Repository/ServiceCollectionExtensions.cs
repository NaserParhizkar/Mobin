﻿using KendoBus;
using Mobin.Repository;
using Northwind;
using PDN;
using System;
using System.Linq;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectRepository(this IServiceCollection services)
        {
            services.AddScoped<NorthwindContext>();
            services.AddTransient<INorthwindUnitOfWork,NorthwindUnitOfWork>();

            services.AddScoped<KendoBusContext>();
            services.AddTransient<IBusUnitOfWork, BusUnitOfWork>();
            
            services.AddScoped<PDNContext>();
            services.AddTransient<PDNUnitOfWork>();

            var busContext = services.BuildServiceProvider().GetService<KendoBusContext>();
            busContext.Database.EnsureCreatedAsync();

            var pdnContext = services.BuildServiceProvider().GetService<PDNContext>();
            pdnContext.Database.EnsureCreatedAsync();


            services.AddTransient<Func<Type, IMobinUnitOfWork>>(serviceProvider => entityType =>
            {
                if (CheckContextHasEntity(typeof(KendoBusContext), entityType))
                    return (IMobinUnitOfWork)serviceProvider.GetService(typeof(BusUnitOfWork));
                else if (CheckContextHasEntity(typeof(PDNContext), entityType))
                    return (IMobinUnitOfWork)serviceProvider.GetService(typeof(PDNUnitOfWork));
                else
                    return (IMobinUnitOfWork)serviceProvider.GetService(typeof(NorthwindUnitOfWork));
            });

            return services;
        }

        /// <summary>
        /// Check entity is a generic property's of dbcontext 
        /// </summary>
        /// <param name="contextType">A dbcontext to search if entityType parameter is generic property's </param>
        /// <param name="entityType">A entity type to search in a properties of dbcontext</param>
        /// <returns></returns>
        private static bool CheckContextHasEntity(Type contextType, Type entityType)
        {
            var props = contextType.GetProperties().Where(y => y.PropertyType.IsGenericType)
                 .Select(p => p.PropertyType.GetGenericArguments()[0]);
            return props.FirstOrDefault(q => q.IsAssignableFrom(entityType)) != null;
        }
    }
}
