using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;


using DevExpress.XtraEditors;
using Socrat.Core.Entities;

namespace Socrat.Shape
{
    /// <summary>
    /// Прямоугольник
    /// </summary>
    public partial class Rectangular : BaseShape
    {
        protected override void DrawMainLines()
        {
            using (Pen pen = new Pen(Color.Black, 1))
            {
                pen.DashStyle = DashStyle.DashDot;
                graphicsShape.DrawLine(pen, A, B);
                graphicsShape.DrawLine(pen, B, C);
                graphicsShape.DrawLine(pen, C, D);
                graphicsShape.DrawLine(pen, D, A);
            }
        }

        protected override void CheckForeignBorders()
        {
            GetShapeComponents();
            GetExtremumPoints();
        }
        public override void DrawSideNumbers()
        {
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            graphicsShape.DrawString("1", drawFontBold, Brushes.Black, A, sf);
            graphicsShape.DrawString("2", drawFontBold, Brushes.Black, B, sf);
            graphicsShape.DrawString("3", drawFontBold, Brushes.Black, C, sf);
            graphicsShape.DrawString("4", drawFontBold, Brushes.Black, D, sf);
        }
        protected override PointF[] GetBasePoints()
        {
            return new PointF[] { A, B, C, D };
        }

        public override void GetShapeComponents()
        {
            using (pen1 = new Pen(Color.Red, 3))
            {
                graphicsShape.DrawPath(pen1, MakeRoundCorner(A, B, C, SetB_radius));
                graphicsShape.DrawPath(pen1, MakeRoundCorner(B, C, D, SetC_radius));
                graphicsShape.DrawPath(pen1, MakeRoundCorner(C, D, A, SetD_radius));
                graphicsShape.DrawPath(pen1, MakeRoundCorner(D, A, B, SetA_radius));

                A.PointRadius = SetA_radius;
                B.PointRadius = SetB_radius;
                C.PointRadius = SetC_radius;
                D.PointRadius = SetD_radius;
                graphicsShape.DrawLine(pen1, A1, B2);
                graphicsShape.DrawLine(pen1, B1, C1);
                graphicsShape.DrawLine(pen1, C2, D1);
                graphicsShape.DrawLine(pen1, D2, A2);
                sf.Alignment = StringAlignment.Far;
                sf.LineAlignment = StringAlignment.Far;
                Font drawFontBold = new Font("Arial", 8, FontStyle.Italic);
                graphicsShape.DrawString("A", drawFontBold, Brushes.Green, A, sf);
                graphicsShape.DrawString("B", drawFontBold, Brushes.Green, B, sf);
                graphicsShape.DrawString("C", drawFontBold, Brushes.Green, C, sf);
                graphicsShape.DrawString("D", drawFontBold, Brushes.Green, D);
                graphicsShape.FillEllipse(Brushes.Black, CrF);
                graphicsShape.FillEllipse(Brushes.Black, BrF);
                graphicsShape.FillEllipse(Brushes.Black, ArF);
                graphicsShape.FillEllipse(Brushes.Black, DrF);
                graphicsShape.DrawString("R=" + SetC_radius, drawFontBold, Brushes.Green, CrF.Location);
                graphicsShape.DrawString("R=" + SetB_radius, drawFontBold, Brushes.Green, BrF.Location);
                graphicsShape.DrawString("R=" + SetA_radius, drawFontBold, Brushes.Green, ArF.Location);
                graphicsShape.DrawString("R=" + SetD_radius, drawFontBold, Brushes.Green, DrF.Location, sf);
                if (IsHasFaultLine == true)
                {
                    using (pen2 = new Pen(Color.Black, 2))
                    {
                        graphicsShape.DrawLine(pen2, A_upFault, B_upFault);
                        graphicsShape.DrawLine(pen2, A_downFault, B_downFault);
                    }
                }


            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstPoint"></param>
        /// <param name="secondPoint"></param>
        /// <param name="thirdPoint"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        protected override double CorrectingRadiusForShapeAngles(ShapePoint firstPoint, ShapePoint secondPoint, ShapePoint thirdPoint, double radius)
        {
            Line aL = new Line(firstPoint, secondPoint);
            Line bL = new Line(thirdPoint, secondPoint);

            if (aL.Length >= bL.Length && radius > bL.Length / 2)
            {

                if (Math.Round(radius, 0) == Math.Round(SetA_radius, 0)) { radius = bL.Length / 2; SetA_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetB_radius, 0)) { radius = bL.Length / 2; SetB_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetC_radius, 0)) { radius = bL.Length / 2; SetC_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetD_radius, 0)) { radius = bL.Length / 2; SetD_radius = (float)Math.Round(radius, 0); }

            }
            else if (bL.Length >= aL.Length && radius > aL.Length / 2)
            {

                if (Math.Round(radius, 0) == Math.Round(SetA_radius, 0)) { radius = aL.Length / 2; SetA_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetB_radius, 0)) { radius = aL.Length / 2; SetB_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetC_radius, 0)) { radius = aL.Length / 2; SetC_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetD_radius, 0)) { radius = aL.Length / 2; SetD_radius = (float)Math.Round(radius, 0); }

            }
            return radius;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="secondPoint"></param>
        /// <param name="rectPoint"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        protected override void CreatingAdvancedPoints(ShapePoint secondPoint, RectangleF rectPoint, PointF a, PointF b)
        {
            if (secondPoint == A)
            {

                A1 = b;
                A2 = a;
                ArF = rectPoint;
            }
            if (secondPoint == B)
            {

                B1 = b;
                B2 = a;
                BrF = rectPoint;
            }
            if (secondPoint == C)
            {

                C1 = a;
                C2 = b;
                CrF = rectPoint;
            }

            if (secondPoint == D)
            {

                D1 = a;
                D2 = b;
                DrF = rectPoint;
            }
        }

        /// <summary>
        /// Gets the ePointXtremum points.
        /// </summary>
        /// <returns></returns>
        public override void GetExtremumPoints()
        {
            ShapePoint APointX = GetNewPoint();
            ShapePoint BPointX = GetNewPoint();
            ShapePoint CPointX = GetNewPoint();
            ShapePoint DPointX = GetNewPoint();
            APointX = GeTextremumPoint(A, ArF, SetA_radius);
            BPointX = GeTextremumPoint(B, BrF, SetB_radius);
            CPointX = GeTextremumPoint(C, CrF, SetC_radius);
            DPointX = GeTextremumPoint(D, DrF, SetD_radius);
            List<ShapePoint> pointList = new List<ShapePoint>() { A1, B1, C1, D1, A2, B2, C2, D2, APointX, BPointX, CPointX, DPointX };

            var PointXMax = pointList.Max(PointX => PointX.PointX);
            var yMax = pointList.Max(PointX => PointX.PointY);
            var PointXMin = pointList.Min(PointX => PointX.PointX);
            var yMin = pointList.Min(PointX => PointX.PointY);
            W_Base = new ShapePoint(PointXMin, yMax);
            X_Base = new ShapePoint(PointXMin, yMin);
            Y_Base = new ShapePoint(PointXMax, yMin);
            Z_Base = new ShapePoint(PointXMax, yMax);

        }


    }
}