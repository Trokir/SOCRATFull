using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.UI.Core;

namespace Socrat.References.Contact
{
    public partial class FxCoworkerContactEdit : FxBaseSimpleDialog
    {
        private List<ContactType> _contactTypes;
        private CoworkerContact _coworkerContact;

        public CoworkerContact CoworkerContact
        {
            get => _coworkerContact;
            set => SetCoworkerContract(value);
        }

        private void SetCoworkerContract(CoworkerContact value)
        {
            _coworkerContact = value;
        }

        public FxCoworkerContactEdit()
        {
            InitializeComponent();

            using (DataFactory _factory = new DataFactory())
            {
                Socrat.Core.IRepository<ContactType> _repository = _factory.CreateRepository<Socrat.Core.IRepository<ContactType>>();
                _contactTypes = _repository.GetAll().ToList();
                lueType.Properties.DataSource = _contactTypes;
            }
        }

        protected override void SetEntity(IEntity value)
        {
            CoworkerContact = value as CoworkerContact;
        }

        protected override IEntity GetEntity()
        {
            return CoworkerContact;
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit>{lueType, teValue};
        }

        protected override void BindData()
        {
            base.BindData();
            teValue.DataBindings.Clear();
            teValue.DataBindings.Add("EditValue", CoworkerContact, "Value", true, DataSourceUpdateMode.OnPropertyChanged);
            lcFio.DataBindings.Clear();
            lcFio.DataBindings.Add("Text", CoworkerContact, "Coworker");
            lueType.EditValue = CoworkerContact?.ContactType?.Id;
        }

        private void lueType_EditValueChanged(object sender, EventArgs e)
        {
            Guid _id;
            if (lueType.EditValue != null && Guid.TryParse(lueType.EditValue.ToString(), out _id))
            {
                _coworkerContact.ContactType = _contactTypes.FirstOrDefault(x => x.Id == _id);
                teValue.Properties.Mask.MaskType = MaskType.RegEx;
                teValue.Properties.Mask.EditMask = _coworkerContact?.ContactType?.RegexMask;
            }
        }
    }
}