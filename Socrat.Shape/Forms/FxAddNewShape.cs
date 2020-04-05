using Socrat.UI.Core;
using Socrat.Shape.Factory;
using Socrat.Core;

namespace Socrat.Shape.Forms
{
    public partial class FxAddNewShape : FxBaseSimpleDialog
    {
      Core.Entities.Shape shape;


        CurrentShape curShape = new CurrentShape();
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
            shape = value as Core.Entities.Shape;

        }



        public override bool Validate()
        {
            return true;
        }
        protected override void OnSaveButtonClick()
        {

            shape.IsCatalogShape = true;
            shape.CatalogNumber = shapeState.CatalogNumber;

            base.OnSaveButtonClick();
        }

    }


}