
using Kendo.Mvc.Extensions;
using Kendo.Mvc.Mobin;
using Kendo.Mvc.UI;
using KendoBus.Repository;
using Mobin.Service;
using Northwind.Service;
using System.Threading.Tasks;

namespace Northwind.WebUI.Areas.Bus.Controllers
{
    public class AddressApiController : CrudController<Address>
    {
        public AddressApiController(ICrudService<Address> _crudService) : base(_crudService)
        {
        }
    }
}