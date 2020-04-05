using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.Lib.Commands;
using Socrat.References;

namespace Socrat.Module.Order
{
    public partial class CxOrders : CxGenericListTable<Core.Entities.Order>
    {
        public event EventHandler FilterClick;
        public event EventHandler FilterCancelClick;
        public event EventHandler NeedShowSpalshSreen;
        public event EventHandler NeedHideSpalshSreen;

        private OrdersFilter _Filter = new OrdersFilter();
        public bool OnLoad { get; set; } = true;
        private GroupControl gcFilterInfo;
        private LabelControl lcFilterInfo;

        public Division Division { get; set; }
        public Customer Customer { get; set; }

        public ObservableCollection<Core.Entities.Order> Orders { get; set; }

        public CxOrders()
        {
            InitializeComponent();
            Orders = new ObservableCollection<Core.Entities.Order>();
            Load += CxOrders_Load;
            gvGrid.RowStyle += GvGrid_RowStyle;
        }

        private void GvGrid_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            int r = gvGrid.GetDataSourceRowIndex(e.RowHandle);
            if (r > -1)
            {
                e.Appearance.BackColor2 = e.Appearance.BackColor;
                e.Appearance.BackColor = Orders[r].OrderStatus.ColorAdjustBrightness(0.3F);
                gvGrid.Appearance.SelectedRow.BackColor = Orders[r].OrderStatus.Color;
                gvGrid.Appearance.FocusedRow.BackColor = Orders[r].OrderStatus.Color;
                gvGrid.Appearance.SelectedRow.Options.UseBackColor = true;
            }
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
            gcFilterInfo.Padding = new Padding(0);

            AddToActionPanel(gcFilterInfo);
            gcFilterInfo.Dock = DockStyle.Fill;
            
            lcFilterInfo = new LabelControl();
            lcFilterInfo.Appearance.Font = new Font(lcFilterInfo.Appearance.Font.FontFamily, lcFilterInfo.Appearance.Font.Size +2);
            lcFilterInfo.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            gcFilterInfo.Controls.Add(lcFilterInfo);
            lcFilterInfo.Dock = DockStyle.Bottom;
            lcFilterInfo.Text = _Filter.Title;
            lcFilterInfo.DoubleClick += (sender, args) => { OnFilterClickExecute(null);};
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
            AddObjectColumn("Площадка", "Division", 120, 0);
            AddColumn("Код 1С", "Code1C", 80, 1);
            AddColumn("Введен", "DateInput", 80, 2);
            AddObjectColumn("Статус", "OrderStatus", 80, 3);
            AddColumn("Заказ №", "Num", 80, 4);
            AddObjectColumn("Заказчик", "Customer", 80, 5);
            AddColumn("Заказ заказчика №", "NumCustomer", 80, 6);
            AddColumn("В плане на", "DateWork", 80, 7);
            AddColumn("Очередь", "QueueNum", 80, 8);
            AddColumn("Отгрузка", "Delivery", 80, 9);
            AddColumn("Изделий", x => x.ItemsCount, 80, 10);
            AddColumnSummary("ItemsCount", "N0");
            AddColumn("S", "SQU", 80, 12);
            AddColumnSummary("SQU", "N2");
            AddColumn("Сложность", "Dificalty", 80, 13);
            AddColumn("Цена", "Price", 80, 14);
            AddColumnSummary("Price", "N2");
            AddColumn("Доставка", "Delivery", 80, 15);
            AddColumn("Адрес доставки", "Address", 80, 16);
            AddColumn("Примечание", "Comment", 80, 17);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxOrderEdit();
        }

        protected override Core.Entities.Order GetNewInstance()
        {
            return new Core.Entities.Order
            {
                Customer = this.Customer,
                Division = this.Division,
                Num = OrderNumerator.GetNext(),
                DateInput = DateTime.Now,
                DateCustomer = this.Customer?.ActualContract?.CalcDateProduct(DateTime.Now) ?? DateTime.Now.AddDays(2)
            };

        }

        protected override ObservableCollection<Core.Entities.Order> GetItems()
        {
            return Orders;
        }

        public void SetFilter(OrdersFilter filter)
        {
            _Filter = filter;
            Division = _Filter.Division;
            lcFilterInfo.Text = _Filter.Title;
            RefreshData();
        }

        public override void RefreshData()
        {
            if (OnLoad)
                return;
            Orders = GetFiltered();
            gcGrid.DataSource = null;
            gcGrid.DataSource = Items;
        }
  
        private ObservableCollection<Core.Entities.Order> GetFiltered()
        {
            ObservableCollection<Core.Entities.Order> _res = null;
            if (Repository != null)
            {
                IQueryable<Core.Entities.Order> _filtered = Repository.GetAll();

                switch (_Filter.DateType)
                {
                    case OrdersFilterDateType.Input:
                        _filtered = _filtered.Where(x => x.DateInput >= _Filter.DateStart && x.DateInput <= _Filter.DateEnd);
                        break;
                    case OrdersFilterDateType.Work:
                        _filtered = _filtered.Where(x => x.DateWork >= _Filter.DateStart && x.DateWork <= _Filter.DateEnd);
                        break;
                    case OrdersFilterDateType.Customer:
                        _filtered = _filtered.Where(x => x.DateCustomer >= _Filter.DateStart && x.DateCustomer <= _Filter.DateEnd);
                        break;
                }

                if (_Filter.Number.Length > 0)
                    switch (_Filter.NumberType)
                    {
                        case OrdersFilterNumberType.Own:
                            _filtered = _filtered.Where(x => x.Num.ToString() == _Filter.Number);
                            break;
                        case OrdersFilterNumberType.Customer:
                            _filtered = _filtered.Where(x => x.NumCustomer.ToString() == _Filter.Number);
                            break;
                    }

                if (_Filter.Customer != null)
                    _filtered = _filtered.Where(x => x.CustomerId == _Filter.Customer.Id);

                if (_Filter.Division != null)
                    _filtered = _filtered.Where(x => x.DivisionId == _Filter.Division.Id);

                if (_Filter.OrderStatus != null)
                    _filtered = _filtered.Where(x => x.OrderStatusId == _Filter.OrderStatusId);

                if (_filtered != null)
                {
                    _res = new ObservableCollection<Core.Entities.Order>(_filtered.ToList().OrderBy(x => x.DateInput));
                    _filtered = null;
                }
            }
            return _res;
        }

        public void AddNewOrder(Core.Entities.Order order)
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

        private void OnNeedShowSpalshSreen()
        {
            NeedShowSpalshSreen?.Invoke(this, EventArgs.Empty);
        }

        private void OnNeedHideSpalshSreen()
        {
            NeedHideSpalshSreen?.Invoke(this, EventArgs.Empty);
        }

        protected override void OpenItem()
        {
            if (Items == null)
                return;
            Core.Entities.Order _entity = Items.FirstOrDefault(x => x.Id == GetCurrentRowId());

            //var v = _entity.OrderRows;
            //if (_entity != null && _entity.OrderRows == null || _entity.OrderRows.Count < 1)
            //{
            //    LoadOrderRows(_entity);
            //}

            if (_entity != null)
            {
                IEntityEditor _fx = GetEditor();
                _fx.Entity = _entity;
                _fx.ReadOnly = this.ReadOnly;
                _fx.SaveButtonClick += (_sender, args) =>
                {
                    if (!_fx.Entity?.Changed ?? false)
                        return;
                    DialogResult _dialogResult = XtraMessageBox.Show("Данные были изменены. Сохранить?", "Сохранение",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    OnNeedShowSpalshSreen();
                    if (_dialogResult == DialogResult.Yes && !this.ReadOnly)
                    {
                        Repository.Save(_entity);
                    }
                    else
                    {
                        _entity = Repository.Revert(_entity);
                    }
                    OnNeedHideSpalshSreen();
                    gvGrid.RefreshData();
                };
                _fx.DialogOutput += _fx_DialogOutput;
                _fx.StartPosition = FormStartPosition.CenterParent;
                OnDialogOutput(_fx, DialogOutputType.Tab);
            }

            //OnOpenItem();
        }

        //private void LoadOrderRows(Core.Entities.Order order)
        //{
        //    OnNeedShowSpalshSreen();
        //    using (Socrat.Core.IRepository<OrderRow> _repo = DataHelper.GetRepository<OrderRow>())
        //    {
        //        var _rows = _repo.GetAll(x => x.Order.Id == order.Id);
        //        order.ReloadRows(_rows);
        //    }
        //    OnNeedHideSpalshSreen();
        //}

        protected override void PreparingDelete(Core.Entities.Order entity)
        {
            foreach (var _orderRow in entity.OrderRows)
            {
                _orderRow.Order = null;
                
            }
            foreach (var _orderStatusHistory in entity.OrderStatusHistories)
            {
                _orderStatusHistory.Order = null;
            }
        }
    }

}
