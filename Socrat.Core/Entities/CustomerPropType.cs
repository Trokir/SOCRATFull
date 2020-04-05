using System.Collections.Generic;

namespace Socrat.Core.Entities
{
    public class CustomerPropType : Entity
    {
        private string _alias;
        public string Alias
        {
            get { return _alias; }
            set { SetField(ref _alias, value, () => Alias); }
        }
        private string _propName;
        public string PropName
        {
            get { return _propName; }
            set { SetField(ref _propName, value, () => PropName); }
        }
        public virtual ICollection<CustomerProp> CustomerProps { get; set; } = new HashSet<CustomerProp>();
    }
}
