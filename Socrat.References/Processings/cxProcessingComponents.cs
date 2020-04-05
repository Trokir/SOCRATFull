using System.Collections.ObjectModel;
using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Processings
{
    public partial class CxProcessingComponents : CxGenericListTable<ProcessingComponent>
    {
        public FormulaItemProcessing FormulaItemProcessing { get; set; }

        public CxProcessingComponents()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddObjectColumn("Комплектующие", "MaterialNom", 200, 0 );
            AddColumn("Кол-во", "Qty", 100, 1);
            AddObjectColumn("Ед.изм", "Measure", 100, 2);
        }

        protected override ObservableCollection<ProcessingComponent> GetItems()
        {
            return FormulaItemProcessing.Components;
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxProcessingComponentEdit();
        }
    }
}
