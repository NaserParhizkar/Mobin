using Kendo.Mvc.Extensions;
using Kendo.Mvc.Mobin.Controllers;
using Kendo.Mvc.UI;
using Mobin.Service;
using Northwind.Repository;
using System.Linq;

namespace Northwind.WebUI.Controllers
{
    public class OrderApiController : CrudController<Order>
    {
        public OrderApiController(ICrudService<Order> _crudService) : base(_crudService)
        {
        }
    }

    public class OrderDetailApiController : CrudController<OrderDetail>
    {
        public OrderDetailApiController(ICrudService<OrderDetail> _crudService) : base(_crudService)
        {
        }


        public DataSourceResult GetCategories([DataSourceRequest]DataSourceRequest request)
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
            }
            );

            return query.ToDataSourceResult(request);
        }
    }

    public class CategoryApiController : CrudController<Category>
    {
        public CategoryApiController(ICrudService<Category> _crudService) : base(_crudService)
        {
        }
    }

    public class ProductApiController : CrudController<Product>
    {
        public ProductApiController(ICrudService<Product> _crudService) : base(_crudService)
        {
        }
    }

}