using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OasisWebApp.Controllers.Custom;
using OasisWebApp.Services.FilmService.Services.Interface;
using System.Threading.Tasks;

namespace OasisWebApp.Services.FilmService.Controller
{
    public class FilmController : CustomController
    {
        private readonly IFilmService filmService;
        private readonly ILogger<FilmController> logger;

        public FilmController(
            [FromServices] IFilmService filmService,
            [FromServices] ILogger<FilmController> logger)
        {
            this.filmService = filmService;
            this.logger = logger;
        }

        [HttpGet("films")]
        public async Task<ActionResult> Films()
        {
            var films = await filmService.FindAsync();
            return View(films);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> Film([FromRoute] int Id)
        {
            var film = await filmService.GetAsync(Id);
            return View(film);
        }
    }
}
