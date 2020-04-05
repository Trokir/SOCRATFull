using System.Collections.Generic;
using System.Collections.ObjectModel;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.Lib.Commands;


namespace Socrat.References.Contract
{
    public partial class CxContractPrices : CxGenericListTable<ContractPrice>
    {
        public Core.Entities.Contract Contract { get; set; }

        public CxContractPrices()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Раздел", x => x.PriceType, 200, 0);
            AddColumn("Колонка", x => x.PriceColumn, 100, 1);
            AddColumn("Ставка %", x => x.Discount, 100, 1);
            AddColumn("Коррекция +/-р", x => x.Delta, 100, 1);
            AddColumn("Изменен", x => x.EditDate, 100, 1);
        }

        protected override ObservableCollection<ContractPrice> GetItems()
        {
            return new ObservableCollection<ContractPrice>(Contract.ContractPrices);
        }

        protected override ContractPrice GetNewInstance()
        {
            return new ContractPrice { Contract = this.Contract };
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxContractPriceEdit();
        }

        protected override void InitCommands()
        {
            _commands = new List<ReferenceCommand>
            {
                new ReferenceCommand(MenuCommandType.Item, "Обновить", RefreshDataExecute, null) { Image = Properties.Resources.refresh2_16x16 },
                new ReferenceCommand(MenuCommandType.Item, "Просмотр", OpenItemExecute, null) { Image = Properties.Resources.preview_16x16 },
                new ReferenceCommand(MenuCommandType.Item, "Развернуть", RotateExecute, null),
            };
        }

        private void RotateExecute(object obj)
        {
            //todo: Реализовать разворот таблицы
        }
    }
}
