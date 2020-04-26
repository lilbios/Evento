using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Interfaces
{
    public interface IEventService<T> where T : class
    {
         Task<IEnumerable<T>> GetAllEvents();
        Task AddEvent(T e);

        Task EditEvent(object id, T e);

        Task RemoveEvent(object id);

        Task<IEnumerable<T>> GetEventByLocation(int id);

        Task<IEnumerable<T>> GetEventByTitle(string search);

        Task<IEnumerable<T>> GetEventByDateStart(string date);

        Task<IEnumerable<T>> GetEventByDateStartAndLater(string date);

        Task<IEnumerable<T>> GetStartedEvent();

        Task<IEnumerable<T>> GetNotStartedEvent();

        Task<IEnumerable<T>> GetStartedandNotFinishedEvent();

        Task<IEnumerable<T>> GetNotFinishedEvent();

        Task<IEnumerable<T>> GetFinishedEvent();

    }
}
