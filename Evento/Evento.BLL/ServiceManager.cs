using Evento.BLL.Interfaces;
using Evento.BLL.Services;
using Evento.DTO.Entities;
using Evento.DTO.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.BLL
{
    public class ServiceManager
    {
        public IAccountService<User> UserAccounts { get; }
        public ICategoryService<Category> Categories { get; }
        public ICommentService<Comment> Comments { get; }
        public IEventService<Event> Events { get; }
        public ILocationService<Location> Locations { get; }
        public IMemorizeService<Memorize> Memorizes { get; }
        public ISubscriptionService<Subscription> Subscriptions { get; }
        public ITagService<Tag> Tags { get; }
        public IUserService<User> Users { get; }

        public ServiceManager(IUnitOfWork unitOfWork,
            UserManager<User> userManager, SignInManager<User> signInManager)
        {
            UserAccounts = new AccountService(userManager,signInManager);
            
        }


    }
}
