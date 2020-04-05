using System;
using Socrat.Lib;

namespace Socrat.Model
{
    public class Entity: PropertyChangedBase, IEntity
    {
        private Guid _Id = Guid.NewGuid();
        public Guid Id
        {
            get { return _Id; }
            set { SetField(ref _Id, value, () => Id); }
        }
        
        private string _Title;
        public string Title
        {
            get { return GetTitle(); }
            set { SetField(ref _Title, value, () => Title); }
        }

        protected virtual string GetTitle()
        {
            if (string.IsNullOrEmpty(_Title))
                _Title = this.ToString();
            return _Title;
        }
    }
}
