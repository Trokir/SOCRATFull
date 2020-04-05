using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;


using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Socrat.Shape
{
    /// <summary>
    /// Пятиугольник
    /// </summary>
    public partial class Pentagon : BaseShape
    {
        protected override void DrawMainLines()
        {
            using (Pen pen = new Pen(Color.Black, 1))
            {
                pen.DashStyle = DashStyle.DashDot;
                graphicsShape.DrawLine(pen, A, B);
                graphicsShape.DrawLine(pen, B, C);
                graphicsShape.DrawLine(pen, C, D);
                graphicsShape.DrawLine(pen, D, E);
                graphicsShape.DrawLine(pen, A, E);
            }
        }

        protected override void CheckForeignBorders()
        {
            GetShapeComponents();
            GetExtremumPoints();
        }
        public override void GetShapeComponents()
        {
            #region BasePath
           
            using (pen1 = new Pen(Color.Red, 2))
            {

                graphicsShape.DrawPath(pen1, MakeRoundCorner(A, B, C, SetB_radius));
                graphicsShape.DrawPath(pen1, MakeRoundCorner(B, C, D, SetC_radius));
                graphicsShape.DrawPath(pen1, MakeRoundCorner(C, D, E, SetD_radius));
                graphicsShape.DrawPath(pen1, MakeRoundCorner(D, E, A, SetE_radius));
                graphicsShape.DrawPath(pen1, MakeRoundCorner(E, A, B, SetA_radius));
                A.PointRadius = SetA_radius;
                B.PointRadius = SetB_radius;
                C.PointRadius = SetC_radius;
                D.PointRadius = SetD_radius;
                E.PointRadius = SetE_radius;
                graphicsShape.DrawLine(pen1, A1, B2);
                graphicsShape.DrawLine(pen1, B1, C1);
                graphicsShape.DrawLine(pen1, C2, D1);
                graphicsShape.DrawLine(pen1, D2, E1);
                graphicsShape.DrawLine(pen1, E2, A2);

                sf.Alignment = StringAlignment.Far;
                sf.LineAlignment = StringAlignment.Far;
                Font drawFontBold = new Font("Arial", 8, FontStyle.Italic);
                graphicsShape.DrawString("A", drawFontBold, Brushes.Green, A, sf);
                graphicsShape.DrawString("B", drawFontBold, Brushes.Green, B, sf);
                graphicsShape.DrawString("C", drawFontBold, Brushes.Green, C, sf);
                graphicsShape.DrawString("D", drawFontBold, Brushes.Green, D, sf);
                graphicsShape.DrawString("E", drawFontBold, Brushes.Green, E, sf);
                graphicsShape.FillEllipse(Brushes.Black, CrF);
                graphicsShape.FillEllipse(Brushes.Black, BrF);
                graphicsShape.FillEllipse(Brushes.Black, ArF);
                graphicsShape.FillEllipse(Brushes.Black, DrF);
                graphicsShape.FillEllipse(Brushes.Black, ErF);
                graphicsShape.DrawString("R=" + SetC_radius, drawFontBold, Brushes.Green, CrF.Location);
                graphicsShape.DrawString("R=" + SetB_radius, drawFontBold, Brushes.Green, BrF.Location);
                graphicsShape.DrawString("R=" + SetA_radius, drawFontBold, Brushes.Green, ArF.Location);
                graphicsShape.DrawString("R=" + SetD_radius, drawFontBold, Brushes.Green, DrF.Location);
                graphicsShape.DrawString("R=" + SetE_radius, drawFontBold, Brushes.Green, ErF.Location);
            }
     
            #endregion
        }

        public override void DrawSideNumbers()
        {
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            graphicsShape.DrawString("1",drawFontBold, Brushes.Black, A, sf);
            graphicsShape.DrawString("2",drawFontBold, Brushes.Black, B, sf);
            graphicsShape.DrawString("3",drawFontBold, Brushes.Black, C, sf);
            graphicsShape.DrawString("4",drawFontBold, Brushes.Black, D, sf);
            graphicsShape.DrawString("5", drawFontBold, Brushes.Black, E, sf);   
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
            Line aL = new Line(firstPoint, secondPoint);
            Line bL = new Line(thirdPoint, secondPoint);

            if (aL.Length >= bL.Length && radius > bL.Length / 2)
            {

                if (Math.Round(radius, 0) == Math.Round(SetA_radius, 0)) { radius = bL.Length; SetA_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetB_radius, 0)) { radius = bL.Length; SetB_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetC_radius, 0)) { radius = bL.Length; SetC_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetD_radius, 0)) { radius = bL.Length; SetD_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetE_radius, 0)) { radius = bL.Length; SetE_radius = (float)Math.Round(radius, 0); }
            }
            else if (bL.Length >= aL.Length && radius > aL.Length / 2)
            {

                if (Math.Round(radius, 0) == Math.Round(SetA_radius, 0)) { radius = aL.Length; SetA_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetB_radius, 0)) { radius = aL.Length; SetB_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetC_radius, 0)) { radius = aL.Length; SetC_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetD_radius, 0)) { radius = aL.Length; SetD_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetD_radius, 0)) { radius = aL.Length; SetE_radius = (float)Math.Round(radius, 0); }
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
            { // = GetNewPoint();
               
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
            if (secondPoint == E)
            {
               
                E1 = a;
                E2 = b;
                ErF = rectPoint;
            }
        }


        public override void GetExtremumPoints()
        {
            Core.Entities.ShapePoint APointX = GetNewPoint();
            Core.Entities.ShapePoint BPointX = GetNewPoint();
            Core.Entities.ShapePoint CPointX = GetNewPoint();
            Core.Entities.ShapePoint DPointX = GetNewPoint();
            Core.Entities.ShapePoint EPointX = GetNewPoint();
            APointX = GeTextremumPoint(A, ArF, SetA_radius);
            BPointX = GeTextremumPoint(B, BrF, SetB_radius);
            CPointX = GeTextremumPoint(C, CrF, SetC_radius);
            DPointX = GeTextremumPoint(D, DrF, SetD_radius);
            EPointX = GeTextremumPoint(E, ErF, SetE_radius);
            List<Core.Entities.ShapePoint> pointList = new List<Core.Entities.ShapePoint>() { A1, B1, C1, D1,E1, A2, B2, C2, D2,E2 ,APointX, BPointX, CPointX, DPointX,EPointX };

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
