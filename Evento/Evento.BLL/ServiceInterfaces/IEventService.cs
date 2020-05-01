using Evento.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Interfaces
{
    public interface IEventService<T> where T : class
    {
        Task<ICollection<T>> GetAllEvents();
        Task AddEvent(T e);

        Task EditEvent( T e);

        Task RemoveEvent(object id);

        Task<T> GetById(int id);

        Task<ICollection<T>> GetEventByCity(string cityName);

        Task<ICollection<T>> GetEventByTitle(string search);

        Task<ICollection<T>> GetEventByDateStart(string date);

        Task<ICollection<T>> GetEventByDateStartAndLater(string date);

        Task<ICollection<T>> GetStartedEvent();

        Task<ICollection<T>> GetNotStartedEvent();

        Task<ICollection<T>> GetStartedandNotFinishedEvent();

        Task<ICollection<T>> GetNotFinishedEvent();

        Task<ICollection<T>> GetFinishedEvent();
        Task<ICollection<T>> GetUserCreatedEvents(string userId);

    }
}
