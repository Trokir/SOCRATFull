using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.BL.PriceLists.Abstract;
//using Socrat.Core.BL.PriceLists.Concrete;
using Socrat.Core.DI;
using Socrat.Core.Entities;
using Socrat.References.Customer;
using Socrat.References.Division;
using Socrat.UI.Core;

namespace Socrat.References.Price
{
    public partial class FxNewPrice : FxBaseSimpleDialog
    {
        private IPriceService _priceService;
        private Core.Entities.Price _price;
        public Core.Entities.Price Price
        {
            get { return _price; }
            set { _price = value; }
        }

        protected override IEntity GetEntity()
        {
            return Price;
        }

        protected override void SetEntity(IEntity value)
        {
            Price = value as Core.Entities.Price;
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { tePriceName, beDivision };
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(tePriceName, Price, x => x.Name);
            beCustomer.DataBindings.Clear();
            beCustomer.DataBindings.Add("EditValue", _price, "Customer", true, DataSourceUpdateMode.OnPropertyChanged);
            beDivision.DataBindings.Clear();
            beDivision.DataBindings.Add("EditValue", _price, "Division", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void OpenCustomerList()
        {
            FxCustomers customers = new FxCustomers();
            customers.SetSingleSelectMode(Price.Customer);
            DialogResult dialogResult = customers.ShowDialog(this);
            if (dialogResult != DialogResult.Cancel && customers.SelectedItem != null)
                Price.Customer = customers.SelectedItem as Core.Entities.Customer;
        }

        public FxNewPrice()
        {
            InitializeComponent();
            _priceService = CompositionRoot.Resolve<IPriceService>();
            //    SaveButtonClick += FxNewPrice_SaveButtonClick;
        }

        //private void FxNewPrice_SaveButtonClick(object sender, EventArgs e)
        //{
        //    _priceService.AddPrice(Price);
        //    Price.Changed = false;
        //    Close();

        //}

        private void beCustomer_Click(object sender, EventArgs e)
        {
            OpenCustomerList();
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