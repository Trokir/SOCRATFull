using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core.Entities;
using Socrat.DataProvider;

namespace Socrat.References.Customer
{
    public partial class CxIpCommon : CxCustomerControl
    {
        private List<Country> _countries = null;

        public CxIpCommon()
        {
            InitializeComponent();

            if (null != Site && Site.DesignMode)
                return;

            Load += OnLoad;
        }

        protected override void OnLoad(object sender, EventArgs e)
        {
            if (null != Site && Site.DesignMode)
                return;

            _countries = DataHelper.GetAll<Country>();

            if (_customer != null)
                BindData();

            lueCountry.Properties.DataSource = null;
            lueCountry.Properties.DataSource = _countries;

            base.OnLoad(sender, e);
        }

        protected override void SetReadOnly(bool value)
        {
            _readOnly = value;
            teName.ReadOnly = value;
            teCode1C.ReadOnly = value;
            teInn.ReadOnly = value;
            deReg.ReadOnly = value;
            lueCountry.ReadOnly = value;
        }

        private void BindData()
        {
            teName.DataBindings.Clear();
            teName.DataBindings.Add("EditValue", Customer, "FullName", true, DataSourceUpdateMode.OnPropertyChanged);
            teCode1C.DataBindings.Clear();
            teCode1C.DataBindings.Add("EditValue", Customer, "Code1C", true, DataSourceUpdateMode.OnPropertyChanged);
            teInn.DataBindings.Clear();
            teInn.DataBindings.Add("EditValue", Customer, "Inn", true, DataSourceUpdateMode.OnPropertyChanged);
            deReg.DataBindings.Clear();
            deReg.DataBindings.Add("EditValue", Customer, "DateReg");
;
            lcFullName.DataBindings.Clear();
            lcFullName.DataBindings.Add("Text", Customer, "FullName", true, DataSourceUpdateMode.OnPropertyChanged);

            lueCountry.EditValue = Customer?.Country?.Id;
        }


        private void deReg_EditValueChanged(object sender, EventArgs e)
        {
            Customer.DateReg = deReg.DateTime;
        }

        private void lueCitezenship_EditValueChanged(object sender, EventArgs e)
        {
            Guid _id;
            if (_countries != null && lueCountry.EditValue != null && Guid.TryParse(lueCountry.EditValue.ToString(), out _id))
            {
                Customer.Country = _countries.FirstOrDefault(x => x.Id == _id);
            }
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit>{ teName, lueCountry};
        }
    }
}
