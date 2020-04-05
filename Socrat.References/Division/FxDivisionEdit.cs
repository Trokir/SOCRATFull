using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.References.Address;
using Socrat.UI.Core;

namespace Socrat.References.Division
{
    public partial class FxDivisionEdit : FxBaseSimpleDialog
    {
        private AddressButtonEditAssistent _addressButtonEditAssistent;

        private CxDivisionCustomers _cxDivisionCustomers;
        private CxDivisionCoworkers _cxDivisionCoworkers;
        private CxDivisionSignatures _cxDivisionSignatures;
        private CxDivisionContacts _cxDivisionContacts;
        private Socrat.Core.Entities.Division _division;

        public FxDivisionEdit()
        {
            InitializeComponent();

            Load += FxDivisionEdit_Load;
        }

        private void FxDivisionEdit_Load(object sender, EventArgs e)
        {
            InitCustomersTab();
            InitCoworkers();
            InitDivisionSignatures();
            InitDivisionContacts();

            _addressButtonEditAssistent = new AddressButtonEditAssistent(beAdsress, Division.Address, null, OnDialogOutput);
            _addressButtonEditAssistent.BindProperty(Division, x => x.Address);
        }

        private void InitDivisionContacts()
        {
            _cxDivisionContacts = new CxDivisionContacts();
            _cxDivisionContacts.DependedSaving = true;
            _cxDivisionContacts.Division = Division;
            _cxDivisionContacts.DialogOutput += _OnDialogOutput;
            tpContacts.Controls.Add(_cxDivisionContacts);
            _cxDivisionContacts.Dock = DockStyle.Fill;
            _cxDivisionContacts.ReadOnly = this.ReadOnly;
        }

        private void InitCustomersTab()
        {
            _cxDivisionCustomers = new CxDivisionCustomers();
            _cxDivisionCustomers.DependedSaving = true;
            _cxDivisionCustomers.Division = Division;
            _cxDivisionCustomers.DialogOutput += _OnDialogOutput;
            tpCutomers.Controls.Add(_cxDivisionCustomers);
            _cxDivisionCustomers.Dock = DockStyle.Fill;
            _cxDivisionCustomers.ReadOnly = this.ReadOnly;
        }

        private void InitCoworkers()
        { 
            _cxDivisionCoworkers = new CxDivisionCoworkers();
            _cxDivisionCoworkers.DependedSaving = true;
            _cxDivisionCoworkers.Division = Division;
            _cxDivisionCoworkers.DialogOutput += _OnDialogOutput;
            tpCoworkers.Controls.Add(_cxDivisionCoworkers);
            _cxDivisionCoworkers.Dock = DockStyle.Fill;
            _cxDivisionCoworkers.ReadOnly = this.ReadOnly;
        }

        private void InitDivisionSignatures()
        {
            _cxDivisionSignatures = new CxDivisionSignatures();
            _cxDivisionSignatures.DependedSaving = true;
            _cxDivisionSignatures.Division = Division;
            _cxDivisionSignatures.DialogOutput += _OnDialogOutput;
            tpSignatures.Controls.Add(_cxDivisionSignatures);
            _cxDivisionSignatures.Dock = DockStyle.Fill;
            _cxDivisionSignatures.ReadOnly = this.ReadOnly;
        }

        private void _OnDialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
        }

        public Core.Entities.Division Division
        {
            get => _division;
            set => SetDivision(value);
        }

        private void SetDivision(Core.Entities.Division value)
        {
            _division = value;
        }

        protected override void SetEntity(IEntity value)
        {
            Division = value as Core.Entities.Division;
        }

        protected override IEntity GetEntity()
        {
            return Division;
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teAlias, teFullName, teShortName, cbRegion};
        }

        protected override void BindData()
        {
            base.BindData();
            teFullName.DataBindings.Clear();
            teFullName.DataBindings.Add("EditValue", Division, "FullName", true, DataSourceUpdateMode.OnPropertyChanged);
            teShortName.DataBindings.Clear();
            teShortName.DataBindings.Add("EditValue", Division, "ShortName", true, DataSourceUpdateMode.OnPropertyChanged);
            teAlias.DataBindings.Clear();
            teAlias.DataBindings.Add("EditValue", Division, "AliasName", true, DataSourceUpdateMode.OnPropertyChanged);
            cbRegion.DataBindings.Clear();
            cbRegion.DataBindings.Add("EditValue", Division, "Region", true, DataSourceUpdateMode.OnPropertyChanged);
            seNumber.DataBindings.Clear();
            seNumber.DataBindings.Add("EditValue", Division, "Number", true, DataSourceUpdateMode.OnPropertyChanged);
            beAdsress.EditValue = Division.Address;
        }

        //private void beAdsress_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    FxAddressEdit _fx = new FxAddressEdit();
        //    _fx.Address = Division.Address ?? new Core.Entities.Address();
        //    _fx.SaveButtonClick += (o, args) =>
        //    {
        //        Division.Address = _fx.Address;
        //        DevExpress.XtraEditors.ButtonEdit edit = sender as DevExpress.XtraEditors.ButtonEdit;
        //        edit.Text = _fx.Address.ToString();
        //        edit.EditValue = _fx.Address;
        //    };
        //    OnDialogOutput(_fx, DialogOutputType.Dialog);
        //}
    }
}