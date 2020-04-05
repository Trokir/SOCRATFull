using System;

namespace Socrat.Core.Entities
{
    public class MaterialSpecProperty : Entity
    {
        public Guid? MaterialId { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name); }
        }

        private string _comment;
        public string Comment
        {
            get { return _comment; }
            set { SetField(ref _comment, value, () => Comment); }
        }

        [ParentItem]
        private Material _material;
        public virtual Material Material
        {
            get { return _material; }
            set { SetField(ref _material, value, () => Material); }
        }

        protected override string GetTitle()
        {
            return $"Специальное свойство материала {Material?.Name}";
        }

        public override string ToString()
        {
            return $"Дополнительный параметр {Name}";
        }

    }
}
