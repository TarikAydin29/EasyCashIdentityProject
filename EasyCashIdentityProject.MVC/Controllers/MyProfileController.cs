﻿using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.MVC.Controllers
{
    public class MyProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
