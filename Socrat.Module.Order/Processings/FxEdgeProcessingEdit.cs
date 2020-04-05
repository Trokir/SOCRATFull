using System;
using System.Drawing;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.Shape.Factory;
using Socrat.UI.Core;

namespace Socrat.Module.Order.Processings
{
    public partial class FxEdgeProcessingEdit : FxBaseSimpleDialog
    {
        public FormulaItemProcessing FormulaItemProcessing { get; set; }
        public OrderRow OrderRow { get; set; }
        private CurrentUserShape shape { get; set; }
        Graphics graphics;

        public FxEdgeProcessingEdit()
        {
            InitializeComponent();
            shape = new CurrentUserShape();
            Load += FxEdgeProcessingEdit_Load;
            graphics = peShape.CreateGraphics();
            pgOutcrop.CellValueChanged += PgOutcrop_CellValueChanged;

        }

        private void PgOutcrop_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {
            if (shape.SelectedShape.ValidValue == true)
            {
                return;
            }
            else
            {
                graphics.Clear(Color.White);
                shape.SelectedShape.IsToothVector = true;
                FormulaItemProcessing.Distance1 = shape.SelectedShape.CheckCut1;
                FormulaItemProcessing.Distance2 = shape.SelectedShape.CheckCut2;
                FormulaItemProcessing.Distance3 = shape.SelectedShape.CheckCut3;
                FormulaItemProcessing.Distance4 = shape.SelectedShape.CheckCut4;
                FormulaItemProcessing.Distance5 = shape.SelectedShape.CheckCut5;
                FormulaItemProcessing.Distance6 = shape.SelectedShape.CheckCut6;
                FormulaItemProcessing.Distance7 = shape.SelectedShape.CheckCut7;
                FormulaItemProcessing.Distance8 = shape.SelectedShape.CheckCut8;
                InitShape();
                shape.SelectedShape.ValidValue = false;
            }
          
        }

        private void FxEdgeProcessingEdit_Load(object sender, System.EventArgs e)
        {
            DrawNewShape(OrderRow.ShapeId ?? Guid.Empty);

        }

        protected override IEntity GetEntity()
        {
            return FormulaItemProcessing;
        }

        protected override void SetEntity(IEntity value)
        {
            FormulaItemProcessing = value as EdgeProcessing;
        }

        private void InitShape()
        {
            shape.SelectedShape.InitShape(peShape);
            pgOutcrop.RefreshAllProperties();
            pgSizes.RefreshAllProperties();
            peShape.Refresh();
            lcName.Text = GetShapeNumber();
        }

        private string GetShapeNumber()
        {
            string _str = string.Empty;
            var _shape = DataHelper.GetItem<Core.Entities.Shape>(shape.Id);
            if (_shape != null)
                _str = $"Фигура {_shape.CatalogNumber}";
            return _str;
        }

        private void DrawNewShape(Guid number)
        {
            graphics.Dispose();
            graphics = peShape.CreateGraphics();
            peShape.Refresh();
            shape.Selector_Id = number;
            shape.IsCanDrawSizeLines = true;
            shape.GetShape.InitShape(peShape);
            var property = shape.GetShape;
            shape.SelectedShape.IsShowSizeAttr = true;

            property.CheckCut1 = FormulaItemProcessing.Distance1 ?? 0;
            property.CheckCut2 = FormulaItemProcessing.Distance2 ?? 0;
            property.CheckCut3 = FormulaItemProcessing.Distance3 ?? 0;
            property.CheckCut4 = FormulaItemProcessing.Distance4 ?? 0;
            property.CheckCut5 = FormulaItemProcessing.Distance5 ?? 0;
            property.CheckCut6 = FormulaItemProcessing.Distance6 ?? 0;
            property.CheckCut7 = FormulaItemProcessing.Distance7 ?? 0;
            property.CheckCut8 = FormulaItemProcessing.Distance8 ?? 0;

            pgSizes.SelectedObject = null;
            pgSizes.SelectedObject = property;
            pgOutcrop.SelectedObject = null;
            pgOutcrop.SelectedObject = property;
            
            graphics.Clear(Color.White);
            InitShape();
            peShape.Focus();
        }

        public override bool Validate()
        {
            return true;
        }

        private void pgSizes_CustomPropertyDescriptors(object sender, DevExpress.XtraVerticalGrid.Events.CustomPropertyDescriptorsEventArgs e)
        {
            shape.SelectedShape.AddCustomParametersProperties(sender, e);
        }

        private void pgOutcrop_CustomPropertyDescriptors(object sender, DevExpress.XtraVerticalGrid.Events.CustomPropertyDescriptorsEventArgs e)
        {
            shape.SelectedShape.AddCustomToothProperties(sender, e);
        }
    }
}