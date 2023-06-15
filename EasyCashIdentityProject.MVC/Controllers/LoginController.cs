using EasyCashIdentityProject.EntityLayer.Concrete;
using EasyCashIdentityProject.MVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginVM loginVM)
        {
            var result = await signInManager.PasswordSignInAsync(loginVM.UserName, loginVM.Password, false, true);
            if (result.Succeeded)
            {
                var user = await userManager.FindByNameAsync(loginVM.UserName);
                if (user.EmailConfirmed == true)
                {
                    return RedirectToAction("Index", "MyProfile");
                }
                //else lütfen mail adresinizi onaylayın
            }
            //Kullanıcı adı veya şifre hatalı
            return View();
        }
    }
}
