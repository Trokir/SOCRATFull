using System;
using Socrat.UI.Core;
using System.Drawing;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using Socrat.Shape.Factory;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System.Diagnostics;
using Socrat.Core;
using Socrat.DataProvider.Repos;
using System.Windows.Forms;

namespace Socrat.Shape.Forms
{
    public partial class FxShapeEditor : FxBaseSimpleDialog
    {
        private const string DEFAULT_GUID_VALUE = "3f91882e-ad49-4110-b49a-b74af4213169";
        public Guid? Id_ForOrder { get; set; }
        public double? H_value_ForOrder { get; set; }
        public double? L_value_ForOrder { get; set; }
        public double? Hvalue { get; set; }
        public double? Lvalue { get; set; }
        public bool IsAddAdwansedParams { get; set; }
      //  Graphics graphics;

        // private CurrentShape shape = new CurrentShape();
        private CurrentUserShape shape = new CurrentUserShape();
        private Core.Entities.ShapePoint _customPoint = new Core.Entities.ShapePoint();

        private RepositoryItem[] inplaceEditors;
        //  public FxShapeEditor() { }

        public FxShapeEditor(Guid? id)
        {

            Id_ForOrder = id;

            InitializeComponent();
            Load += FxShapeEditor_Load;

          //  graphics = pkbDraw.CreateGraphics();

            gridCmbShape.Properties.DisplayMember = "CatalogNumber";
            gridCmbShape.Properties.ValueMember = "Id";
            gridCmbShape.Properties.DataSource = shape.GetAllShapesFromCatalog();
            gridCmbShape.Properties.View.BestFitColumns();
            gridCmbShape.Properties.PopupFilterMode = PopupFilterMode.Contains;
            gridCmbShape.Properties.ImmediatePopup = true;
            gridCmbShape.Properties.TextEditStyle = TextEditStyles.Standard;
            prpGrid.OptionsBehavior.PropertySort = DevExpress.XtraVerticalGrid.PropertySort.NoSort;
            prpGrid.CustomPropertyDescriptors += PrpGrid_CustomPropertyDescriptors;
            pkbDraw.Properties.SizeMode = PictureSizeMode.Squeeze;
            prpGrid.CustomDrawRowHeaderCell += PrpGrid_CustomDrawRowHeaderCell;
            prpGrid.FocusedRowChanged += PrpGrid_FocusedRowChanged;
            gridCmbShape.EditValueChanged += GridCmbShape_EditValueChanged;
            gridCmbShape.Properties.ValidateOnEnterKey = true;
            Shown += FxShapeEditor_Shown;

           
            prpGrid.CellValueChanged += (s, e) =>
            {
                if (shape.SelectedShape.ValidValue == true)
                {
                    return;
                }
                else
                {
                  //   graphics.Clear(Color.White);
                    InitShape();
                    shape.SelectedShape.ValidValue = false;
                }
            };
        }
        private void GridCmbShape_EditValueChanged(object sender, EventArgs e)
        {
            if (Flag && val != 1)
            { val = 1; DrawNewShape(Id_ForOrder.Value); }
            else
            {
                Guid number = Guid.NewGuid();
                Guid.TryParse(gridCmbShape.EditValue.ToString(), out number);
                if (number != Guid.Empty)
                {
                    DrawNewShape(number);
                }
                else
                {
                    if (number != Guid.Empty)
                    {
                        gridCmbShape.MaskBox.Clear();
                        DialogResult _dialogResult = XtraMessageBox.Show("Фигура с таким номером в каталоге отсутствует.", " Ошибка",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (_dialogResult == DialogResult.OK) return;
                    }
                    else return;
                }
            }
        }
        bool Flag { get; set; } = false;
        int val { get; set; } = 0;
        private void FxShapeEditor_Shown(object sender, EventArgs e)
        {
            if (Id_ForOrder != Guid.Empty)
            {
                var number = shape.GetCatalogNumberById(Id_ForOrder ?? Guid.Empty).ToString();
                gridCmbShape.MaskBox.AppendText(number);
                Flag = true;
            }
        }
        private void DrawNewShape(Guid number)
        {
           // graphics.Dispose();
            pkbDraw.Refresh();
            shape.Selector_Id = number;
            if (Hvalue != null && Lvalue != null)
            {
                shape.Hvalue = Hvalue;
                shape.Lvalue = Lvalue;
            }
            shape.GetShape.IsAddAdwansedParams = IsAddAdwansedParams;
            shape.SelectedShape.Move();
            // shape.GetShape.InitShape(pkbDraw);
            prpGrid.SelectedObject = null;
            prpGrid.SelectedObject = shape.GetShape;
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
                    //  graphics.Clear(Color.White);
                    shape.SelectedShape.InitShape(pictureBox: pkbDraw);
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
            shape.SelectedShape.Move(1, 1);
            shape.SelectedShape.Move(-1, -1);
            shape.SelectedShape.InitShape(pkbDraw);
            prpGrid.RefreshAllProperties();
            pkbDraw.Refresh();
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
                edit.Properties.SizeMode = PictureSizeMode.Zoom;
                edit.Image.Dispose();
                edit.Image = image;

                //Image image = shape.SelectedShape.CropImage();

                //    edit.Properties.SizeMode = PictureSizeMode.Zoom;
                //    edit.Image.Dispose();
                //    edit.Image = image;
                //    //  image.Dispose();
            }
        }
        private int CurrentShapeNumber { get; set; }
        public Core.Entities.Shape ShapeForOrderRow { get; set; }
        protected override void SaveButtonClicked()
        {

            DialogResult _dialogResult = XtraMessageBox.Show("Данные были изменены. Сохранить?", "Сохранение",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            switch (_dialogResult)
            {
                case DialogResult.Yes:
                    try
                    {
                        using (var shapeRepository = new ShapeRepository())
                        {
                            using (var paramRepository = new ShapeParamRepository())
                            {
                                using (var paramModifiedRepository = new ShapeModifiedParamRepository())
                                {
                                    var shapeSave = new Core.Entities.Shape()
                                    {
                                        SidesCount = shape.Selector,
                                        CatalogNumber = shape.GetCatalogNumber,
                                        IsCatalogShape = false
                                    };
                                    ShapeForOrderRow = shapeSave;
                                    shapeSave.ShapePoints = shape.ShapePoints(shapeSave);
                                    shapeRepository.Save(shapeSave);
                                    var shapeParamSave = new Core.Entities.ShapeParam()
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
                                    CurrentShapeNumber = shapeSave.CatalogNumber;
                                    var shapeModifiedParamSave = new Core.Entities.ShapeModifedParam()
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
                                    Id_ForOrder = shapeSave.Id;
                                    H_value_ForOrder = shapeParamSave.H_param;
                                    L_value_ForOrder = shapeParamSave.L_param;
                                    paramModifiedRepository.Save(shapeModifiedParamSave);
                                    gridCmbShape.Properties.DataSource = shape.GetAllShapesFromCatalog();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        throw new Exception(ex.Message);
                    }
                    break;
            }

        }
        protected override string GetTitle()
        {
            return $"Фигура{CurrentShapeNumber}";
        }
        private void tglToothVector_Toggled(object sender, EventArgs e)
        {
            shape.SelectedShape.IsToothVector = true;
            shape.SelectedShape.SetZeroChecCutValue();
            prpGrid.CloseEditor();
        }
    }
}