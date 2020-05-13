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
        Task<ICollection<TEntity>> GetAll();

        Task<ICollection<TEntity>> GetByCondition(Expression<Func<TEntity, bool>> expression);
        Task <TEntity> GetObjectByCondition(Expression<Func<TEntity, bool>> expression);

        Task Create(TEntity entity);
        Task<TEntity> CreateItem(TEntity entity); 

        Task Update(TEntity entity);

        Task Delete(TEntity entity);

        Task Delete(object id);
        Task<int> Count();
        Task<TEntity> GetByID(object id);
        Task<TEntity> GetObjectLazyLoad(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] children);
        Task<IQueryable<TEntity>> GetAllLazyLoad(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] children);

    }
}
