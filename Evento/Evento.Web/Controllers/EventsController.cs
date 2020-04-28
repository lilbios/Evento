using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Evento.BLL.Interfaces;
using Evento.DTO.Entities;

namespace Evento.Web.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventService<Event> _eventService;
        public EventsController(IEventService<Event> eventService)
        {
            _eventService = eventService;
        }
        public ActionResult Index()
        {
            var events = _eventService.GetAllEvents();
            return View(events);
        }

        // GET: Events/Details/5
        public ActionResult Details(int id)
        {
            var eventForDetail = _eventService.GetById(id);
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
        public ActionResult Create(Event create)
        {
            try
            {
                
                _eventService.AddEvent(create);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int id)
        {
            var edit = _eventService.GetById(id);
            
            return View(edit);
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Event edit)
        {
            try
            {
                _eventService.EditEvent(id, edit);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int id)
        {
            var delete = _eventService.GetById(id);
            return View(delete);
        }

        // POST: Events/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _eventService.RemoveEvent(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}