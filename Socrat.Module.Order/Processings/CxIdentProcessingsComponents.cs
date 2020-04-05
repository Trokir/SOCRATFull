using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.References;
using Socrat.References.Processings;
using Socrat.Shape.Factory;

namespace Socrat.Module.Order.Processings
{
    public partial class CxIdentProcessingsComponents : CxGenericListTable<ProcessingComponent>
    {
        public FormulaItemProcessing FormulaItemProcessing { get; set; }

        public OrderRow OrderRow { get; set; }

        public CxIdentProcessingsComponents()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddObjectColumn("Комплектующие", "MaterialNom", 200, 0);
            AddColumn("Кол-во", "Qty", 100, 1);
            AddObjectColumn("Ед.изм", "Measure", 100, 2);

            foreach (GridColumn gvGridColumn in gvGrid.Columns)
            {
                if (gvGridColumn.FieldName == "MaterialNom")
                    continue;
                gvGridColumn.OptionsColumn.AllowEdit = false;
            }
        }

        protected override ObservableCollection<ProcessingComponent> GetItems()
        {
            return FormulaItemProcessing.Components;
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxProcessingComponentEdit { ChoiseNomenclatureOnly = true};
        }

        protected override ProcessingComponent GetNewInstance()
        {
            double _sq = 0;
            using (CurrentUserShape shape = new CurrentUserShape())  
            {
                using (PictureEdit _pictureEdit = new PictureEdit())
                using (Graphics graphics = _pictureEdit.CreateGraphics())
                {
                    shape.Selector_Id = OrderRow.Shape.Id;
                    shape.GetShape.InitShape(_pictureEdit);
                    shape.SelectedShape.CheckCut1 = FormulaItemProcessing.Distance1 ?? 0;
                    shape.SelectedShape.CheckCut2 = FormulaItemProcessing.Distance2 ?? 0;
                    shape.SelectedShape.CheckCut3 = FormulaItemProcessing.Distance3 ?? 0;
                    shape.SelectedShape.CheckCut4 = FormulaItemProcessing.Distance4 ?? 0;
                    shape.SelectedShape.CheckCut5 = FormulaItemProcessing.Distance5 ?? 0;
                    shape.SelectedShape.CheckCut6 = FormulaItemProcessing.Distance6 ?? 0;
                    shape.SelectedShape.CheckCut7 = FormulaItemProcessing.Distance7 ?? 0;
                    shape.SelectedShape.CheckCut8 = FormulaItemProcessing.Distance8 ?? 0;
                    shape.SelectedShape.InitShape(_pictureEdit);
                    graphics.Clear(Color.White);
                    _sq =Math.Round(shape.SelectedShape.IdentSquare,3);
                }
            }

            return new ProcessingComponent
            {
                Qty =Math.Abs(_sq),
                Measure = DataHelper.GetAll<Measure>().Where(x => x.OkeiCode == 111).FirstOrDefault()
            };
        }
    }
}
