using Evento.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evento.DAL
{
    public class EventoDbContext : IdentityDbContext<User>
    {
        public EventoDbContext(DbContextOptions<EventoDbContext> options)
          : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<Memorize> Memorizes { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<TagEvent> TagEvents { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder
        //        .UseLazyLoadingProxies()
        //        .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=eventodb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //}
    }
}
