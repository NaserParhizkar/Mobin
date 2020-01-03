using Kendo.Mvc.Mobin.Controllers;
using KendoBus.Repository;
using Mobin.Service;

namespace Northwind.WebUI.Areas.Bus.Controllers
{
    public class AddressApiController : CrudController<Address>
    {
        public AddressApiController(ICrudService<Address> _crudService) : base(_crudService)
        {
        }
    }
}