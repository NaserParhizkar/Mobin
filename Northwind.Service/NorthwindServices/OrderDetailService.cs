using Mobin.Service;
using Northwind.Repository;
using System.Linq;

namespace Northwind.Service
{
    public interface IOrderDetailService : ICrudService<OrderDetail>
    {
    }

    public class OrderDetailService : CrudService<OrderDetail>, IOrderDetailService
    {
        //public CustomerService(IMobinUnitOfWork unitofwork) : base(unitofwork) { }
        private readonly NorthwindUnitOfWork northwindUnitOfWork;

        public OrderDetailService(INorthwindUnitOfWork unitofwork) : base(unitofwork)
            => northwindUnitOfWork = (NorthwindUnitOfWork)unitofwork;

        public override IQueryable<OrderDetail> GetAllAsQueryable()
        {
            return base.GetAllAsQueryable();
        }
    }
}