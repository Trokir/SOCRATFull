using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.UI.Core;
using Socrat.References.Customer;
using Socrat.References.Division;

namespace Socrat.References.Price
{
    public enum TradeMarginType { Square, Figure, Complexity }
    public partial class FxPriceSelector : FxBaseSimpleDialog
    {
        private CxPriceTypes _cxPriceTypes;
        private CxPriceLogList _cxPriceLogList;
        private CxPriceContractList _cxPriceContractList;
        private ButtonEditAssistent<Core.Entities.Customer, FxCustomers, FxCustomerEdit> _customerButtonEditAssistent;
        private ButtonEditAssistent<Core.Entities.Division, FxDivisions, FxDivisionEdit> _divisionButtonEditAssistent;

        private Core.Entities.Price _price;
        public Core.Entities.Price Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                InitPriceType();
            }
        }

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
            CustomerSelectionItem.Visibility = Price.IsCommon ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never : DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teName, Price, x => x.Name);
            BindEditor(teSpo, Price.CurrentPricePeriod, x => x.BaseSpo);
            BindEditor(teSpd, Price.CurrentPricePeriod, x => x.BaseSpd);

            cxPriceEditorTitle.DataBindings.Clear();
            cxPriceEditorTitle.DataBindings.Add("Text", Price, "Name", true, DataSourceUpdateMode.OnPropertyChanged);
            cxPriceEditorTitle.DataBindings.Add("DivisionName", Price.Division, "FullName", true, DataSourceUpdateMode.OnPropertyChanged);

            if (Price.Customer != null)
                cxPriceEditorTitle.DataBindings.Add("CustomerName", Price.Customer, "FullName", true, DataSourceUpdateMode.OnPropertyChanged);
            cxPriceEditorTitle.DataBindings.Add("IsCommon", Price, "IsCommon", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teName, beDivision };
        }

        public FxPriceSelector()
        {
            InitializeComponent();
            SaveButtonClick += FxPriceEdit_SaveButtonClick;
            Load += FxPriceSelector_Load;
        }

        private void FxPriceSelector_Load(object sender, EventArgs e)
        {
            _customerButtonEditAssistent = 
                new ButtonEditAssistent<Core.Entities.Customer, FxCustomers, FxCustomerEdit>(
                    beCustomer, Price.Customer, OnDialogOutput);
            _customerButtonEditAssistent.BindProperty(Price, x => x.Customer);

            _divisionButtonEditAssistent =
                new ButtonEditAssistent<Core.Entities.Division, FxDivisions, FxDivisionEdit>(
                    bePlatform, Price.Division, OnDialogOutput);
            _divisionButtonEditAssistent.BindProperty(Price, x => x.Division);
        }

        private void FxPriceEdit_SaveButtonClick(object sender, EventArgs e)
        {
            IRepository<Core.Entities.Price> repository = DataHelper.GetRepository<Core.Entities.Price>();
            repository.Save(Price);
        }

        
        private void InitPriceType()
        {
            IRepository<PriceType> repository = DataHelper.GetRepository<PriceType>();

            //инит контрола листа элементов прайса
            _cxPriceTypes = new CxPriceTypes();
            _cxPriceTypes.DialogOutput += _cxPriceTypes_DialogOutput;
            _cxPriceTypes.PriceTypes = new System.Collections.ObjectModel.ObservableCollection<PriceType>(repository.GetAll().ToList());
            _cxPriceTypes.Price = Price;
            pcPriceType.Controls.Add(_cxPriceTypes);
            _cxPriceTypes.Dock = DockStyle.Fill;

            //инит контрола лога изменений прайса
            _cxPriceLogList = new CxPriceLogList();
            _cxPriceLogList.Price = Price;
            pcPriceLog.Controls.Add(_cxPriceLogList);
            _cxPriceLogList.Dock = DockStyle.Fill;

            //инит контрола списка контрактов
            _cxPriceContractList = new CxPriceContractList(Price);
            pcPriceContract.Controls.Add(_cxPriceContractList);
            _cxPriceContractList.Dock = DockStyle.Fill;
        }

        private void _cxPriceTypes_DialogOutput(object sender, WindowOutputEventArgs e)
        {
            OnDialogOutput(e);
        }

        private void listBoxControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListBoxControl lb = sender as ListBoxControl;
            if (lb != null)
            {
                TradeMarginType marginType = (TradeMarginType)lb.SelectedIndex;

                switch (marginType)
                {
                    case TradeMarginType.Square:
                        FxPriceSquRatios priceSquRatios = new FxPriceSquRatios(Price);
                        priceSquRatios.DialogOutput += PriceSquRatios_DialogOutput;
                        OnDialogOutput(priceSquRatios, DialogOutputType.Dialog, this);
                        break;
                    case TradeMarginType.Figure:
                        FxPriceForms priceForms = new FxPriceForms(Price);
                        priceForms.DialogOutput += PriceSquRatios_DialogOutput;
                        OnDialogOutput(priceForms, DialogOutputType.Dialog, this);
                        break;
                    case TradeMarginType.Complexity:
                        FxPriceSlozes priceSlozes = new FxPriceSlozes(Price);
                        priceSlozes.DialogOutput += PriceSquRatios_DialogOutput;
                        OnDialogOutput(priceSlozes, DialogOutputType.Dialog, this);
                        break;
                    default:
                        break;
                }
            }
        }

        private void PriceSquRatios_DialogOutput(object sender, WindowOutputEventArgs e)
        {
            OnDialogOutput(e);
        }

        #region Title events processing

        private void cxPriceEditorTitle_RenamingRequested(object sender, EventArgs e)
        {
            if (TabGroup.SelectedTabPage != CommonGroup)
                TabGroup.SelectedTabPage = CommonGroup;
            PriceNameItem.Control.Focus();
        }

        private void cxPriceEditorTitle_DivisionChangingRequested(object sender, EventArgs e)
        {
            if (TabGroup.SelectedTabPage != CommonGroup)
                TabGroup.SelectedTabPage = CommonGroup;
            DivisionSelectionItem.Control.Focus();
            beDivision.PerformClick(null);
        }

        private void cxPriceEditorTitle_CustomerChangingRequested(object sender, EventArgs e)
        {
            if (TabGroup.SelectedTabPage != CommonGroup)
                TabGroup.SelectedTabPage = CommonGroup;
            CustomerSelectionItem.Control.Focus();
            beCustomer.PerformClick(null);
        }

        #endregion

        private void cxPricePeriodSelector1_NextPeriodRequested(object sender, EventArgs e)
        {
            Price.SelectedPricePeriod = Price.GetNext(Price.SelectedPricePeriod);
        }

        private void cxPricePeriodSelector1_PreviousPeriodRequested(object sender, EventArgs e)
        {
            Price.SelectedPricePeriod = Price.GetPrevious(Price.SelectedPricePeriod);
        }

        private void cxPricePeriodSelector1_CurrentPeriodRequested(object sender, EventArgs e)
        {
            Price.SelectedPricePeriod = Price.CurrentPricePeriod;
        }
    }
}