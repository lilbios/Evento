using Evento.BLL.Interfaces;
using Evento.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Services
{
    public class MemorizeService : IMemorizeService<Memorize>
    {
        public Task AttachMemorizeToVisitedEvent(Memorize memorize, int subscriptionId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMemorize(int id)
        {
            throw new NotImplementedException();
        }

        public Task Edit(int id)
        {
            throw new NotImplementedException();
        }
    }
}
