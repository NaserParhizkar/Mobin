using Kendo.Mvc.Mobin.Controllers;
using Kendo.Mvc.Mobin.DataAnnotations.Internal;
using Kendo.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using Mobin.Repository;
using Mobin.Service;
using System.Collections.Generic;

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
            yield return ServiceDescriptor.Transient(typeof(ICrudRepository<>), typeof(CrudRepository<>));
            yield return ServiceDescriptor.Transient(typeof(ICrudService<>), typeof(CrudService<>));
            yield return ServiceDescriptor.Transient(typeof(CrudController<>), typeof(CrudService<>));

            yield return ServiceDescriptor.Singleton<IValidationAttributeAdapterProvider, MobinValidatiomAttributeAdapterProvider>();
        }
    }
}
