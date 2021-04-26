using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CuckooStore.BusinessLogicLayer
{
    public interface IBaseServices<TEntity> where TEntity : class
    {
        int Create(TEntity entity);
        Task<int> CreateAsync(TEntity entity);

        bool Update(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);

        bool Delete(object id);
        Task<bool> DeleteAsync(object id);

        int Count();
        Task<int> CountAsync();
        //int Count(Expression<Func<TEntity, bool>> filter);

        TEntity GetById(object id);
        Task<TEntity> GetByIdAsync(object id);

        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();

        TEntity Find(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter);
        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> GetTop(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
    }
}
