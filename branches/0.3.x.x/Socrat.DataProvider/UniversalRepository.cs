using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using Socrat.Log;
using Socrat.Core;

namespace Socrat.DataProvider
{
    public class UniversalRepository<T> : BaseRepository<T> where T : class, IEntity, new()
    {
        public SocratEntities SocratEntities
        {
            get { return EntityFrameworkConnection.SocratEntities; }
        }
        public override bool Save(IEnumerable<T> entities)
        {
            bool _res = false;
            try
            {
                T[] _items = entities.ToArray();
                SocratEntities.Set<T>().AddOrUpdate(_items);
                _res = SocratEntities.SafetySaveChanges();
                if (_res)
                {
                    foreach (var entity in entities)
                        entity.Changed = false;
                }
                else
                {
                    SocratEntities.DiscardEntityChanges(_items);
                }
            }
            catch (Exception e)
            {
                Logger.AddErrorMsgEx($"{this}.Save", e);
            }

            return _res;
        }

        public override bool Save(T entity)
        {
            bool _res = false;
            try
            {
                SocratEntities.Set<T>().AddOrUpdate(entity);
                _res = SocratEntities.SafetySaveChanges();
                if (_res)
                    entity.Changed = false;
            }
            catch (Exception e)
            {
                Logger.AddErrorMsgEx($"{this}.Save", e);
            }
            return _res;
        }

        public override T Revert(T entity)
        {
            T res = entity;
            try
            {
                IQueryable<T> _qry = SocratEntities.Set<T>();
                T _source = _qry.FirstOrDefault(x => x.Id == entity.Id);
                res.Changed = false;
            }
            catch (Exception e)
            {
                Logger.AddErrorEx("UniversalRepository.Revert", e);
            }
            return res;
        }

        public override void Delete(Guid id)
        {
            T _item = SocratEntities.Set<T>().FirstOrDefault(x => x.Id == id);
            if (_item != null)
            {
                var _ent = SocratEntities.Entry(_item);
                _ent.State = EntityState.Deleted;
                SocratEntities.SafetySaveChanges();
            }
        }

        public override T GetItem(Guid id)
        {
            T _item = null;
            try
            {
                _item = SocratEntities.Set<T>()?.FirstOrDefault(x => x.Id == id);
                if (_item != null)
                    _item.Changed = false;
            }
            catch (Exception e)
            {
                Logger.AddErrorMsgEx($"{this}.GetItem", e);
            }
            return _item;
        }

        public override T GetItem(Func<T, bool> predicate)
        {
            T _item = null;
            try
            {
                _item = SocratEntities.Set<T>()?.FirstOrDefault(predicate);

                if (_item != null)
                    _item.Changed = false;
            }
            catch (Exception e)
            {
                Logger.AddErrorMsgEx($"{this}.GetItem", e);
            }
            return _item;
        }

        public override T GetIncludeItem(Guid id, params Expression<Func<T, object>>[] includeProperties)
        {
            T _item = null;
            try
            {
                _item = GetWithIncludeCriteria(x => x.Id == id, includeProperties).FirstOrDefault();
                if (_item != null)
                    _item.Changed = false;
            }
            catch (Exception e)
            {
                Logger.AddErrorMsgEx($"{this}.GetItem", e);
            }
            return _item;
        }

        public override IQueryable<T> GetAll()
        {
            return SocratEntities.Set<T>();
        }

        public override IQueryable<T> GetAll(Expression<Func<T, bool>> criteria)
        {
            return SocratEntities.Set<T>().Where(criteria);
        }

        public override IQueryable<T> GetIncludeAll(Expression<Func<T, bool>> criteria, params Expression<Func<T, object>>[] includeProperties)
        {
           return GetWithIncludeCriteria(criteria, includeProperties);
        }

        private IQueryable<T> GetWithIncludeCriteria(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties)
        {
            var query = GetSourceItemsWithInclude(includeProperties);
            return query.Where(predicate);
        }

        private IQueryable<T> GetSourceItemsWithInclude(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = SocratEntities.Set<T>();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
        
        public override bool Any(Expression<Func<T, bool>> criteria)
        {
            bool res = false;
            IQueryable<T> query = SocratEntities.Set<T>();
            res = query.Any(criteria);
            return res;
        }

        public override void Dispose()
        {
        }
    }
}