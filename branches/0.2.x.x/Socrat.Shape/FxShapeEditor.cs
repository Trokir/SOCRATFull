using System;
using Socrat.UI.Core;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using Socrat.Shape;
using Socrat.Shape.Factory;
using Socrat.DataProvider;
using System.Linq;
using Socrat.Lib;
using System.ComponentModel;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraEditors.Controls;
using Socrat.Shape.Rectangles;

namespace Socrat.Shape
{



    public partial class FxShapeEditor : FxBaseSimpleDialog
    {



        Point cursor;
        Graphics graphics;
       // private CurrentShape shape = new CurrentShape();
        private CurrentUserShape shape = new CurrentUserShape();

        private Model.Shapes.Shape _shape = new Model.Shapes.Shape();
        private Model.Shapes.CustomPoint _customPoint = new Model.Shapes.CustomPoint();
        
       
        public FxShapeEditor()
        {

            InitializeComponent();

            
            graphics = pkbDraw.CreateGraphics();
            cmbShapes.Properties.DisplayMember = "CatalogNumber";
            cmbShapes.Properties.ValueMember = "Id";
            prpGrid.CustomPropertyDescriptors += PrpGrid_CustomPropertyDescriptors;
            cmbShapes.Properties.DataSource = shape.GetAllShapes();

            pkbDraw.MouseDoubleClick += (s, e) =>
            {
                shape.SelectedShape.MovePoint(e.Location.X, e.Location.Y);
                InitShape();
            };
            pkbDraw.MouseMove += (s, e) =>
            {
                cursor = pkbDraw.PointToClient(Cursor.Position);
                mouseCursor.Text = "X: " + cursor.X + " Y: " + cursor.Y;
            };
            btnScale.Click += (s, e) =>
            {
                if (Validate())
                {
                    graphics.Clear(Color.White);
                shape.SelectedShape.Scale();
                InitShape();
                 }
            };
            btnUnscale.Click += (s, e) =>
            {
                if (Validate())
                {
                    graphics.Clear(Color.White);
                shape.SelectedShape.Scale(0.9);
                InitShape();
                 }
            };
            btnClear.Click += (s, e) =>
            {
                if (Validate())
                {
                    prpGrid.SelectedObject = null;
                prpGrid.Refresh();
                graphics.Clear(Color.White);
                  }
            };
            btnRotate.Click += (s, e) =>
            {
                if (Validate())
                {
                    graphics.Clear(Color.White);
                    shape.SelectedShape.Rotate();
                InitShape();
                }

            };

            btnDraw.Click += (s, e) =>
            {
                if (Validate())
                {
                    shape.GetShape.InitShape(pkbDraw);
                    prpGrid.SelectedObject = null;
                   prpGrid.SelectedObject = shape.GetShape;
              
                }
            };
           

            cmbShapes.EditValueChanged += (s, e) =>
            {
                Guid number;
                graphics.Clear(Color.White);
                bool success = Guid.TryParse(cmbShapes.EditValue.ToString(), out number);
                if (success)
                {
                    shape.Selector_Id = number;
                }

            };
            prpGrid.CellValueChanged += (s, e) =>
            {
                graphics.Clear(Color.White);
                InitShape();
            };

        }

       

       

        private void PrpGrid_CustomPropertyDescriptors(object sender, DevExpress.XtraVerticalGrid.Events.CustomPropertyDescriptorsEventArgs e)
        {
           shape.SelectedShape.AddCustomProperties(sender, e);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit>() { cmbShapes };
        }
        private void InitShape()
        {
            shape.SelectedShape.InitShape(pkbDraw);
            prpGrid.RefreshAllProperties();
        }

        private void btnMoveLeft_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                try
                {
                    switch (((SimpleButton)sender).Name)
                    {
                        case "btnMoveLeft":
                            shape.SelectedShape.Move(-10, 0);
                            InitShape();
                            break;
                        case "btnMoveUp":
                            shape.SelectedShape.Move(0, -10);
                            InitShape();
                            break;
                        case "btnMoveDown":
                            shape.SelectedShape.Move(0, 10);
                            InitShape();
                            break;
                        case "btnMoveRight":
                            shape.SelectedShape.Move(10, 0);

                            InitShape();
                            break;
                    }
                }
                catch (NullReferenceException ex)
                {
                    throw new NullReferenceException("Не выбрана фигура");
                }

            }

        }



        Model.Shapes.Shape shapes = new Model.Shapes.Shape();


        protected override IEntity GetEntity()
        {
            return shapes;
        }

        protected override void SetEntity(IEntity value)
        {

            shapes = value as Model.Shapes.Shape;
        }


        protected override void SaveButtonClicked()
        {
            if (Validate())
            {
                using (ShapeRepository shapeRepository = new ShapeRepository())
                {
                    using (ShapePointRepository shapePointRepository = new ShapePointRepository())
                    {
                        Model.Shapes.Shape shapeSave = new Model.Shapes.Shape();

                        shapeSave = new Model.Shapes.Shape()
                        {
                            SidesCount = shape.Selector,
                            CatalogNumber = shape.GetCatalogNumberWithDateTime,
                            IsCatalog = false,
                            ShapePoints = shape.CustomPoints(shapeSave)
                        };
                        shapeRepository.Save(shapeSave);
                        cmbShapes.Properties.DataSource = shape.GetAllShapes();
                    }
                }
            }

        }

       
    }
}