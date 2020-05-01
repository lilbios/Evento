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

using Evento.Web.Models.Events;
using AutoMapper;
using System.IO;


namespace Evento.Web.Controllers
{
    public class EventsController : BaseController
    {
        private readonly IEventService<Event> eventService;
        private static readonly IStringLocalizer<BaseController> _localizer;
        private readonly IMapper mapper;
        private ICategoryService<Category> caregoryService ;
        public EventsController(IEventService<Event> eventService, ICategoryService<Category> caregoryService, IMapper mapper) : base(_localizer)
        {
            this.caregoryService = caregoryService;
            this.eventService = eventService;
            this.mapper = mapper;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            var events = await eventService.GetAllEvents();
            return View(events);
        }


        // GET: Events/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var selectedEvent = await eventService.GetById(id);

            if (selectedEvent != null)
            {
                return View(selectedEvent);
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: Events/Create
        [HttpGet]
        public async Task<IActionResult> CreateNewEvent(EventViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

               
                   
                       
                       
                        
                  
                
                var newEvent = mapper.Map<Event>(viewModel);
                if (Request.Form.Files.Count != 0)
                {
                    var img = Request.Form.Files[0];
                    if (img.ContentType == "image/jpeg" || img.ContentType == "image/png"
                         || img.ContentType == "image/tiff" || img.ContentType == "image/gif"
                         || img.ContentType == "image/bmp")
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await img.CopyToAsync(memoryStream);
                            viewModel.Photo= memoryStream.ToArray();
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", "Uncorrect format file");
                    }
                }
                await eventService.AddEvent(newEvent);
            }
            var categories = await caregoryService.GetAllCategories();
             ViewData["CategoryId"] = new SelectList(categories, "Id", "Title");
         
            return View(viewModel);
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create()
        {
            return View();
        }

        // GET: Events/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var exsistedEvent = await eventService.GetById(id);
            return View(exsistedEvent);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EventViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var updatedEvent = mapper.Map<Event>(viewModel);
                await eventService.EditEvent(updatedEvent);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);

        }

        // GET: Events/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await eventService.RemoveEvent(id);
            return RedirectToAction(nameof(OrganizedEvents),new { userId = 1});
        }
        [HttpGet]
        public async Task<IActionResult> OrganizedEvents(string userId) {

            var usersOrganizedEvents = await eventService.GetUserCreatedEvents(userId);
            return View(usersOrganizedEvents);
        }


    }
}

