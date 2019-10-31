using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Models.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        void DeleteEntity(int entityId);
        Task<TEntity> GetEntityById(object entityId);
        Task<IEnumerable<TEntity>> GetEntityOnPage(int pageId);
        void InsertEntity(TEntity entity);
        void UpdateEntity(TEntity entity);
        void Save();
        void Commit();
        void BeginTransaction();
        void RollBackTransaction();
        void Dispose();

    }
}
