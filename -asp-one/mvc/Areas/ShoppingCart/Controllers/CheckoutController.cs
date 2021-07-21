using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Areas.ShoppingCart.Controllers
{
    [Area("ShoppingCart")]
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Checkout";
            return View();
        }
    }
}
