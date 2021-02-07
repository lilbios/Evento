using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Interfaces
{
    public interface IMemorizeService<T> where T : class
    {
        public Task AttachMemorizeToVisitedEvent(T memorize,int subscriptionId);
        public Task Edit(int id, T memorieze);
        public Task DeleteMemorize(int id);
    }
}
