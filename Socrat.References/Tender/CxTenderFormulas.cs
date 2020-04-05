using Socrat.Core;
using Socrat.Core.Entities.Tender;
using Socrat.Lib.Commands;
using Socrat.References.Tender;
using Socrat.Common.UI;


namespace Socrat.References.Contract
{
    public partial class CxTenderFormulas : CxGenericListTable<TenderFormula>
    {
        private Core.Entities.Tender.Tender _Tender;
        public Core.Entities.Tender.Tender Tender
        {
            get { return _Tender; }
            set { _Tender = value; }
        }

        public CxTenderFormulas()
        {
            InitializeComponent();
        }

        protected override void InitCommands()
        {
            base.InitCommands();
            _commands.Add(new ReferenceCommand(MenuCommandType.Item, "Использование", UsingListExecute, 
                null, ReferenceCommand.ActionTypes.Custom) { Image = Properties.Resources.preview_16x16 });
        }

        private void UsingListExecute(object obj)
        {
            TenderFormula selectedTenderFormula = GetFocusedItem();
            if (selectedTenderFormula != null)
            {
                FxTenderFormulaUsing _fx = new FxTenderFormulaUsing();
                _fx.TenderFormula = selectedTenderFormula;
                OnDialogOutput(_fx, DialogOutputType.Dialog);
            }
        }

        protected override void InitColumns()
        {
            AddObjectColumn("Формула изделия", "Formula", 200, 0);
            AddColumn("Цена за кв.м", "Price", 80, 1);
            AddColumn("Использовано кв.м", "SquReady", 80, 2);
            AddColumn("Лимит кв.м", "Limit", 80, 3);
        }

        protected override AttachedList<TenderFormula> GetItems()
        {
            return Tender.TenderFormulas;
        }

        protected override TenderFormula GetNewInstance()
        {
            return new TenderFormula { Tender = this.Tender, Loaded = true, Changed = true};
        }

        protected override IEntityEditor GetEditor(OpenMode openMode = OpenMode.Default)
        {
            return new FxTenderFormulaEdit();
        }
    }
}
