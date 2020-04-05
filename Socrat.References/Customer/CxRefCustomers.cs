using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;

namespace Socrat.References.Customer
{
    public partial class CxRefCustomers : CxGenericListTable<Core.Entities.Customer>
    {
        private FilterPreset _filterPreset;
        public FilterPreset FilterPreset
        {
            get { return _filterPreset; }
            set { SetFilter(value); }
        }

        private void SetFilter(FilterPreset value)
        {
            _filterPreset = value;
            RefreshData();
        }

        private ObservableCollection<Core.Entities.Customer> _items;
        protected override ObservableCollection<Core.Entities.Customer> GetItems()
        {
            return _items;
        }

        private void LoadItems()
        {
            IEnumerable<Core.Entities.Customer> _customers = null;
            switch (_filterPreset)
            {
                case FilterPreset.IP:
                    //_customers = Repository?.GetIncludeAll<DataProvider.Customer>(x => x.OPF.Alias == "ИП", x => x.OPF);
                    _customers = Repository?.GetAll(x => x.Opf.IsIP ?? false);
                    break;
                case FilterPreset.Legal:
                    //_customers = Repository?.GetIncludeAll<DataProvider.Customer>(x => x.OPF.Alias != "ИП", x => x.OPF);
                    _customers = Repository?.GetAll(x => !(x.Opf.IsIP ?? false));
                    break;
                default:
                case FilterPreset.All:
                    _customers = Repository?.GetAll();
                    break;
            }

            if (_customers != null)
            {
                if (ExternalFilterExp != null)
                    _customers = _customers.Where(ExternalFilterExp.Compile());
                _items = new ObservableCollection<Core.Entities.Customer>(_customers);
            }
        }

        public override void RefreshData()
        {
            LoadItems();
            gcGrid.DataSource = null;
            gcGrid.DataSource = _items;
            if (RowHighlightingExp != null)
                _HighlightedRows = GetItems()?.ToList().Where(RowHighlightingExp.Compile()).Select(x => x.Id).ToList();
            if (SelectedItem != null)
                SetFocusedRow(SelectedItem.Id);
            OnRefreshButtonClick();
        }

        protected override Core.Entities.Customer GetNewInstance()
        {
            switch (_filterPreset)
            {
                case FilterPreset.IP:
                    return AddNewIp();
                default:
                    return AddNewLegal();
            }
        }


        private Core.Entities.Customer AddNewLegal()
        {
            Core.Entities.Customer _customer = new Core.Entities.Customer();
            _customer.FullName = "Новое юр.лицо";
            _customer.DateReg = DateTime.Now;
            _customer.Changed = false;
            return _customer;
        }

        private Core.Entities.Customer AddNewIp()
        {
            Core.Entities.Customer _customer = new Core.Entities.Customer();
            _customer.FullName = "Новый ИП";
            _customer.Opf = DataHelper.GetAll<Opf>()?.FirstOrDefault(x => x.IsIP ?? false);
            _customer.DateReg = DateTime.Now;
            _customer.Changed = false;
            return _customer;
        }

        protected override void InitColumns()
        {
            AddColumn("Контрагент", "FullName", 250, 1);
            AddColumn("ИНН", "Inn", 120, 2);
            AddColumn("Регион", "Region", 120, 3);
            AddColumn("Адрес", "AdrStr", 120, 4);
            AddColumn("Код 1С", "Code_1C", 120, 5);
            AddColumn("Заблокирован", "DenyActions", 120, 6);
            AddColumn("Запрет на прием заказа", "DenyOrdering", 120, 7);
            AddColumn("Запрет на пр-во", "DenyProduct", 120, 8);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxCustomerEdit();
        }
    }
}
