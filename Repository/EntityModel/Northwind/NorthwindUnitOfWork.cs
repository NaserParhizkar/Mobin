using Microsoft.EntityFrameworkCore;
using Mobin.Repository;

namespace Northwind
{
    public interface INorthwindUnitOfWork : IMobinUnitOfWork<NorthwindContext>, IMobinUnitOfWork { }

    public class NorthwindUnitOfWork : MobinUnitOfWork<NorthwindContext>, INorthwindUnitOfWork
    {
        public NorthwindUnitOfWork(NorthwindContext dbContext) : base(dbContext)
        {
        }
    }
}
