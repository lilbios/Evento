using Evento.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Interfaces
{
    public interface ISubscriptionService
    {
        public Task<ICollection<Subscription>> GetSubscriptionsCurrentUser(string id);
        public Task Subscribe(int eventId, string userId);
        public Task Unsubscribe(int eventId, string userId);


    }
}
