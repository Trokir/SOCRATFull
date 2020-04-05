using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Socrat.Core.Added;

namespace Socrat.Core.Entities
{
    public class Coworker : Entity
    {
        public Coworker()
        {
            _coworkerContacts = new ObservableCollection<CoworkerContact>();
            _coworkerContacts.CollectionChanged += _contacts_CollectionChanged;
        }

        private void _contacts_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Changed = true;
        }
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { SetField(ref _firstName, value, () => FirstName, () => Initials, () => Title); }
        }
        private string _middleName;
        public string MiddleName
        {
            get { return _middleName; }
            set { SetField(ref _middleName, value, () => MiddleName, () => Initials, () => Title); }
        }
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { SetField(ref _lastName, value, () => LastName, () => Title); }
        }
        public Guid? GenderId { get; set; }

        private DateTime? _birthDay = DateTime.Now.AddDays(-40);
        public DateTime? BirthDay
        {
            get { return _birthDay; }
            set { SetField(ref _birthDay, value, () => BirthDay); }
        }
        private Gender _gender;
        public virtual Gender Gender
        {
            get { return _gender; }
            set { SetField(ref _gender, value, () => Gender); }
        }
        public virtual ICollection<Contract> Contracts { get; set; } = new HashSet<Contract>();
        private ObservableCollection<CoworkerContact> _coworkerContacts;

        public virtual ObservableCollection<CoworkerContact> CoworkerContacts
        {
            get => _coworkerContacts;
            set => _coworkerContacts = value;
        }
        public virtual ICollection<CoworkerPosition> CoworkerPositions { get; set; } = new HashSet<CoworkerPosition>();
        public virtual ICollection<DivisionSignature> DivisionSignatures { get; set; } = new HashSet<DivisionSignature>();
        public string Initials
        {
            get { return GetInitials(); }
        }
        private string GetInitials()
        {
            return ((!string.IsNullOrEmpty(FirstName)
                        ? FirstName.Substring(0, 1) + "."
                        : String.Empty) +
                    (!string.IsNullOrEmpty(MiddleName)
                        ? " " + MiddleName.Substring(0, 1) + "."
                        : string.Empty)).Trim();
        }
        public string FullName
        {
            get { return (LastName + " " + FirstName + " " + MiddleName)?.Trim(); }
        }

        public string MobilePhone
        {
            get { return CoworkerContacts.FirstOrDefault(x => x.ContactType.ContactTypeEnum == ContactTypes.Mobile)?.Value; }
        }

        public string WorkPhone
        {
            get { return CoworkerContacts.FirstOrDefault(x => x.ContactType.ContactTypeEnum == ContactTypes.WorkPhone)?.Value; }
        }

        public string InternalPhone
        {
            get { return CoworkerContacts.FirstOrDefault(x => x.ContactType.ContactTypeEnum == ContactTypes.WorkPhone)?.Value; }
        }

        public override string ToString()
        {
            return LastName + " " + Initials;
        }

        protected override string GetTitle()
        {
            return $"Карточка сотрудника: {LastName} {Initials}";
        }

    }
}
