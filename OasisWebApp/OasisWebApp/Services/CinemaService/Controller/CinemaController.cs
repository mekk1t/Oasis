using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OasisWebApp.CinemaService.Services.Interface;
using OasisWebApp.Controllers.Custom;
using OasisWebApp.DTOs;
using System.Threading.Tasks;

namespace OasisWebApp.CinemaService.Controller
{
    public class CinemaController : CustomController
    {
        private readonly ICinemaService cinemaService;
        private readonly ILogger<CinemaController> logger;

        public CinemaController(
            [FromServices] ICinemaService cinemaService,
            [FromServices] ILogger<CinemaController> logger)
        {
            this.logger = logger;
            this.cinemaService = cinemaService;
        }

        [Route("success")]
        public IActionResult Success()
        {
            ViewData["Message"] = "Операция выполнена!";
            return View();
        }


        [HttpGet("cinemas")]
        public async Task<ActionResult> Cinemas()
        {
            var cinemas = await cinemaService.FindAsync();
            return View(cinemas);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> Cinema([FromRoute] int Id)
        {
            var result = await cinemaService.GetAsync(Id);
            return View(result);
        }

        [HttpGet("del/{Id}")]
        public async Task<ActionResult> Delete([FromRoute] int Id)
        {

            await cinemaService.DeleteAsync(Id);
            logger.LogInformation("DELETE-Request is completed");
            return RedirectToAction("Cinemas");
        }

        #region Добавить кинотеатр
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> New(
            [FromForm] CinemaDto cinema)
        {
            if (ModelState.IsValid)
            {
                await cinemaService.CreateAsync(cinema);
                return RedirectToAction("Cinemas");
            }
            return Redirect("OasisWebApp/Home");
        }

        [Route("items")]
        public IActionResult Items()
        {
            return View();
        }

        #endregion



    }
}
