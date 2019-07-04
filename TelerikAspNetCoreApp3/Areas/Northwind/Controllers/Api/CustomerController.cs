using Kendo.Mvc.Mobin;
using Kendo.Mvc.UI;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Repository;
using Kendo.Mvc.Extensions;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Mobin.Service;
using Northwind.Service;

namespace Northwind.WebUI.Controllers
{
    public class CustomerApiController : CrudController<Customer>
    {
        private readonly CustomerService customerService;
        public CustomerApiController(ICustomerService _customerService) : base(_customerService)
        {
            customerService = (CustomerService)_customerService;
        }

        public override async System.Threading.Tasks.Task<object> Read([DataSourceRequest] DataSourceRequest request)
        {
            var query = customerService.GetAllAsQueryable();
            return await query.ToDataSourceResultAsync(request);
        }

        public DataSourceResult GetCustomersOrderInfo([DataSourceRequest] DataSourceRequest request)
        {
            var query  = customerService.GetAllAsQueryable().Where(request.Filters).Cast<Order>();
            request.Filters.Clear();
            var finalQuery = query.Select(t => new { OrderDate = t.OrderDate });
            var dataSourceResult = finalQuery.ToDataSourceResult(request);
            return dataSourceResult;
        }
    }
}