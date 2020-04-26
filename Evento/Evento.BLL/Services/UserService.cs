using Evento.DTO.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.BLL.Services
{
    public class UserService
    {
        private readonly IUnitOfWork unitOfWork;
        public UserService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
    }
}
