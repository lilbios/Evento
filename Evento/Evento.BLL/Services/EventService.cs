using Evento.BLL.Interfaces;
using Evento.DTO.Entities;
using Evento.DTO.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Services
{
    public class EventService : IEventService<Event>
    {
        private readonly IUnitOfWork unitOfWork;
        public EventService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public async Task CreateNewEvent(Event newEvent)
        {
            await unitOfWork.Events.Create(newEvent);
        }

        public async Task DeleteEvent(int id)
        {
            await _unitOfWork.Events.Delete(id);
        }

        public Task EditEvent(int id)
        {
            throw new NotImplementedException();
        }

        public async  Task<IEnumerable<Event>> GetAllEvents()
        {
          

        }

        public Task<Event> GetCurrentEvent(int id)
        {
            throw new NotImplementedException();
        }
    }
}
