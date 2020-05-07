using AutoMapper;
using Evento.BLL.Interfaces;
using Evento.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evento.BLL.Services
{
    public class SubscriptionService : ISubscriptionService<Subscription>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public SubscriptionService(IUnitOfWork _unitOfWork,IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task<ICollection<Subscription>> GetSubscriptionsCurrentUser(string id)
        {
            //add user manager
            var subscriptions = await unitOfWork.Subscriptions.GetByCondition(x => x.User.Id == id);
            return subscriptions.ToList();
        }

        public async Task Subscribe(int eventId, string userId)
        {

            var subscription = new Subscription()
            {
                EventId = eventId,
                UserId = userId
            };
            await unitOfWork.Subscriptions.Create(subscription);
        }



        public async Task Unsubscribe(int eventId, string userId)
        {
            var subscription = unitOfWork.Subscriptions.GetByCondition(s=> s.UserId == userId && s.EventId == eventId);
            await unitOfWork.Subscriptions.Delete(subscription);
        }
    }
}
