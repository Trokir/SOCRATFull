using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using Socrat.DataProvider;
using Socrat.Lib;
using Socrat.Model;
using Socrat.Model.Convertion;
using Socrat.Model.Params;
using Socrat.Module.Order.Properties;
using Socrat.References.Params;
using Socrat.UI.Core;

namespace Socrat.Module.Order
{
    public partial class FxOrders : FxBaseForm
    {
        private CxOrders cxOrders;
        public OrdersFilter Filter { get; set; }
        public List<Model.Division> Divisions { get; set; }
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

            Load += FxOrders_Load;
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
            using (EFDataFactory _factory = new EFDataFactory())
            {
                IRepository<Model.Division> _repo = _factory.CreateRepository<IRepository<Model.Division>>();
                Divisions = _repo.GetAll().ToList();
                lueDivision.DataSource = null;
                lueDivision.DataSource = Divisions;
            }

            beiDivisions.EditValue = Divisions.FirstOrDefault(x => x.Id == Guid.Parse(AppParams.Params[ParamAlias.CurrentDivision]));

            BindData();
        }

        private void BindData()
        {
            lcFilter.DataBindings.Clear();
            lcFilter.DataBindings.Add("Text", Filter, "Title", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void CxOrders_DialogOutput(object sender, Lib.WindowOutputEventArgs ta)
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
            Filter.Division = beiDivisions.EditValue as Model.Division;
            cxOrders.SetFilter(Filter);
        }

        private void ExportFromDisp()
        {
            OpenFileDialog _dialog = new OpenFileDialog();
            _dialog.Filter = "*.xml|*.xml";
            DialogResult _dialogResult = _dialog.ShowDialog(this);
            if (_dialogResult != DialogResult.Cancel)
            {
                OrderConverter _converter = new OrderConverter();
                Model.Order[] _orders = _converter.ConvertFromDispXml(File.ReadAllText(_dialog.FileName));
                DialogResult _res = XtraMessageBox.Show(String.Format("В файле {0} заказ/а. Загрузить?", _orders.Length),
                    "Импорт заказов", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (_res == DialogResult.Yes)
                    foreach (Model.Order _order in _orders)
                    {
                        _order.Division = Filter.Division;
                        _order.Num = AppParams.Params.UseNextOrderNum();
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