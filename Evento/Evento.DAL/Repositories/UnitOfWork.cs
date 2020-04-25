using Evento.DTO.Entities;
using Evento.DTO.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private EventoDbContext _eventoDbContext;
        private IRepository<User> _users;
        private IRepository<Event> _events;
        private IRepository<Subscription> _subscriptions;
        private IRepository<Memorize> _memorizes;
        private IRepository<Comment> _comments;
        private IRepository<Location> _locations;
        private IRepository<Category> _categories;
        private IRepository<Tag> _tags;

        public UnitOfWork(EventoDbContext eventoDbContext)
        {
            _eventoDbContext = eventoDbContext;
        }

        public IRepository<User> Users
        {
            get
            {
                return _users ??
                    (_users = new Repository<User>(_eventoDbContext));
            }
        }

        public IRepository<Event> Events
        {
            get
            {
                return _events ??
                    (_events = new Repository<Event>(_eventoDbContext));
            }
        }

        public IRepository<Subscription> Subscriptions
        {
            get
            {
                return _subscriptions ??
                    (_subscriptions = new Repository<Subscription>(_eventoDbContext));
            }
        }

        public IRepository<Memorize> Memorizes
        {
            get
            {
                return _memorizes ??
                    (_memorizes = new Repository<Memorize>(_eventoDbContext));
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return _comments ??
                    (_comments = new Repository<Comment>(_eventoDbContext));
            }
        }

        public IRepository<Location> Locations
        {
            get
            {
                return _locations ??
                    (_locations = new Repository<Location>(_eventoDbContext));
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                return _categories ??
                    (_categories = new Repository<Category>(_eventoDbContext));
            }
        }

        public IRepository<Tag> Tags
        {
            get
            {
                return _tags ??
                    (_tags = new Repository<Tag>(_eventoDbContext));
            }
        }

        public async Task SaveChangesAsync()
        {
            await _eventoDbContext.SaveChangesAsync();
        }
    }
}
