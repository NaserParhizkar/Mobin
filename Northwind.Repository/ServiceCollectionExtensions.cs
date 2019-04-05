using Microsoft.Extensions.DependencyInjection;
using Mobin.Repository;

namespace Northwind.Repository
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNorthwindRepository(this IServiceCollection services)
        {
            services.AddScoped<NorthwindContext>();
            services.AddTransient<IMobinUnitOfWork,MobinUnitOfWork<NorthwindContext>>();
            return services;
        }
    }
}
