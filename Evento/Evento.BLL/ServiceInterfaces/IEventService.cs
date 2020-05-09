using Evento.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Interfaces
{
    public interface IEventService
    {

        public Task<int> Count { get; }
        public Task<ICollection<Event>> GetAllEvents(int numberToSkip, int numberToTake);
        public Task AddEvent(Event e);

        public Task EditEvent(int id, Event e);

        public Task RemoveEvent(object id);

        public Task<Event> GetById(int id);

        public Task<ICollection<Event>> GetEventByTitle(string search);

        public Task<ICollection<Event>> GetEventByDateStart(string date);

        public Task<ICollection<Event>> GetEventByDateStartAndLater(string date);

        public Task<ICollection<Event>> GetStartedEvent();

        public Task<ICollection<Event>> GetNotStartedEvent();

        public Task<ICollection<Event>> GetStartedandNotFinishedEvent();

        public Task<ICollection<Event>> GetNotFinishedEvent();

        public Task<ICollection<Event>> GetFinishedEvent();
        public Task<ICollection<Event>> GetUserCreatedEvents(string userId);
        public Task<bool> IsExsistsEvent(string titleEvent);

        public Task<Event> CreateNew(Event item);

    }
}
