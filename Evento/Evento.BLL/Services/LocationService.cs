using Evento.BLL.Interfaces;
using Evento.DTO.Entities;
using Evento.DTO.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Services
{
    public class LocationService : ILocationService<Location>
    {
        private readonly IUnitOfWork _unitOfWork;
        public LocationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddLocation(Location location)
        {
            Location _location = new Location();
            _location.City = location.City;
            _location.Country = location.Country;       
            _location.Street = location.Street;
            await _unitOfWork.Locations.Create(_location);
        }

        public async Task DeleteLocation(int id)
        {

            await _unitOfWork.Locations.Delete(id);
        }

        public async Task EditLocation(int id, Location location)
        {
            var _location = _unitOfWork.Locations.GetByID(id);
            _location.Result.City = location.City;
            _location.Result.Country = location.Country;
            _location.Result.Latitute = location.Latitute;
            _location.Result.Street = location.Street;
            _location.Result.Longtitute = location.Longtitute;
            _unitOfWork.Locations.Update(_location.Result);
        }
    }
}
