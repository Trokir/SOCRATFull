using System.Collections.Generic;
using Socrat.Core.Added;
using Socrat.Core.Helpers;

namespace Socrat.Core.Entities
{
    public class ContactType : Entity
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name, () => Title); }
        }
        private string _regexMask;
        public string RegexMask
        {
            get { return _regexMask; }
            set { SetField(ref _regexMask, value, () => RegexMask); }
        }

        private int _contactTypeNum;
        public int ContactTypeNum
        {
            get { return _contactTypeNum; }
            set { SetField(ref _contactTypeNum, value, () => ContactTypeNum); }
        }
        public virtual ICollection<AddressContact> AddressContacts { get; set; } = new HashSet<AddressContact>();
        public virtual ICollection<CoworkerContact> CoworkerContacts { get; set; } = new HashSet<CoworkerContact>();
        public virtual ICollection<CustomerContact> CustomerContacts { get; set; } = new HashSet<CustomerContact>();
        public virtual ICollection<DivisionContact> DivisionContacts { get; set; } = new HashSet<DivisionContact>();

        public ContactTypes ContactTypeEnum
        {
            get { return EnumHelper<ContactTypes>.FromNum(_contactTypeNum); }

        }

        public override string ToString()
        {
            return Name;
        }

        protected override string GetTitle()
        {
            return $"Тип контакта: {Name}";
        }
    }
}
