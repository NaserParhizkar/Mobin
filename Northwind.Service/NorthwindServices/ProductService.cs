using Mobin.Service;
using Northwind.Repository;
using System;
using System.Collections.Generic;

namespace Northwind.Service
{
    public interface IProductService : ICrudService<Product>
    {
    }

    public class ProductService : CrudService<Product>, IProductService
    {
        //public CustomerService(IMobinUnitOfWork unitofwork) : base(unitofwork) { }
        private readonly NorthwindUnitOfWork northwindUnitOfWork;

        public ProductService(INorthwindUnitOfWork unitofwork) : base(unitofwork)
            => northwindUnitOfWork = (NorthwindUnitOfWork)unitofwork;
    }
}