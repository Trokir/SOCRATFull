using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core.BL.PriceLists.Abstract;
using Socrat.Core.DI;
using Socrat.UI.Core;

namespace Socrat.References.Price
{
    public enum DisplayedPrices { All, Common, Individual }
    public partial class FxPriceList : FxBaseSimpleDialog
    {
        private IPriceService _priceService;
        private CxPriceList _cxPriceList;
        public FxPriceList()
        {
            InitializeComponent();
            _priceService = CompositionRoot.Resolve<IPriceService>();
            InitPriceType();
            Text = "Прайсы";
        }


        private void InitPriceType()
        {
            _cxPriceList = new CxPriceList();
            _cxPriceList.DialogOutput += _cxPriceList_DialogOutput;
            
            pcAll.Controls.Add(_cxPriceList);
            _cxPriceList.Dock = DockStyle.Fill;
        }

        private void _cxPriceList_DialogOutput(object sender, Core.WindowOutputEventArgs e)
        {
            OnDialogOutput(e);
        }

        protected override string GetTitle()
        {
            return "Прайсы";
        }

        private void tabbedControlGroup1_SelectedPageChanging(object sender, DevExpress.XtraLayout.LayoutTabPageChangingEventArgs e)
        {
            if (e.Page == groupAll)
            {
                UpdateData(pcAll, _cxPriceList.Items);
            }
            else if (e.Page == groupCommon)
            {
                UpdateData(pcCommon,
                    new ObservableCollection<Core.Entities.Price>(_cxPriceList.Items
                        .Where(p => p.PriceType.Equals("Общий", StringComparison.OrdinalIgnoreCase)).ToList()));
            }
            else if (e.Page == groupIndividual)
            {
                UpdateData(pcIndividual,
                    new ObservableCollection<Core.Entities.Price>(_cxPriceList.Items.Where(p =>
                        p.PriceType.Equals("Индивидуальный", StringComparison.OrdinalIgnoreCase)).ToList()));
            }
        }

        private void UpdateData(PanelControl panelControl, ObservableCollection<Core.Entities.Price> items)
        {
            panelControl.Controls.Clear();
            _cxPriceList.gcGrid.DataSource = items;
            panelControl.Controls.Add(_cxPriceList);
            _cxPriceList.Dock = DockStyle.Fill;
        }
    }
}