using Evento.BLL.Interfaces;
using Evento.BLL.Services;
using Evento.DAL.Repositories;
using Evento.Models.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;


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
            services.AddTransient<IRepository<Category>, Repository<Category>>();
            services.AddTransient<IRepository<Event>, Repository<Event>>();
            services.AddTransient<IRepository<Tag>, Repository<Tag>>();
            services.AddTransient<IRepository<Memorize>, Repository<Memorize>>();
            services.AddTransient<IRepository<Category>, Repository<Category>>();
            services.AddTransient<IRepository<Subscription>, Repository<Subscription>>();


            services.AddTransient<ITagService<Tag>, TagService>();
            services.AddTransient<IEventService<Event>, EventService>();
            services.AddTransient<ISubscriptionService<Subscription>, SubscriptionService>();
            services.AddTransient<ICategoryService<Category>, CategoryService>();
            services.AddTransient<ICommentService<Comment>, CommentService>();
            services.AddTransient<IMemorizeService<Memorize>, MemorizeService>();



            return services;
        }
    }
}
