using Mobin.Repository;
using Mobin.Service;
using Northwind.Repository;
using System;
using System.Linq;

namespace Northwind.Service
{
    public interface ICategoryService : ICrudService<Category>
    {
    }

    public class CategoryService : CrudService<Category>, ICategoryService
    {
        //public CustomerService(IMobinUnitOfWork unitofwork) : base(unitofwork) { }
        private readonly NorthwindUnitOfWork northwindUnitOfWork;

        public CategoryService(INorthwindUnitOfWork unitofwork) : base(unitofwork)
            => northwindUnitOfWork = (NorthwindUnitOfWork)unitofwork;

        public override IQueryable<Category> GetAllAsQueryable()
        {
            return base.GetAllAsQueryable();
        }
    }
}