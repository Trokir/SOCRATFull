using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Socrat.Lib;
using Socrat.Log;

namespace Socrat.DataProvider
{
    /// <summary>
    /// Универсальный репозиторий заточеный на работу с EF  через AutoMapper
    /// </summary>
    /// <typeparam name="T1">Тип визуальной модели</typeparam>
    /// <typeparam name="T2">Тип модели данных(EF-сгенерированный тип)</typeparam>
    public class UniversalRepository<T1, T2> : BaseRepository<T1> where T1 : class, IEntity, new() where T2 : class, ISourceEntity
    {
        public override void Save(T1 entity)
        {
            try
            {
                Mapper.Initialize(MapperConfig.CfgDesc);
                T2 _item;
                _item = Mapper.Map<T1, T2>(entity);
                _socratEntities.Set<T2>().AddOrUpdate(_item);
                if (_socratEntities.SafetySaveChanges())
                    entity.Changed = false;
            }
            catch (Exception e)
            {
                Logger.AddErrorMsgEx($"{this}.Save", e);
            }
        }

        public override T1 Revert(T1 entity)
        {
            return GetItem(entity.Id);
        }

        public override void Delete(Guid id)
        {
            T2 _item = _socratEntities.Set<T2>().FirstOrDefault(x => x.Id == id);
            if (_item != null)
            {
                _socratEntities.Set<T2>().Remove(_item);
                _socratEntities.SafetySaveChanges();
            }
        }

        public override T1 GetItem(Guid id)
        {
            T1 _item = null;
            try
            {
                Mapper.Initialize(MapperConfig.Cfg);
                T2 _sourceItem = _socratEntities.Set<T2>()?.FirstOrDefault(x => x.Id == id);
                _item = Mapper.Map<T2, T1>(_sourceItem);
                if (_item != null)
                    _item.Changed = false;
            }
            catch (Exception e)
            {
                Logger.AddErrorMsgEx($"{this}.GetItem", e);
            }
            return _item;
        }

        public T1 GetItem(Func<T2, bool> predicate)
        {
            T1 _item = null;
            try
            {
                T2 _sourceItem = _socratEntities.Set<T2>()?.FirstOrDefault(predicate);
                Mapper.Initialize(MapperConfig.Cfg);
                _item = Mapper.Map<T2, T1>(_sourceItem);
                if (_item != null)
                    _item.Changed = false;
            }
            catch (Exception e)
            {
                Logger.AddErrorMsgEx($"{this}.GetItem", e);
            }
            return _item;
        }

        public T1 GetIncludeItem(Guid id, params Expression<Func<T2, object>>[] includeProperties)
        {
            T1 _item = null;
            try
            {
                Mapper.Initialize(MapperConfig.Cfg);
                T2 _sourceItem = GetWithInclude(x => x.Id == id, includeProperties).FirstOrDefault();
                _item = Mapper.Map<T2, T1>(_sourceItem);
                if (_item != null)
                    _item.Changed = false;
            }
            catch (Exception e)
            {
                Logger.AddErrorMsgEx($"{this}.GetItem", e);
            }
            return _item;
        }

        public override IEnumerable<T1> GetAll()
        {
            List<T1> _items = new List<T1>();
            try
            {
                Mapper.Initialize(MapperConfig.Cfg);
                T1 destItem;
                foreach (T2 sourceItem in _socratEntities.Set<T2>())
                {
                    destItem = Mapper.Map<T2, T1>(sourceItem);
                    if (destItem != null)
                        _items.Add(destItem);
                }
                _items.RemoveAll(x => x == null);
                _items.ForEach(x => x.Changed = false);
            }
            catch (Exception e)
            {
                Logger.AddErrorMsgEx($"{this}.GetAll", e);
            }
            return _items;
        }

        public IEnumerable<T1> GetIncludeAll(params Expression<Func<T2, object>>[] includeProperties)
        {
            List<T1> _items = null;
            try
            {
                Mapper.Initialize(MapperConfig.Cfg);
                var _res = GetWithInclude(includeProperties);
                _items = Mapper.Map<IEnumerable<T2>, List<T1>>(_res);
                _items.RemoveAll(x => x == null);
                _items.ForEach(x => x.Changed = false);
            }
            catch (Exception e)
            {
                Logger.AddErrorMsgEx($"{this}.GetAll", e);
            }
            return _items;
        }

        private IEnumerable<T2> GetWithInclude(params Expression<Func<T2, object>>[] includeProperties)
        {
            return GetSourceItemsWithInclude(includeProperties).ToList();
        }

        private IEnumerable<T2> GetWithInclude(Func<T2, bool> predicate,
            params Expression<Func<T2, object>>[] includeProperties)
        {
            var query = GetSourceItemsWithInclude(includeProperties);
            return query.Where(predicate).ToList();
        }

        private IQueryable<T2> GetSourceItemsWithInclude(params Expression<Func<T2, object>>[] includeProperties)
        {
            IQueryable<T2> query = _socratEntities.Set<T2>();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
        


    }
}