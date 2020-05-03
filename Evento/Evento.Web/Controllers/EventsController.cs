using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Evento.Models.Entities;
using Evento.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using Evento.Web.Models.Events;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Evento.BLL.Third_part;
using System.Linq;

namespace Evento.Web.Controllers
{
    public class EventsController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISubscriptionService<Subscription> subscriptionService;
        private readonly IEventService<Event> eventService;
        private static readonly IStringLocalizer<BaseController> _localizer;
        private readonly ITagService<Tag> tagService;
        private readonly IMapper mapper;
        private ICategoryService<Category> caregoryService;
        public EventsController(ISubscriptionService<Subscription> _Service, IUnitOfWork _unitOfWork, IEventService<Event> eventService, ITagService<Tag> tagService,
            ICategoryService<Category> caregoryService, IMapper mapper) : base(_localizer)
        {

            this._unitOfWork = _unitOfWork;
            this.caregoryService = caregoryService;
            this.eventService = eventService;
            this.mapper = mapper;
            this.tagService = tagService;
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

        [HttpGet]
        public async Task<IActionResult> CreateNewEvent()
        {
            var categories = await caregoryService.GetAllCategories();
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Title");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CreateNewEvent(EventViewModel viewModel, IFormFile image)
        {

            var result = await eventService.IsExsistsEvent(viewModel.Title);
            if (result)
            {
                ModelState.AddModelError("Title", "Event with this title already exsists");
            }
            if (DateTime.Compare(viewModel.DateFinish, viewModel.DateFinish) > 0)
            {
            }
            if (ModelState.IsValid)
            {

                var newEvent = mapper.Map<Event>(viewModel);


                if (image != null && image.Length > 0)
                {

                    newEvent.Photo = ImageConvertor.ConvertImageToBytes(image);

                }
                await eventService.AddEvent(newEvent);
                var createdEvent = await eventService.GetCurrentEventByTitle(viewModel.Title);

                var tags = viewModel.Tags.Split(',').ToList().Select(t=> new Tag {TagName = t });

                foreach (var item in tags)
                {
                    var tag = await tagService.GetTagByName(item.TagName);
                    if (tag is null)
                    {
                        await tagService.AddTag(item);
                        tag = await tagService.GetTagByName(item.TagName);

                    }

                    await tagService.AttachTagToEvent(tag, createdEvent);


                }


            }
            var categories = await caregoryService.GetAllCategories();
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Title");

            return View(viewModel);
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

