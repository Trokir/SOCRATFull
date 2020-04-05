using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Socrat.Lib;

namespace Socrat.Model
{
    public class ContactType: Entity
    {

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetField(ref _Name, value, () => Name, () => Title); }
        }


        private string _RegexMask;
        public string RegexMask
        {
            get { return _RegexMask; }
            set { SetField(ref _RegexMask, value, () => RegexMask); }
        }


        private int _ContactTypeNum;
        public int ContactTypeNum
        {
            get { return _ContactTypeNum; }
            set { SetField(ref _ContactTypeNum, value, () => ContactTypeNum); }
        }


        public ContactTypes ContactTypeEnum
        {
            get { return EnumHelper<ContactTypes>.FromNum(ContactTypeNum); }

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
