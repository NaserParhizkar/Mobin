using Microsoft.Extensions.DependencyInjection;
using Mobin.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMobinService(this IServiceCollection services)
        {
            services.AddTransient<ICrudService,CrudService>(serviceProvider 
                => 
            {
                return null;
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
