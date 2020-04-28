using System;
using System.Collections.Generic;
using System.Diagnostics;
using Evento.BLL.Interfaces;
using Evento.DTO.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Evento.Web.Models;
using System.Threading.Tasks;
namespace Evento.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

         private readonly IEventService<Event> _eventService;
        public HomeController(ILogger<HomeController> logger,IEventService<Event> eventService)
        {
            _logger = logger;
            _eventService = eventService;
        }
        public IActionResult Login()
        {
            return View();
        }
     
        public async Task<ActionResult> Index()
        {
            var events = await _eventService.GetAllEvents();
            return View(events);
        }

        public  IActionResult Privacy()
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
