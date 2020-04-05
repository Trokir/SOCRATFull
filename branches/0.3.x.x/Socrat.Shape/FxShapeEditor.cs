using System;
using Socrat.UI.Core;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using Socrat.Shape.Factory;
using Socrat.DataProvider;
using Socrat.Lib;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System.Diagnostics;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider.Repos;

namespace Socrat.Shape
{



    public partial class FxShapeEditor : FxBaseSimpleDialog
    {

        public Guid? Id_ForOrder { get; set; }
        public double? H_value_ForOrder { get; set; }
        public double? L_value_ForOrder { get; set; }
        Graphics graphics;

        // private CurrentShape shape = new CurrentShape();
        private CurrentUserShape shape = new CurrentUserShape();
        private Core.Entities.Shape _shape = new Core.Entities.Shape();
        private ShapePoint _customPoint = new ShapePoint();

        private RepositoryItem[] inplaceEditors;
        //  public FxShapeEditor() { }

        public FxShapeEditor(Guid? id)
        {
            Id_ForOrder = id;
            InitializeComponent();
            RepositoryItemCheckEdit repSidesCountEdit = new RepositoryItemCheckEdit();
            Load += FxShapeEditor_Load;
            graphics = pkbDraw.CreateGraphics();
            gridCmbShape.Properties.DisplayMember = "CatalogNumber";
            gridCmbShape.Properties.ValueMember = "Id";
            gridCmbShape.Properties.DataSource = shape.GetAllShapesFromCatalog();
            gridCmbShape.Properties.View.BestFitColumns();
            gridCmbShape.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            gridCmbShape.Properties.ImmediatePopup = true;
            gridCmbShape.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            prpGrid.OptionsBehavior.PropertySort = DevExpress.XtraVerticalGrid.PropertySort.NoSort;
            prpGrid.CustomPropertyDescriptors += PrpGrid_CustomPropertyDescriptors;
            pkbDraw.Properties.SizeMode = PictureSizeMode.Squeeze;
            pkbDraw.Properties.ContextMenuStrip = new ContextMenuStrip();
            prpGrid.CustomDrawRowHeaderCell += PrpGrid_CustomDrawRowHeaderCell;
            prpGrid.FocusedRowChanged += PrpGrid_FocusedRowChanged;

            btnClear.Click += (s, e) =>
            {

                prpGrid.SelectedObject = null;
                prpGrid.Refresh();
                graphics.Clear(Color.White);
                shape.GetShape.InitShape(pkbDraw);
                prpGrid.SelectedObject = null;
                prpGrid.SelectedObject = shape.GetShape;
                graphics.Clear(Color.White);

                InitShape();

            };
            btnRotate.Click += (s, e) =>
            {

                graphics.Clear(Color.White);
                // shape.SelectedShape.IsCanRotate = true;
                shape.SelectedShape.Rotate();
                InitShape();
            };

            gridCmbShape.EditValueChanged += (s, e) =>
            {
                Guid number = Guid.NewGuid();

                if (gridCmbShape.EditValue != null && Guid.TryParse(gridCmbShape.EditValue.ToString(), out number))
                {
                    //  graphics.Clear(Color.White);
                    DrawNewShape(number);
                }

            };


            prpGrid.CellValueChanged += (s, e) =>
            {
                if (shape.SelectedShape.ValidValue == true)
                {
                    return;
                }
                else
                {

                    graphics.Clear(Color.White);
                    InitShape();
                    //  pkbDraw.Refresh();
                    shape.SelectedShape.ValidValue = false;

                }

            };

        }

        private void DrawNewShape(Guid number)
        {
            graphics.Dispose();
            graphics = pkbDraw.CreateGraphics();
            pkbDraw.Refresh();
            shape.Selector_Id = number;
            shape.GetShape.InitShape(pkbDraw);
            prpGrid.SelectedObject = null;
            prpGrid.SelectedObject = shape.GetShape;
            graphics.Clear(Color.White);
            InitShape();
            pkbDraw.Focus();
        }

        private void FxShapeEditor_Load(object sender, EventArgs e)
        {
            if (Id_ForOrder != null)
            {
                if (Id_ForOrder != Guid.Empty)
                {
                    DrawNewShape(Id_ForOrder ?? Guid.Empty);
                }
            }

            inplaceEditors = new RepositoryItem[] { repSidesCountEdit };
            prpGrid.RepositoryItems.Add(repSidesCountEdit);
            prpGrid.CustomRecordCellEdit += PrpGrid_CustomRecordCellEdit;

        }

        private void PrpGrid_FocusedRowChanged(object sender, DevExpress.XtraVerticalGrid.Events.FocusedRowChangedEventArgs e)
        {
            if (e.Row != null && e.Row.IsFocused)
            {
                if (e.Row.Name == "rowCheckCut1" ||
                    e.Row.Name == "rowCheckCut2" ||
                    e.Row.Name == "rowCheckCut3" ||
                    e.Row.Name == "rowCheckCut4" ||
                    e.Row.Name == "rowCheckCut5" ||
                    e.Row.Name == "rowCheckCut6" ||
                    e.Row.Name == "rowCheckCut7" ||
                    e.Row.Name == "rowCheckCut8")
                {
                    shape.SelectedShape.ColorMarker = e.Row.Name;
                    graphics.Clear(Color.White);
                    shape.SelectedShape.InitShape(pkbDraw);
                }
            }
            else { return; }
        }

        private void PrpGrid_CustomRecordCellEdit(object sender, DevExpress.XtraVerticalGrid.Events.GetCustomRowCellEditEventArgs e)
        {
            if (e.RecordIndex < 3 && e.Row.Properties.FieldName == "IsSelectSameAllowance") { e.RepositoryItem = inplaceEditors[e.RecordIndex]; }
            if (e.RecordIndex < 3 && e.Row.Properties.FieldName == "IsCuttingGlass") { e.RepositoryItem = inplaceEditors[e.RecordIndex]; }
            if (e.RecordIndex < 3 && e.Row.Properties.FieldName == "IsBendingDistanceFrame") { e.RepositoryItem = inplaceEditors[e.RecordIndex]; }
            if (e.RecordIndex < 3 && e.Row.Properties.FieldName == "IsFormSealing") { e.RepositoryItem = inplaceEditors[e.RecordIndex]; }
            if (e.RecordIndex < 3 && e.Row.Properties.FieldName == "IsGasFillingForm") { e.RepositoryItem = inplaceEditors[e.RecordIndex]; }
            if (e.RecordIndex < 3 && e.Row.Properties.FieldName == "IsVertBendingMashineRobot") { e.RepositoryItem = inplaceEditors[e.RecordIndex]; }
            if (e.RecordIndex < 3 && e.Row.Properties.FieldName == "IsVertMashineEdgeMaking") { e.RepositoryItem = inplaceEditors[e.RecordIndex]; }
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

        Core.Entities.Shape shapes = new Core.Entities.Shape();


        protected override IEntity GetEntity()
        {
            return shapes;
        }

        protected override void SetEntity(IEntity value)
        {

            shapes = value as Core.Entities.Shape;
        }

        /// <summary>
        /// Saves the bit map.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        public void SavePicture(PictureEdit edit)
        {
            if (gridCmbShape.SelectedText != String.Empty)
            {
                Image image = pkbDraw.Image.Clone() as Image;
                edit.Properties.SizeMode = PictureSizeMode.Squeeze;
                edit.Image.Dispose();
                edit.Image = image;
                //  image.Dispose();
            }
        }



        public int CurrentShapeNumber { get; set; }

        protected override void SaveButtonClicked()
        {
            try
            {
                using (ShapeRepository shapeRepository = new ShapeRepository())
                {
                    using (ShapeParamRepository paramRepository = new ShapeParamRepository())
                    {
                        using (ShapeModifiedParamRepository paramModifiedRepository = new ShapeModifiedParamRepository())
                        {
                            Core.Entities.Shape shapeSave = new Core.Entities.Shape();
                            ShapeParam shapeParamSave = new ShapeParam();
                            ShapeModifedParam shapeModifiedParamSave = new ShapeModifedParam();
                            shapeSave = new Core.Entities.Shape()
                            {
                                SidesCount = shape.Selector,
                                CatalogNumber = shape.GetCatalogNumber,
                                IsCatalogShape = false,
                                ShapePoints = shape.CustomPoints(shapeSave),
                            };
                            shapeRepository.Save(shapeSave);
                            shapeParamSave = new ShapeParam()
                            {
                                Id = shapeSave.Id,
                                IsCanCutGlass = shape.SelectedShape.IsCuttingGlass,
                                IsCanBendDistanceFrame = shape.SelectedShape.IsBendingDistanceFrame,
                                IsCanFormSeal = shape.SelectedShape.IsFormSealing,
                                IsCanGasFillForm = shape.SelectedShape.IsGasFillingForm,
                                IsCanVertBendMashineRobot = shape.SelectedShape.IsVertBendingMashineRobot,
                                IsCanVertMashineEdgeMake = shape.SelectedShape.IsVertMashineEdgeMaking,
                                LParam = shape.SelectedShape.SetL,
                                HParam = shape.SelectedShape.SetH,
                                L1Param = shape.SelectedShape.SetL1,
                                L2Param = shape.SelectedShape.SetL2,
                                H1Param = shape.SelectedShape.SetH1,
                                H2Param = shape.SelectedShape.SetH2,
                                RParam = shape.SelectedShape.SetRadius,
                                R1Param = shape.SelectedShape.SetRadius1,
                                R2Param = shape.SelectedShape.SetRadius2,
                                R3Param = shape.SelectedShape.SetRadius3,
                                R4Param = shape.SelectedShape.SetRadius4,
                                ChordParam = shape.SelectedShape.SetChord,
                                B1Param = shape.SelectedShape.SetB1,
                                B2Param = shape.SelectedShape.SetB2,
                                B3Param = shape.SelectedShape.SetB3,
                                B4Param = shape.SelectedShape.SetB4,
                                CheckCut1Param = shape.SelectedShape.CheckCut1,
                                CheckCut2Param = shape.SelectedShape.CheckCut2,
                                CheckCut3Param = shape.SelectedShape.CheckCut3,
                                CheckCut4Param = shape.SelectedShape.CheckCut4,
                                CheckCut5Param = shape.SelectedShape.CheckCut5,
                                CheckCut6Param = shape.SelectedShape.CheckCut6,
                                CheckCut7Param = shape.SelectedShape.CheckCut7,
                                CheckCut8Param = shape.SelectedShape.CheckCut8,
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
                            CurrentShapeNumber = shapeSave.CatalogNumber;
                            shapeModifiedParamSave = new ShapeModifedParam()
                            {
                                Id = shapeSave.Id,
                                LParamT = shape.SelectedShape.SetL_t,
                                HParamT = shape.SelectedShape.SetH_t,
                                L1ParamT = shape.SelectedShape.SetL1_t,
                                L2ParamT = shape.SelectedShape.SetL2_t,
                                H1ParamT = shape.SelectedShape.SetH1_t,
                                H2ParamT = shape.SelectedShape.SetH2_t,
                                RParamT = shape.SelectedShape.SetRadius_t,
                                R1ParamT = shape.SelectedShape.SetRadius1_t,
                                R2ParamT = shape.SelectedShape.SetRadius2_t,
                                R3ParamT = shape.SelectedShape.SetRadius3_t,
                                R4ParamT = shape.SelectedShape.SetRadius4_t,
                                ChordParamT = shape.SelectedShape.SetChord_t,
                                TrueArea = shape.SelectedShape.Area,
                                TruePerimeter = shape.SelectedShape.Perimeter,
                                Shape = shapeSave

                            };
                            Id_ForOrder = shapeSave.Id;
                            H_value_ForOrder = shapeParamSave.HParam;
                            L_value_ForOrder = shapeParamSave.LParam;
                            paramModifiedRepository.Save(shapeModifiedParamSave);

                            gridCmbShape.Properties.DataSource = shape.GetAllShapesFromCatalog();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw new Exception();

            }



        }

        private void tglToothVector_Toggled(object sender, EventArgs e)
        {
            shape.SelectedShape.IsToothVector = true;
            shape.SelectedShape.SetZeroChecCutValue();

            prpGrid.CloseEditor();

        }


        protected override string GetTitle()
        {
            return $"Фигура{CurrentShapeNumber}";
        }
    }
}