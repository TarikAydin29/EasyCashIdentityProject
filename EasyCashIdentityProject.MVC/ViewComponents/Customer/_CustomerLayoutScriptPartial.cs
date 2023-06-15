using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.MVC.ViewComponents.Customer
{
    public class _CustomerLayoutScriptPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
