using System.Collections.ObjectModel;
using Socrat.Lib.Commands;
using Socrat.Model;
using Socrat.References;

namespace Socrat.Module.Order
{
    public partial class CxItemProcessing : CxGenericListTable<Model.Processing>
    {
        public Model.FormulaItem FormulaItem { get; set; }

        public CxItemProcessing()
        {
            InitializeComponent();
        }

        protected override ObservableCollection<Processing> GetItems()
        {
            return FormulaItem.Processings;
        }

        protected override Processing GetNewInstance()
        {
            return new Processing {Material = FormulaItem.MaterialNom.Material};
        }

        protected override void InitColumns()
        {
            AddColumn("Наименование", "Name", 300, 0);
        }

        protected override void InitCommamds()
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
