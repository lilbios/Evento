using AutoMapper;
using Evento.Models.Entities;
using Evento.Web.Models.Accounts;
using Evento.Web.Models.Events;

namespace Evento.Web.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //View models mapping
            CreateMap<RegisterViewModel, User>();
            CreateMap<EventViewModel, Event>();

            

        }
    }
}
