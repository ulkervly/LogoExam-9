
using Logo.Business.Services.Interfaces;
using Logo.Core.Models;
using Logo.Data.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Logo.MVC.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly IFeatureService _featureService;

        public HomeController(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        public async Task<IActionResult>Index()
        {
             List<Feature> features= await  _featureService.GetAllAsync();
            return View(features);
        }

       
    }
}
