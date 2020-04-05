using System;
using System.Drawing;
using System.Windows.Forms;
using Socrat.Shape.Factory;
using Socrat.Shape.Forms;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.Lib;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Socrat.Shape
{
    public partial class CxShapeEdit : XtraUserControl
    {
        private const string DEFAULT_GUID_VALUE = "3f91882e-ad49-4110-b49a-b74af4213169";
        FxShapeEditor _fxShapeEditor;
        private CurrentUserShape shapeForOrder = new CurrentUserShape();
        //List<ShapePoint> customPoints;
        //RectangleForShow rectangle;

        Graphics graphics;
        protected ShapePoint A { get; set; }
        protected ShapePoint B { get; set; }
        protected ShapePoint C { get; set; }
        protected ShapePoint D { get; set; }

        //public double _SetHeight { get; set; }
        //public double _SetWidth { get; set; }

        //  private bool IsDrawShape = true;

        private Guid? _shapeId;
        public Guid? ShapeId
        {
            get { return _shapeId; }
            set { _shapeId = value; }

        }

        private OrderRow _row;
        private double? _shape_H;
        public double? Shape_H
        {
            get { return _shape_H; }
            set { _shape_H = value; }
        }
        private double? _shape_L;
        public double? Shape_L
        {
            get { return _shape_L; }
            set { _shape_L = value; }
        }


        public event WindowOutputHandler DialogOutput;
        public event EventHandler ShapeChanged;

        public CxShapeEdit()
        {
            InitializeComponent();
            Load += CxShapeEdit_Load;
            pkbDraw.Properties.SizeMode = PictureSizeMode.Zoom;
            pkbDraw.Properties.ContextMenuStrip = new ContextMenuStrip();
        }

        private void CxShapeEdit_Load(object sender, EventArgs e)
        {
            if (Row != null)
                Row.SizeChanged += Row_SizeChanged;
            RefreshImage();

        }

        private void Row_SizeChanged(object sender, EventArgs e)
        {
            if (shapeForOrder.CheckValidValue())
            {
                return;
            }
            else
            {
                RefreshImage();
                shapeForOrder.SelectedShape.ValidValue = false;
            }
        }

        /// <summary>
        /// Refreshes the image.
        /// </summary>
        public void RefreshImage()
        {

            if (ShapeId != null)
            {
                shapeForOrder.Selector_Id = ShapeId ?? Guid.Empty;
                shapeForOrder.GetShape.IsShowSizeAttr = true;
                shapeForOrder.IsCanDrawSizeLines = true;
                shapeForOrder.Hvalue = Row.OverallH;
                shapeForOrder.Lvalue = Row.OverallW;
                shapeForOrder.SelectedShape.ValidValue = false;
                shapeForOrder.IsAddAdwansedParams = Row.Shape.IsAddAdwansedParams;
                shapeForOrder.GetShape.InitShape(pkbDraw);
            }
            else
            {
                var repo = DataProvider.DataHelper.GetRepository<Core.Entities.Shape>();
                shapeForOrder.Selector_Id = repo.GetAll(x => x.CatalogNumber == 0 && x.IsCatalogShape == true).FirstOrDefault().Id;
                ShapeId = shapeForOrder.Selector_Id;
                shapeForOrder.IsDrawPictureToAnotherWindows = true;
                shapeForOrder.IsCanDrawSizeLines = true;
                shapeForOrder.Hvalue = Row.OverallH;
                shapeForOrder.Lvalue = Row.OverallW;
                shapeForOrder.IsAddAdwansedParams = Row.Shape.IsAddAdwansedParams;
                shapeForOrder.GetShape.InitShape(pkbDraw);
            }
        }

        public bool IsValidValue { get; set; }

        private void GetPointsForDefaultRectangle()
        {

            A = new ShapePoint(60, 1130);
            B = new ShapePoint(60, 130);
            C = new ShapePoint(1060, 130);
            D = new ShapePoint(1060, 1130);
            A.PointName = "A";
            B.PointName = "B";
            C.PointName = "C";
            D.PointName = "D";
        }

        //public void GetShapeSize(double height, double width)
        //{
        //    if (IsDrawShape != true) return;
        //    RefreshImage();
        //    rectangle.ResizeHeight(height);
        //    rectangle.ResizeWidth(width);
        //    rectangle.InitShape(pkbDraw);
        //    RefreshImage();
        //}

        protected Guid? GetCurrentId()
        {
            return _fxShapeEditor.Id_ForOrder;
        }
        private void Btn_Settings_Click(object sender, EventArgs e)
        {
            _fxShapeEditor = new FxShapeEditor(ShapeId);
            _fxShapeEditor.IsAddAdwansedParams = Row.Shape.IsAddAdwansedParams;
            shapeForOrder.GetShape.IsAddAdwansedParams = true;

            if (Shape_H != null && Shape_L != null)
            {
                _fxShapeEditor.Hvalue = Row.OverallH;
                _fxShapeEditor.Lvalue = Row.OverallW;
            }

            _fxShapeEditor.SaveButtonClick += (s, ea) =>
            {
                //graphics.Clear(Color.White);
                //_fxShapeEditor.SavePicture(pkbDraw);
                ShapeId = GetCurrentId();

                _shape_H = _fxShapeEditor.H_value_ForOrder;
                _shape_L = _fxShapeEditor.L_value_ForOrder;
                //IsDrawShape = false;
                if (_fxShapeEditor.ShapeForOrderRow != null)
                {
                    Row.Shape = _fxShapeEditor.ShapeForOrderRow;
                    Row.ShapeId = Row.Shape.Id;
                }
                Row.SetSize(Shape_H, Shape_L);
                OnShapeChanged();
                RefreshImage();
            };
            if (ShapeId != Guid.Empty && ShapeId != null)
            {
                _fxShapeEditor.Id_ForOrder = ShapeId;

                _fxShapeEditor.IsAddAdwansedParams = Row.Shape.IsAddAdwansedParams;
            }
            else
            {
                var tempGuid = Guid.Parse(DEFAULT_GUID_VALUE);
                _fxShapeEditor.Id_ForOrder = tempGuid;

                _fxShapeEditor.IsAddAdwansedParams = Row.Shape.IsAddAdwansedParams;
            }

            _fxShapeEditor.IsAddAdwansedParams = true;
            OnDialogOutput(_fxShapeEditor, DialogOutputType.Dialog);

        }

        public void OnDialogOutput(ITabable outForm, DialogOutputType outputType)
        {
            DialogOutput?.Invoke(this, new WindowOutputEventArgs { NewTab = outForm, OutputType = outputType });
        }

        private void OnShapeChanged()
        {
            ShapeChanged?.Invoke(this, EventArgs.Empty);
        }

        public string Title => "";
        public bool ReadOnly { get; set; }

        public OrderRow Row
        {
            get { return _row; }
            set
            {
                SetRow(value);
            }
        }
        public bool IsDrawAdw { get; set; }
        private void SetRow(OrderRow value)
        {
            _row = value;
            if (Row != null)
            {
                Shape_H = Row.OverallH;
                Shape_L = Row.OverallW;
                IsDrawAdw = Row?.Shape?.IsAddAdwansedParams ?? false;
            }
            else
            {
                return;
            }
        }
    }
}
