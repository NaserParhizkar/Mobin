using Microsoft.EntityFrameworkCore;
using Mobin.Repository;

namespace KendoBus
{
    public class BusUnitOfWork : MobinUnitOfWork<DbContext>
    {
        public BusUnitOfWork(KendoBusContext dbContext) : base(dbContext)
        {
        }
    }
}
