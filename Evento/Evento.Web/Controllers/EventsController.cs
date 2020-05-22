using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Evento.Models.Entities;
using Evento.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Evento.Web.Models.Events;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Evento.BLL.Third_part;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Evento.BLL.Accounts;
using Evento.BLL.ServiceInterfaces;

namespace Evento.Web.Controllers
{
    public class EventsController : Controller
    {
        private readonly IMapper mapper;
        private readonly ITagService tagService;
        private readonly IEventService eventService;
        private readonly ICookieService cookieService;
        private readonly UserManager<User> userManager;
        private readonly ICategoryService caregoryService;
      
        private readonly ISubscriptionService subscriptionService;


        public EventsController(ISubscriptionService subscriptionService, IEventService eventService,
        ICategoryService caregoryService, ITagService tagService,IMapper mapper,UserManager<User> userManager,
        ICookieService cookieService)

        {
            this.subscriptionService = subscriptionService;
            this.caregoryService = caregoryService;
            this.cookieService = cookieService;
            this.eventService = eventService;
            this.userManager = userManager;
            this.tagService = tagService;
            this.mapper = mapper;
        }

        // GET: Events
        public async Task<IActionResult> Index(string searchString)
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


        public async Task<IActionResult> Subscribe(int eventId)
        {
            var userId = userManager.GetUserId(User);
            await subscriptionService.Subscribe(eventId, userId);
            return RedirectToAction(nameof(Details), new { id = eventId });
        }

        public async Task<IActionResult> Unsubscribe(int eventId)
        {
            var userId = userManager.GetUserId(User);
            await subscriptionService.Unsubscribe(eventId, userId);
            return RedirectToAction(nameof(Details), new { id = eventId });

        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var selectedEvent = await eventService.GetById(id);

            if (selectedEvent != null)
            {
                var detEvent = mapper.Map<EventViewModel>(selectedEvent);
              
                detEvent.Subscription = await subscriptionService.GetCurrentSubscription(id, userManager.GetUserId(User));
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
                currentEvent.Longtitute =placeViewModel.Longtitude.ToString();
                currentEvent.Latitute = (placeViewModel.Latitude).ToString();

                await eventService.EditEvent(3, currentEvent);
                return RedirectToAction(nameof(Details), new { Id = placeViewModel.EventId });
            }
            return View(placeViewModel);

        }

        [HttpGet]
        public async Task<IActionResult> CreateNewEvent()
        {

            cookieService.Key = "tags";
            cookieService.Value = string.Empty;
            cookieService.SetExpireTime(7);
            Response.Cookies.Append(cookieService.Key, cookieService.Value, cookieService.CookieOptions);
            var categories = await caregoryService.GetAllCategories();
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Title");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> CreateNewEvent(EventViewModel viewModel, IFormFile image)
        {

            var foundResult = await eventService.IsExsistsEvent(viewModel.Title);

            if (!foundResult)
            {
                ModelState.AddModelError("Title", "Event with this title already exsists");
            }

            if (DateTime.Compare(viewModel.DateFinish, viewModel.DateFinish) > 0)
            {
                ModelState.AddModelError("DateFinish", "Finish date cannot be earlier than start");
            }

            if (ModelState.IsValid)
            {
                var newEvent = mapper.Map<Event>(viewModel);

                if (image != null && image.Length > 0)
                {
                    newEvent.Photo = ImageConvertor.ConvertImageToBytes(image);
                }

                var createdEvent = await eventService.CreateNew(newEvent);
                if (viewModel.Tags != null)
                {
                    var tags = viewModel.Tags.Split(',').ToList().Select(t => new Tag { TagName = t });

                    foreach (var item in tags)
                    {
                        var tag = await tagService.FindTagByName(item.TagName);

                        if (tag is null)
                        {
                            tag = await tagService.AddTag(item);
                        }
                        await tagService.AttachTagToEvent(tag, createdEvent);
                    }
                    ViewData["Created"] = "Event successfully created";
                }
                return RedirectToAction(nameof(Details), new { id = createdEvent.Id });
            }

            var categories = await caregoryService.GetAllCategories();
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Title");

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
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
        public async Task<IActionResult> Edit(int id, EventViewModel e, IFormFile image)
        {

            if (ModelState.IsValid)
            {

                var editEvent = mapper.Map<Event>(e);


                if (image != null && image.Length > 0)

                {
                    editEvent.Photo = ImageConvertor.ConvertImageToBytes(image);
                }
                await eventService.EditEvent(id, editEvent);


                ViewData["Edited"] = "Event successfully edited";

            }
            var categories = await caregoryService.GetAllCategories();
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Title");
            return View(e);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await eventService.RemoveEvent(id);
            return View(nameof(Index));
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> OrganizedEvents()
        {
            var user = await userManager.GetUserAsync(User);
            var usersOrganizedEvents = await eventService.GetUserCreatedEvents(user.Id);
            return View(usersOrganizedEvents);
        }
    }
}

