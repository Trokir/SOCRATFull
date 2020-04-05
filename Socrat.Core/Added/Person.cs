using System.Collections.ObjectModel;
using System.Linq;
using Socrat.Core.Entities;

namespace Socrat.Core.Added
{
    public class Person : Entity
    {


        private Gender _gender;
        public Gender Gender
        {
            get { return _gender; }
            set { SetField(ref _gender, value, () => Gender); }
        }


        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set { SetField(ref _surname, value, () => Surname); }
        }


        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name); }
        }

        private string _patronymic;
        public string Patronymic
        {
            get { return _patronymic; }
            set { SetField(ref _patronymic, value, () => Patronymic); }
        }

        public ObservableCollection<Socrat.Core.Entities.CustomerContact> Contacts { get; set; }


        public string DisplayName
        {
            get { return GetDisplayName(); }
        }

        private string GetDisplayName()
        {
            return string.Format("{0} {1} {2}", Surname, Name, Patronymic);
        }

        public string TitleName
        {
            get { return GetTitleName(); }
        }

        private string GetTitleName()
        {
            string res = "";
            if (!string.IsNullOrEmpty(Surname))
                res += Surname;
            if (!string.IsNullOrEmpty(Name))
            {
                if (!string.IsNullOrEmpty(Surname))
                    res += " " + Name.Substring(0, 1) + ".";
                else
                    res += Name;
            }

            if (!string.IsNullOrEmpty(Patronymic))
            {
                if (!string.IsNullOrEmpty(Surname))
                    res += " " + Patronymic.Substring(0, 1) + ".";
                else
                    res += " " + Patronymic;
            }

            return res;
        }

        public string Phone
        {
            get { return GetPresonPhone(); }
        }

        private string GetPresonPhone()
        {
            string _phone = string.Empty;
            CustomerContact _contact = Contacts.FirstOrDefault(x => x.ContactType.ContactTypeEnum == ContactTypes.Mobile);
            if (_contact == null)
                _contact = Contacts.FirstOrDefault(x => x.ContactType.ContactTypeEnum == ContactTypes.WorkPhone);
            if (_contact != null)
                _phone = _contact.Value;
            return _phone;
        }
    }
}
