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
        private readonly string connectionString;
        public EventoDbContext(DbContextOptions<EventoDbContext> options)
          : base(options)
        {
            var sqlServerOptionsExtension = options.FindExtension<SqlServerOptionsExtension>();
            if (sqlServerOptionsExtension != null)
            {
                connectionString = sqlServerOptionsExtension.ConnectionString;
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionString);
        }

        public DbSet<Event> Events { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<Memorize> Memorizes { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}
