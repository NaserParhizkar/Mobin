using Kendo.Mvc.Mobin.Controllers;
using Kendo.Mvc.UI;
using Northwind.Repository;
using Northwind.Service;
using System.Threading.Tasks;

namespace Northwind.WebUI.Controllers
{
    public class CategoryController : CrudController<Category>
    {
        private readonly CategoryService categoryService;
        public CategoryController(ICategoryService _categoryService) : base(_categoryService)
        {
            categoryService = (CategoryService)_categoryService;
        }
    }
}
