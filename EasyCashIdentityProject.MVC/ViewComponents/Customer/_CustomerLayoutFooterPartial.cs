using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.MVC.ViewComponents.Customer
{
    public class _CustomerLayoutFooterPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
