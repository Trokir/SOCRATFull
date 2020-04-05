/* Для фигур 43,44, 20,62*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Socrat.Shape
{

    /// <summary>
    /// Класс треугольник
    /// </summary>
    public partial class Triangle : BaseShape
    {
        protected override void DrawMainLines()
        {
            using (Pen pen = new Pen(Color.Black, 1))
            {
                pen.DashStyle = DashStyle.DashDot;
                graphicsShape.DrawLine(pen, A, B);
                graphicsShape.DrawLine(pen, B, C);
                graphicsShape.DrawLine(pen, C, A);
            }
        }

        protected override void CheckForeignBorders()
        {
            GetShapeComponents();
            GetExtremumPoints();
        }

        public override void GetShapeComponents()
        {
            System.Drawing.Point[] curvePoints = GetFigurePoints();
            #region BasePath
            using (pen1 = new Pen(Color.Red, 2))
            {

                graphicsShape.DrawPath(pen1, MakeRoundCorner(A, B, C, SetB_radius));
                graphicsShape.DrawPath(pen1, MakeRoundCorner(B, C, A, SetC_radius));
                graphicsShape.DrawPath(pen1, MakeRoundCorner(C, A, B, SetA_radius));
                A.PointRadius = SetA_radius;
                B.PointRadius = SetB_radius;
                C.PointRadius = SetC_radius;
                graphicsShape.DrawLine(pen1, A1, B2);
                graphicsShape.DrawLine(pen1, B1, C1);
                graphicsShape.DrawLine(pen1, C2, A2);
                sf.Alignment = StringAlignment.Far;
                sf.LineAlignment = StringAlignment.Far;
                Font drawFontBold = new Font("Arial", 8, FontStyle.Italic);
                graphicsShape.DrawString("A", drawFontBold, Brushes.Green, A, sf);
                graphicsShape.DrawString("B", drawFontBold, Brushes.Green, B, sf);
                graphicsShape.DrawString("C", drawFontBold, Brushes.Green, C, sf);
                graphicsShape.FillEllipse(Brushes.Black, CrF);
                graphicsShape.FillEllipse(Brushes.Black, BrF);
                graphicsShape.FillEllipse(Brushes.Black, ArF);
                graphicsShape.DrawString("R=" + SetC_radius, drawFontBold, Brushes.Green, CrF.Location);
                graphicsShape.DrawString("R=" + SetB_radius, drawFontBold, Brushes.Green, BrF.Location);
                graphicsShape.DrawString("R=" + SetA_radius, drawFontBold, Brushes.Green, ArF.Location);


              
            }
            #endregion
        }
        public override void DrawSideNumbers()
        {
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            graphicsShape.DrawString("1",drawFontBold, Brushes.Black, A, sf);
            graphicsShape.DrawString("2",drawFontBold, Brushes.Black, B, sf);
            graphicsShape.DrawString("3", drawFontBold, Brushes.Black, C, sf);
        }
       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstPoint"></param>
        /// <param name="secondPoint"></param>
        /// <param name="thirdPoint"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        protected override double CorrectingRadiusForShapeAngles(Core.Entities.ShapePoint firstPoint, Core.Entities.ShapePoint secondPoint, Core.Entities.ShapePoint thirdPoint, double radius)
        {
            Line aL = new Line(firstPoint, thirdPoint);
            if (radius >= aL.Length / 2)
            {
                if (Math.Round(radius, 0) == Math.Round(SetA_radius, 0))
                {
                    radius = B_line.Length / 2;
                    SetA_radius = (float)radius;
                }
                else if (Math.Round(radius, 0) == Math.Round(SetB_radius, 0))
                {
                    radius = C_line.Length / 2;
                    SetB_radius = (float)radius;
                }
                else if (Math.Round(radius, 0) == Math.Round(SetC_radius, 0))
                {
                    radius = A_line.Length / 2;
                    SetC_radius = (float)radius;
                }

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
        protected override void CreatingAdvancedPoints(Core.Entities.ShapePoint secondPoint, RectangleF rectPoint, PointF a, PointF b)
        {
            if (secondPoint == A)
            {
                A1 = b;
                A2 = a;
                ArF = rectPoint;

                // TempPoint=  GeTextremumPoint(A, ArF, SetA_radius);
            }
            if (secondPoint == B)
            {
                B1 = b;
                B2 = a;
                BrF = rectPoint;
                // TempPoint = GeTextremumPoint(B, BrF, SetB_radius);
            }
            if (secondPoint == C)
            {
                C1 = a;
                C2 = b;
                CrF = rectPoint;
                //    GeTextremumPoint(C, CrF, SetC_radius);
            }
        }

        /// <summary>
        /// Gets the ePointXtremum points.
        /// </summary>
        /// <returns></returns>
        public override void GetExtremumPoints()
        {
            Core.Entities.ShapePoint APointX = GetNewPoint();
            Core.Entities.ShapePoint BPointX = GetNewPoint();
            Core.Entities.ShapePoint CPointX = GetNewPoint();
            APointX = GeTextremumPoint(A, ArF, SetA_radius);
            BPointX = GeTextremumPoint(B, BrF, SetB_radius);
            CPointX = GeTextremumPoint(C, CrF, SetC_radius);
            List<Core.Entities.ShapePoint> pointList = new List<Core.Entities.ShapePoint>() { A1, B1, C1, A2, B2, C2, APointX, BPointX, CPointX };

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
