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
        
        private readonly ISubscriptionService<Subscription> Service;
        private readonly IEventService<Event> eventService;
        private static readonly IStringLocalizer<BaseController> _localizer;
        private readonly IMapper mapper;

        private ICategoryService<Category> caregoryService;
      
        public EventsController(ISubscriptionService<Subscription> _Service,IUnitOfWork _unitOfWork,IEventService<Event> eventService, ICategoryService<Category> caregoryService, IMapper mapper) : base(_localizer)

        {
             Service = _Service;
          
            this.caregoryService = caregoryService;
            this.eventService = eventService;
            this.mapper = mapper;
        }

        // GET: Events
        public async Task<IActionResult> Index( string searchString)
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
                var detEvent = mapper.Map<EventViewModel>(selectedEvent);
                return View(detEvent);
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

                await eventService.EditEvent(3,currentEvent);
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


        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editEvent = await eventService.GetById(id);

            if (editEvent == null)
            {
                return NotFound();
            }
            var categories = await caregoryService.GetAllCategories();
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Title");
            var edited = mapper.Map<EventViewModel>(editEvent);
            return View(edited);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EventViewModel e, IFormFile Image)
        {

            if (ModelState.IsValid)
            {

                var editEvent = mapper.Map<Event>(e);
                try
                {



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
                            editEvent.Photo = p1;

                        }
                    }
                    await eventService.EditEvent(id, editEvent);

                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }
                return RedirectToAction(nameof(Index));

            }
            var categories = await caregoryService.GetAllCategories();
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Title");
            return View(e);
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

