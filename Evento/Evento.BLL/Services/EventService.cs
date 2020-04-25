using Evento.BLL.Interfaces;
using Evento.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Services
{
    public class EventService : IEventService<Event>
    {
        public Task CreateNewEvent(Event newEvent)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEvent(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditEvent(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Event>> GetAllEvents()
        {
            throw new NotImplementedException();
        }

        public Task<Event> GetCurrentEvent(int id)
        {
            throw new NotImplementedException();
        }
    }
}
