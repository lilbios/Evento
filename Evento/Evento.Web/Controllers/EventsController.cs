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
using Microsoft.AspNetCore.Authorization;

namespace Evento.Web.Controllers
{
    public class EventsController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISubscriptionService<Subscription> Service;
        private readonly IEventService<Event> eventService;
        private static readonly IStringLocalizer<BaseController> _localizer;
        private readonly IMapper mapper;
<<<<<<< HEAD
        private ICategoryService<Category> caregoryService;
        public EventsController(IEventService<Event> eventService, ICategoryService<Category> caregoryService, IMapper mapper) : base(_localizer)
=======
        private ICategoryService<Category> caregoryService ;
        public EventsController(ISubscriptionService<Subscription> _Service,IUnitOfWork _unitOfWork,IEventService<Event> eventService, ICategoryService<Category> caregoryService, IMapper mapper) : base(_localizer)
>>>>>>> c00965a8a528d30d6fb6da2d1f784721f633ab0d
        {
             Service = _Service;
            this._unitOfWork=  _unitOfWork;
            this.caregoryService = caregoryService;
            this.eventService = eventService;
            this.mapper = mapper;
        }

        // GET: Events
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
          

            ViewData["CurrentFilter"] = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                var eventsSearch = await eventService.GetEventByTitle(searchString);

                return View(eventsSearch);
            }
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


        [HttpGet]
        public IActionResult AddDetailsToEvent(int id)
        {
            if (id != 0)
            {
                var placeView = new PlaceViewModel()
                {
                    EventId = id
                };
                return View(placeView);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddDetailsToEvent(PlaceViewModel placeViewModel)
        {

            var currentEvent = await eventService.GetById(placeViewModel.EventId);
            if (currentEvent != null)
            {
                currentEvent.Place = placeViewModel.Place;
                currentEvent.Longtitute = Convert.ToDouble(placeViewModel.Longtitude);
                currentEvent.Latitute = Convert.ToDouble(placeViewModel.Latitude);

                await eventService.EditEvent(currentEvent);
                return RedirectToAction(nameof(Details), new { Id = placeViewModel.EventId });
            }
            return View(placeViewModel);

        }

        public async Task<IActionResult> CreateNewEvent()
        {
            var categories = await caregoryService.GetAllCategories();
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Title");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CreateNewEvent(EventViewModel viewModel, IFormFile Image)
        {
            if (ModelState.IsValid)
            {

                var newEvent = mapper.Map<Event>(viewModel);

                if (Image != null)

                {
                    if (Image.Length > 0)
                    {

                        byte[] p1 = null;
                        using (var fs1 = Image.OpenReadStream())
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                        newEvent.Photo = p1;

                    }
                }

                await eventService.AddEvent(newEvent);
            }
            var categories = await caregoryService.GetAllCategories();
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Title");

            return View(viewModel);
        }

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
            return RedirectToAction(nameof(OrganizedEvents), new { userId = 1 });
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> OrganizedEvents(string userId)
        {

            

            var usersOrganizedEvents = await eventService.GetUserCreatedEvents(userId);
            return View(usersOrganizedEvents);
        }

      


    }
}

