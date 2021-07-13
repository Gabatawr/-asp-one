using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using mvc.Models;
using mvc.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmailOptions _emailOptions;

        public HomeController(ILogger<HomeController> logger, IOptions<EmailOptions> emailOptions)
        {
            _logger = logger;
            _emailOptions = emailOptions.Value;
        }

        public IActionResult Index()
        {
            ViewBag.EmailOptions = _emailOptions;
            return View();
        }
        public IActionResult Privacy(Guid? id)
        {
            return View(id);
        }
        [ActionName("PrivacyByInt")]
        public IActionResult Privacy(int id)
        {
            return View("Privacy", id);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
