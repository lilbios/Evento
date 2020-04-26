using Evento.DTO.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.BLL.Services
{
    public class TagService
    {
        private readonly IUnitOfWork unitOfWork;
        public TagService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
    }
}
