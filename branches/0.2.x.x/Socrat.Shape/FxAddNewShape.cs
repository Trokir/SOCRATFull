using System;
using Socrat.UI.Core;
using Socrat.DataProvider;
using Socrat.Shape.Factory;
using Socrat.Lib;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using DevExpress.XtraEditors.DXErrorProvider;

namespace Socrat.Shape
{
    public partial class FxAddNewShape : FxBaseSimpleDialog
    {
        Model.Shapes.Shape shape;
        // CurrentShape shape = new CurrentShape();
        ShapeCurrentState shapeState = new ShapeCurrentState();
        FxShapeCatalogEditor catalogEditor;
        public FxAddNewShape()
        {

            InitializeComponent();
            prpTecnical.SelectedObject = shapeState;
            catalogEditor = new FxShapeCatalogEditor();
          
        }



        protected override IEntity GetEntity()
        {
            return shape;
        }

        protected override void SetEntity(IEntity value)
        {
            shape = value as Model.Shapes.Shape;
        }

        public override bool Validate()
        {
            return true;
        }
        protected override void OnSaveButtonClick()
        {

            shape.CatalogNumber = shapeState.CatalogNumber;
            shape.IsCuttingGlass = shapeState.IsCuttingGlass;
            shape.IsBendingDistanceFrame = shapeState.IsBendingDistanceFrame;
            shape.IsFormSealing = shapeState.IsFormSealing;
            shape.IsGasFillingForm = shapeState.IsGasFillingForm;
            shape.IsVertBendingMashineRobot = shapeState.IsVertBendingMashineRobot;
            shape.IsVertMashineEdgeMaking = shapeState.IsVertMashineEdgeMaking;
            base.OnSaveButtonClick();
        }
      
    }

   
}  
