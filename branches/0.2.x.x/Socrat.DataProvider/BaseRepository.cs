using System;
using System.Collections.Generic;
using Socrat.Lib;

namespace Socrat.DataProvider
{
    public abstract class BaseRepository<T> : IDisposable, IRepository<T> where T : class, IEntity, new() 
    {
        public SocratEntities _socratEntities
        {
            get { return EntityFrameworkConnection.SocratEntities; }
        }

        public BaseRepository()
        {
        }

        //public BaseRepository(SocratEntities socratEntities)
        //{
        //    _socratEntities = socratEntities;
        //}

        public abstract void Save(T entity);
        public abstract T Revert(T entity);
        public abstract void Delete(Guid id);
        public abstract T GetItem(Guid id);
        public abstract IEnumerable<T> GetAll();

        public void Dispose()
        {
            //if (_socratEntities != null)
            //    _socratEntities.Dispose();
        }
    }
}
