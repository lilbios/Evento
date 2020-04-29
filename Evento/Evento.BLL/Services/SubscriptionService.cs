using AutoMapper;
using Evento.BLL.Interfaces;
using Evento.Models.DTO;
using Evento.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evento.BLL.Services
{
    public class SubscriptionService : ISubscriptionService<SubscriptionDTO>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public SubscriptionService(IUnitOfWork _unitOfWork,IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task<IEnumerable<Subscription>> GetSubscriptionsCurrentUser(string id)
        {
            //add user manager
            var subscriptions = await unitOfWork.Subscriptions.GetByCondition(x => x.User.Id == id);
            return subscriptions.ToList();
        }

        public async Task Subscribe(SubscriptionDTO subscriptionDto)
        {

            var subscription = mapper.Map<Subscription>(subscriptionDto);
            await unitOfWork.Subscriptions.Create(subscription);
        }



        public async Task Unsubscribe(int id)
        {
            var subscription = unitOfWork.Subscriptions.GetByID(id);
            await unitOfWork.Subscriptions.Delete(subscription);
        }
    }
}
