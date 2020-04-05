using System.Collections.Generic;

namespace Socrat.Core.Entities
{
    public class PriceTagType : Entity
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name); }
        }

        private string _designation;
        public string Designation
        {
            get { return _designation; }
            set { SetField(ref _designation, value, () => Designation); }
        }
        public virtual ICollection<PriceType> PriceTypes { get; set; }

        public override string ToString()
        {
            return "Размерность";
        }
    }
}
