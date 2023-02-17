using Kendo.Mvc.Mobin.Controllers;
using Mobin.Service;
using Northwind.Repository;
using Northwind.Service;

namespace Northwind.WebUI.Controllers
{
    public class ProductApiController : CrudController<Product>
    {
        public ProductApiController(IProductService _productService) : base(_productService)
        {
        }
    }
}