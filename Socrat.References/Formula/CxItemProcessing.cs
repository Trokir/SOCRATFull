using System.Collections.ObjectModel;
using Socrat.Core.Entities;
using Socrat.Lib.Commands;

namespace Socrat.References.Formula
{
    public partial class CxItemProcessing : CxGenericListTable<FormulaItemProcessing>
    {
        public FormulaItem FormulaItem { get; set; }

        public CxItemProcessing()
        {
            InitializeComponent();
        }

        protected override ObservableCollection<FormulaItemProcessing> GetItems()
        {
            return FormulaItem.FormulaItemProcessings;
        }

        protected override FormulaItemProcessing GetNewInstance()
        {
            return null;
            //return new Processing { Material = FormulaItem.MaterialNom?.VendorMaterialNom?.Material };
        }

        protected override void InitColumns()
        {
            AddColumn("Наименование", "Name", 300, 0);
        }

        protected override void InitCommands()
        {
            _commands.Add(new ReferenceCommand(MenuCommandType.Item, "Просмотр", OnOpenClickExecute, null));
            _commands.Add(new ReferenceCommand(MenuCommandType.Item, "Добавить", OnAddClickExecute, null));
            _commands.Add(new ReferenceCommand(MenuCommandType.Item, "Удалить", OnDeleteClickExecute, null));
        }

        private void OnDeleteClickExecute(object obj)
        {
        }

        private void OnAddClickExecute(object obj)
        {
        }

        private void OnOpenClickExecute(object obj)
        {
        }
    }
}
