using Microsoft.EntityFrameworkCore;
using Mobin.Repository;

namespace Northwind
{
    public class NorthwindUnitOfWork : MobinUnitOfWork<NorthwindContext>, IMobinUnitOfWork
    {
        public NorthwindUnitOfWork(NorthwindContext dbContext) : base(dbContext)
        {
        }
    }
}
