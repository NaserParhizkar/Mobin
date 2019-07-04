using Kendo.Mvc.Mobin;
using Kendo.Mvc.UI;
using Mobin.Service;
using Northwind.Repository;
using Northwind.Service;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public override Task<object> Read([DataSourceRequest] DataSourceRequest request)
        {
            return base.Read(request);
        }
    }
}
