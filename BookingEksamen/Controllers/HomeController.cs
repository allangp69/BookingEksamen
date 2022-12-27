﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BookingEksamenWebUI.Models;
using Microsoft.AspNetCore.Identity;

namespace BookingEksamen.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(SignInManager<IdentityUser> signInManager, ILogger<HomeController> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                if (User.IsInRole("Artist"))
                {
                    return RedirectToAction("Index", "Artist");    
                }
                return RedirectToAction("Index", "Booker");
            }
            return View();
        }
        
        public IActionResult ReadMore()
        {
            return View();
        }
        
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}