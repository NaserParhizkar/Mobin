using Kendo.Mvc.Mobin.Controllers;
using Mobin.Service;
using Northwind.Repository;
using Northwind.Service;

namespace Northwind.WebUI.Controllers
{
    public class OrderApiController : CrudController<Order>
    {
        public OrderApiController(IOrderService _orderService) : base(_orderService)
        {
        }
    }

    //public class CategoryApiController : CrudController<Category>
    //{
    //    public CategoryApiController(ICrudService<Category> _crudService) : base(_crudService)
    //    {
    //    }
    //}
}