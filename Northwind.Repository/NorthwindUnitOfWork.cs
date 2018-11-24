using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Mobin.Repository;
using Northwind.Repository.EntityModels;

namespace Northwind.Repository
{
    public class NorthwindUnitOfWork : MobinUnitOfWork<DbContext>
    {
        NorthwindUnitOfWork(NorthwindContext dbContext) : base(dbContext)
        {
        }
    }
}
