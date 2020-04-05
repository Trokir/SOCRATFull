using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Socrat.Shape.Rectangles
{
    public  class RectangleForShow:Rectangular
    {
      
        public RectangleForShow(List<Core.Entities.ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList) { }

        protected override PointF[] GetBasePoints()
        {
            return new PointF[] { A, B, C, D };
        }

         protected override void DrawMainLines()
        {
            using (Pen pen = new Pen(Color.Red, SizeLineBoundArgument*2))
            {
                graphicsShape.DrawLine(pen, A, B);
                graphicsShape.DrawLine(pen, B, C);
                graphicsShape.DrawLine(pen, C, D);
                graphicsShape.DrawLine(pen, D, A);
            }
            graphicsShape.FillPolygon(new SolidBrush(Color.FromArgb(30, Color.Blue)), GetBasePoints());
        }

        protected override void CheckForeignBorders()
        {
            GetExtremumPoints();
        }

        public override void GetShapeComponents()
        {
            using (Pen pen = new Pen(Color.Blue, SizeLineBoundArgument))
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                pen.StartCap = LineCap.ArrowAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                pen.DashStyle = DashStyle.Solid;


                Core.Entities.ShapePoint hs = GetNewCustomPoint(C.PointX + 20 * LineBoundArgument, B.PointY);
                Core.Entities.ShapePoint he = GetNewCustomPoint(D.PointX + 20 * LineBoundArgument, A.PointY);
                Line lh = GetNewLine(hs, he);
                Core.Entities.ShapePoint hcenter = GetNewCustomPoint(C.PointX + 20 * LineBoundArgument, A.PointY - lh.Length / 2);
                graphicsShape.DrawLine(pen, hs, he);
                sf.FormatFlags = StringFormatFlags.LineLimit;
                if (lh.Length > 8)
                {
                    graphicsShape.DrawString("H=" + SetH, drawFontBold, Brushes.Black, hcenter, sf);
                }

                Core.Entities.ShapePoint ls = GetNewCustomPoint(A.PointX, A.PointY + 20 * LineBoundArgument);
                Core.Entities.ShapePoint le = GetNewCustomPoint(D.PointX, D.PointY + 20 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                Core.Entities.ShapePoint lcenter = GetNewCustomPoint(A.PointX + (ll.Length / 3), A.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                    graphicsShape.DrawString("L=" + SetL, drawFontBold, Brushes.Black, lcenter, sf);
                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {
                    graphicsShape.DrawLine(pens, hs, C);
                    graphicsShape.DrawLine(pens, he, D);
                    graphicsShape.DrawLine(pens, ls, A);
                    graphicsShape.DrawLine(pens, le, D);
                }
            }
           
        }
     

       



        public override double SetH
        {
            get { return A_line.Length;  }
            set
            {
                SetField(ref _SetH, value, () => SetH);
                if (_SetH < SetH1) { SetH1 = _SetH; }
                if (_SetH <= 0) { _SetH = 1; }
                ResizeHeight(_SetH);
            }
        }

        public override double SetL
        {
            get { return D_line.Length; }
            set
            {
                SetField(ref _SetL, value, () => SetL);
                if (_SetL <= 0) { _SetL = 1; }

                ResizeWidth(_SetL);
            }
        }

        public void ResizeHeight(double factor)
        {
          
            A.PointX = SetCurrentLineLength(B, A,factor).PointX;
            A.PointY= SetCurrentLineLength( B, A, factor).PointY;
            C.PointY = B.PointY;
            D.PointY = A.PointY;
            GetExtremumPoints();
        }

        public void ResizeWidth(double factor)
        {

            Move(0,SetL);
            D.PointX = SetCurrentLineLength(A, D,factor ).PointX;
            D.PointY = SetCurrentLineLength(A, D, factor).PointY;

           // A.PointX = SetCurrentLineLength(TempPoint, A,factor).PointX;
            C.PointX = D.PointX;
            B.PointX = A.PointX;
            GetExtremumPoints();
        }
        public override void GetExtremumPoints()
        {

            List<Core.Entities.ShapePoint> pointList = new List<Core.Entities.ShapePoint>() { A, B, C, D};

            var PointXMax = pointList.Max(PointX => PointX.PointX);
            var yMax = pointList.Max(PointX => PointX.PointY);
            var PointXMin = pointList.Min(PointX => PointX.PointX);
            var yMin = pointList.Min(PointX => PointX.PointY);
            W_Base = new Core.Entities.ShapePoint(PointXMin, yMax);
            X_Base = new Core.Entities.ShapePoint(PointXMin, yMin);
            Y_Base = new Core.Entities.ShapePoint(PointXMax, yMin);
            Z_Base = new Core.Entities.ShapePoint(PointXMax, yMax);

        }

    }

    
}
