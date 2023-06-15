using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.MVC.Controllers
{
    public class MyAccountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
