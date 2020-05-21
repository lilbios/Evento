using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Evento.Web.Models;
using Evento.BLL.Interfaces;
using Evento.Models.Entities;
using Evento.Web.Models.Events;
using MailKit.Net.Smtp;
using MimeKit;
using Evento.BLL.Services;
using Microsoft.AspNetCore.Identity;
using System;
using Evento.BLL.ServiceInterfaces;
using Evento.Models.Message;

namespace Evento.Web.Controllers
{

    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IEventService _eventService;
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;

        public HomeController(UserManager<User> userManager,ILogger<HomeController> logger, IEventService eventService, IEmailSender emailSender)
        {
            _logger = logger;
            _eventService = eventService;
            _emailSender = emailSender;
            _userManager = userManager;
        }
        public IActionResult Login()
        {
            return View();
        }
       public async Task<ActionResult> Email(string Content)
        {
            if (!String.IsNullOrEmpty(Content))
            {
                var message = new Message(new string[] { "nastyah6235@gmail.com" }, "Message from Evento", Content);
                _emailSender.SendEmail(message);
            }
            return RedirectToAction(nameof(Index));
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
