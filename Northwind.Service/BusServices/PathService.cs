
using KendoBus.Repository;
using Mobin.Repository;
using Mobin.Service;
using System;
using System.Linq;

namespace Northwind.Service
{
    public interface IPathService : ICrudService<Path>
    {
    }

    public class PathService : CrudService<Path>, IPathService
    {
        public PathService(Func<Type, IMobinUnitOfWork> unitofwork) : base(unitofwork)
        {
        }

        public override IQueryable<Path> GetAllAsQueryable()
        {
            return base.GetAllAsQueryable();
        }
    }
}