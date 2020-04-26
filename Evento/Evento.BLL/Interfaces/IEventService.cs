using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Interfaces
{
    public interface IEventService<T> where T : class
    {
        public Task<ICollection<T>> GetAllEvents();
        public Task<T> GetCurrentEvent(int id);
        public Task CreateNewEvent(T newEvent);
        public Task DeleteEvent(int id);
        public Task EditEvent(int id);

    }
}
