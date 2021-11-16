using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLayerProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using NLayerProject.Web.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace NLayerProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authorize(Roles ="user,admin")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles ="admin")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(ErrorDto errorDto)
        {
            return View(errorDto);
        }
    }
}
