using System;
using System.Collections.Generic;
using Socrat.Lib;

namespace Socrat.DataProvider
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        void Save(T entity);
        T Revert(T entity);
        void Delete(Guid id);
        T GetItem(Guid id);
        IEnumerable<T> GetAll();
    }
}