using AutoMapper;
using Evento.Models.DTO;
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
            CreateMap<EventViewModel, EventDTO>();

            //DTO mapping
            CreateMap<CategoryDTO, Category>();
            CreateMap<CommentDTO, Comment>();
            CreateMap<EventDTO, Event>();
            CreateMap<MemorizeDTO, Memorize>();
            CreateMap<LocationDTO, Location>();
            CreateMap<TagDTO, Tag>();
            CreateMap<SubscriptionDTO, Subscription>();
            CreateMap<UserDTO, User>();

        }
    }
}
