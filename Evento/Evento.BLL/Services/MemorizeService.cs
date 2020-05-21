using AutoMapper;
using Evento.BLL.Interfaces;
using Evento.Models.Entities;
using System.Threading.Tasks;

namespace Evento.BLL.Services
{
    public class MemorizeService : IMemorizeService
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public MemorizeService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        public async Task<Memorize> AttachMemorizeToVisitedEvent(Memorize memorize,int subscriptionId)
        {

            await unitOfWork.Memorizes.Create(memorize);
            return null;
        }

        public async Task DeleteMemorize(int id)
        {
            await unitOfWork.Memorizes.Delete(id);
        }

        public async Task Edit( Memorize _memorize)
        {
            var memorize = mapper.Map<Memorize>(_memorize);
            await unitOfWork.Memorizes.Update(memorize);
        }


    }
}
