using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using Ninject.Infrastructure.Language;

namespace Socrat.Core
{
    public class Entity : PropertyChangedBase, IEntity
    {
        private Guid _id = Guid.NewGuid();
        [Display(AutoGenerateField = false)]
        public Guid Id
        {
            get => _id;
            set { SetField(ref _id, value, () => Id); }
        }

        private List<IEntity> _parentEntities;
        [Display(AutoGenerateField = false)]
        public List<IEntity> ParentEntities
        {
            get => GetParentEntity();
            set => _parentEntities = value;
        }

        private List<IEntity> GetParentEntity()
        {
            List<Type> _types = this.GetType().GetAllBaseTypes().ToList();
            
            _types.ForEach( x =>
            {
               var tmp =  x.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).ToList()
                    .Where(y => y.GetCustomAttribute(typeof(ParentItemAttribute)) != null).ToList();
               if (tmp.Count > 0)
               {
                    if (null == _parentEntities)
                        _parentEntities = new List<IEntity>();
                    _parentEntities.Clear();
                    foreach (FieldInfo fieldInfo in tmp)
                    {
                       var _val = fieldInfo.GetValue(this) as IEntity;
                       if (_val != null)
                        _parentEntities.Add(_val);
                    }
               }
            });
                
            return _parentEntities;
        }

        private string _title;
        [Display(AutoGenerateField = false)]
        [NotMapped]
        public string Title
        {
            get => GetTitle();
            set { SetField(ref _title, value, () => Title); }
        }

        protected virtual string GetTitle()
        {
            if (string.IsNullOrEmpty(_title))
                _title = this.ToString();
            return _title;
        }

        public void Dispose()
        {
            _id = Guid.Empty;
            _title = null;
        }
    }

    public class EntityIdComparer : IEqualityComparer<Entity>
    {
        public bool Equals(Entity x, Entity y)
        {
            if (x == null || y == null)
            {
                return false;
            }
            return x.Id == y.Id;
        }

        public int GetHashCode(Entity obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
