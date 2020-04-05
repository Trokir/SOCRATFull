using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Socrat.Core
{
    public interface IRepository<T> : IDisposable where T : class, IEntity, IDisposable, new()
    {
        bool Save(IEnumerable<T> entities);
        bool Save(T entity);
        T Revert(T entity);
        void Delete(Guid id);
        T GetItem(Guid id);
        T GetItem(Func<T, bool> predicate);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetIncludeAll(Expression<Func<T, bool>> criteria, params Expression<Func<T, object>>[] includeProperties);
        T GetIncludeItem(Guid id, params Expression<Func<T, object>>[] includeProperties);
        bool Any(Expression<Func<T, bool>> criteria);
    }
}