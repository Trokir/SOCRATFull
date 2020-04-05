using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Lib.Interfaces;
using Socrat.UI.Core;

namespace Socrat.Module.Price
{
    /// <summary>
    /// Список прайс-листов, разделенный на табы по типам - общие/индивидуальные
    /// Используется как основной в заходе из главного меню
    /// </summary>
    public partial class FxPrices : FxBaseForm, ISelectionDialogFilterable<Core.Entities.Price>
    {
        private CxPrices _cxPriceList;
        public FxPrices()
        {
            InitializeComponent();
            InitPriceList();
        }

        public System.Linq.Expressions.Expression<Func<Core.Entities.Price, bool>> ExternalFilterExp { get; set; }
        public System.Linq.Expressions.Expression<Func<Core.Entities.Price, bool>> ExternalPostFilterExp { get; set; }

        public IEntity SelectedItem => _cxPriceList.SelectedItem;

        public event EventHandler ItemSelected;

        public void SetSingleSelectMode(IEntity selectedItem)
        {
            _cxPriceList.SetSingleSelectMode(selectedItem as Core.Entities.Price);
        }

        private void InitPriceList()
        {
            pcAll.SuspendLayout();
            _cxPriceList = new CxPrices()
            {
                Dock = DockStyle.Fill,
                ExternalFilterExp = null,
                FilterVisible = false,
                MultiSelect = false,
                MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect,
                Name = "_cxPriceList",
            };
            _cxPriceList.SelectItemEvent += (o, e) => 
            {
                ItemSelected?.Invoke(this, e);
                DialogResult = DialogResult.OK;
                Close();
            };
            _cxPriceList.DialogOutput += (o, e) => OnDialogOutput(e);
            pcAll.Controls.Add(_cxPriceList);
            pcAll.ResumeLayout();
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
                    new AttachedList<Core.Entities.Price>(_cxPriceList.Items
                        .Where(p => p.PriceType.Equals("Общий", StringComparison.OrdinalIgnoreCase)).ToList()));
            }
            else if (e.Page == groupIndividual)
            {
                UpdateData(pcIndividual,
                    new AttachedList<Core.Entities.Price>(_cxPriceList.Items.Where(p =>
                        p.PriceType.Equals("Индивидуальный", StringComparison.OrdinalIgnoreCase)).ToList()));
            }
        }

        private void UpdateData(PanelControl panelControl, AttachedList<Core.Entities.Price> items)
        {
            panelControl.Controls.Clear();
            _cxPriceList.gcGrid.DataSource = items;
            panelControl.Controls.Add(_cxPriceList);
        }
    }
}