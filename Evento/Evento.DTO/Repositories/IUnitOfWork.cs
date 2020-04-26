using Evento.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.DTO.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }

        IRepository<Event> Events { get; }

        IRepository<Subscription> Subscriptions { get; }

        IRepository<Memorize> Memorizes { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Location> Locations { get; }

        IRepository<Category> Categories { get; }

        IRepository<Tag> Tags { get; }
        IRepository<TagEvent> TagEvents { get; }

    }
}
