﻿using Kendo.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddKendo(this IServiceCollection services)
        {
            foreach (var service in KendoServices.GetServices())
            {
                services.Add(service);
            }

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            return services;
        }

        public static IServiceCollection AddMobin(this IServiceCollection services)
        {
            foreach (var service in MobinServices.GetServices())
            {
                services.Add(service);
            }

            return services;
        }
    }
}
