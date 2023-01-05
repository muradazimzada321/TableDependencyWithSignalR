using Microsoft.AspNetCore.Mvc;
using TableDependencyWithSignalR.Mediatr.Handlers.ProductHandlers;
using TableDependencyWithSignalR.Mediatr.Queries.ProductQueries;

namespace TableDependencyWithSignalR.Controllers
{
    public class DashboardController : Controller
    {
        public  IActionResult Index()
        {
            return View();
        }
    }
}
