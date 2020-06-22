using Microsoft.AspNetCore.Mvc;
using OasisWebApp.Controllers.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OasisWebApp.Services.CartService.Controller
{
    public class CartController : CustomController
    {
        [Route("Cart")]
        public IActionResult Cart()
        {
            return View();
        }
    }
}
