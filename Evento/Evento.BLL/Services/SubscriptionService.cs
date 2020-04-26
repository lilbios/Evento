using Evento.BLL.Interfaces;
using Evento.DTO.Entities;
using Evento.DTO.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Services
{
    public class SubscriptionService : ISubscriptionService<Subscription>
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubscriptionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Subscription>> GetSubscriptionsCurrentUser(string id)
        {
            //add user manager
            var subscriptions =  _unitOfWork.Subscriptions.GetByCondition(x => x.User.Id == id).ToList();
           return  subscriptions;
        }

        public async Task Subscribe(Subscription subscription)
        {
            Subscription follow = new Subscription();
            follow.EventId = subscription.EventId;
            follow.UserId = subscription.UserId; 
           await _unitOfWork.Subscriptions.Create(follow);
        }
       

     
        public async Task Unsubscribe(int id)
        {
            var subscription = _unitOfWork.Subscriptions.GetByID(id);
           await _unitOfWork.Subscriptions.Delete(subscription);
        }
    }
}
