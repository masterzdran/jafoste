using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Models.Abstractions;

namespace Infrastructure.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal DbContext context;
        private IDbContextTransaction _transaction;
        internal DbSet<TEntity> dbSet;
        protected const int pageSize = IDefaultValues.DefaultNumberOfRecords;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();

        }

        public virtual async Task<IEnumerable<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }


        public void DeleteEntity(int entityId)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetEntityById(object entityId)
        {
            return await dbSet.FindAsync(entityId);
        }


        public async Task<IEnumerable<TEntity>> GetEntityOnPage(int pageId)
        {
            return await this.dbSet
                       .Take(pageId).Skip(pageSize)
                       .ToListAsync();
        }

        public void InsertEntity(TEntity entity)
        {
            dbSet.Add(entity);
        }


        public void UpdateEntity(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception dbEx)
            {
                throw new Exception("3er", dbEx);
            }
        }

        public void Commit()
        {
            _transaction.Commit();
        }
        public void BeginTransaction()
        {
            _transaction = context.Database.BeginTransaction();
        }
        public void RollBackTransaction()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
