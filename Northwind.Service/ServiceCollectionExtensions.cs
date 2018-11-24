using Microsoft.EntityFrameworkCore;
using Northwind.Repository;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNorthwindService(this IServiceCollection services)
        {
            services.AddNorthwindRepository();
            return services;
        }
    }
}
