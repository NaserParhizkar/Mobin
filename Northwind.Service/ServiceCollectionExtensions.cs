using Northwind.Service;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectService(this IServiceCollection services)
        {
            services.AddProjectRepository();
            services.AddTransient(typeof(ICustomerService), typeof(CustomerService));
            services.AddTransient(typeof(ICategoryService), typeof(CategoryService));

            services.AddTransient(typeof(IPathService), typeof(PathService));

            return services;
        }
    }
}
