﻿using Microsoft.AspNetCore.Mvc;

namespace Furniture_Management_MVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
