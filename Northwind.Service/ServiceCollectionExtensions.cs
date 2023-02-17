using Mobin.Repository;
using Mobin.Service;
using Northwind;
using Northwind.Repository;
using Northwind.Service;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectService(this IServiceCollection services)
        {
            //services.AddMobinService();

            services.AddProjectRepository();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderDetailService, OrderDetailService>();
            services.AddTransient<IPathService, PathService>();
 
            

            //services.AddTransient(typeof(CrudService<Product>), serviceProvider =>
            //               serviceProvider.GetService<NorthwindUnitOfWork>());

            //services.AddTransient<ICrudService<Product>, CrudService<Product>>();
          


            //services.AddTransient<IPathService,PathService>();

            return services;
        }
    }
}
