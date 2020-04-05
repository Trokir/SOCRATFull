using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socrat.Model
{
    public class Contact: Entity
    {

        private ContactType _ContactType;
        public ContactType ContactType
        {
            get { return _ContactType; }
            set { SetField(ref _ContactType, value, () => ContactType); }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetField(ref _Name, value, () => Name); }
        }


        private string _Value;
        public string Value
        {
            get { return _Value; }
            set { SetField(ref _Value, value, () => Value); }
        }


        private string _Comment;
        public string Comment
        {
            get { return _Comment; }
            set { SetField(ref _Comment, value, () => Comment); }
        } 


        private DateTime _DateBeg;
        public DateTime DateBeg
        {
            get { return _DateBeg; }
            set { SetField(ref _DateBeg, value, () => DateBeg); }
        }


        private DateTime _DateEnd;
        public DateTime DateEnd
        {
            get { return _DateEnd; }
            set { SetField(ref _DateEnd, value, () => DateEnd); }
        }
    }
}
