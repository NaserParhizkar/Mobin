using Microsoft.EntityFrameworkCore;
using Mobin.Repository;

namespace KendoBus
{
    public interface IBusUnitOfWork : IMobinUnitOfWork<KendoBusContext>, IMobinUnitOfWork { }

    public class BusUnitOfWork : MobinUnitOfWork<KendoBusContext>, IBusUnitOfWork
    {
        public BusUnitOfWork(KendoBusContext dbContext) : base(dbContext)
        {
        }
    }
}
