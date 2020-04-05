using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Socrat.Model
{
    public class Coworker: Entity
    {
        public Coworker()
        {
            _contacts = new ObservableCollection<CoworkerContact>();
            _contacts.CollectionChanged += _contacts_CollectionChanged;
        }

        private void _contacts_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Changed = true;
        }

        private string _NameFirst;
        public string NameFirst
        {
            get { return _NameFirst; }
            set { SetField(ref _NameFirst, value, () => NameFirst, () => Initials, () => Title); }
        }

        private string _NameMiddle;
        public string NameMiddle
        {
            get { return _NameMiddle; }
            set { SetField(ref _NameMiddle, value, () => NameMiddle, () => Initials, () => Title); }
        }

        public string Initials
        {
            get { return GetInitials(); }
        }

        private string _NameLast;
        public string NameLast
        {
            get { return _NameLast; }
            set { SetField(ref _NameLast, value, () => NameLast, () => Title); }
        }

        private Gender _Gender;
        public Gender Gender
        {
            get { return _Gender; }
            set { SetField(ref _Gender, value, () => Gender); }
        }

        public Nullable<Guid> Gender_Id
        {
            get { return Gender?.Id; }
        }

        private Nullable<System.DateTime> _Birth = DateTime.Now.AddDays(-40);
        public Nullable<System.DateTime> Birth
        {
            get { return _Birth; }
            set { SetField(ref _Birth, value, () => Birth); }
        }

        private Division _Division;
        public Division Division
        {
            get { return _Division; }
            set { SetField(ref _Division, value, () => Division); }
        }

        public Nullable<Guid> Division_Id
        {
            get { return Division?.Id; }
        }

        private string GetInitials()
        {
            return ((!string.IsNullOrEmpty(_NameFirst)
                ? _NameFirst.Substring(0, 1) + "."
                : String.Empty) +
                  (!string.IsNullOrEmpty(_NameMiddle)
                    ? " " + _NameMiddle.Substring(0, 1) + "."
                    : string.Empty)).Trim();
        }

        private ObservableCollection<CoworkerContact> _contacts;

        public ObservableCollection<CoworkerContact> Contacts
        {
            get => _contacts;
            set => _contacts = value;
        }

        public string FullName
        {
            get { return (NameLast + " " + NameFirst + " " + NameMiddle)?.Trim(); }
        }

        public string MobilePhone
        {
            get { return Contacts.FirstOrDefault(x => x.ContactType.ContactTypeEnum == ContactTypes.Mobile)?.Value; }
        }

        public string WorkPhone
        {
            get { return Contacts.FirstOrDefault(x => x.ContactType.ContactTypeEnum == ContactTypes.WorkPhone)?.Value; }
        }

        public string InternalPhone
        {
            get { return Contacts.FirstOrDefault(x => x.ContactType.ContactTypeEnum == ContactTypes.WorkPhone)?.Value; }
        }

        public override string ToString()
        {
            return NameLast + " " + Initials;
        }

        protected override string GetTitle()
        {
            return $"Карточка сотрудника: {NameLast} {Initials}";
        }
    }
}