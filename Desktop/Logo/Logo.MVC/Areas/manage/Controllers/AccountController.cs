using Logo.Business.Exceptions;
using Logo.Core.Models;
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
        //public async Task<IActionResult> Login(AdminLoginViewModel vm)
        //{
        //    var user= await _userManager.FindByNameAsync(vm.UserName);  
        //    if (user == null)
        //    {
        //        throw new InvalidCredException();
        //    }
        //    var result = await _signInManager.PasswordSignInAsync(vm.);
        //}
    }
}
