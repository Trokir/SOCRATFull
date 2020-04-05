using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.References.Params;
using Socrat.UI.Core;

namespace Socrat.Module.Order
{
    public partial class FxOrders : FxBaseForm
    {
        private CxOrders cxOrders;
        public OrdersFilter Filter { get; set; }
        public List<Division> Divisions { get; set; }
        public FxOrders()
        {
            InitializeComponent();

            Filter = new OrdersFilter();
            cxOrders = new CxOrders();
            pcOrders.Controls.Add(cxOrders);
            cxOrders.Dock = DockStyle.Fill;

            cxOrders.DialogOutput += CxOrders_DialogOutput;
            cxOrders.FilterClick += CxOrders_FilterClick;
            cxOrders.FilterCancelClick += CxOrders_FilterCancelClick;
            cxOrders.NeedHideSpalshSreen += CxOrders_NeedHideSpalshSreen;
            cxOrders.NeedShowSpalshSreen += CxOrdersOnNeedShowSpalshSreen;
            Load += FxOrders_Load;
        }

        private void CxOrdersOnNeedShowSpalshSreen(object sender, EventArgs e)
        {
            this.ShowSplashScreen();
        }

        private void CxOrders_NeedHideSpalshSreen(object sender, EventArgs e)
        {
            this.HideSplashScreen();
        }

        private void CxOrders_FilterCancelClick(object sender, EventArgs e)
        {
            Filter = new OrdersFilter();
            cxOrders.SetFilter(Filter);
        }

        private void CxOrders_FilterClick(object sender, EventArgs e)
        {
            EditFilter();
        }

        private void FxOrders_Load(object sender, EventArgs e)
        {
            Divisions = DataHelper.GetAll<Division>();
            lueDivision.DataSource = null;
            lueDivision.DataSource = Divisions;
            string tmp = AppParams.Params[ParamAlias.CurrentDivision];
            beiDivisions.EditValue = Divisions.FirstOrDefault(x => x.Id == Guid.Parse(tmp));
            cxOrders.Division = Divisions.FirstOrDefault(x => x.Id == Guid.Parse(tmp));
        }

        private void CxOrders_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
           OnDialogOutput(ta.NewTab, ta.OutputType);
        }

        private void labelControl1_DoubleClick(object sender, EventArgs e)
        {
            EditFilter();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            EditFilter();
        }

        private void EditFilter()
        {
            FxOrdersFilter _fx = new FxOrdersFilter();
            _fx.Filter = Filter;
            _fx.SetFilter += (sender, args) => SetFilter();
            OnDialogOutput(_fx, DialogOutputType.Dialog);
        }

        private void SetFilter()
        {
            cxOrders.SetFilter(Filter);
        }

        private void lueDivision_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void beiDivisions_EditValueChanged(object sender, EventArgs e)
        {
            Filter.Division = beiDivisions.EditValue as Division;
            cxOrders.SetFilter(Filter);
            cxOrders.Division = Filter.Division;
        }

        private void ExportFromDisp()
        {
            OpenFileDialog _dialog = new OpenFileDialog();
            _dialog.Filter = "*.xml|*.xml";
            DialogResult _dialogResult = _dialog.ShowDialog(this);
            if (_dialogResult != DialogResult.Cancel)
            {
                OrderConverter _converter = new OrderConverter();
                Core.Entities.Order[] _orders = _converter.ConvertFromDispXml(File.ReadAllText(_dialog.FileName));
                DialogResult _res = XtraMessageBox.Show(String.Format("В файле {0} заказ/а. Загрузить?", _orders.Length),
                    "Импорт заказов", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_res == DialogResult.Yes)
                    foreach (Core.Entities.Order _order in _orders)
                    {
                        _order.Division = Filter.Division;
                        _order.Num = OrderNumerator.GetNext();
                        cxOrders.AddNewOrder(_order);
                    }
            }
        }

        private void bbiImportFromXml_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportFromDisp();
        }

        protected override void SetReadOnly(bool value)
        {
            base.SetReadOnly(value);
            if (cxOrders != null)
                cxOrders.ReadOnly = value;
            pcOrders.Update();
        }

        protected override string GetTitle()
        {
            return "Заказы";
        }
    }
}