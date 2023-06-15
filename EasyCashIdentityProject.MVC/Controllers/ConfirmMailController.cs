using EasyCashIdentityProject.DataAccessLayer.Concrete;
using EasyCashIdentityProject.EntityLayer.Concrete;
using EasyCashIdentityProject.MVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.MVC.Controllers
{
    public class ConfirmMailController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly Context context;

        public ConfirmMailController(UserManager<AppUser> userManager,Context context)
        {
            this.userManager = userManager;
            this.context = context;
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
                user.EmailConfirmed = true;
                context.SaveChanges();
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
