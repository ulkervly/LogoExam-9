using Microsoft.AspNetCore.Mvc;

namespace Logo.MVC.Areas.manage.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
