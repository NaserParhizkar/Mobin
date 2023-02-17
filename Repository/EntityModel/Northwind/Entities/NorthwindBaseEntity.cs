using KendoBus.Repository;
using Mobin.Common.Entities;
using Mobin.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Repository.EntityModel.Northwind.Entities
{
    public interface INorthwindBaseEntity : IMobinBaseEntity{}

    public class NorthwindBaseEntity : MobinBaseEntity, INorthwindBaseEntity{}
}
