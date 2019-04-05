using Microsoft.EntityFrameworkCore;
using Mobin.Repository;
using Mobin.Service;
using Northwind.Repository;
using Northwind.Repository.EntityModels;
using System;
using System.Linq;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNorthwindService(this IServiceCollection services)
        {
            services.AddNorthwindRepository();
            services.AddTransient(typeof(ICustomerService), typeof(CustomerService));
            return services;
        }
    }

    public interface ICustomerService : ICrudService<Customer>
    {
        IQueryable<object> GetCustomersOrderInfo();
    }

    public class CustomerService : CrudService<Customer>, ICustomerService
    {
        public CustomerService(IMobinUnitOfWork unitofwork) : base(unitofwork)
        {
        }

        public override IQueryable<Customer> GetAllAsQueryable()
        {
            var query = mobinUnitOfWork.Repository<Customer>().GetAll();
            var ordersIncludedQuery = query.Include(t => t.Orders);

            return ordersIncludedQuery;
        }

        public IQueryable<object> GetCustomersOrderInfo()
        {
            var ordersQuery = mobinUnitOfWork.Repository<Order>().GetAll();

            var customersOrderInfoQuery = ordersQuery.Select(t => new
            {
                Customer = new
                {
                    CustomerId = t.CustomerId,
                    CompanyName = t.Customer.CompanyName,
                    Country = t.Customer.Country,
                    City = t.Customer.City
                },
                OrderDate = t.OrderDate
            });

            return customersOrderInfoQuery;
        }
    }
}
