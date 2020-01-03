using Kendo.Mvc.Extensions;
using Kendo.Mvc.Mobin.Controllers;
using Kendo.Mvc.UI;
using Northwind.Repository;
using Northwind.Service;
using System.Linq;

namespace Northwind.WebUI.Controllers
{
    public class CustomerApiController : CrudController<Customer>
    {
        private readonly ICustomerService customerService;
        public CustomerApiController(ICustomerService _customerService) : base(_customerService)
        {
            customerService = _customerService;
        }

        public override async System.Threading.Tasks.Task<object> Read([DataSourceRequest] DataSourceRequest request)
        {
            var query = customerService.GetAllAsQueryable();
            return await query.ToDataSourceResultAsync(request);
        }

        public DataSourceResult GetCustomersOrderInfo([DataSourceRequest] DataSourceRequest request)
        {
            var query = customerService.GetAllAsQueryable().Where(request.Filters).Cast<Order>();
            request.Filters.Clear();
            var finalQuery = query.Select(t => new { OrderDate = t.OrderDate });
            var dataSourceResult = finalQuery.ToDataSourceResult(request);
            return dataSourceResult;
        }
    }
}