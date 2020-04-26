using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Interfaces
{
    public interface ISubscriptionService<T> where T : class
    {
        public Task<IEnumerable<T>> GetSubscriptionsCurrentUser(int id);
        public Task Subscribe(T subscription);
        public Task Unsubscribe(T subscription);


    }
}
