using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Socrat.Shape.Factory;
using Socrat.Shape.Rectangles;
using DevExpress.XtraEditors.Controls;
using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.Shape
{
    public partial class CxShapeEdit : DevExpress.XtraEditors.XtraUserControl, ITabable
    {
        FxShapeEditor fxShapeEditor;




        CurrentUserShape shapeForOrder = new CurrentUserShape();
        List<ShapePoint> customPoints;
        RectangleForShow rectangle;

        Graphics graphics;
        protected ShapePoint A { get; set; }
        protected ShapePoint B { get; set; }
        protected ShapePoint C { get; set; }
        protected ShapePoint D { get; set; }

        public double _SetHeight { get; set; }
        public double _SetWidth { get; set; }

        private bool IsDrawShape = true;
        private CurrentUserShape shape = new CurrentUserShape();
        private Core.Entities.Shape _shape = new Core.Entities.Shape();
        private Guid? _shapeId;
        public Guid? ShapeId
        {
            get { return _shapeId; }
            set { _shapeId = value; }

        }
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


        public event EventHandler<WindowOutputEventArgs> DialogOutput;
        public event EventHandler ShapeSelected;


        public CxShapeEdit()
        {
            InitializeComponent();
            Draw(IsDrawShape);
            fxShapeEditor = new FxShapeEditor(ShapeId);
            Load += CxShapeEdit_Load;
            graphics = pkbDraw.CreateGraphics();
            pkbDraw.Properties.SizeMode = PictureSizeMode.Squeeze;
            pkbDraw.Properties.ContextMenuStrip = new ContextMenuStrip();


        }



        private void CxShapeEdit_Load(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            if (ShapeId != null)
            {
                shapeForOrder.Selector_Id = ShapeId ?? Guid.Empty;
                graphics.Clear(Color.White);
                shapeForOrder.GetShape.InitShape(pkbDraw);

            }
            else { rectangle.InitShape(pkbDraw); }

            RefreshImage();
        }

        /// <summary>
        /// Refreshes the image.
        /// </summary>
        public void RefreshImage()
        {
            graphics.Clear(Color.White);
            if (ShapeId != null)
            {
                shapeForOrder.Selector_Id = ShapeId ?? Guid.Empty;
                graphics.Clear(Color.White);
                shapeForOrder.GetShape.InitShape(pkbDraw);

            }
            else { rectangle.InitShape(pkbDraw); }

        }



        private void Draw(bool factor)
        {
            if (factor)
            {
                GetPointsForDefaultRectangle();
                customPoints = new List<ShapePoint>() { A, B, C, D };
                List<dynamic> drawList = new List<dynamic>();
                rectangle = new RectangleForShow(customPoints, drawList);
                IsDrawShape = true;
            }
        }



        private void GetPointsForDefaultRectangle()
        {
            A = new ShapePoint(pkbDraw.Left + 100, pkbDraw.Bottom - 100);
            B = new ShapePoint(pkbDraw.Left + 100, pkbDraw.Top + 100);
            C = new ShapePoint(pkbDraw.Right - 100, pkbDraw.Top + 100);
            D = new ShapePoint(pkbDraw.Right - 100, pkbDraw.Bottom - 100);
            A.PointName = "A";
            B.PointName = "B";
            C.PointName = "C";
            D.PointName = "D";
        }





        public void GetShapeSize(double height, double width)
        {
            if (IsDrawShape == true)
            {
                RefreshImage();
                rectangle.ResizeHeight(height);
                rectangle.ResizeWidth(width);
                rectangle.InitShape(pkbDraw);
                RefreshImage();
            }
        }

        protected Guid? GetCurrentId()
        {
            return fxShapeEditor.Id_ForOrder;
        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {

            fxShapeEditor.SaveButtonClick += (s, ea) =>
            {
                graphics.Clear(Color.White);
                fxShapeEditor.SavePicture(pkbDraw);
                ShapeId = GetCurrentId();
                _shape_H = fxShapeEditor.H_value_ForOrder;
                _shape_L = fxShapeEditor.L_value_ForOrder;
                IsDrawShape = false;
                OnShapeSelected();
            };
            if (ShapeId != Guid.Empty && ShapeId != null)
            {
                fxShapeEditor.Id_ForOrder = ShapeId;
            }
            else
            {
                var tempGuid = Guid.Parse("ceb3ebb9-0de5-4e3c-815b-a01c90ff1d6f");
                fxShapeEditor.Id_ForOrder = tempGuid;
            }
            OnDialogOutput(fxShapeEditor, DialogOutputType.Dialog);
        }

        public void OnDialogOutput(ITabable outForm, DialogOutputType outputType)
        {
            DialogOutput?.Invoke(this, new WindowOutputEventArgs { NewTab = outForm, OutputType = outputType });
        }

        private void OnShapeSelected()
        {
            ShapeSelected?.Invoke(this, EventArgs.Empty);
        }

        public string Title => "";
        public bool ReadOnly { get; set; }
    }
}
