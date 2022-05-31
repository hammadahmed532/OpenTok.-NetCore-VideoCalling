using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenTokDemoV2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenTokDemoV2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        OpenTokService _openTokService;

        public HomeController(ILogger<HomeController> logger, OpenTokService openTokService)
        {
            _logger = logger;
            _openTokService = openTokService;
        }

        public IActionResult Index()
        {
            dynamic locals = new ExpandoObject();

            locals.ApiKey = _openTokService.OpenTok.ApiKey.ToString();
            locals.SessionId = _openTokService.Session.Id;
            locals.Token = _openTokService.Session.GenerateToken();
            return View(locals);
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
