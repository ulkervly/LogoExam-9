
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Logo.MVC.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

       
    }
}
