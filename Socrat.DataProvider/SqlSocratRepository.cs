using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Socrat.Core;
using Socrat.Core.Repositories;
using Socrat.Core.Repositories.Abstract;

namespace Socrat.DataProvider
{
    public class SqlSocratRepository<TEntity> : IDisposable, ISocratRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private DbContext _context;
        private DbSet<TEntity> _dbSet;

        public SqlSocratRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate);
        }
        public TEntity GetById(Guid id)
        {
            TEntity entity = _dbSet.Find(id);
            return entity;

        }

        public dynamic Context
        {
            get
            {
                return _context;
            }
        }

        public void AddEntity(TEntity item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }
        public void UpdateEntity(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void DeleteEntity(TEntity item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
