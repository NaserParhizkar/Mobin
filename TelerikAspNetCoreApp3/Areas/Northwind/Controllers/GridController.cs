using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Northwind.Repository;
using System;
using System.Linq;

namespace Northwind.WebUI.Areas.NorthwindArea.Controllers
{
    public class GridController : Controller
    {
        public ActionResult Orders_Read([DataSourceRequest]DataSourceRequest request)
        {
            var result = Enumerable.Range(0, 50).Select(i => new OrderViewModel
            {
                OrderID = i,
                Freight = i * 10,
                OrderDate = new DateTime(2016, 9, 15).AddDays(i % 7),
                ShipName = "ShipName " + i,
                ShipCity = "ShipCity " + i
            });

            var dsResult = result.ToDataSourceResult(request);
            return Json(dsResult);
        }


        public ActionResult NaserOrders_Read([DataSourceRequest]DataSourceRequest request)
        {
            return null;
        }
    }
}
