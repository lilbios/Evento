using Evento.DAL.Repositories;
using Evento.DTO.Entities;
using Evento.DTO.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evento.Web
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterEventoServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IRepository<User>, Repository<User>>();

            return services;
        }
    }
}
