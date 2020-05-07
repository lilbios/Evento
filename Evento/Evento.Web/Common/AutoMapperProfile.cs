using AutoMapper;
using Evento.BLL.Accounts.DTO;
using Evento.Models.Entities;
using Evento.Web.Models.Accounts;
using Evento.Web.Models.Categories;
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
            CreateMap<Event,EventViewModel>();
            CreateMap<CreateViewModel, Category>();
            CreateMap<Category, CreateViewModel>();
            CreateMap<RegisterDTO, User>();
        }
    }
}
