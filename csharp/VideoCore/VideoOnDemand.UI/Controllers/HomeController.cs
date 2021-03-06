﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VideoOnDemand.Data.Data.Entities;
using VideoOnDemand.UI.Models;

namespace VideoOnDemand.UI.Controllers
{
    public class HomeController : Controller
    {
        private SignInManager<User> _signInMngr;

        public HomeController(SignInManager<User> signInMngr)
        {
            _signInMngr = signInMngr;
        }

        public IActionResult Index()
        {
            if (!_signInMngr.IsSignedIn(User))
                return RedirectToAction("Login", "Account");

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
