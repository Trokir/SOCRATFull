using System.Collections.Generic;

namespace Socrat.Core.Entities
{
    public class Country : Entity
    {
        private string _aliasName;
        public string AliasName
        {
            get { return _aliasName; }
            set { SetField(ref _aliasName, value, () => AliasName, () => Title); }
        }


        private string _shortName;
        public string ShortName
        {
            get { return _shortName; }
            set { SetField(ref _shortName, value, () => ShortName);}
        }


        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set { SetField(ref _fullName, value, () => FullName); }
        }

        protected override string GetTitle()
        {
            return "Страна: " + AliasName;
        }

        public virtual ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
        public virtual ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();
    }
}
