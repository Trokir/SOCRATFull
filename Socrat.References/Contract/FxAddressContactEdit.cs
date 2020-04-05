using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.References.Division;
using Socrat.UI.Core;

namespace Socrat.References.Contract
{
    public partial class FxAddressContactEdit : FxBaseSimpleDialog
    {
        public AddressContact Contact { get; set; }
        public List<ContactType> ContactTypes { get => GetСontactTypes();}

        private List<ContactType> GetСontactTypes()
        {
            if (_contactTypes == null)
                using (DataFactory _factory = new DataFactory())
                {
                    Socrat.Core.IRepository<ContactType> _repo =
                        _factory.CreateRepository<Socrat.Core.IRepository<ContactType>>();
                    _contactTypes = _repo.GetAll().ToList();
                }

            lueContactType.Properties.DataSource = null;
            lueContactType.Properties.DataSource = _contactTypes;

            return _contactTypes;
        }

        private List<ContactType> _contactTypes;

        public FxAddressContactEdit()
        {
            InitializeComponent();
            Load += FxContractAddressContractEdit_Load;
        }

        private void FxContractAddressContractEdit_Load(object sender, System.EventArgs e)
        {
            GetСontactTypes();
        }

        protected override IEntity GetEntity()
        {
            return Contact;
        }

        protected override void SetEntity(IEntity value)
        {
            Contact = value as AddressContact;
        }

        private void beWorkPosition_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FxWorkPositions _fx = new FxWorkPositions();
            _fx.SetSingleSelectMode(Contact.WorkPosition);
            _fx.DialogOutput += (o, ta) => OnDialogOutput(ta);
            _fx.ItemSelected += (o, args) =>
            {
                beWorkPosition.EditValue = _fx.SelectedItem;
                Contact.WorkPosition = _fx.SelectedItem as WorkPosition;
            };
            OnDialogOutput(_fx, DialogOutputType.Dialog, this);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { lueContactType, teContactValue, teFio, beWorkPosition };
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teContactValue, Contact, x => x.Value);
            BindEditor(teFio, Contact, x => x.Name);
            beWorkPosition.EditValue = Contact.WorkPosition;
            lueContactType.EditValue = Contact.ContactType?.Id;
        }

        private void lueContactType_EditValueChanged(object sender, System.EventArgs e)
        {
            Guid _id;
            if (lueContactType.EditValue != null && Guid.TryParse(lueContactType.EditValue.ToString(), out _id))
            {
                Contact.ContactType = ContactTypes.FirstOrDefault(x => x.Id == _id);
                teContactValue.Properties.Mask.MaskType = MaskType.RegEx;
                teContactValue.Properties.Mask.EditMask = string.Format(@"{0}", Contact.ContactType.RegexMask);
            }
        }
    }
}