using System;
using System.Collections.Generic;
using Evento.BLL.Services;
using Evento.BLL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Evento.DTO.Entities;

namespace Evento.BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            services.AddTransient<IEventService<Event>, EventService>();
            
            services.AddTransient<ICategoryService<Category>, CategoryService>();


            return services;
        }
    }
}
