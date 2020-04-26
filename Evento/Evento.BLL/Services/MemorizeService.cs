﻿using Evento.BLL.Interfaces;
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

        private readonly IUnitOfWork unitOfWork;
        public MemorizeService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
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
