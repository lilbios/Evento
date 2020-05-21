using Evento.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Interfaces
{
    public interface IMemorizeService
    {
        public Task AttachMemorizeToVisitedEvent(Memorize memorize,int subscriptionId);
        public Task Edit(Memorize memorieze);
        public Task DeleteMemorize(int id);
    }
}
