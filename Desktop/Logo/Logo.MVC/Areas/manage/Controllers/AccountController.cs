using Logo.Business.Exceptions;
using Logo.Core.Models;
using Logo.MVC.Areas.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Logo.MVC.Areas.manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AdminLoginViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var user = await _userManager.FindByNameAsync(vm.UserName);
            if (user == null)
            {
                throw new InvalidCredException();
            }

            var result = await _signInManager.PasswordSignInAsync(user,vm.Password,false,false);
                if (!result.Succeeded)
            {
                throw new InvalidCredException("");
            }
            return RedirectToAction("Index","Dashboard");
            
            
            
        }
        //public async Task<IActionResult> CreateRole()
        //{
        //    var role1 = new IdentityRole("SuperAdmin");
        //    var role2 = new IdentityRole("Admin");
        //    await _roleManager.CreateAsync(role1);
        //    await _roleManager.CreateAsync(role2);
        //    return Ok();
        //}
        //public async Task<IActionResult> CraeteAdmin()
        //{
        //    AppUser user = new AppUser
        //    {
        //        FullName = "Ulker Veliyeva",
        //        UserName = "SuperAdmin"
        //    };
        //    await _userManager.CreateAsync(user,"Admin123@");
        //    await _userManager.AddToRoleAsync(user,"SuperAdmin");
        //    return Ok();
        //}
    }
}
