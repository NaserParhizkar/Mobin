using Mobin.Repository;
using Mobin.Service;
using Northwind.Repository;
using System;
using System.Linq;
using Mobin.Common;

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
            var aa = mobinUnitOfWork.Repository<Customer>().GetAll().Select(p =>
                 new { p.CustomerId, Reverse = p.Orders.Where(t => t.OrderDate != null)
                 .Select(t => new { date = t.OrderDate.Value.GetPersianDate("yyyy/MM/dd") + " " + t.CustomerId }) });

            var asdasdasd = aa.ToList();


            return mobinUnitOfWork.Repository<Order>().GetAll().Select(t => new
            {
                OrderDate = t.OrderDate
            });
        }
    }

    public static class A
    {
        public static string GetReverse(this string value)
        {
            var stringChar = value.AsEnumerable();
            return string.Concat(stringChar.Reverse());
        }
    }
}