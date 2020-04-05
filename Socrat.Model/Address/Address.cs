using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Socrat.Model
{
    public class Address: Entity
    {
        public Address()
        {
            AddressItems = new ObservableCollection<AddressItem>();
            AddressItems.CollectionChanged += AddressItems_CollectionChanged;
            AddressContacts = new ObservableCollection<AddressContact>();
            AddressContacts.CollectionChanged += AddressItems_CollectionChanged;
        }

        private void AddressItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Changed = true;
            OnPropertyChanged(() => Title);
        }

        private Country _Country;
        public Country Country
        {
            get { return _Country; }
            set { SetField(ref _Country, value, () => Country); }
        }

        public Nullable<Guid> Country_Id
        {
            get { return Country?.Id; }
        }

        private string _ZipCode;
        public string ZipCode
        {
            get { return _ZipCode; }
            set { SetField(ref _ZipCode, value, () => ZipCode); }
        } 

        private string _ValueStr;
        public string ValueStr
        {
            get { return GetValueStr(); }
            set { SetField(ref _ValueStr, value, () => ValueStr); }
        }

        private string GetValueStr()
        {
            if (string.IsNullOrEmpty(_ValueStr))
                _ValueStr = GetStrAddress();
            return _ValueStr;
        }

        public ObservableCollection<AddressItem> AddressItems { get; set; }
        public ObservableCollection<AddressContact> AddressContacts { get; set; }

        public override string ToString()
        {
            return GetStrAddress();
        }

        private string GetStrAddress()
        {
            string _address = String.Empty;
            IEnumerable<Model.AddressItem> _items = AddressItems.OrderBy(x => x.AddressElement.AddressElementType.Sort);
            _address = (Country == null || string.IsNullOrEmpty(Country.NameFull) 
                            ? string.Empty 
                            : Country.NameFull + ", ") + string.Join(", ", _items);
            return _address;
        }

        protected override string GetTitle()
        {
            return "Адрес: " + GetStrAddress();
        }

        public void AppendItem(AddressItem item)
        {
            AddressItems.Add(item);
            Changed = true;
        }

        public void ReplaceItem(AddressItem oldItem, AddressItem item)
        {
            item.Id = oldItem.Id;
            AddressItems.Remove(oldItem);
            AddressItems.Add(item);
            Changed = true;
        }
    }
}