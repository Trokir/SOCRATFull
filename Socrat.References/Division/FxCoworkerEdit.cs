using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.References.Contact;
using Socrat.UI.Core;

namespace Socrat.References.Division
{
    public partial class FxCoworkerEdit : FxBaseSimpleDialog
    {
        private Coworker _coworker;
        public Coworker Coworker
        {
            get => _coworker;
            set => SetCoworker(value);
        }

        private List<Gender> _genders;

        private CxCoworkerContacts _cxCoworkerContacts;

        public FxCoworkerEdit()
        {
            InitializeComponent();

            Load += FxCoworkerEdit_Load;

            using (DataFactory _factory = new DataFactory())
            {
                var _repo = _factory.CreateRepository<Socrat.Core.IRepository<Gender>>();
                _genders = _repo.GetAll().ToList();
                lueGender.Properties.DataSource = _genders;
            }
        }

        private void FxCoworkerEdit_Load(object sender, EventArgs e)
        {
            teInitials.ReadOnly = true;
            InitContacts();
        }

        private void SetCoworker(Coworker value)
        {
            _coworker = value;
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teLastName, _coworker, x => x.LastName);
            BindEditor(teMiddleName, _coworker, x => x.MiddleName);
            BindEditor(teFirstName, _coworker, x => x.FirstName);
            BindEditor(teInitials, _coworker, x => x.Initials);

            deBirth.DateTime = _coworker.BirthDay ?? DateTime.Now.AddDays(-35);
            lueGender.EditValue = _coworker.Gender?.Id;
        }

        private void InitContacts()
        {
            _cxCoworkerContacts = new CxCoworkerContacts();
            _cxCoworkerContacts.DependedSaving = true;
            _cxCoworkerContacts.Coworker = Coworker;
            tableLayoutPanelContent.Controls.Add(_cxCoworkerContacts, 0, 1);
            _cxCoworkerContacts.Dock = DockStyle.Fill;
            _cxCoworkerContacts.DialogOutput += CxCoworkerContacts_DialogOutput;
            _cxCoworkerContacts.ReadOnly = this.ReadOnly;
        }

        private void CxCoworkerContacts_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
        }

        protected override IEntity GetEntity()
        {
            return Coworker;
        }

        protected override void SetEntity(IEntity value)
        {
            Coworker = value as Coworker;
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teFirstName, teLastName, deBirth };
        }

        private void deBirth_EditValueChanged(object sender, EventArgs e)
        {
            _coworker.BirthDay = deBirth.DateTime;
        }

        private void lueGender_EditValueChanged(object sender, EventArgs e)
        {
            if (lueGender.EditValue != null)
            {
                Guid _id;
                if (Guid.TryParse(lueGender.EditValue.ToString(), out _id))
                {
                    _coworker.Gender = _genders.FirstOrDefault(x => x.Id == _id);
                }
            }
        }

        protected override void SetReadOnly(bool value)
        {
            base.SetReadOnly(value);
            layoutControl.Controls.OfType<BaseEdit>().ForEach(x => x.ReadOnly = value);
            if (null != _cxCoworkerContacts)
                _cxCoworkerContacts.ReadOnly = value;
        }
    }
}