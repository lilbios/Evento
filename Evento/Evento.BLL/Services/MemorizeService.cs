using Evento.BLL.Interfaces;
using Evento.DTO.Entities;
using Evento.DTO.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Services
{
    public class MemorizeService : IMemorizeService<Memorize>
    {

        private readonly IUnitOfWork _unitOfWork;
        public MemorizeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AttachMemorizeToVisitedEvent(Memorize memorize, int subscriptionId)
        {
            Memorize _memorize = new Memorize();
            _memorize.MemorizeComment = memorize.MemorizeComment;
            _memorize.MemorizePhoto = memorize.MemorizePhoto;
            _memorize.Title = memorize.Title;
            _memorize.SubscriptionId = subscriptionId;
           await _unitOfWork.Memorizes.Create(_memorize);
        }

        public async Task DeleteMemorize(int id)
        {
            await _unitOfWork.Memorizes.Delete(id);
        }

        public async Task Edit(int id, Memorize memorize)
        {
            var _memorize = _unitOfWork.Memorizes.GetByID(id);
            _memorize.Result.MemorizeComment = memorize.MemorizeComment;
            _memorize.Result.MemorizePhoto = memorize.MemorizePhoto;
            _memorize.Result.Title = memorize.Title;
            _memorize.Result.SubscriptionId = memorize.SubscriptionId;
            _unitOfWork.Memorizes.Update(_memorize.Result);
        }


    }
}
