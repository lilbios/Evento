using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Evento.Web.Models;
using Evento.BLL.Interfaces;
using Evento.Models.Entities;
using Evento.Web.Models.Events;

namespace Evento.Web.Controllers
{

    public class HomeController : Controller
    {

        private readonly IEventService _eventService;
        private readonly ILogger<HomeController> _logger;
       

        public HomeController(ILogger<HomeController> logger, IEventService eventService)
        {
            _logger = logger;
            _eventService = eventService;
        }
        public IActionResult Login()
        {
            return View();
        }


        [HttpGet]
        public async Task<ActionResult> Index(int page = 1)
        {

            var events = await _eventService.GetAllEvents(page, 3);
            var count = await _eventService.Count;

            var pageViewModel = new PageViewModel(count, page, 3);
            var eventsViewModel = new EventsViewModel()
            {
                Items = events,
                PageViewModel = pageViewModel
            };

            return View(eventsViewModel);
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
