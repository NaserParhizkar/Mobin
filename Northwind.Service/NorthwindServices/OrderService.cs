using Mobin.Service;
using Northwind.Repository;
using System;

namespace Northwind.Service
{
    public interface IOrderService : ICrudService<Order>
    {
    }

    public class OrderService : CrudService<Order>, IOrderService
    {
        //public CustomerService(IMobinUnitOfWork unitofwork) : base(unitofwork) { }
        private readonly NorthwindUnitOfWork northwindUnitOfWork;

        public OrderService(INorthwindUnitOfWork unitofwork) : base(unitofwork)
            => northwindUnitOfWork = (NorthwindUnitOfWork)unitofwork;
    }
}