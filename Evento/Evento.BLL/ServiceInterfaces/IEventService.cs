using Evento.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Interfaces
{
    public interface IEventService<T> where T : class
    {

        public Task<int> Count { get;}
        public Task<ICollection<T>> GetAllEvents(int numberToSkip, int numberToTake);
        public Task AddEvent(T e);

        public Task EditEvent(int id, T e);

        public Task RemoveEvent(object id);

        public Task<T> GetById(int id);

        public Task<ICollection<T>> GetEventByTitle(string search);

        public Task<ICollection<T>> GetEventByDateStart(string date);

        public Task<ICollection<T>> GetEventByDateStartAndLater(string date);

        public Task<ICollection<T>> GetStartedEvent();

        public Task<ICollection<T>> GetNotStartedEvent();

        public Task<ICollection<T>> GetStartedandNotFinishedEvent();

        public Task<ICollection<T>> GetNotFinishedEvent();

        public Task<ICollection<T>> GetFinishedEvent();
        public Task<ICollection<T>> GetUserCreatedEvents(string userId);
        public Task<bool> IsExsistsEvent(string titleEvent);

        public Task<T> CreateNew(T item);

    }
}
