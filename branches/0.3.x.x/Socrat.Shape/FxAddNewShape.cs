using Socrat.UI.Core;
using Socrat.Shape.Factory;
using Socrat.Core;

namespace Socrat.Shape
{
    public partial class FxAddNewShape : FxBaseSimpleDialog
    {
        Core.Entities.Shape _shape;

        CurrentShape _curShape = new CurrentShape();
        ShapeCurrentState shapeState = new ShapeCurrentState();
        FxShapeCatalogEditor _catalogEditor;
        public FxAddNewShape()
        {
            InitializeComponent();
            prpTecnical.SelectedObject = shapeState;
            _catalogEditor = new FxShapeCatalogEditor();
        }

        protected override IEntity GetEntity()
        {
            return _shape;

        }

        protected override void SetEntity(IEntity value)
        {
            _shape = value as Core.Entities.Shape;
        }

        public override bool Validate()
        {
            return true;
        }
        protected override void OnSaveButtonClick()
        {

            _shape.IsCatalogShape = true;
            _shape.CatalogNumber = shapeState.CatalogNumber;

            base.OnSaveButtonClick();
        }
    }
}
