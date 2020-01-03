using Mobin.Repository;
using Mobin.Service;
using Northwind.Repository;
using System;
using System.Linq;

namespace Northwind.Service
{
    public interface ICustomerService : ICrudService<Customer>
    {
        IQueryable<object> GetCustomersOrderInfo();
    }

    public class CustomerService : CrudService<Customer>, ICustomerService
    {
        //public CustomerService(IMobinUnitOfWork unitofwork) : base(unitofwork) { }

        public CustomerService(Func<Type, IMobinUnitOfWork> unitofwork) : base(unitofwork)
        {
        }

        public override IQueryable<Customer> GetAllAsQueryable()
        {
            return base.GetAllAsQueryable();
        }

        public IQueryable<object> GetCustomersOrderInfo()
        {
            return mobinUnitOfWork.Repository<Order>().GetAll().Select(t => new
            {
                OrderDate = t.OrderDate
            });
        }
    }
}