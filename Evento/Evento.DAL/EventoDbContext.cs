using Evento.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.DAL
{
    public class EventoDbContext : IdentityDbContext<User>
    {
        public EventoDbContext(DbContextOptions<EventoDbContext> options)
          : base(options) { }

        public DbSet<Event> Events { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<Memorize> Memorizes { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}
