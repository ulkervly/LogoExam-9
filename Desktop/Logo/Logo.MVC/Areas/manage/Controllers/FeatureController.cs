using Logo.Business.Exceptions;
using Logo.Business.Services.Interfaces;
using Logo.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Logo.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles ="SuperAdmin")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _featureService.GetAllAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Feature feature)
        {
            if (!ModelState.IsValid)
            {
                return View(feature);
            }
            try
            {
                await _featureService.CreateAsync(feature);
            }
            catch (FeatureNullReference ex)
            {

                ModelState.AddModelError("Feature", "Feature can not send null");
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            if (id < 0)
            {
                throw new IdBelowZeroException();
            }
            var exist = await _featureService.GetAsync(id);
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Feature feature)
        {
            if (!ModelState.IsValid)
            {
                return View(feature);
            }
            
            try
            {
                await _featureService.Updateasync(feature);
            }
            catch (FeatureNullReference ex)
            {

                ModelState.AddModelError("Feature", "Feature can not send null");
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Delete(int id)
        {
           
           if(id < 0)
            {
                throw new IdBelowZeroException();
            }
           var exist=await _featureService.GetAsync(id);
           await _featureService.DeleteAsync(id);
            return RedirectToAction("Index");

        }
    }
}
