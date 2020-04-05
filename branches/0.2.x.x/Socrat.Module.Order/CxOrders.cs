using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Socrat.DataProvider;
using Socrat.Lib;
using Socrat.Lib.Commands;
using Socrat.Model;
using Socrat.References;
using Socrat.References.Params;

namespace Socrat.Module.Order.Properties
{
    public partial class CxOrders : CxGenericListTable<Model.Order>
    {
        public event EventHandler FilterClick;
        public event EventHandler FilterCancelClick;
        public ObservableCollection<Model.Order> Orders { get; set; }
        private OrdersFilter _Filter = new OrdersFilter();
        public bool OnLoad { get; set; } = true;
        private GroupControl gcFilterInfo;
        private LabelControl lcFilterInfo;

        public Model.Division Division { get; set; }
        public Model.Customer Customer { get; set; }

        public CxOrders()
        {
            InitializeComponent();
            Orders = new ObservableCollection<Model.Order>();
            Load += CxOrders_Load;
        }

        private void CxOrders_Load(object sender, EventArgs e)
        {
            InitFilterInfoPanel();
            OnLoad = false;
        }

        private void InitFilterInfoPanel()
        {
            gcFilterInfo = new GroupControl();
            gcFilterInfo.Text = "Фильтр по";
            AddToActionPanel(gcFilterInfo);
            gcFilterInfo.Dock = DockStyle.Fill;
            

            lcFilterInfo = new LabelControl();
            gcFilterInfo.Controls.Add(lcFilterInfo);
            lcFilterInfo.Dock = DockStyle.Bottom;
            lcFilterInfo.DataBindings.Add("Text", _Filter, "Title", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        protected override void InitCommamds()
        {
            base.InitCommamds();
            _commands.Add(new ReferenceCommand(MenuCommandType.Item, "Фильтр", OnFilterClickExecute, null)
                { Image = Properties.Resources.filter_16x16, BeginGroup = true});
            _commands.Add(new ReferenceCommand(MenuCommandType.Item, "Сброс", OnFilterCancelClickExecute, null) { Image = Properties.Resources.clearfilter_16x16 });
        }

        private void OnFilterCancelClickExecute(object obj)
        {
            OnFilterCancelClick();
        }

        private void OnFilterClickExecute(object obj)
        {
            OnFilterClick();
        }

        private void OnFilterCancelClick()
        {
            FilterCancelClick?.Invoke(this, EventArgs.Empty);
        }

        private void OnFilterClick()
        {
            FilterClick?.Invoke(this, EventArgs.Empty);
        }

        protected override void InitColumns()
        {
            AddColumn("Площадка", "Division", 120, 0);
            AddColumn("Код 1С", "Code1C", 80, 1);
            AddColumn("Введен", "DateInput", 80, 1);
            AddColumn("Заказ №", "Num", 80, 1);
            AddColumn("Заказчик", "Customer", 80, 1);
            AddColumn("Заказ заказчика №", "NumCustomer", 80, 1);
            AddColumn("В плане на", "DateWork", 80, 1);
            AddColumn("Очередь", "QueueNum", 80, 1);
            AddColumn("Отгрузка", "Delivery", 80, 1);
            AddColumn("Изделий", x => x.ItemsCount , 80, 1);
            AddColumnSummary("ItemsCount", "N0");
            AddColumn("S", "SQU", 80, 1);
            AddColumnSummary("SQU", "N2");
            AddColumn("Сложность", "Dificalty", 80, 1);
            AddColumn("Цена", "Price", 80, 1);
            AddColumnSummary("Price", "N2");
            AddColumn("Доставка", "Delivery", 80, 1);
            AddColumn("Адрес доставки", "Address", 80, 1);
            AddColumn("Примечание", "Comment", 80, 1);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxOrderEdit();
        }

        protected override Model.Order GetNewInstance()
        {
            return new Model.Order
            {
                Customer = this.Customer,
                Division = this.Division,
                Num = AppParams.Params.UseNextOrderNum(),
                DateInput = DateTime.Now,
                DateCustomer = this.Customer?.ActualContract?.CalcDateProduct(DateTime.Now) ?? DateTime.Now.AddDays(2)
            };

        }

        protected override ObservableCollection<Model.Order> GetItems()
        {
            return Orders;
        }

        public void SetFilter(OrdersFilter filter)
        {
            _Filter = filter;
            Division = _Filter.Division;
            RefreshData();
        }

        protected override void RefreshData()
        {
            if (OnLoad)
                return;

            Orders = new ObservableCollection<Model.Order>(((OrderRepository)Repository).GetFiltered(_Filter));
            gcGrid.DataSource = null;
            gcGrid.DataSource = Items;
        }

        public void AddNewOrder(Model.Order order)
        {
            IEntityEditor _fx = GetEditor();
            _fx.Entity = order;
            _fx.ReadOnly = this.ReadOnly;
            _fx.SaveButtonClick += (_sender, args) =>
            {
                if (!_fx.Entity?.Changed ?? false)
                    return;
                DialogResult _dialogResult = XtraMessageBox.Show("Данные были изменены. Сохранить?", "Сохранение",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (_dialogResult == DialogResult.Yes)
                {
                    Repository.Save(order);
                    if (!Items.Contains(order))
                        Items.Add(order);
                }
                gvGrid.RefreshData();
            };
            _fx.DialogOutput += _fx_DialogOutput;
            OnDialogOutput(_fx, DialogOutputType.Tab);
        }

        private void _fx_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta.NewTab, DialogOutputType.Dialog);
        }

        protected override void SetReadOnly(bool value)
        {
            base.SetReadOnly(value);
            if (value)
            {
                WriteCommandsButtons.ForEach(x => x.Hide());
                WriteCommandsBarButtons.ForEach(x => x.Visibility = BarItemVisibility.Never);
            }
        }
    }

}
