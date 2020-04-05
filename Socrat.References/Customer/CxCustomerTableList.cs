using System;
using System.Collections.Generic;
using Socrat.UI.Core;

namespace Socrat.References.Customer
{
    public partial class CxCustomerTableList : CxTableList, ICustomerControl
    {
        public event EventHandler ListChanged;
        public event EventHandler NeedFocus;

        private List<ICustomerControl> _customerControls = null; 

        public CxCustomerTableList()
        {
            InitializeComponent();

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

           
            _customerControls = new List<ICustomerControl>();
        }

        protected Core.Entities.Customer _customer;

        public Core.Entities.Customer Customer
        {
            get => _customer;
            set => SetCustomer(value);
        }

        private void SetCustomer(Core.Entities.Customer value)
        {
            _customer = value;
            if (_customerControls != null)
                for (int i = 0; i < _customerControls.Count; i++)
                {
                    _customerControls[i].Customer = value;
                }
        }

        public List<ICustomerControl> CustomerControls
        {
            get { return _customerControls; }
            set { _customerControls = value; }
        }

        protected void OnListChanged()
        {
            if (ListChanged != null)
                ListChanged(this, new EventArgs());
        }
    }
}
