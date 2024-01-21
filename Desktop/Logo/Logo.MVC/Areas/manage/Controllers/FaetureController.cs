using Microsoft.AspNetCore.Mvc;

namespace Logo.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    public class FaetureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
