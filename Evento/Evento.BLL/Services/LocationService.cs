using AutoMapper;
using Evento.BLL.Interfaces;
using Evento.Models.Entities;
using System.Threading.Tasks;

namespace Evento.BLL.Services
{
    public class LocationService : ILocationService<Location>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public LocationService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;

        }

        public async Task AddLocation(Location locationDto)
        {
            var location = mapper.Map<Location>(locationDto);
            await unitOfWork.Locations.Create(location);
        }

        public async Task DeleteLocation(int id)
        {

            await unitOfWork.Locations.Delete(id);
        }

        public async Task EditLocation(int id, Location _location)
        {
            var location = mapper.Map<Location>(_location);
            await unitOfWork.Locations.Update(location);
        }
    }
}
