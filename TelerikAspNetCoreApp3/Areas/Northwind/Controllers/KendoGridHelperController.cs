using Microsoft.AspNetCore.Mvc;

namespace Northwind.WebUI.Areas.Northwind.Controllers
{
    public class KendoGridHelperController : Controller
    {
        public ViewResult Index() => View();
        public ViewResult MySearchInputs() => View();
        public ViewResult TestExpression() => View();
    }
}
