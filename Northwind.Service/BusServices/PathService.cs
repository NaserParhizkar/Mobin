
using KendoBus;
using KendoBus.Repository;
using Mobin.Repository;
using Mobin.Service;
using System;
using System.Linq;

namespace Northwind.Service
{
    public interface IPathService : ICrudService<Path> {}

    public class PathService : CrudService<Path>, IPathService
    {
        private readonly BusUnitOfWork busUnitOfWork;

        public PathService(IBusUnitOfWork unitofwork) : base(unitofwork)
          => busUnitOfWork = (BusUnitOfWork)unitofwork;

        public override IQueryable<Path> GetAllAsQueryable()
        {
            return base.GetAllAsQueryable();
        }
    }
}