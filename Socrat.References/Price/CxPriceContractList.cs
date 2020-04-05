using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;
using Socrat.Core;
using Socrat.DataProvider;
using Socrat.Lib.Commands;

namespace Socrat.References.Price
{
    public partial class CxPriceContractList : CxGenericListTable<Core.Entities.Contract>
    {
        private int activeCount;

        private ObservableCollection<Core.Entities.Contract> contracts;
        public Core.Entities.Price Price { get; private set; }

        public CxPriceContractList()
        {
            InitializeComponent();
        }

        public CxPriceContractList(Core.Entities.Price price):this()
        {
            Price = price;
        }

        protected override void InitCommands()
        {
            _commands = new List<ReferenceCommand>
            {
                new ReferenceCommand(MenuCommandType.Item, "Обновить", RefreshDataExecute, null) { Image = Properties.Resources.refresh2_16x16 },
                new ReferenceCommand(MenuCommandType.Item, "Просмотр", OpenItemExecute, null) { Image = Properties.Resources.preview_16x16 }
            };
        }

        protected override void OpenItem()
        {
            Guid? g = GetCurrentRowId();
            if (g == Guid.Empty)
                return;

            Core.Entities.Contract entity = Items.FirstOrDefault(x => x.Id == GetCurrentRowId());

            if (entity == null)
                return;

            Contract.FxContractEdit edit = new Contract.FxContractEdit(entity);
            edit.DialogOutput += Form_DialogOutput;
            OnDialogOutput(edit, DialogOutputType.Dialog);
            edit.Show();
        }

        protected override ObservableCollection<Core.Entities.Contract> GetItems()
        {
            IRepository<Core.Entities.Contract> repos = DataHelper.GetRepository<Core.Entities.Contract>();
            contracts = new ObservableCollection<Core.Entities.Contract>(repos.GetAll().Where(contract => contract.CustomerId == Price.CustomerId ));
            activeCount = contracts.Count(contract => contract.Actual);
            return contracts;
        }

        protected override void InitColumns()
        {
            AddColumn("№", "Num", 50, 0);
            AddColumn("От", "DateBegin", 100, 1);
            AddColumn("Действует до", "DateEnd", 100, 2);
            AddColumn("Контрагент", "Customer", 250, 3);
            AddColumn("colLimit", "Лимит", "PaymentCreditLimit", DevExpress.Utils.FormatType.Numeric, "c2", 80, 4);
        }

        protected override IEntityEditor GetEditor()
        {
            Core.Entities.Contract val = (Core.Entities.Contract)((GridView)gcGrid.MainView).GetFocusedRow();

            if (val != null)
                return new Contract.FxContractEdit(val);
            else
                return null;
        }

        private void Form_DialogOutput(object sender, WindowOutputEventArgs e)
        {
            OnDialogOutput(e);
        }

        protected override void UpdateFooter()
        {
            base.UpdateFooter();
            Footer += $". Действующих контрактов: {activeCount}";
        }
    }
}
