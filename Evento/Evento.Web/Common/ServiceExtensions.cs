using Evento.BLL.Accounts;
using Evento.BLL.Interfaces;
using Evento.BLL.ServiceInterfaces;
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
            services.AddScoped<IAccountsService, AccountsService>();

            services.AddTransient<IRepository<User>, Repository<User>>();
            services.AddTransient<IRepository<Category>, Repository<Category>>();
            services.AddTransient<IRepository<Event>, Repository<Event>>();
            services.AddTransient<IRepository<Tag>, Repository<Tag>>();
            services.AddTransient<IRepository<Memorize>, Repository<Memorize>>();
            services.AddTransient<IRepository<Category>, Repository<Category>>();
            services.AddTransient<IRepository<Subscription>, Repository<Subscription>>();
            services.AddScoped<IEmailSender, EmailSender>();

            services.AddTransient<ITagService, TagService>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<ISubscriptionService, SubscriptionService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IMemorizeService, MemorizeService>();
            services.AddTransient<ICookieService, СookieService>();



            return services;
        }
    }
}
