using CuckooStore.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CuckooStore.BusinessLogicLayer
{
    public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class
    {
        #region Fields
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IGenericRepository<TEntity> _repository;
        #endregion


        public BaseServices(IUnitOfWork unitOfWork, IGenericRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public virtual int Count()
        {
            return _repository.Count();
        }

        //public virtual int Count(Expression<Func<TEntity, bool>> filter)
        //{
        //    return _repository.Count(filter);
        //}

        public virtual async Task<int> CountAsync()
        {
            return await _repository.CountAsync();
        }

        public virtual int Create(TEntity entity)
        {
           _repository.Add(entity);
            return _unitOfWork.Commit();
        }

        public virtual async Task<int> CreateAsync(TEntity entity)
        {
            _repository.Add(entity);
            return await _unitOfWork.CommitAsync();
        }

        public virtual bool Delete(object id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                throw new Exception("ID: " + id + " cần xóa không tìm thấy");
            }
            _repository.Delete(entity);
            return _unitOfWork.Commit() > 0;
        }

        public virtual async Task<bool> DeleteAsync(object id)
        {
            var entity = _repository.GetById(id);
            if (entity == null)
            {
                throw new Exception("ID: " + id + " cần xóa không tìm thấy");
            }
            _repository.Delete(entity);
            return await _unitOfWork.CommitAsync() > 0;
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> filter)
        {
            return _repository.Find(filter);
        }

        public virtual IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            return _repository.FindAll(filter);
        }

        public virtual async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _repository.FindAllAsync(filter);
        }

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _repository.FindAsync(filter);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual TEntity GetById(object id)
        {
            return _repository.GetById(id);
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual IEnumerable<TEntity> GetTop(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            var query = orderBy(_repository.GetAll());
            return query.Take(10);
        }

        public virtual bool Update(TEntity entity)
        {
            _repository.Update(entity);
            return _unitOfWork.Commit() > 0;
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            _repository.Update(entity);
            return await _unitOfWork.CommitAsync() > 0;
        }
    }
}
