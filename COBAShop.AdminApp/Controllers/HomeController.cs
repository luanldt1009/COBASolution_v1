using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using COBAShop.AdminApp.Models;
using Microsoft.AspNetCore.Http;

namespace COBAShop.AdminApp.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            var user = User.Identity.Name;

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