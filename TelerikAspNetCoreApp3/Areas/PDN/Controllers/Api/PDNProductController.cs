using Kendo.Mvc.Extensions;
using Kendo.Mvc.Mobin;
using Kendo.Mvc.UI;
using Mobin.Service;
using PDN.Repository;
using System.Linq;

namespace Northwind.WebUI.Areas.PDN.Controllers
{
    public class PDNProductApiController : CrudController<PDNProduct>
    {
        public PDNProductApiController(ICrudService<PDNProduct> _crudService) : base(_crudService)
        {
        }
    }
}