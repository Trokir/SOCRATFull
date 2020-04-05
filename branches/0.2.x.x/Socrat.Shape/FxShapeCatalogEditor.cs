using System;
using Socrat.UI.Core;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using Socrat.Shape.Factory;
using Socrat.DataProvider;
using Socrat.Lib;

namespace Socrat.Shape
{
    public partial class FxShapeCatalogEditor : FxBaseSimpleDialog
    {
        Point cursor;
        Graphics graphics;
        CurrentShape shape = new CurrentShape();
        Model.Shapes.Shape _shape = new Model.Shapes.Shape();
        Model.Shapes.CustomPoint _customPoint = new Model.Shapes.CustomPoint();
        CustomInputShape _CustomInputShape = new CustomInputShape();
        CxShapeCatalog catalog = new CxShapeCatalog();
        ShapeCurrentState shapeState = new ShapeCurrentState();

        /// <summary>
        /// Initializes a new instance of the <see cref="FxShapeCatalogEditor"/> class.
        /// </summary>
        public FxShapeCatalogEditor() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="FxShapeCatalogEditor"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public FxShapeCatalogEditor(Guid id)
        {

            InitializeComponent();
            prpAdvancedInfo.OptionsBehavior.Editable = false;
            cxShapeCatalog1.gvGrid.RowCellClick += GvGrid_RowCellClick;
            cxShapeCatalog1.DeleteItemEvent += CxShapeCatalog1_DeleteItemEvent;
            cxShapeCatalog1.DialogOutput += CxShapeCatalog1_DialogOutput;
            cxShapeCatalog1.AddItemEvent += CxShapeCatalog1_AddItemEvent;

            graphics = pkbDraw.CreateGraphics();

            cmbSelectByCatalogNumber.Properties.DisplayMember = "CatalogNumber";
            cmbSelectByCatalogNumber.Properties.ValueMember = "Id";

            tglSwitch.EditValueChanged += TglSwitch_EditValueChanged;

            cmbShapes.Properties.DataSource = Enum.GetValues(typeof(SelectedShapeBySides));

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
                            if (shape.IsCustomInputEnabledTrue == false)
                            {

                                graphics.Clear(Color.White);
                                shape.SelectedShape.Scale();
                                InitShape();

                            }
                            else if (shape.IsCustomInputEnabledTrue == true && shape.Selector > 0)
                            {
                                graphics.Clear(Color.White);
                                shape.SelectedShape.Scale();
                                InitShape();
                            }
                        };
            btnUnscale.Click += (s, e) =>
            {

                if (shape.IsCustomInputEnabledTrue == false)
                {

                    graphics.Clear(Color.White);
                    shape.SelectedShape.Scale(0.9);
                    InitShape();

                }
                else if (shape.IsCustomInputEnabledTrue == true && shape.Selector > 0)
                {
                    graphics.Clear(Color.White);
                    shape.SelectedShape.Scale(0.9);
                    InitShape();
                }

            };
            btnClear.Click += (s, e) =>
            {
                DataClear();

            };
            btnRotate.Click += (s, e) =>
            {

                if (shape.IsCustomInputEnabledTrue == false)
                {

                    graphics.Clear(Color.White);
                    shape.SelectedShape.Rotate();
                    InitShape();

                }
                else if (shape.IsCustomInputEnabledTrue == true && shape.Selector > 0)
                {
                    graphics.Clear(Color.White);
                    shape.SelectedShape.Rotate();
                    InitShape();
                }

            };

            //Отрисовка
            btnDraw.Click += (s, e) =>
            {

                DrawCurrentShape();
            };

            //Ручной ввод точек
            pkbDraw.MouseClick += (s, e) =>
            {
                if (tglSwitch.IsOn && shape.IsShapeLoaded == true)
                {
                    switch (e.Button)
                    {

                        case MouseButtons.Left:
                            if (shape.Selector < 8)
                            {
                                cursor = pkbDraw.PointToClient(Cursor.Position);
                                shape.GetCustomPointsList.Add(cursor);
                                _CustomInputShape.GetCustomInputPointsList.Add(cursor);
                                shape.Selector++;
                            }
                            _CustomInputShape.OnPaint(pkbDraw);
                            pkbDraw.Refresh();
                            break;
                        case MouseButtons.Right:
                            _CustomInputShape.GetCustomInputPointsList.Clear();
                            break;
                        default:
                            break;
                    }
                }

            };

            /* перебор по числу углов*/
            cmbShapes.EditValueChanged += (s, e) =>
            {
                if (cmbShapes.EditValue != null)
                {
                    Enum.TryParse<SelectedShapeBySides>(cmbShapes.EditValue.ToString(), out shape.SetedShape);
                    cmbSelectByCatalogNumber.Properties.DataSource = shape.GetAllShapesBySidesCount();
                    cmbSelectByCatalogNumber.ShowPopup();
                }
            };

            cmbSelectByCatalogNumber.EditValueChanged += cmbSelectByCatalogNumber_EditValueChanged;

            /* Изменение свойств*/
            prpGrid.CellValueChanged += (s, e) =>
            {
                graphics.Clear(Color.White);
                InitShape();
            };

        }

        private void CxShapeCatalog1_AddItemEvent(object sender, ListItemEventArgs e)
        {
            AddNewShape();
        }

        private void CxShapeCatalog1_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta.NewTab, ta.OutputType);
        }

        /// <summary>
        /// Handles the DeleteItemEvent event of the CxShapeCatalog1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ListItemEventArgs"/> instance containing the event data.</param>
        private void CxShapeCatalog1_DeleteItemEvent(object sender, ListItemEventArgs e)
        {
            DataClear();
        }

        /// <summary>
        /// Handles the RowCellClick event of the GvGrid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs"/> instance containing the event data.</param>
        private void GvGrid_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            shape.Selector_Id = cxShapeCatalog1.OnInit();
            using (ShapeRepository shapeRepository = new ShapeRepository())
            {
                var getShape = shapeRepository.GetShapeById(shape.Selector_Id);
                prpAdvancedInfo.SelectedObject = getShape;
                
            }

            DrawCurrentShape();
        }



        /// <summary>
        /// Draws the current shape.
        /// </summary>
        public void DrawCurrentShape()
        {
            shape.IsShapeLoaded = false;
            if (shape.IsCustomInputEnabledTrue == false)
            {

                shape.GetShape.InitShape(pkbDraw);
                prpGrid.SelectedObject = shape.GetShape;

            }
            else if (shape.IsCustomInputEnabledTrue == true && shape.Selector > 0)
            {

                shape.GetShape.InitShape(pkbDraw);
                prpGrid.SelectedObject = shape.GetShape;

            }
        }


        /// <summary>
        /// Datas the clear.
        /// </summary>
        public void DataClear()
        {
            prpGrid.SelectedObject = null;
            shape.SelectedShape = null;
            pkbDraw.Image = null;
            shape.Selector = 0;
            shape.GetCustomPointsList.Clear();
            _CustomInputShape.GetCustomInputPointsList.Clear();
            cmbSelectByCatalogNumber.EditValue = null;
            cmbShapes.EditValue = null;
            if (tglSwitch.IsOn) { tglSwitch.Toggle(); }
            graphics.Clear(Color.White);

        }


        /// <summary>
        /// Изменение способа создания фигуры
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="NotImplementedException"></exception>
        private void TglSwitch_EditValueChanged(object sender, EventArgs e)
        {
            if (tglSwitch.IsOn == true)
            {
                prpGrid.SelectedObject = null;
                shape.SelectedShape = null;
                pkbDraw.Image = null;
                shape.Selector = 0;
                shape.GetCustomPointsList.Clear();
                _CustomInputShape.GetCustomInputPointsList.Clear();
                cmbSelectByCatalogNumber.EditValue = null;
                cmbShapes.EditValue = null;     
                graphics.Clear(Color.White);
                shape.IsShapeLoaded = true;
                shape.IsCustomInputEnabledTrue = true;
            }
            if (tglSwitch.IsOn == false)
            {
                shape.IsShapeLoaded = false;
                shape.IsCustomInputEnabledTrue = false;
            }
        }




        private void cmbSelectByCatalogNumber_EditValueChanged(object sender, EventArgs e)
        {
            Guid number;
            graphics.Clear(Color.White);
            if (cmbSelectByCatalogNumber.EditValue != null)
            {
                bool success = Guid.TryParse(cmbSelectByCatalogNumber.EditValue.ToString(), out number);
                if (success)
                {
                    shape.Selector_Id = number;
                }
            }

        }


        /// <summary>
        /// Saves the button clicked.
        /// </summary>
        protected override void SaveButtonClicked()
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
                        IsCuttingGlass = shapeSave.IsCuttingGlass,
                        IsBendingDistanceFrame = shapeSave.IsBendingDistanceFrame,
                        IsFormSealing = shapeSave.IsFormSealing,
                        IsGasFillingForm = shapeSave.IsGasFillingForm,
                        IsVertBendingMashineRobot = shapeSave.IsVertBendingMashineRobot,
                        IsVertMashineEdgeMaking = shapeSave.IsVertMashineEdgeMaking,
                        ShapePoints = shape.CustomPoints(shapeSave)
                    };
                    if (!cxShapeCatalog1.Items.Contains(shapeSave))
                        cxShapeCatalog1.Items.Add(shapeSave);
                    shapeRepository.Save(shapeSave);
                    cmbSelectByCatalogNumber.Properties.DataSource = null;
                    cxShapeCatalog1.gvGrid.RefreshData();
                }
            }
        }



        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit>() { };
        }
        private void InitShape()
        {
            shape.SelectedShape.InitShape(pkbDraw);
            prpGrid.RefreshAllProperties();
        }

        private void btnMoveLeft_Click(object sender, EventArgs e)
        {
            if (shape.IsCustomInputEnabledTrue == false)
            {
                //if (Validate())
                //{
                EnableShapeMoving(sender);
                //  }
            }
            else if (shape.IsCustomInputEnabledTrue == true && shape.Selector > 0)
            {
                EnableShapeMoving(sender);
            }
        }
        /// <summary>
        /// Enables the shape moving.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <exception cref="NullReferenceException">Не выбрана фигура</exception>
        private void EnableShapeMoving(object sender)
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


        protected override IEntity GetEntity()
        {
            return shape;
        }

        protected override void SetEntity(IEntity value)
        {
            shape = value as Shape.Factory.CurrentShape;
        }
        /// <summary>
        /// Добавление новой каталожной фигуры
        /// 
        /// </summary>
        public void AddNewShape()
        {
           
                if (shape.Selector >= 3)
                {
                    using (ShapeRepository shapeRepository = new ShapeRepository())
                    {
                        using (ShapePointRepository shapePointRepository = new ShapePointRepository())
                        {

                            Model.Shapes.Shape shapeSave = new Model.Shapes.Shape();
                            IEntityEditor _fx = new FxAddNewShape();
                            _fx.Entity = shapeSave;


                            _fx.SaveButtonClick += (_sender, args) =>
                            {
                                if (!_fx.Entity?.Changed ?? false)
                                    return;
                                DialogResult _dialogResult = XtraMessageBox.Show("Данные были изменены. Сохранить?", "Сохранение",
                                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                                if (_dialogResult == DialogResult.Yes && !this.ReadOnly)
                                {
                                    shapeSave.SidesCount = shape.Selector;
                                    shapeSave.ShapePoints = shape.CustomPoints(shapeSave);
                                    if (!cxShapeCatalog1.Items.Contains(shapeSave))
                                        cxShapeCatalog1.Items.Add(shapeSave);
                                    shapeRepository.Save(shapeSave);
                                    cxShapeCatalog1.RefreshGrid();
                                    DataClear();
                                }

                            };
                            _fx.StartPosition = FormStartPosition.CenterParent;
                            OnDialogOutput(_fx, DialogOutputType.Dialog);

                        }
                    }

                }
                else { MessageBox.Show("Введите точки","Error"); }
            }
           
       






    }
}



