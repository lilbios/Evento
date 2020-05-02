using Evento.BLL.Interfaces;
using Evento.Models.Entities;
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
        public async Task AddEvent(Event _event)
        {
            await _unitOfWork.Events.Create(_event);

        }
        public async Task<Event> GetById(int id)
        {
           var _event =  await _unitOfWork.Events.GetByID(id);
            return _event;
        }

        public async Task RemoveEvent(object id)
        {
            var eventForRemoving = await _unitOfWork.Events.GetByID(id);
            await _unitOfWork.Events.Delete(eventForRemoving);
        }

        public async Task<ICollection<Event>> GetEventByCity(string cityName)
        {
            var eventList = await _unitOfWork.Events.GetByCondition(x => x.City.StartsWith(cityName));
            return eventList.ToList();
        }

        public async Task<ICollection<Event>> GetEventByTitle(string search)
        {
            var eventList = await _unitOfWork.Events.GetByCondition(s => s.Title.Contains(search));
            return eventList.OrderBy(s => s.Title).ToList();
        }

        public async Task<ICollection<Event>> GetEventByDateStart(string date)
        {
            DateTime searchDate = DateTime.Parse(date);
            var eventList = await _unitOfWork.Events.GetByCondition(s => s.DateStart == searchDate);
            return eventList.OrderBy(s => s.DateStart).ToList();
        }

        public async Task<ICollection<Event>> GetEventByDateStartAndLater(string date)
        {
            DateTime searchDate = DateTime.Parse(date);
            var eventList = await _unitOfWork.Events.GetByCondition(s => s.DateStart <= searchDate);
            return eventList.OrderBy(s => s.DateStart).ToList();
        }

        public async Task<ICollection<Event>> GetStartedEvent()
        {
            DateTime date = DateTime.Now;
            var eventList = await _unitOfWork.Events.GetByCondition(s => s.DateStart >= date);
            return eventList.OrderBy(s => s.DateStart).ToList();
        }

        public async Task<ICollection<Event>> GetNotStartedEvent()
        {
            DateTime date = DateTime.Now;
            var eventList = await _unitOfWork.Events.GetByCondition(s => s.DateStart < date);
            return eventList.OrderBy(s => s.DateStart).ToList();
        }

        public async Task<ICollection<Event>> GetStartedandNotFinishedEvent()
        {
            DateTime date = DateTime.Now;
            var eventList = await _unitOfWork.Events.GetByCondition(s => s.DateStart >= date && s.DateFinish < date);
            return eventList.OrderBy(s => s.DateStart).ToList();
        }
        public async Task<ICollection<Event>> GetNotFinishedEvent()
        {
            DateTime date = DateTime.Now;
            var eventList = await _unitOfWork.Events.GetByCondition(s => s.DateFinish <= date);
            return eventList.OrderBy(s => s.DateStart).ToList();
        }

        public async Task<ICollection<Event>> GetFinishedEvent()
        {
            DateTime date = DateTime.Now;
            var eventList = await _unitOfWork.Events.GetByCondition(s => s.DateFinish > date);
            return eventList.OrderBy(s => s.DateStart).ToList();
        }

        public async Task<ICollection<Event>> GetAllEvents()
        {
            var eventList = await _unitOfWork.Events.GetAll();
            return eventList.ToList();
        }
      

        public async Task EditEvent(Event e)
        {

            var eventForEditing = _unitOfWork.Events.GetByID(e.Id);
            eventForEditing.Result.Title = e.Title;
            eventForEditing.Result.CategoryId = e.CategoryId;
            eventForEditing.Result.DateFinish = e.DateFinish;
            eventForEditing.Result.DateStart = e.DateStart;
            eventForEditing.Result.Description = e.Description;
            eventForEditing.Result.Subscriptions = e.Subscriptions;
            await _unitOfWork.Events.Update(eventForEditing.Result);

        }

        public async Task<ICollection<Event>> GetUserCreatedEvents(string userId)
        {
            var user = await _unitOfWork.Users.GetByID(userId);
            var subscriptionsOwner = await Task.Run(()=> user.Subscriptions.Where(s=> s.UserId == userId && s.IsOwner == true ));
            return null;
            
        }
    }
}
