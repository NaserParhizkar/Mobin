using Kendo.Mvc.Mobin.Controllers;
using Kendo.Mvc.UI;
using Northwind.Repository;
using Northwind.Service;
using System.Threading.Tasks;

namespace Northwind.WebUI.Controllers
{
    public class CategoryApiController : CrudController<Category>
    {
        private readonly ICategoryService categoryService;
        public CategoryApiController(ICategoryService crudService) : base(crudService) =>
            categoryService = (ICategoryService)crudService;
    }
}
