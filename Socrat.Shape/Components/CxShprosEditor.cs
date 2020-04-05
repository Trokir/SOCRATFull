using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Socrat.Shape.Factory;
using Socrat.Shape.Rectangles;
using DevExpress.XtraEditors.Controls;
using Socrat.Shape.Shproses;
using Socrat.Shape.Forms;
using Socrat.Core;
using Socrat.Core.Entities;
using DevExpress.XtraEditors;
using System.Linq;

namespace Socrat.Shape
{
    public partial class CxShprosEditor : XtraUserControl, ITabable
    {
        private const string DEFAULT_GUID_VALUE = "3f91882e-ad49-4110-b49a-b74af4213169";
        private Guid? _shapeId;
        public Guid? ShapeId
        {
            get => _shapeId;
            set => _shapeId = value;
        }
        private double? _resultLength;
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
        public double? ResultLength
        {
            get { return _resultLength; }
            set { _resultLength = value; }
        }

        private Guid _ModuleId = Guid.NewGuid();
        public Guid ModuleId
        {
            set => _ModuleId = value;
            get => _ModuleId;
        }

        private bool IsDrawShape = true;

        

        CurrentUserShape shapeForOrder = new CurrentUserShape();
        private FxShprosEditor _fxShapeEditor;
         List<ShapePoint> customPoints;
        RectangleForShow rectangle;
     

        protected ShapePoint A { get; set; }
        protected ShapePoint B { get; set; }
        protected ShapePoint C { get; set; }
        protected ShapePoint D { get; set; }

        public CxShprosEditor()
        {
            
            InitializeComponent();
            btnShprosSettings.Click += BtnSettings_Click;
            Load += CxShprosEditor_Load;
            pkbDrawShpros.Properties.SizeMode = PictureSizeMode.Squeeze;
            pkbDrawShpros.Properties.ContextMenuStrip = new ContextMenuStrip();
            
        }

        public void RefreshPictureEdit()
        {
            shapeForOrder.Selector_Id = ShapeId ?? Guid.Empty;
            shapeForOrder.GetShape.InitShape(pkbDrawShpros);
        }
        private void GetTotalShprosesSizes()
        {
            lblRetainerCounter.Text = shapeForOrder.SelectedShape.RetainerCounter.ToString();
            lblCrossCount.Text = (shapeForOrder.SelectedShape.VerticalShprosCounter * shapeForOrder.SelectedShape.HorisontalShprosCounter).ToString();
            lblHabaritLength.Text =$"{Math.Round((shapeForOrder.SelectedShape.TotalShprosLength) / 1000, 2)} m";
            //TODO: Реализовать расчет 
            lblCheckHabaritLength.Text= $"{Math.Round((shapeForOrder.SelectedShape.TotalShprosLength) / 1000, 2)} m";
            Refresh();
            //lblHabaritLength.Text = ResultLength.ToString();
            //Refresh();
        }
        private void CxShprosEditor_Load(object sender, EventArgs e)
        {
           
            RefreshImage();
        }
        public void RefreshImage()
        {
            if (ShapeId != null)
            {
                shapeForOrder.Selector_Id = ShapeId ?? Guid.Empty;
                shapeForOrder.GetShape.IsShowSizeAttr = true;
                shapeForOrder.IsCanDrawSizeLines = true;
                shapeForOrder.Hvalue = Shape_H;
                shapeForOrder.Lvalue = Shape_L;
                shapeForOrder.GetShape.InitShape(pkbDrawShpros);
            }
           
        }


        private void BtnSettings_Click(object sender, EventArgs e)
        {
            if (ShapeId == null)
            {
                Guid.TryParse(DEFAULT_GUID_VALUE, out Guid val);
                ShapeId = val;
            }
            else if(ShapeId == Guid.Empty)
            {
                Guid.TryParse(DEFAULT_GUID_VALUE, out Guid val);
                ShapeId = val;
            }
           
            _fxShapeEditor = new FxShprosEditor(ShapeId?? Guid.Parse(DEFAULT_GUID_VALUE));
            Shpros<BaseShape>.ShapeTemplate = shapeForOrder.SelectedShape;
            _fxShapeEditor.BShape = Shpros<BaseShape>.GetCurrentShape(Shpros<BaseShape>.ShapeTemplate);
            if (Shape_H != null && Shape_L != null)
            {
                Shpros<BaseShape>.ShapeTemplate.SetH = Shape_H.Value;
                Shpros<BaseShape>.ShapeTemplate.SetL = Shape_L.Value;
            }
            _fxShapeEditor.SaveButtonClick += (s, ea) =>
            {
                _fxShapeEditor.SavePicture(pkbDrawShpros);
            };
            _fxShapeEditor.GetTotalSizeParameters += (s, es) => GetTotalShprosesSizes();
            _fxShapeEditor.DialogOutput += FXShprosEditor_DialogOutput;
            OnDialogOutput(_fxShapeEditor, DialogOutputType.Dialog);
           
        }

        private void FXShprosEditor_DialogOutput(object sender, WindowOutputEventArgs e)
        {
            OnDialogOutput(e.NewTab, e.OutputType);
        }

        private void Draw(bool factor)
        {
            if (factor)
            {
                GetPointsForDefaultRectangle();
                customPoints = new List<ShapePoint>() { A, B, C, D };
                var drawList = new List<dynamic>();
                rectangle = new RectangleForShow(customPoints, drawList);
                shapeForOrder.IsCanDrawSizeLines = true;
                IsDrawShape = true;
            }
        }

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

        public event EventHandler<WindowOutputEventArgs> DialogOutput;

        public void OnDialogOutput(ITabable outForm, DialogOutputType outputType)
        {
            DialogOutput?.Invoke(this, new WindowOutputEventArgs { NewTab = outForm, OutputType = outputType });
        }
        public void OnDialogOutput(WindowOutputEventArgs ta)
        {
            DialogOutput?.Invoke(this, new WindowOutputEventArgs { NewTab = ta.NewTab, OutputType = ta.OutputType });
        }
        public string Title => "Редактор шпросов";
        public bool ReadOnly { get; set; }

        private OrderRow _row;
        public OrderRow Row
        {
            get { return _row; }
            set
            {
                SetRow(value);
            }
        }

        private void SetRow(OrderRow value)
        {
            _row = value;
            if (Row != null)
            {
                Shape_H = Row.OverallH;
                Shape_L = Row.OverallW;
            }
            else
            {
                return;
            }
        }

    }
}
