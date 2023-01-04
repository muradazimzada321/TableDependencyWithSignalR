using Microsoft.AspNetCore.Mvc;

namespace TableDependencyWithSignalR.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
