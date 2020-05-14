using Kendo.Mvc.Extensions;
using Kendo.Mvc.Mobin;
using Kendo.Mvc.UI;
using Mobin.Service;
using PDN.Repository;
using System.Linq;

namespace Northwind.WebUI.Areas.PDN.Controllers
{
    public class PDNOrderItemApiController : CrudController<PDNOrderItem>
    {
        public PDNOrderItemApiController(ICrudService<PDNOrderItem> _crudService) : base(_crudService)
        {
        }
    }
}