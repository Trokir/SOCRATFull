using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.BL.PriceLists.Abstract;
using Socrat.UI.Core;
using Socrat.References.Customer;
using Socrat.References.Division;

namespace Socrat.References.Price
{
    public partial class FxPriceEdit : FxBaseSimpleDialog
    {
        private IPriceService _priceService;
        public Core.Entities.Price Price { get; set; }

        protected override string GetTitle()
        {
            return "Региональный прайс";
        }

        protected override IEntity GetEntity()
        {
            return Price;
        }

        protected override void SetEntity(IEntity value)
        {
            Price = value as Core.Entities.Price;
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(tePriceName, Price, x => x.Name);
            beCustomer.DataBindings.Clear();
            beCustomer.DataBindings.Add("EditValue", Price, "Customer", true, DataSourceUpdateMode.OnPropertyChanged);
            beDivision.DataBindings.Clear();
            beDivision.DataBindings.Add("EditValue", Price, "Division", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { tePriceName, beDivision };
        }

        public FxPriceEdit()
        {
            InitializeComponent();
           // _priceService = CompositionRoot.Resolve<IPriceService>();

        }

        private void beCustomer_Click(object sender, EventArgs e)
        {
            OpenCustomerList();
        }
        private void OpenCustomerList()
        {
            FxCustomers customers = new FxCustomers();
            customers.SetSingleSelectMode(Price.Customer);
            DialogResult dialogResult = customers.ShowDialog(this);
            if (dialogResult != DialogResult.Cancel && customers.SelectedItem != null)
                Price.Customer = customers.SelectedItem as Core.Entities.Customer;
        }

        private void beDivision_Click(object sender, EventArgs e)
        {
            OpenDivisionList();
        }

        private void OpenDivisionList()
        {
            FxDivisions divisions = new FxDivisions();
            divisions.SetSingleSelectMode(Price.Division);
            DialogResult dialogResult = divisions.ShowDialog(this);
            if (dialogResult != DialogResult.Cancel && divisions.SelectedItem != null)
                Price.Division = divisions.SelectedItem as Core.Entities.Division;
        }
    }
}