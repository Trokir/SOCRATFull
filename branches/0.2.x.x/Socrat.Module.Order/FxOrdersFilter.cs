using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Socrat.DataProvider;
using Socrat.Model;
using Socrat.UI.Core;

namespace Socrat.Module.Order
{
    public partial class FxOrdersFilter : FxBaseForm
    {
        public event EventHandler SetFilter;
        public OrdersFilter Filter { get; set; }
        public List<Model.Customer> _customers { get; set; }

        public FxOrdersFilter()
        {
            InitializeComponent();
            Load += FxOrdersFilter_Load;

       }

        private void FxOrdersFilter_Load(object sender, System.EventArgs e)
        {
            using (EFDataFactory _factory = new EFDataFactory())
            {
                IRepository<Model.Customer> _repository = _factory.CreateRepository<IRepository<Model.Customer>>();
                _customers = _repository.GetAll().ToList();
            }

            lueCustomer.Properties.DataSource = null;
            lueCustomer.Properties.DataSource = _customers;

            deStartPeriod.DateTime = Filter.DateStart;
            deEndPeriod.DateTime = Filter.DateEnd;
            rgDate.EditValue = (int)Filter.DateType;
            teNum.Text = Filter.Number;
            rgNumType.EditValue = (int)Filter.NumberType;
            lueCustomer.EditValue = Filter.Customer?.Id;
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
    }
}