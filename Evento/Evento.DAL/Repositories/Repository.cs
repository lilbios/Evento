using Evento.DTO.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
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

        public IEnumerable<TEntity> GetAll()
        {
            return eventoDbSet;
        }

        public IEnumerable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return eventoDbSet.Where(expression);
        }

        public void Create(TEntity entity)
        {
            eventoDbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            eventoDbSet.Attach(entity);
            repositoryContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            if (repositoryContext.Entry(entity).State == EntityState.Detached)
            {
                eventoDbSet.Attach(entity);
            }

            eventoDbSet.Remove(entity);
        }

        public void Delete(object id)
        {
            TEntity entityToDelete = eventoDbSet.Find(id);
            Delete(entityToDelete);
        }

        public TEntity GetByID(object id)
        {
            return eventoDbSet.Find(id);
        }
    }
}
