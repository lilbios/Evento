using AutoMapper;
using Evento.BLL.Interfaces;
using Evento.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Services
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Task<int> Count => _unitOfWork.Events.Count();

        public EventService(IUnitOfWork unitOfWork,  IMapper mapper)
        {
         _mapper= mapper;
        _unitOfWork = unitOfWork;
        }
        public async Task AddEvent(Event _event)
        {
            await _unitOfWork.Events.Create(_event);

        }
        public async Task<Event> GetById(int id)
        {
            var _event = await _unitOfWork.Events.GetObjectLazyLoad(e => e.Id == id, e => e.Category, e => e.TagEvents);
            return _event;
        }

        public async Task RemoveEvent(object id)
        {
            var eventForRemoving = await _unitOfWork.Events.GetByID(id);
            await _unitOfWork.Events.Delete(eventForRemoving);
        }

      

        public async Task<ICollection<Event>> GetEventByTitle(string search)
        {
            var eventList = await _unitOfWork.Events.GetByCondition(s => s.Title.StartsWith(search));
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

        public async Task<ICollection<Event>> GetAllEvents(int numberToSkip, int numberToTake)
        {
            var eventList = await _unitOfWork.Events.GetAll();
            return eventList.Skip((numberToSkip - 1) * numberToTake).Take(numberToTake).ToList();
        }
      

        public async Task EditEvent(int id, Event e)
        {
            await _unitOfWork.Events.Update(e);
        }

       
            
        public async Task<ICollection<Event>> GetUserCreatedEvents(string userId)
        {
            //var user = await _unitOfWork.Users.GetObjectLazyLoad(u => u.Id == userId, u => u.Subscriptions);
            //If below code doesn't work you must use in this method JOIN for tables Events and Users 
            var envents = await _unitOfWork.Events.GetAllLazyLoad(e => e.Subscriptions.Any(s=> s.UserId == userId && s.IsOwner == true) ,e=> e.Category);
            return envents.ToList();
        }

        public async Task<bool> IsExsistsEvent(string titleEvent)
        {
            var item =  await _unitOfWork.Events.GetObjectByCondition(e=> e.Title == titleEvent);
           return  item is null;
        }

        public async Task<Event> CreateNew(Event item)
        {
           return await _unitOfWork.Events.CreateItem(item);
           
        }

        public async Task<ICollection<Event>> GetAllEvents()
        {
            return await _unitOfWork.Events.GetAll();
        }
    }
}
