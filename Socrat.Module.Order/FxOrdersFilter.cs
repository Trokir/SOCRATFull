using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.UI.Core;

namespace Socrat.Module.Order
{
    public partial class FxOrdersFilter : FxBaseForm
    {
        public event EventHandler SetFilter;
        public OrdersFilter Filter { get; set; }
        public List<Customer> _customers { get; set; }
        private List<OrderStatus> _orderStatuses;

        public FxOrdersFilter()
        {
            InitializeComponent();
            Load += FxOrdersFilter_Load;

       }

        private void FxOrdersFilter_Load(object sender, System.EventArgs e)
        {
            using (DataFactory _factory = new DataFactory())
            {
                IRepository<Customer> _repository = _factory.CreateRepository<IRepository<Customer>>();
                _customers = _repository.GetAll().ToList();
            }
            lueCustomer.Properties.DataSource = null;
            lueCustomer.Properties.DataSource = _customers;


            using (DataFactory _factory = new DataFactory())
            {
                IRepository<OrderStatus> _repository = _factory.CreateRepository<IRepository<OrderStatus>>();
                _orderStatuses = _repository.GetAll().ToList();
            }

            lueStatus.Properties.DataSource = null;
            lueStatus.Properties.DataSource = _orderStatuses;

            deStartPeriod.DateTime = Filter.DateStart;
            deEndPeriod.DateTime = Filter.DateEnd;
            rgDate.EditValue = (int)Filter.DateType;
            teNum.Text = Filter.Number;
            rgNumType.EditValue = (int)Filter.NumberType;
            lueCustomer.EditValue = Filter.Customer?.Id;
            lueStatus.EditValue = Filter.OrderStatus?.Id;
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            Filter.DateStart = deStartPeriod.DateTime;
            Filter.DateEnd = deEndPeriod.DateTime;
            Filter.DateType = (OrdersFilterDateType)rgDate.EditValue;
            Filter.Number = teNum.Text;
            Filter.NumberType = (OrdersFilterNumberType)rgNumType.EditValue;

            Guid _customerId;
            if (lueCustomer.EditValue != null && Guid.TryParse(lueCustomer.EditValue.ToString(), out _customerId))
                Filter.Customer = _customers.FirstOrDefault(x => x.Id == _customerId);

            Guid _status;
            if (lueStatus.EditValue != null && Guid.TryParse(lueStatus.EditValue.ToString(), out _status))
                this.Filter.OrderStatus = _orderStatuses.FirstOrDefault(x => x.Id == _status);

            OnSetFilter();

            DialogResult = DialogResult.OK;
            Close();
        }

        public void OnSetFilter()
        {
            SetFilter?.Invoke(this, EventArgs.Empty);
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void lueStatus_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}