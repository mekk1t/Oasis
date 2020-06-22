using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OasisWebApp.CinemaService.Repository.Interface;
using OasisWebApp.Controllers.Custom;
using OasisWebApp.Database.Entities;
using OasisWebApp.Models;

namespace OasisWebApp.Controllers
{
    [Route("OasisWebApp")]
    public class HomeController : CustomController
    {
        
        private readonly ILogger<HomeController> logger;
        private readonly ICinemaRepository cinemaRepository;

        public HomeController(
            [FromServices] ILogger<HomeController> logger,
            [FromServices] ICinemaRepository cinemaRepository)
        {
            this.logger = logger;
            this.cinemaRepository = cinemaRepository;
        }
       
        [Route("Home")]
        public IActionResult Home()
        {
            return View();
        }
        [Route("Privacy")]
        public IActionResult Privacy()
        { 
            ViewData["Title"] = "Privacy, madafakaaaa";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
