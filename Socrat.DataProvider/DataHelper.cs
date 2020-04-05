using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.Log;

namespace Socrat.DataProvider
{
    public static class DataHelper
    {
        public static Socrat.Core.IRepository<T> GetRepository<T>() where T : class, IEntity, new()
        {
            Socrat.Core.IRepository<T> _repo = null;
            using (DataFactory _dataFactory = new DataFactory())
            {
                _repo = _dataFactory.CreateRepository<Socrat.Core.IRepository<T>>();
            }
            return _repo;
        }

        public static List<T> GetAll<T>() where T : class, IEntity, new()
        {
            List<T> _res = null;
            using (DataFactory _dataFactory = new DataFactory())
            {
                Socrat.Core.IRepository<T> _repo = _dataFactory.CreateRepository<Socrat.Core.IRepository<T>>();
                _res = _repo.GetAll()?.ToList();
            }
            if (_res == null)
                _res = new List<T>();
            return _res;
        }

        public static bool Save<T>(T entity) where T : class, IEntity, new()
        {
            bool res = false;
            using (DataFactory _dataFactory = new DataFactory())
            {
                Socrat.Core.IRepository<T> _repo = _dataFactory.CreateRepository<Socrat.Core.IRepository<T>>();
                res = _repo.Save(entity);
                _repo.Dispose();
            }
            return res;
        }

        public static bool Delete<T>(T entity) where T : class, IEntity, new()
        {
            bool res = false;
            using (DataFactory _dataFactory = new DataFactory())
            {
                Socrat.Core.IRepository<T> _repo = _dataFactory.CreateRepository<Socrat.Core.IRepository<T>>();
                _repo.Delete(entity.Id);
                _repo.Dispose();
                res = true;
            }
            return res;
        }

        public static bool SaveCollection<T>(IEnumerable<T> entities) where T : class, IEntity, new()
        {
            bool res = false;
            using (DataFactory _dataFactory = new DataFactory())
            {
                Socrat.Core.IRepository<T> _repo = _dataFactory.CreateRepository<Socrat.Core.IRepository<T>>();
                res = _repo.Save(entities);
                _repo.Dispose();
            }
            return res;
        }

        public static object Invoke<T>(string methodName, object[] args)
            where T : class, IEntity, new()
        {
            object res = null;
            try
            {
                using (DataFactory _dataFactory = new DataFactory())
                {
                    Socrat.Core.IRepository<T> _repo = _dataFactory.CreateRepository<Socrat.Core.IRepository<T>>();
                    Type _repoType = _repo.GetType();
                    var _method = _repoType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
                    if (_method != null)
                        res = _method.Invoke(_repo, args);
                }
            }
            catch (Exception ex)
            {
                Logger.AddErrorEx("DataHelper.Invoke", ex);
            }

            return res;
        }

        public static T GetItem<T>(Guid id)
            where T : class, IEntity, new()
        {
            T _res = null;

            using (Socrat.Core.IRepository<T> _repo = GetRepository<T>())
            {
                _res = _repo.GetItem(id);
            }

            return _res;
        }

        public static void ReloadCollection<T>(T entity, string collectionName)
            where T : class, IEntity, new()
        {
            if (EntityFrameworkConnection.SocratEntities.Entry(entity).State != EntityState.Deleted)
                EntityFrameworkConnection.SocratEntities.Entry(entity).Collection(collectionName).Load();
        }

        public static void LoadProperty<T>(T entity, string properyName)
            where T : class, IEntity, new()
        {
            if (EntityFrameworkConnection.SocratEntities.Entry(entity).State != EntityState.Deleted)
            {
                EntityFrameworkConnection.SocratEntities.Entry(entity).Reference(properyName).Load();
            }
        }

        /// <summary>
        /// Распаковка в настоящий тип сущности
        /// </summary>
        /// <typeparam name="T">настоящий тип сущности</typeparam>
        /// <param name="efObject">исходный обьект контекста</param>
        /// <returns>приведенный объект</returns>
        //public static T UnProxy<T>(T efObject) where T : new()
        //{
        //    var type = efObject.GetType();

        //    if (type.Namespace.StartsWith("Socrat.Core"))
        //    {
        //        var baseType = type.BaseType;
        //        var returnObject = new T();

        //        var sourceProperties = baseType.GetProperties()
        //            .Where(p => p.CanRead && p.CanWrite
        //              && p.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute), true).Length == 0
        //              && p.GetCustomAttributes(typeof(Socrat.Core.ParentItemAttribute), true).Length == 0);

        //        foreach (var property in sourceProperties)
        //        {
        //            var propertyType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
        //            if (propertyType.Namespace == "System")
        //            {
        //                var value = property.GetValue(efObject);
        //                property.SetValue(returnObject, value);
        //            }
        //        }
        //        return returnObject;
        //    }

        //    return efObject;
        //}

        public static T UnProxy<T>(object proxyObject) where T : class
        {
            var proxyCreationEnabled = EntityFrameworkConnection.SocratEntities.Configuration.ProxyCreationEnabled;
            try
            {
                EntityFrameworkConnection.SocratEntities.Configuration.ProxyCreationEnabled = false;
                T poco = EntityFrameworkConnection.SocratEntities.Entry(proxyObject).CurrentValues.ToObject() as T;
                return poco;
            }
            finally
            {
                EntityFrameworkConnection.SocratEntities.Configuration.ProxyCreationEnabled = proxyCreationEnabled;
            }
        }
    }
}
