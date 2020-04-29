using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Evento.BLL.Interfaces;
using Evento.Models.Entities;
using AutoMapper;
using Evento.Web.Models.Events;

namespace Evento.Web.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventService<Event> eventService;
        private readonly IMapper mapper;
        public EventsController(IEventService<Event> eventService, IMapper mapper)
        {
            this.eventService = eventService;
            this.mapper = mapper;
        }
        public async Task<ActionResult> Index()
        {
            var events = await eventService.GetAllEvents();
            return View(events);
        }

        // GET: Events/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var eventForDetail = await eventService.GetById(id);
            return View(eventForDetail);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EventViewModel eventViewModel)
        {


            if (ModelState.IsValid)
            {
                var newEvent = mapper.Map<Event>(eventViewModel);
                await eventService.AddEvent(newEvent);

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Events/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var edit = await eventService.GetById(id);

            return View(edit);
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EventViewModel eventView)
        {

            var editEvent = mapper.Map<Event>(eventView);
            await eventService.EditEvent(id, editEvent);
            return RedirectToAction(nameof(Index));

        }

        // GET: Events/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            await eventService.RemoveEvent(id);
            return RedirectToAction(nameof(Index));

        }

        // POST: Events/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}