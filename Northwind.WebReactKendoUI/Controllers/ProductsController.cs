using Microsoft.AspNetCore.Mvc;
using Northwind.WebReactKendoUI.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Northwind.WebReactKendoUI.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        // GET: api/Products
        [HttpGet]
        public JsonResult GetProducts([DataSourceRequest]DataSourceRequest request)
        {
            // ToDataSourceResult works with IQueryable and thus Entity Framework could be used as a source
            // instead of an in-memory list.
            return Json(Products.Items.ToDataSourceResult(request));
        }
    }
}