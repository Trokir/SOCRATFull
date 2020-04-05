using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Utils;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.UI.Core;

namespace Socrat.References.Address
{
    public partial class FxAddressEdit : FxBaseSimpleDialog
    {
        public Core.Entities.Address Address { get; set; }
        private List<Country> _countries;
        private List<AddressElement> _addressElements;

        private Socrat.Core.IRepository<AddressItem> _adressItemsRepository;
        private Socrat.Core.IRepository<AddressItem> AdressItemsRepository
        {
            get { return GetAdressItemsRepository(); }
        }

        public FxAddressEdit()
        {
            InitializeComponent();
            Load += FxAddressEdit_Load;
        }

        private void FxAddressEdit_Load(object sender, System.EventArgs e)
        {
            using (DataFactory _factory = new DataFactory())
            {
                Socrat.Core.IRepository<Socrat.Core.Entities.Country> _countryRepo = _factory.CreateRepository<Socrat.Core.IRepository<Country>>();
                _countries = _countryRepo.GetAll().ToList();

                Socrat.Core.IRepository<AddressElement> _aeRepo = _factory.CreateRepository<Socrat.Core.IRepository<AddressElement>>();
                _addressElements = _aeRepo.GetAll().ToList();
            }

            CustomizeLookUps();

            lueCountry.Properties.DataSource = _countries;
            lueSubject.Properties.DataSource = _addressElements
                .Where(x => x.AddressElementType.Enum == AddressElementTypeEnum.Subject);
            lueRegion.Properties.DataSource = _addressElements
                .Where(x => x.AddressElementType.Enum == AddressElementTypeEnum.Region);
            lueCity.Properties.DataSource = _addressElements
                .Where(x => x.AddressElementType.Enum == AddressElementTypeEnum.City);
            lueStreet.Properties.DataSource = _addressElements
                .Where(x => x.AddressElementType.Enum == AddressElementTypeEnum.Street);
            lueHouse.Properties.DataSource = _addressElements
                .Where(x => x.AddressElementType.Enum == AddressElementTypeEnum.House);
            lueCorp.Properties.DataSource = _addressElements
                .Where(x => x.AddressElementType.Enum == AddressElementTypeEnum.Subhouse);
            lueFlat.Properties.DataSource = _addressElements
                .Where(x => x.AddressElementType.Enum == AddressElementTypeEnum.Flat);

            lueCountry.EditValue = Address?.Country?.Id;
            BindEditor(teZipCode, Address, x => x.ZipCode);
            SetAddressItems();
            Address.Changed = false;
        }

        private void SetAddressItems()
        {
            foreach (Socrat.Core.Entities.AddressItem addressItem in Address.AddressItems)
            {
                switch (addressItem.AddressElement.AddressElementType.Enum)
                {
                    case AddressElementTypeEnum.Subject:
                        GetItem(lueSubject, teSubject, addressItem);
                        break;
                    case AddressElementTypeEnum.Region:
                        GetItem(lueRegion, teRegion, addressItem);
                        break;
                    case AddressElementTypeEnum.City:
                        GetItem(lueCity, teCity, addressItem);
                        break;
                    case AddressElementTypeEnum.Street:
                        GetItem(lueStreet, teStreet, addressItem);
                        break;
                    case AddressElementTypeEnum.House:
                        GetItem(lueHouse, teHouse, addressItem);
                        break;
                    case AddressElementTypeEnum.Subhouse:
                        GetItem(lueCorp, teCorp, addressItem);
                        break;
                    case AddressElementTypeEnum.Flat:
                        GetItem(lueFlat, teFlat, addressItem);
                        break;
                }
            }
        }

        private void GetItem(LookUpEdit lookUpEdit, TextEdit textEdit, AddressItem addressItem)
        {
            lookUpEdit.EditValue = addressItem.AddressElement.Id;
            textEdit.EditValue = addressItem.Value;
        }

        private void CustomizeLookUps()
        {
            List<LookUpEdit> _lookUpEdits = new List<LookUpEdit>
            {
                lueCountry, lueSubject, lueRegion, lueCity, lueStreet, lueHouse, lueCorp, lueFlat
            };

            foreach (LookUpEdit lookUpEdit in _lookUpEdits)
            {
                lookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                    new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ShortName", "Имя")});
                lookUpEdit.Properties.DisplayMember = "ShortName";
                lookUpEdit.Properties.ValueMember = "Id";
                lookUpEdit.Properties.ShowFooter = false;
                lookUpEdit.Properties.ShowHeader = false;
                lookUpEdit.Properties.AllowNullInput = DefaultBoolean.False;
            }
        }

        protected override IEntity GetEntity()
        {
            return Address;
        }

        protected override void SetEntity(IEntity value)
        {
            Address = value as Core.Entities.Address;
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { lueCountry, lueCity };
        }

        private string GetAddressElementNameFromLookUp(LookUpEdit lookUpEdit, ComboBoxEdit valueList)
        {
            string _name = string.Empty;
            AddressElement _element = GetAddressElementFromLookUp(lookUpEdit);
            _name = _element?.Name;

            if (valueList != null)
            {
                valueList.Properties.Items.Clear();
                var _items = AdressItemsRepository
                    .GetAll(x => x.AddressElement.Id == _element.Id)
                    .Select(x => x.Value).Distinct().OrderBy(x => x).ToArray();

                valueList.Properties.Items.AddRange(_items);
            }

            return _name;
        }

        private AddressElement GetAddressElementFromLookUp(LookUpEdit lookUpEdit)
        {
            Guid _id;
            AddressElement _element = null;
            if (lookUpEdit.EditValue != null && Guid.TryParse(lookUpEdit.EditValue.ToString(), out _id))
            {
                _element = _addressElements.FirstOrDefault(x => x.Id == _id);
            }
            return _element;
        }

        private void lueSubject_EditValueChanged(object sender, EventArgs e)
        {
            layoutControlItem4.Text = GetAddressElementNameFromLookUp(lueSubject, teSubject);

        }

        private void lueRegion_EditValueChanged(object sender, EventArgs e)
        {
            layoutControlItem6.Text = GetAddressElementNameFromLookUp(lueRegion, teRegion);
        }

        private void lueCity_EditValueChanged(object sender, EventArgs e)
        {
            layoutControlItem8.Text = GetAddressElementNameFromLookUp(lueCity, teCity);
        }

        private void lueStreet_EditValueChanged(object sender, EventArgs e)
        {
            layoutControlItem10.Text = GetAddressElementNameFromLookUp(lueStreet, teStreet);
        }

        private void lueHouse_EditValueChanged(object sender, EventArgs e)
        {
            layoutControlItem12.Text = GetAddressElementNameFromLookUp(lueHouse, null);
        }

        private void lueCorp_EditValueChanged(object sender, EventArgs e)
        {
            layoutControlItem14.Text = GetAddressElementNameFromLookUp(lueCorp, null);
        }

        private void lueFlat_EditValueChanged(object sender, EventArgs e)
        {
            layoutControlItem16.Text = GetAddressElementNameFromLookUp(lueFlat, null);
        }

        private void teSubject_EditValueChanged(object sender, EventArgs e)
        {
            SetItem(lueSubject, teSubject);
        }

        private void SetItem(LookUpEdit lookUpEdit, ComboBoxEdit textEdit)
        {
            Address.Changed = true;
            if (lookUpEdit.EditValue != null && textEdit.EditValue != null)
            {
                AddressElement _element = GetAddressElementFromLookUp(lookUpEdit);
                if (_element == null)
                    return;

                AddressItem _item = Address
                    .AddressItems
                    .FirstOrDefault(x => x.AddressElement.AddressElementType.Id == _element.AddressElementType.Id);
                if (_item == null)
                {
                    _item = new AddressItem { Address = this.Address, AddressElement = _element };
                    Address.AddressItems.Add(_item);
                }

                _item.AddressElement = _element;
                _item.Value = textEdit.EditValue.ToString();
            }
        }

        private void teRegion_EditValueChanged(object sender, EventArgs e)
        {
            SetItem(lueRegion, teRegion);
        }

        private void teCity_EditValueChanged(object sender, EventArgs e)
        {
            SetItem(lueCity, teCity);
        }

        private void teStreet_EditValueChanged(object sender, EventArgs e)
        {
            SetItem(lueStreet, teStreet);
        }

        private void teHouse_EditValueChanged(object sender, EventArgs e)
        {
            SetItem(lueHouse, teHouse);
        }

        private void teCorp_EditValueChanged(object sender, EventArgs e)
        {
            SetItem(lueCorp, teCorp);
        }

        private void teFlat_EditValueChanged(object sender, EventArgs e)
        {
            SetItem(lueFlat, teFlat);
        }

        private void lueCountry_EditValueChanged(object sender, EventArgs e)
        {
            Guid _id;
            if (lueCountry.EditValue != null && Guid.TryParse(lueCountry.EditValue.ToString(), out _id))
            {
                Address.Country = _countries.FirstOrDefault(x => x.Id == _id);
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            Address.ZipCode = teZipCode.Text;
        }

        protected override void SaveButtonClicked()
        {
            Close();
        }

        protected override void SetReadOnly(bool value)
        {
            base.SetReadOnly(value);
            layoutControl.Controls.OfType<BaseEdit>().ForEach(x => x.ReadOnly = value);
        }

        private Socrat.Core.IRepository<AddressItem> GetAdressItemsRepository()
        {
            if (_adressItemsRepository == null)
                _adressItemsRepository = DataHelper.GetRepository<AddressItem>();
            return _adressItemsRepository;
        }
    }
}