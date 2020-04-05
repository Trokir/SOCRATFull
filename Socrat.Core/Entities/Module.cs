using System.Collections.Generic;

namespace Socrat.Core.Entities
{
    public class Module : Entity
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name); }
        }

        private string _ModuleName;
        public string ModuleName
        {
            get { return _ModuleName; }
            set { SetField(ref _ModuleName, value, () => ModuleName); }
        } 
        
        public virtual ICollection<TreeItem> TreeItems { get; set; } = new HashSet<TreeItem>();

        public override string ToString()
        {
            return $"Модуль: {Name}";
        }

        protected override string GetTitle()
        {
            return ModuleName;
        }
    }
}
