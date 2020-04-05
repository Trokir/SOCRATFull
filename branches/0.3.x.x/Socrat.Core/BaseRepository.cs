using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Socrat.Core
{
    public abstract class BaseRepository<T> : IDisposable, IRepository<T> where T : class, IEntity, new()
    {
        public abstract bool Save(IEnumerable<T> entities);
        public abstract bool Save(T entity);
        public abstract T Revert(T entity);
        public abstract void Delete(Guid id);
        public abstract T GetItem(Guid id);
        public abstract IQueryable<T> GetAll();
        public abstract IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        public abstract T GetItem(Func<T, bool> predicate);
        public abstract IQueryable<T> GetIncludeAll(Expression<Func<T, bool>> criteria, params Expression<Func<T, object>>[] includeProperties);
        public abstract T GetIncludeItem(Guid id, params Expression<Func<T, object>>[] includeProperties);
        public abstract bool Any(Expression<Func<T, bool>> criteria);
        public abstract void Dispose();
    }
}
