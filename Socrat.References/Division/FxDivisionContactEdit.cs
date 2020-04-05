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

namespace Socrat.References.Division
{
    public partial class FxDivisionContactEdit : FxBaseSimpleDialog
    {
        public DivisionContact DivisionContact { get; set; }
        private List<DepartmentType> _departmentTypes;
        private List<ContactType> _contactTypes;

        public FxDivisionContactEdit()
        {
            InitializeComponent();
            Load += FxDivisionContactEdit_Load;
        }

        private void FxDivisionContactEdit_Load(object sender, EventArgs e)
        {
            using (DataFactory _factory = new DataFactory())
            {
                var _dtr = _factory.CreateRepository<Socrat.Core.IRepository<DepartmentType>>();
                _departmentTypes = _dtr.GetAll().ToList();
                lueDepart.Properties.DataSource = null;
                lueDepart.Properties.DataSource = _departmentTypes;

                var _dtc = _factory.CreateRepository<Socrat.Core.IRepository<ContactType>>();
                _contactTypes = _dtc.GetAll().ToList();
                lueConatctType.Properties.DataSource = null;
                lueConatctType.Properties.DataSource = _contactTypes;
            }
        }

        protected override IEntity GetEntity()
        {
            return DivisionContact;
        }

        protected override void SetEntity(IEntity value)
        {
            DivisionContact = value as DivisionContact;
        }

        protected override void BindData()
        {
            base.BindData();
            teValue.DataBindings.Add("EditValue", DivisionContact, "Value", true, DataSourceUpdateMode.OnPropertyChanged);
            lueDepart.EditValue = DivisionContact.DepartmentTypeId;
            lueConatctType.EditValue = DivisionContact.ContactTypeId;
        }

        private void lueDepart_EditValueChanged(object sender, EventArgs e)
        {
            Guid _id;
            if (lueDepart.EditValue != null
                && Guid.TryParse(lueDepart.EditValue.ToString(), out _id)
                && _departmentTypes != null)
            {
                DivisionContact.DepartmentType = _departmentTypes?.FirstOrDefault(x => x.Id == _id);
            }
        }

        private void lueConatctType_EditValueChanged(object sender, EventArgs e)
        {
            Guid _id;
            if (lueConatctType.EditValue != null
                && Guid.TryParse(lueConatctType.EditValue.ToString(), out _id)
                && _contactTypes != null)
            {
                DivisionContact.ContactType = _contactTypes.FirstOrDefault(x => x.Id == _id);
                teValue.Properties.Mask.MaskType = MaskType.RegEx;
                teValue.Properties.Mask.EditMask = DivisionContact.ContactType.RegexMask;
                teValue.Properties.Mask.AutoComplete = AutoCompleteType.Strong;
            }
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { lueDepart, lueConatctType, teValue };
        }
    }
}