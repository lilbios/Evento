using AutoMapper;
using Evento.BLL.Accounts.DTO;
using Evento.Models.Entities;
using Evento.Web.Models.Accounts;
using Evento.Web.Models.Categories;
using Evento.Web.Models.Events;
using Evento.Web.Models.Memorizes;

namespace Evento.Web.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //View models mapping
            CreateMap<RegisterDTO, User>();
            CreateMap<RegisterViewModel, User>();
            CreateMap<EventViewModel, Event>().ReverseMap();
            CreateMap<CreateViewModel, Category>().ReverseMap();
            CreateMap<MemorizeViewModel, Memorize>().ReverseMap();
           
           
        }
    }
}
