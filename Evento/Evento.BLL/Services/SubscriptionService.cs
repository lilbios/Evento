using Evento.DTO.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.BLL.Services
{
    public class SubscriptionService
    {
        private readonly IUnitOfWork unitOfWork;
        public SubscriptionService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
    }
}
