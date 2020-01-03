
using Kendo.Mvc.Extensions;
using Kendo.Mvc.Mobin.Controllers;
using Kendo.Mvc.UI;
using KendoBus.Repository;
using Northwind.Service;

namespace Northwind.WebUI.Areas.Bus.Controllers
{
    public class PathApiController : CrudController<Path>
    {
        private readonly IPathService pathService;
        public PathApiController(IPathService _pathService) : base(_pathService)
        {
            pathService = _pathService;
        }

        public override async System.Threading.Tasks.Task<object> Read([DataSourceRequest] DataSourceRequest request)
        {
            var query = pathService.GetAllAsQueryable();
            return await query.ToDataSourceResultAsync(request);
        }
    }
}