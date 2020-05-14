using Kendo.Mvc.Extensions;
using Kendo.Mvc.Mobin;
using Kendo.Mvc.UI;
using Mobin.Service;
using PDN.Repository;
using System.Linq;

namespace Northwind.WebUI.Areas.PDN.Controllers
{
    public class OrderApiController : CrudController<PDNOrder>
    {
        public OrderApiController(ICrudService<PDNOrder> _crudService) : base(_crudService)
        {
        }
    }
}