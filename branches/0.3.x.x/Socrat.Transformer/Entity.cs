using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using Socrat.Lib;

namespace Socrat.Transformer
{
    [Serializable]
    [Browsable(false)]
    public class Entity: PropertyChangedBase, IEntity
    {
        private Guid _Id = Guid.NewGuid();
        public void DependedDelete(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public Guid Id
        {
            get { return _Id; }
            set { SetField(ref _Id, value, () => Id); }
        }

        [XmlIgnore]
        public IEntity ParentEntity
        {
            get => _parentEntity;
            set => _parentEntity = value;
        }

        private string _Title;
        private IEntity _parentEntity;
        private List<IEntity> _deletedEntities;

        public string Title
        {
            get { return GetTitle(); }
            set { SetField(ref _Title, value, () => Title); }
        }

        [XmlIgnore]
        public List<IEntity> DeletedEntities
        {
            get => _deletedEntities;
            set => _deletedEntities = value;
        }

        protected virtual string GetTitle()
        {
            if (string.IsNullOrEmpty(_Title))
                _Title = this.ToString();
            return _Title;
        }

        public void Dispose()
        {
            _Id = Guid.Empty;
            _Title = null;
        }
    }
}
