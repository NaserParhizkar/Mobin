
using Kendo.Mvc.Extensions;
using Kendo.Mvc.Mobin;
using Kendo.Mvc.UI;
using KendoBus.Repository;
using Northwind.Service;
using System.Threading.Tasks;

namespace Northwind.WebUI.Areas.Bus.Controllers
{
    public class PathApiController : CrudController<Path>
    {
        private readonly PathService pathService;
        public PathApiController(IPathService _pathService) : base(_pathService)
        {
            pathService = (PathService)_pathService;
        }

        public override async System.Threading.Tasks.Task<object> Read([DataSourceRequest] DataSourceRequest request)
        {
            var query = pathService.GetAllAsQueryable();
            return await query.ToDataSourceResultAsync(request);
        }
    }
}