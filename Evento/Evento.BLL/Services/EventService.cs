using AutoMapper;
using Evento.BLL.Interfaces;
using Evento.Models.DTO;
using Evento.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evento.BLL.Services
{
    public class EventService : IEventService<EventDTO>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public EventService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        public async Task AddEvent(EventDTO _event)
        {
            var newEvent = mapper.Map<Event>(_event);
            await unitOfWork.Events.Create(newEvent);
        }
     

        public async Task RemoveEvent(object id)
        {
            var eventForRemoving = await unitOfWork.Events.GetByID(id);
            await unitOfWork.Events.Delete(eventForRemoving);
        }

        public async Task<IEnumerable<Event>> GetEventByLocation(int id)
        {
            var eventList = await unitOfWork.Events.GetByCondition(x => x.LocationId == id);
            return eventList;
        }

        public async Task<IEnumerable<Event>> GetEventByTitle(string search)
        {
            var eventList = await unitOfWork.Events.GetByCondition(s => s.Title.Contains(search));
            return eventList.OrderBy(s => s.Title);
        }

        public async Task<IEnumerable<Event>> GetEventByDateStart(string date)
        {
            DateTime searchDate = DateTime.Parse(date);
            var eventList = await unitOfWork.Events.GetByCondition(s => s.DateStart == searchDate);
            return eventList.OrderBy(s => s.DateStart);
        }

        public async Task<IEnumerable<Event>> GetEventByDateStartAndLater(string date)
        {
            DateTime searchDate = DateTime.Parse(date);
            var eventList = await unitOfWork.Events.GetByCondition(s => s.DateStart <= searchDate);
            return eventList.OrderBy(s => s.DateStart);
        }

        public async Task<IEnumerable<Event>> GetStartedEvent()
        {
            DateTime date = DateTime.Now;
            var eventList = await unitOfWork.Events.GetByCondition(s => s.DateStart >= date);
            return eventList.OrderBy(s => s.DateStart);
        }

        public async Task<IEnumerable<Event>> GetNotStartedEvent()
        {
            DateTime date = DateTime.Now;
            var eventList = await unitOfWork.Events.GetByCondition(s => s.DateStart < date);
            return eventList.OrderBy(s => s.DateStart);
        }

        public async Task<IEnumerable<Event>> GetStartedandNotFinishedEvent()
        {
            DateTime date = DateTime.Now;
            var eventList = await unitOfWork.Events.GetByCondition(s => s.DateStart >= date && s.DateFinish < date);
            return eventList.OrderBy(s => s.DateStart);
        }
        public async Task<IEnumerable<Event>> GetNotFinishedEvent()
        {
            DateTime date = DateTime.Now;
            var eventList = await unitOfWork.Events.GetByCondition(s => s.DateFinish <= date);
            return eventList.OrderBy(s => s.DateStart);
        }

        public async Task<IEnumerable<Event>> GetFinishedEvent()
        {
            DateTime date = DateTime.Now;
            var eventList = await unitOfWork.Events.GetByCondition(s => s.DateFinish > date);
            return eventList.OrderBy(s => s.DateStart);
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            var eventList = await unitOfWork.Events.GetAll();
            return eventList;
        }

        public async Task EditEvent(object id, EventDTO _event)
        {

            var eventForEditing = await unitOfWork.Events.GetByID(id);
            eventForEditing = mapper.Map<Event>(_event);
            await unitOfWork.Events.Update(eventForEditing);

        }

        public async Task<Event> GetById(int id)
        {
            var _event = await unitOfWork.Events.GetByID(id);
            return _event;
        }
    }
}
