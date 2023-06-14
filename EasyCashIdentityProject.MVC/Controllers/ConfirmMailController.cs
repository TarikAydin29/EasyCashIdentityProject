using EasyCashIdentityProject.EntityLayer.Concrete;
using EasyCashIdentityProject.MVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.MVC.Controllers
{
    public class ConfirmMailController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public ConfirmMailController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ConfirmMailVM confirmMailVM)
        {
            //Email adresini buradan alabiliriz.
            string mail = HttpContext.Session.GetString("Email");


            var user = await userManager.FindByEmailAsync(confirmMailVM.Email);
            if (user.ConfirmCode == confirmMailVM.ConfirmCode)
            {
                return RedirectToAction("Index", "MyProfile");
            }
            return View();
        }
    }
}
