using Kendo.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using global::Kendo.Mvc.Mobin;
using Mobin.Service;
using Mobin.Repository;

namespace Kendo.Mvc
{
    public class KendoServices
    {
        public static IEnumerable<ServiceDescriptor> GetServices()
        {
            yield return ServiceDescriptor.Transient<IKendoHtmlGenerator, KendoHtmlGenerator>();
            yield return ServiceDescriptor.Transient<IUrlGenerator, UrlGenerator>();
        }
    }

    public class MobinServices
    {
        public static IEnumerable<ServiceDescriptor> GetServices() 
        {
            yield return ServiceDescriptor.Transient(typeof(ICrudRepository<>),typeof(CrudRepository<>));
            yield return ServiceDescriptor.Transient(typeof(ICrudService<>), typeof(CrudService<>));
            yield return ServiceDescriptor.Transient(typeof(CrudController<>), typeof(CrudService<>));
        }
    }
}
