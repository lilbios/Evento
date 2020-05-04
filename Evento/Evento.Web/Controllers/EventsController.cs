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

        private readonly ISubscriptionService<Subscription> subscriptionService;
        private readonly IEventService<Event> eventService;
        private static readonly IStringLocalizer<BaseController> _localizer;
        private readonly ITagService<Tag> tagService;
        private readonly IMapper mapper;
        private ICategoryService<Category> caregoryService;
      
        public EventsController(ISubscriptionService<Subscription>subscriptionService; ,IEventService<Event> eventService, 
        ICategoryService<Category> caregoryService, ITagService<Tag> tagService,IMapper mapper) : base(_localizer)

        {
             this.subscriptionService= subscriptionService;
            this.caregoryService = caregoryService;
            this.eventService = eventService;
            this.mapper = mapper;
            this.tagService = tagService;
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

