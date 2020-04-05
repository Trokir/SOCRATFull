using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.DataProvider;
using Socrat.Lib;
using Socrat.UI.Core;

namespace Socrat.Module.Order
{
    public partial class FxOrderEdit : FxBaseSimpleDialog
    {
        public Model.Order Order { get; set; }
        private CxOrderRows cxOrderRows;
        private List<Model.Division> _divisions;
        private List<Model.Customer> _customers;
        private List<Model.Account> _accounts;

        public FxOrderEdit()
        {
            InitializeComponent();

            cxOrderRows = new CxOrderRows();
            cxOrderRows.Order = Order;
            pnlRows.Controls.Add(cxOrderRows);
            cxOrderRows.Dock = DockStyle.Fill;
            cxOrderRows.DialogOutput += CxOrderRows_DialogOutput;

            Load += FxOrderEdit_Load;
            Resize += FxOrderEdit_Resize1;
        }

        private void FxOrderEdit_Resize1(object sender, EventArgs e)
        {
            Update();
        }

        private void CxOrderRows_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta.NewTab, ta.OutputType);
        }

        private void FxOrderEdit_Load(object sender, EventArgs e)
        {
        }

        private void LoadComboboxData()
        {
            using (EFDataFactory _factory = new EFDataFactory())
            {
                IRepository<Model.Division> _divisionRepo = _factory.CreateRepository<IRepository<Model.Division>>();
                _divisions = _divisionRepo.GetAll().ToList();
            }

            lueDivision.Properties.DataSource = null;
            lueDivision.Properties.DataSource = _divisions;
        }

        protected override IEntity GetEntity()
        {
            return Order;
        }

        protected override void SetEntity(IEntity value)
        {
            Order = value as Model.Order;
            cxOrderRows.Order = Order;
        }

        protected override void BindData()
        {
            base.BindData();
            //deInput.DateTime = Order.DateInput;
            //deWork.DateTime = Order.DateWork;
            //deCustomer.DateTime = Order.DateCustomer;

            BindEditor(deInput, Order, x => x.DateInput);
            BindEditor(deWork, Order, x => x.DateWork);
            BindEditor(deCustomer, Order, x => x.DateCustomer);

            this.DataBindings.Clear();
            this.DataBindings.Add("Text", Order, "Title", false, DataSourceUpdateMode.OnPropertyChanged);

            btnOrderSave.DataBindings.Clear();
            btnOrderSave.DataBindings.Add("Enabled", Order, "Changed", false, DataSourceUpdateMode.OnPropertyChanged);

            teNumCustomer.DataBindings.Clear();
            teNumCustomer.DataBindings.Add("EditValue", Order, "NumCustomer", false, DataSourceUpdateMode.OnPropertyChanged);
            meComment.DataBindings.Clear();
            meComment.DataBindings.Add("EditValue", Order, "Comment", false, DataSourceUpdateMode.OnPropertyChanged);

            LoadComboboxData();

            //lueDivision.DataBindings.Clear();
            //lueDivision.DataBindings.Add("EditValue", Order, "Division_Id", false, DataSourceUpdateMode.OnPropertyChanged);
            lueDivision.EditValue = Order.Division_Id;

            //lueCustomer.DataBindings.Clear();
            //lueCustomer.DataBindings.Add("EditValue", Order, "Customer_Id", false, DataSourceUpdateMode.OnPropertyChanged);
            lueCustomer.EditValue = Order.Customer_Id;

            //lueAccunt.DataBindings.Clear();
            //lueAccunt.DataBindings.Add("EditValue", Order, "Account_Id", false, DataSourceUpdateMode.OnPropertyChanged);
            lueAccunt.EditValue = Order.Account_Id;

            ceSelfShipping.Checked = Order.SelfShipping;
        }

        private void lueDivision_EditValueChanged(object sender, EventArgs e)
        {
            Guid _id;
            if (lueDivision.EditValue != null && Guid.TryParse(lueDivision.EditValue.ToString(), out _id))
            {
                Order.Division = _divisions.FirstOrDefault(x => x.Id == _id);

                _customers = null;
                _customers = Order.Division.DivisionCustomers.Select(x => x.Customer).ToList();
                lueCustomer.Properties.DataSource = null;
                lueCustomer.Properties.DataSource = _customers;
            }
        }

        private void lueCustomer_EditValueChanged(object sender, EventArgs e)
        {
            Guid _id;
            if (lueCustomer.EditValue != null && Guid.TryParse(lueCustomer.EditValue.ToString(), out _id))
            {
                Order.Customer = _customers.FirstOrDefault(x => x.Id == _id);

                _accounts = null;
                _accounts = Order?.Customer?.Accounts.ToList();

                lueAccunt.Properties.DataSource = null;
                lueAccunt.Properties.DataSource = _accounts;
            }
        }

        private void lueAccunt_EditValueChanged(object sender, EventArgs e)
        {
            Guid _id;
            if (lueAccunt.EditValue != null && Guid.TryParse(lueAccunt.EditValue.ToString(), out _id))
            {
                Order.Account = _accounts.FirstOrDefault(x => x.Id == _id);
            }
        }

        private void ceSelfShipping_EditValueChanged(object sender, EventArgs e)
        {
            Order.SelfShipping = ceSelfShipping.Checked;
            meAddress.Enabled = !ceSelfShipping.Checked;
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit>
            {
                lueDivision,
                lueCustomer,
                lueAccunt,
                teNumCustomer,
                deInput,
                deWork,
                deCustomer
            };
        }

        public override bool Validate()
        {
            return base.Validate() && cxOrderRows.Validate();
        }

        private void btnOrderSave_Click(object sender, EventArgs e)
        {
            if (Validate())
             OnSaveButtonClick();
        }

        private void btnOkNew_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                OnSaveButtonClick();
                SetEntity(new Model.Order());
                BindData();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}