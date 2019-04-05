using Kendo.Mvc.Mobin;
using Kendo.Mvc.UI;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Repository.EntityModels;
using Kendo.Mvc.Extensions;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Northwind.WebUI.Controllers
{
    public class CustomerApiController : CrudController<Customer>
    {
        private readonly ICustomerService customerService;
        public CustomerApiController(ICustomerService _crudService) : base(_crudService)
        {
            customerService = _crudService;
        }

        public override object Read([DataSourceRequest] DataSourceRequest request)
        {
            var query = customerService.GetAllAsQueryable();
            var dataSourceResult = query.ToDataSourceResult(request);

            return dataSourceResult;
        }

        public DataSourceResult GetCustomersOrderInfo([DataSourceRequest] DataSourceRequest request)
        {
            var query = customerService.GetCustomersOrderInfo();
            var dataSourceResult = query.ToDataSourceResult(request);

            return dataSourceResult;
        }
    }
}