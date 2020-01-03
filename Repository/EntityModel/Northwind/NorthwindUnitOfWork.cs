using Microsoft.EntityFrameworkCore;
using Mobin.Repository;

namespace Northwind
{
    public class NorthwindUnitOfWork : MobinUnitOfWork<DbContext>, IMobinUnitOfWork
    {
        public NorthwindUnitOfWork(NorthwindContext dbContext) : base(dbContext)
        {
        }
    }
}
