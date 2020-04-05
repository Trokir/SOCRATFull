using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.UI.Core;

namespace Socrat.References.Contact
{
    public partial class FxCustomerContactEdit : FxBaseSimpleDialog
    {
        public CustomerContact CustomerContact { get; set; }
        private List<ContactType> _contactTypes;

        public FxCustomerContactEdit()
        {
            InitializeComponent();
            Load += FxCustomerContactEdit_Load;
        }

        private void FxCustomerContactEdit_Load(object sender, EventArgs e)
        {
            _contactTypes = DataHelper.GetAll<ContactType>().ToList();
            lueContactType.Properties.DataSource = _contactTypes;
        }

        protected override IEntity GetEntity()
        {
            return CustomerContact;
        }

        protected override void SetEntity(IEntity value)
        {
            CustomerContact = value as CustomerContact;
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teValue, CustomerContact, x => x.Value);
            lueContactType.EditValue = CustomerContact?.ContactType?.Id;
        }

        private void lueContactType_EditValueChanged(object sender, EventArgs e)
        {
            Guid _id;
            if (_contactTypes != null && lueContactType.EditValue != null && Guid.TryParse(lueContactType.EditValue.ToString(), out _id))
            {
                ContactType _contactType = _contactTypes.FirstOrDefault(x => x.Id == _id);
                CustomerContact.ContactType = _contactType;
                if (_contactType != null)
                {
                    teValue.Properties.Mask.MaskType = MaskType.RegEx;
                    teValue.Properties.Mask.EditMask = _contactType.RegexMask;
                    teValue.Properties.Mask.AutoComplete = AutoCompleteType.Strong;
                }
            }

        }
        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { lueContactType, teValue };
        }
    }
}