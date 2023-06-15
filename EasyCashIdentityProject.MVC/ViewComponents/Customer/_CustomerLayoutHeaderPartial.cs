using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.MVC.ViewComponents.Customer
{
    public class _CustomerLayoutHeaderPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
