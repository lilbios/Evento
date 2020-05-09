using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evento.BLL.Accounts;
using Evento.BLL.Interfaces;
using Evento.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Evento.Web.Controllers
{
    public class MemoraizesController : Controller
    {
        private readonly IEventService eventService;
        public MemoraizesController(UserManager<User> userManager, IEventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet]
        public Task<IActionResult> VisitedEvents() { 
                
        }
       
    }
}