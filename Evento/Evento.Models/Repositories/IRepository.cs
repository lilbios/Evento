using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Evento.Models.Entities
{
    public interface IRepository<TEntity>
      where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<IEnumerable<TEntity>> GetByCondition(Expression<Func<TEntity, bool>> expression);

        Task Create(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(TEntity entity);

        Task Delete(object id);

        Task<TEntity> GetByID(object id);
        Task<IEnumerable<TEntity>> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties);


        Task<IQueryable<TEntity>> Include(params Expression<Func<TEntity, object>>[] includeProperties);

    }
}
