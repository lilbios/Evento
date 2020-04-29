using Evento.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Interfaces
{
    public interface IEventService<T> where T : class
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task AddEvent(T e);

        Task EditEvent(object id, T e);

        Task RemoveEvent(object id);

        Task<Event> GetById(int id);

        Task<IEnumerable<Event>> GetEventByLocation(int id);

        Task<IEnumerable<Event>> GetEventByTitle(string search);

        Task<IEnumerable<Event>> GetEventByDateStart(string date);

        Task<IEnumerable<Event>> GetEventByDateStartAndLater(string date);

        Task<IEnumerable<Event>> GetStartedEvent();

        Task<IEnumerable<Event>> GetNotStartedEvent();

        Task<IEnumerable<Event>> GetStartedandNotFinishedEvent();

        Task<IEnumerable<Event>> GetNotFinishedEvent();

        Task<IEnumerable<Event>> GetFinishedEvent();

    }
}
