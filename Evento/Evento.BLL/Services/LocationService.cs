using Evento.DTO.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.BLL.Services
{
    public class LocationService
    {
        private readonly IUnitOfWork unitOfWork;
        public LocationService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
    }
}
