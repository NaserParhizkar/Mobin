using Kendo.Mvc.Extensions;
using Kendo.Mvc.Mobin.Controllers;
using Kendo.Mvc.UI;
using Mobin.Service;
using Northwind.Repository;
using Northwind.Service;
using System.Linq;

namespace Northwind.WebUI.Controllers
{
    public class OrderDetailApiController : CrudController<OrderDetail>
    {
        public OrderDetailApiController(IOrderDetailService _orderDetailService) : base(_orderDetailService)
        {
        }

        public DataSourceResult GetCategories([DataSourceRequest] DataSourceRequest request)
        {
            var query = this.crudService.GetAllAsQueryable().Select(t =>
            new
            {
                Product = new
                {
                    Category = new
                    {
                        t.Product.Category.CategoryId,
                        t.Product.Category.CategoryName
                    }
                }
            });

            return query.ToDataSourceResult(request);
        }
    }
}