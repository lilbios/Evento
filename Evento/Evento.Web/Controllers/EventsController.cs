using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Evento.DAL;
using Evento.Models.Entities;
using Evento.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;

namespace Evento.Web.Controllers
{
    public class EventsController : BaseController
    {
        private readonly IEventService<Event> eventService;
        private static readonly IStringLocalizer<BaseController> _localizer;

      
        
            public EventsController(IEventService<Event> eventService) : base(_localizer)
        {
            this.eventService = eventService;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            var events = await eventService.GetAllEvents();
            return View(events);
        }

        // GET: Events/Details/5
        public IActionResult Details(int? id)
        {
            return View();
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection formCollection)
        {
            return View();
        }

        // GET: Events/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit()
        {
            return View();
        }

        // GET: Events/Delete/5
        public IActionResult Delete(int? id)
        {
            return View();
        }


    }
}

