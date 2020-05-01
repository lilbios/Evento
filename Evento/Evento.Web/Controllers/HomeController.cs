using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Evento.Web.Models;
using Evento.BLL.Interfaces;
using Evento.DTO.Entities;
using Microsoft.Extensions.Localization;
using Evento.Web.Resources;

namespace Evento.Web.Controllers
{
    public class HomeController : BaseController
    {
        
        private readonly ILogger<HomeController> _logger;
        private readonly IEventService<Event> _eventService;
        private static readonly IStringLocalizer<BaseController> localizer;
        private static readonly IStringLocalizer<SharedResource> sharedLocalizer;
        public HomeController(ILogger<HomeController> logger, IEventService<Event> eventService) :base( localizer, sharedLocalizer)
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
            var events =await _eventService.GetAllEvents();
            return View(events);
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
