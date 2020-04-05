using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.Lib.Commands;

namespace Socrat.References.Price
{
    public partial class CxPriceLogList : CxGenericListTable<Core.Entities.PriceLog>
    {
        private ObservableCollection<Core.Entities.PriceLog> _allLogs;
        public Core.Entities.Price Price { get; set; }
        public CxPriceLogList()
        {
            InitializeComponent();
        }

        protected override void InitCommands()
        {


            _commands = new List<ReferenceCommand>
            {
                new ReferenceCommand(MenuCommandType.Item, "Обновить", RefreshDataExecute, null) { Image = Properties.Resources.refresh2_16x16 },
            };

        }

        protected override void OpenItem()
        {
            
        }

        protected override ObservableCollection<Core.Entities.PriceLog> GetItems()
        {
            IRepository<Core.Entities.PriceLog> repos = DataHelper.GetRepository<Core.Entities.PriceLog>();


            PricePeriod period = DataHelper.GetRepository<Core.Entities.PricePeriod>().GetAll().Where(p => p.PriceId == Price.Id).OrderByDescending(p => p.DateBegin.Value).FirstOrDefault();

            if (period == null)
                _allLogs = new ObservableCollection<Core.Entities.PriceLog>();
            else
                _allLogs = new ObservableCollection<Core.Entities.PriceLog>(repos.GetAll().Where(p => p.PricePeriodId == period.Id).ToList());
            return _allLogs;
        }
        protected override void InitColumns()
        {
            AddColumn("Дата", "Date", 150, 0);
            AddColumn("Редактировал", "Editor", 250, 1);
            AddColumn("Период прайса", "PricePeriod.DateBegin", 250, 2);
            AddColumn("Раздел прайса", "PriceType.Name", 150, 3);

            AddColumn("Материал", "MaterialNom.VendorMaterialNom.Name", 150, 4);
            AddColumn("Значение прайса", "PriceValue.PriceVal", 150, 5);
            AddColumn("Прежнее значение", "OldValue", 150, 6);

        }
    }
}
