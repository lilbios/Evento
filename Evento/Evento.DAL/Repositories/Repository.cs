using Evento.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using System.Threading.Tasks;

namespace Evento.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly DbSet<TEntity> eventoDbSet;

        private EventoDbContext repositoryContext;

        public Repository(EventoDbContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
            this.eventoDbSet = repositoryContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var result = await eventoDbSet.ToListAsync();

            return result;
        }

        public async Task<IEnumerable<TEntity>> GetByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return await Task.Run(() => eventoDbSet.Where(expression));
        }

        public async Task Create(TEntity entity)
        {
            await eventoDbSet.AddAsync(entity);
            await repositoryContext.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            eventoDbSet.Attach(entity);
            repositoryContext.Entry(entity).State = EntityState.Modified;
            await repositoryContext.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            if (repositoryContext.Entry(entity).State == EntityState.Detached)
            {
                eventoDbSet.Attach(entity);
            }
            eventoDbSet.Remove(entity);
            await repositoryContext.SaveChangesAsync();
        }

        public async Task Delete(object id)
        {
            TEntity entityToDelete = await eventoDbSet.FindAsync(id);
            await Delete(entityToDelete);
            await repositoryContext.SaveChangesAsync();
        }

        public async Task<TEntity> GetByID(object id)
        {
            var result = await eventoDbSet.FindAsync(id);

            return result;
        }

        public async Task<TEntity> GetObjectLazyLoad(Expression<Func<TEntity, bool>> filter,
            params Expression<Func<TEntity, object>>[] children)
        {
            await Task.Run(() => children.ToList().ForEach(x => eventoDbSet.Include(x).Load()));
            return eventoDbSet.AsTracking().FirstOrDefault();
        }

        public async Task<IQueryable<TEntity>> GetAllLazyLoad(Expression<Func<TEntity, bool>> filter,
            params Expression<Func<TEntity, object>>[] children)
        {
            await Task.Run(() => children.ToList().ForEach(x => eventoDbSet.Include(x).Load()));
            return eventoDbSet;
        }

        public async  Task<TEntity> CreateItem(TEntity entity)
        {
            await eventoDbSet.AddAsync(entity);
            await repositoryContext.SaveChangesAsync();
            return entity;
           
        }
    }
}
