using Microsoft.EntityFrameworkCore;
using Mobin.Repository;

namespace PDN
{
    public class PDNUnitOfWork : MobinUnitOfWork<DbContext>, IMobinUnitOfWork
    {
        public PDNUnitOfWork(PDNContext dbContext) : base(dbContext)
        {
        }
    }
}
