using System;
using Socrat.UI.Core;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.DataProvider.Repos;
using Socrat.Shape.Factory;
using System.Linq;
using Socrat.Core.Entities;

namespace Socrat.Shape.Forms
{
    public partial class FxShapeCatalogEditor : FxBaseSimpleDialog
    {
          Point cursor;
        Graphics graphics;
        CurrentShape shape = new CurrentShape();
        Core.Entities.Shape _shape = new Core.Entities.Shape();
        Core.Entities.ShapePoint _customPoint = new Core.Entities.ShapePoint();
        CustomInputShape _CustomInputShape = new CustomInputShape();
        // CxShapeCatalog catalog = new CxShapeCatalog();
        ShapeCurrentState shapeState = new ShapeCurrentState();
        private float XProp { get; set; }
        private float YProp { get; set; }
        public int pkbDrawW { get; set; }
        public int pkbDrawH { get; set; }
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
            Load += FxShapeCatalogEditor_Load;
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
                  shape.SelectedShape.MovePoint(XProp, YProp);
                  InitShape();
              };
            pkbDraw.MouseMove += (s, e) =>{ParseCurrentCoordinates(e);};

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
                GetExtremumPoints(shape.GetCustomPointsList);
              
                DrawCurrentShape();
                
                labelControl1.Text = $" aX: {shape.SelectedShape.A.PointX}  aY:{shape.SelectedShape.A.PointY}" +
                   $" ///bX: {shape.SelectedShape.B.PointX}  bY:{shape.SelectedShape.B.PointY}";
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
                                 cursor =pkbDraw.PointToClient(Cursor.Position);
                               // Point cursor = new Point((int)XProp, (int)YProp);
                                shape.GetCustomPointsList.Add(cursor);
                                _CustomInputShape.GetCustomInputPointsList.Add(cursor);
                                shape.Selector++;
                            }
                            _CustomInputShape.IsStartDrawCustomShapeElements = false;
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
                    Enum.TryParse(cmbShapes.EditValue.ToString(), out shape.SetedShape);
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
        private  void GetExtremumPoints(List<PointF> pointList)
        {
            List<ShapePoint> points = new List<ShapePoint>();
            var xMin = pointList.Min(x =>x.X);
            var yMin = pointList.Min(x =>x.Y);
            var XDiff = xMin - 150;
            var YDiff = yMin - 150;
            foreach (var item in pointList)
            {
                points.Add(item);
            }
            pointList.Clear();
            foreach (var item in points)
            {
                double newX = item.PointX - XDiff;
                double newY = item.PointY - YDiff;
                item.PointX = newX;
                item.PointY = newY;
                pointList.Add(item);
            }
           
        }

        private void FxShapeCatalogEditor_Load(object sender, EventArgs e)
        {
            _CustomInputShape.IsStartDrawCustomShapeElements = true;
            _CustomInputShape.OnPaint(pkbDraw);
        }

        private void ParseCurrentCoordinates(MouseEventArgs e)
        {
           
            var x = e.X;
            var y = e.Y;
            YProp = e.Y;
            XProp = e.X;
           
            pkbDrawW = _CustomInputShape.pkbDrawW;
            pkbDrawH = _CustomInputShape.pkbDrawH;
            var pkbDrawWs = pkbDraw.ClientSize.Width;
            var pkbDrawHs = pkbDraw.ClientSize.Height;

            float pic_aspect = (pkbDrawWs) / (float)(pkbDrawHs);
            float img_aspect = pkbDrawW / (float)pkbDrawH;
            if (pic_aspect > img_aspect)
            {
                YProp = (int)((float)pkbDrawH * y / (float)pkbDrawHs);
                float scaled_width = pkbDrawW * pkbDrawHs / pkbDrawH;
                float dx = (pkbDrawWs - scaled_width) / 2;
                XProp = (int)((x - dx) * pkbDrawH / (float)pkbDrawHs);
            }
            else
            {
                XProp = (int)(pkbDrawW * x / (float)pkbDrawWs);
                float scaled_height = pkbDrawH * pkbDrawWs / pkbDrawW;
                float dy = (pkbDrawHs - scaled_height) / 2;
                YProp = (int)((y - dy) * pkbDrawW / pkbDrawWs);
            }
            mouseCursor.Text = "X: " + XProp + " Y: " + YProp;
        }

        public CurrentShape GetShapeInfo()
        {
            return shape;
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
                pkbDrawW = shape.SelectedShape.ControlImage.Width;
                pkbDrawH = shape.GetShape.ControlImage.Height;
            }
            else if (shape.IsCustomInputEnabledTrue == true && shape.Selector > 0)
            {
                shape.GetShape.InitShape(pkbDraw);
                prpGrid.SelectedObject = shape.GetShape;
                pkbDrawW = shape.SelectedShape.ControlImage.Width;
                pkbDrawH = shape.SelectedShape.ControlImage.Height;
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
                using (ShapeParamRepository paramRepository = new ShapeParamRepository())
                {
                    using (ShapeModifiedParamRepository paramModifiedRepository = new ShapeModifiedParamRepository())
                    {
                        Core.Entities.Shape shapeSave = new Core.Entities.Shape()
                        {
                            SidesCount = shape.Selector,
                            CatalogNumber = shape.GetCatalogNumber,
                            IsCatalogShape = true
                        };

                        shapeSave.ShapePoints = shape.ShapePoints(shapeSave);

                        if (!cxShapeCatalog1.Items.Contains(shapeSave))
                            cxShapeCatalog1.Items.Add(shapeSave);
                        shapeRepository.Save(shapeSave);
                        Core.Entities.ShapeParam shapeParamSave = new Core.Entities.ShapeParam()
                        {
                            Id = shapeSave.Id,
                            IsCanCutGlass = shape.SelectedShape.IsCuttingGlass,
                            IsCanBendDistanceFrame = shape.SelectedShape.IsBendingDistanceFrame,
                            IsCanFormSeal = shape.SelectedShape.IsFormSealing,
                            IsCanGasFillForm = shape.SelectedShape.IsGasFillingForm,
                            IsCanVertBendMashineRobot = shape.SelectedShape.IsVertBendingMashineRobot,
                            IsCanVertMashineEdgeMake = shape.SelectedShape.IsVertMashineEdgeMaking,
                            IsToothVector = shape.SelectedShape.IsToothVector,
                            L_param = shape.SelectedShape.SetL,
                            H_param = shape.SelectedShape.SetH,
                            L1_param = shape.SelectedShape.SetL1,
                            L2_param = shape.SelectedShape.SetL2,
                            H1_param = shape.SelectedShape.SetH1,
                            H2_param = shape.SelectedShape.SetH2,
                            R_param = shape.SelectedShape.SetRadius,
                            R1_param = shape.SelectedShape.SetRadius1,
                            R2_param = shape.SelectedShape.SetRadius2,
                            R3_param = shape.SelectedShape.SetRadius3,
                            R4_param = shape.SelectedShape.SetRadius4,
                            Chord_param = shape.SelectedShape.SetChord,
                            B1_param = shape.SelectedShape.SetB1,
                            B2_param = shape.SelectedShape.SetB2,
                            B3_param = shape.SelectedShape.SetB3,
                            B4_param = shape.SelectedShape.SetB4,
                            CheckCut1_param = shape.SelectedShape.CheckCut1 = (shape.SelectedShape.CheckCut1 < 0) ? shape.SelectedShape.CheckCut1 * (-1) : shape.SelectedShape.CheckCut1,
                            CheckCut2_param = shape.SelectedShape.CheckCut2 = (shape.SelectedShape.CheckCut2 < 0) ? shape.SelectedShape.CheckCut2 * (-1) : shape.SelectedShape.CheckCut2,
                            CheckCut3_param = shape.SelectedShape.CheckCut3 = (shape.SelectedShape.CheckCut3 < 0) ? shape.SelectedShape.CheckCut3 * (-1) : shape.SelectedShape.CheckCut3,
                            CheckCut4_param = shape.SelectedShape.CheckCut4 = (shape.SelectedShape.CheckCut4 < 0) ? shape.SelectedShape.CheckCut4 * (-1) : shape.SelectedShape.CheckCut4,
                            CheckCut5_param = shape.SelectedShape.CheckCut5 = (shape.SelectedShape.CheckCut5 < 0) ? shape.SelectedShape.CheckCut5 * (-1) : shape.SelectedShape.CheckCut5,
                            CheckCut6_param = shape.SelectedShape.CheckCut6 = (shape.SelectedShape.CheckCut6 < 0) ? shape.SelectedShape.CheckCut6 * (-1) : shape.SelectedShape.CheckCut6,
                            CheckCut7_param = shape.SelectedShape.CheckCut7 = (shape.SelectedShape.CheckCut7 < 0) ? shape.SelectedShape.CheckCut7 * (-1) : shape.SelectedShape.CheckCut7,
                            CheckCut8_param = shape.SelectedShape.CheckCut8 = (shape.SelectedShape.CheckCut8 < 0) ? shape.SelectedShape.CheckCut8 * (-1) : shape.SelectedShape.CheckCut8,
                            BaseArea = shape.SelectedShape.BaseArea,
                            Area = shape.SelectedShape.Area,
                            Perimeter = shape.SelectedShape.Perimeter,
                            ShapeKisPersent = shape.SelectedShape.ShapeKisPersent,
                            ShapeKis = shape.SelectedShape.ShapeKis,
                            ShapeHeight = shape.SelectedShape.ShapeHeightValue,
                            ShapeWidth = shape.SelectedShape.ShapeWidthValue,
                            Shape = shapeSave
                        };
                        paramRepository.Save(shapeParamSave);

                        Core.Entities.ShapeModifedParam shapeModifiedParamSave = new Core.Entities.ShapeModifedParam()
                        {
                            Id = shapeSave.Id,
                            L_param_t = shape.SelectedShape.SetL_t,
                            H_param_t = shape.SelectedShape.SetH_t,
                            L1_param_t = shape.SelectedShape.SetL1_t,
                            L2_param_t = shape.SelectedShape.SetL2_t,
                            H1_param_t = shape.SelectedShape.SetH1_t,
                            H2_param_t = shape.SelectedShape.SetH2_t,
                            R_param_t = shape.SelectedShape.SetRadius_t,
                            R1_param_t = shape.SelectedShape.SetRadius1_t,
                            R2_param_t = shape.SelectedShape.SetRadius2_t,
                            R3_param_t = shape.SelectedShape.SetRadius3_t,
                            R4_param_t = shape.SelectedShape.SetRadius4_t,
                            Chord_param_t = shape.SelectedShape.SetChord_t,
                            TrueArea = shape.SelectedShape.Area,
                            TruePerimeter = shape.SelectedShape.Perimeter,
                            Shape = shapeSave

                        };
                        paramModifiedRepository.Save(shapeModifiedParamSave);
                        cmbSelectByCatalogNumber.Properties.DataSource = null;
                        cxShapeCatalog1.gvGrid.RefreshData();
                    }
                }
            }
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
                    using (ShapeParamRepository paramRepository = new ShapeParamRepository())
                    {
                        using (ShapeModifiedParamRepository paramModifiedRepository = new ShapeModifiedParamRepository())
                        {
                            Core.Entities.Shape shapeSave = new Core.Entities.Shape();
                            Core.Entities.ShapeParam shapeParamSave = new Core.Entities.ShapeParam();
                            Core.Entities.ShapeModifedParam shapeModifiedParamSave = new Core.Entities.ShapeModifedParam();
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
                                    shapeSave.ShapePoints = shape.ShapePoints(shapeSave);
                                    if (!cxShapeCatalog1.Items.Contains(shapeSave))
                                        cxShapeCatalog1.Items.Add(shapeSave);
                                    shapeRepository.Save(shapeSave);
                                    shapeParamSave = new Core.Entities.ShapeParam()
                                    {
                                        Id = shapeSave.Id,
                                        IsCanCutGlass = shape.SelectedShape.IsCuttingGlass,
                                        IsCanBendDistanceFrame = shape.SelectedShape.IsBendingDistanceFrame,
                                        IsCanFormSeal = shape.SelectedShape.IsFormSealing,
                                        IsCanGasFillForm = shape.SelectedShape.IsGasFillingForm,
                                        IsCanVertBendMashineRobot = shape.SelectedShape.IsVertBendingMashineRobot,
                                        IsCanVertMashineEdgeMake = shape.SelectedShape.IsVertMashineEdgeMaking,
                                        L_param = shape.SelectedShape.SetL,
                                        H_param = shape.SelectedShape.SetH,
                                        L1_param = shape.SelectedShape.SetL1,
                                        L2_param = shape.SelectedShape.SetL2,
                                        H1_param = shape.SelectedShape.SetH1,
                                        H2_param = shape.SelectedShape.SetH2,
                                        R_param = shape.SelectedShape.SetRadius,
                                        R1_param = shape.SelectedShape.SetRadius1,
                                        R2_param = shape.SelectedShape.SetRadius2,
                                        R3_param = shape.SelectedShape.SetRadius3,
                                        R4_param = shape.SelectedShape.SetRadius4,
                                        Chord_param = shape.SelectedShape.SetChord,
                                        B1_param = shape.SelectedShape.SetB1,
                                        B2_param = shape.SelectedShape.SetB2,
                                        B3_param = shape.SelectedShape.SetB3,
                                        B4_param = shape.SelectedShape.SetB4,
                                        CheckCut1_param = shape.SelectedShape.CheckCut1,
                                        CheckCut2_param = shape.SelectedShape.CheckCut2,
                                        CheckCut3_param = shape.SelectedShape.CheckCut3,
                                        CheckCut4_param = shape.SelectedShape.CheckCut4,
                                        CheckCut5_param = shape.SelectedShape.CheckCut5,
                                        CheckCut6_param = shape.SelectedShape.CheckCut6,
                                        CheckCut7_param = shape.SelectedShape.CheckCut7,
                                        CheckCut8_param = shape.SelectedShape.CheckCut8,
                                        BaseArea = shape.SelectedShape.BaseArea,
                                        Area = shape.SelectedShape.Area,
                                        Perimeter = shape.SelectedShape.Perimeter,
                                        ShapeKisPersent = shape.SelectedShape.ShapeKisPersent,
                                        ShapeKis = shape.SelectedShape.ShapeKis,
                                        ShapeHeight = shape.SelectedShape.ShapeHeightValue,
                                        ShapeWidth = shape.SelectedShape.ShapeWidthValue,
                                        Shape = shapeSave
                                    };
                                    paramRepository.Save(shapeParamSave);

                                    shapeModifiedParamSave = new Core.Entities.ShapeModifedParam()
                                    {
                                        Id = shapeSave.Id,
                                        L_param_t = shape.SelectedShape.SetL_t,
                                        H_param_t = shape.SelectedShape.SetH_t,
                                        L1_param_t = shape.SelectedShape.SetL1_t,
                                        L2_param_t = shape.SelectedShape.SetL2_t,
                                        H1_param_t = shape.SelectedShape.SetH1_t,
                                        H2_param_t = shape.SelectedShape.SetH2_t,
                                        R_param_t = shape.SelectedShape.SetRadius_t,
                                        R1_param_t = shape.SelectedShape.SetRadius1_t,
                                        R2_param_t = shape.SelectedShape.SetRadius2_t,
                                        R3_param_t = shape.SelectedShape.SetRadius3_t,
                                        R4_param_t = shape.SelectedShape.SetRadius4_t,
                                        Chord_param_t = shape.SelectedShape.SetChord_t,
                                        TrueArea = shape.SelectedShape.TrueArea,
                                        TruePerimeter = shape.SelectedShape.Perimeter,
                                        Shape = shapeSave
                                    };
                                    paramModifiedRepository.Save(shapeModifiedParamSave);

                                    cxShapeCatalog1.RefreshGrid();
                                    DataClear();
                                }

                            };
                            _fx.StartPosition = FormStartPosition.CenterParent;
                            OnDialogOutput(_fx, DialogOutputType.Dialog);

                        }
                    }
                }
            }





            if (shape.Selector >= 3)
            {
                using (ShapeRepository shapeRepository = new ShapeRepository())
                {

                    Core.Entities.Shape shapeSave = new Core.Entities.Shape();
                    IEntityEditor _fx = new FxAddNewShape
                    {
                        Entity = shapeSave
                    };


                    _fx.SaveButtonClick += (_sender, args) =>
                    {
                        if (!_fx.Entity?.Changed ?? false)
                            return;
                        DialogResult _dialogResult = XtraMessageBox.Show("Данные были изменены. Сохранить?", "Сохранение",
                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (_dialogResult == DialogResult.Yes && !this.ReadOnly)
                        {
                            shapeSave.SidesCount = shape.Selector;
                            shapeSave.ShapePoints = shape.ShapePoints(shapeSave);
                            if (!cxShapeCatalog1.Items.Contains(shapeSave))
                                cxShapeCatalog1.Items.Add(shapeSave);
                            shapeRepository.Save(shapeSave);
                            cxShapeCatalog1.RefreshGrid();
                            DataClear();
                        }

                    };
                    _fx.StartPosition = FormStartPosition.CenterParent;
                    OnDialogOutput(_fx, Core.DialogOutputType.Dialog);


                }

            }
            // else { MessageBox.Show("Введите точки", "Error"); }
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
            shape = value as CurrentShape;
        }









    }
}



