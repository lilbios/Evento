using AutoMapper;
using Evento.BLL.Interfaces;
using Evento.Models.DTO;
using Evento.Models.Entities;
using System.Threading.Tasks;

namespace Evento.BLL.Services
{
    public class MemorizeService : IMemorizeService<MemorizeDTO>
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public MemorizeService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        public async Task AttachMemorizeToVisitedEvent(MemorizeDTO _memorize, int subscriptionId)
        {
            var memorize = mapper.Map<Memorize>(_memorize);
            await unitOfWork.Memorizes.Create(memorize);
        }

        public async Task DeleteMemorize(int id)
        {
            await unitOfWork.Memorizes.Delete(id);
        }

        public async Task Edit(int id, MemorizeDTO _memorize)
        {
            var memorize = mapper.Map<Memorize>(_memorize);
            await unitOfWork.Memorizes.Update(memorize);
        }


    }
}
