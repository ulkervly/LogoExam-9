using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Logo.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize (Roles ="SuperAdmin")]

    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
