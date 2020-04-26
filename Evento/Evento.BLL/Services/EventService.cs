using Evento.BLL.Interfaces;
using Evento.DTO.Entities;
using Evento.DTO.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Services
{
    public class EventService : IEventService<Event>
    {
        private readonly IUnitOfWork _unitOfWork;
        public EventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddEvent(Event e)
        {
          await  _unitOfWork.Events.Create(e);
        }
        public async Task GetById(object id)
        {
            await _unitOfWork.Events.GetByID(id);
        }

        public async Task RemoveEvent(object id)
        {
            var eventForRemoving =await _unitOfWork.Events.GetByID(id);
            _unitOfWork.Events.Delete(eventForRemoving);
        }

        public async Task<IEnumerable<Event>> GetEventByLocation(int id)
        {
            var eventList = _unitOfWork.Events.GetByCondition(x => x.LocationId == id);
            return eventList;
        }

        public async Task<IEnumerable<Event>> GetEventByTitle(string search)
        {
            var eventList =  _unitOfWork.Events.GetByCondition(s => s.Title.Contains(search)).OrderBy(s => s.Title);
            return eventList;
        }

        public async Task<IEnumerable<Event>> GetEventByDateStart(string date)
        {
            DateTime searchDate = DateTime.Parse(date);
            var eventList =  _unitOfWork.Events.GetByCondition(s => s.DateStart == searchDate).OrderBy(s => s.DateStart);
            return eventList;
        }

        public async Task<IEnumerable<Event>> GetEventByDateStartAndLater(string date)
        {
            DateTime searchDate = DateTime.Parse(date);
            var eventList =  _unitOfWork.Events.GetByCondition(s => s.DateStart <= searchDate).OrderBy(s => s.DateStart);
            return eventList;
        }

        public async Task<IEnumerable<Event>> GetStartedEvent()
        {
            DateTime date = DateTime.Now;
            var eventList =  _unitOfWork.Events.GetByCondition(s => s.DateStart >= date).OrderBy(s => s.DateStart);
            return eventList;
        }

        public async Task<IEnumerable<Event>> GetNotStartedEvent()
        {
            DateTime date = DateTime.Now;
            var eventList =  _unitOfWork.Events.GetByCondition(s => s.DateStart < date).OrderBy(s => s.DateStart);
            return eventList;
        }

        public async Task<IEnumerable<Event>> GetStartedandNotFinishedEvent()
        {
            DateTime date = DateTime.Now;
            var eventList =  _unitOfWork.Events.GetByCondition(s => s.DateStart >= date && s.DateFinish < date).OrderBy(s => s.DateStart);
            return eventList;
        }
        public async Task<IEnumerable<Event>> GetNotFinishedEvent()
        {
            DateTime date = DateTime.Now;
            var eventList =  _unitOfWork.Events.GetByCondition(s => s.DateFinish <= date).OrderBy(s => s.DateStart);
            return eventList;
        }

        public async Task<IEnumerable<Event>> GetFinishedEvent()
        {
            DateTime date = DateTime.Now;
            var eventList =  _unitOfWork.Events.GetByCondition(s => s.DateFinish > date).OrderBy(s => s.DateStart);
            return  eventList;
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            var eventList = await _unitOfWork.Events.GetAll();
            return eventList;
        }

        public async Task EditEvent(object id, Event e)
        {
           
                var eventForEditing = _unitOfWork.Events.GetByID(id);
                eventForEditing.Result.LocationId = e.LocationId;
                eventForEditing.Result.Title = e.Title;
                eventForEditing.Result.CategoryId = e.CategoryId;
                eventForEditing.Result.DateFinish = e.DateFinish;
                eventForEditing.Result.DateStart = e.DateStart;
                eventForEditing.Result.Description = e.Description;
                eventForEditing.Result.Subscriptions = e.Subscriptions;
                _unitOfWork.Events.Update(eventForEditing.Result);
            
        }
    }
}
