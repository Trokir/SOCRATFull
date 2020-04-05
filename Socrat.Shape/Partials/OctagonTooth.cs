using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Socrat.Shape
{
    public partial class Octagon : BaseShape
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
                graphicsShape.DrawLine(pen, E, F);
                graphicsShape.DrawLine(pen, F, G);
                graphicsShape.DrawLine(pen, G, H);
                graphicsShape.DrawLine(pen, H, A);
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
            graphicsShape.DrawString("1",drawFontBold, Brushes.Black, A, sf);
            graphicsShape.DrawString("2",drawFontBold, Brushes.Black, B, sf);
            graphicsShape.DrawString("3",drawFontBold, Brushes.Black, C, sf);
            graphicsShape.DrawString("4",drawFontBold, Brushes.Black, D, sf);
            graphicsShape.DrawString("5",drawFontBold, Brushes.Black, E, sf);
            graphicsShape.DrawString("6",drawFontBold, Brushes.Black, F, sf);
            graphicsShape.DrawString("7",drawFontBold, Brushes.Black, G, sf);
            graphicsShape.DrawString("8",drawFontBold, Brushes.Black, H, sf);
        }
        public override void GetShapeComponents()
        {
            #region BasePath
            
            using (pen1 = new Pen(Color.Red, 2))
            {
                graphicsShape.DrawPath(pen1, MakeRoundCorner(H, A, B, SetA_radius));
                graphicsShape.DrawPath(pen1, MakeRoundCorner(A, B, C, SetB_radius));
                graphicsShape.DrawPath(pen1, MakeRoundCorner(B, C, D, SetC_radius));
                graphicsShape.DrawPath(pen1, MakeRoundCorner(C, D, E, SetD_radius));
                graphicsShape.DrawPath(pen1, MakeRoundCorner(D, E, F, SetE_radius));
                graphicsShape.DrawPath(pen1, MakeRoundCorner(E, F, G, SetF_radius));
                graphicsShape.DrawPath(pen1, MakeRoundCorner(F, G, H, SetG_radius));
                graphicsShape.DrawPath(pen1, MakeRoundCorner(G, H, A, SetH_radius));
                A.PointRadius = SetA_radius;
                B.PointRadius = SetB_radius;
                C.PointRadius = SetC_radius;
                D.PointRadius = SetD_radius;
                E.PointRadius = SetE_radius;
                F.PointRadius = SetF_radius;
                G.PointRadius = SetG_radius;
                H.PointRadius = SetH_radius;
                graphicsShape.DrawLine(pen1, A1, B2);
                graphicsShape.DrawLine(pen1, B1, C1);
                graphicsShape.DrawLine(pen1, C2, D1);
                graphicsShape.DrawLine(pen1, D2, E1);
                graphicsShape.DrawLine(pen1, E2, F1);
                graphicsShape.DrawLine(pen1, F2, G2);
                graphicsShape.DrawLine(pen1, G1, H1);
                graphicsShape.DrawLine(pen1, H2, A2);


                sf.Alignment = StringAlignment.Far;
                sf.LineAlignment = StringAlignment.Far;
                Font drawFontBold = new Font("Arial", 9, FontStyle.Italic);
                graphicsShape.DrawString("A", drawFontBold, Brushes.Green, A);
                graphicsShape.DrawString("B", drawFontBold, Brushes.Green, B, sf);
                graphicsShape.DrawString("C", drawFontBold, Brushes.Green, C, sf);
                graphicsShape.DrawString("D", drawFontBold, Brushes.Green, D, sf);
                graphicsShape.DrawString("  E", drawFontBold, Brushes.Green, E);
                graphicsShape.DrawString("F", drawFontBold, Brushes.Green, F);
                graphicsShape.DrawString("G", drawFontBold, Brushes.Green, G);
                graphicsShape.DrawString("H", drawFontBold, Brushes.Green, H);
                graphicsShape.FillEllipse(Brushes.Black, CrF);
                graphicsShape.FillEllipse(Brushes.Black, BrF);
                graphicsShape.FillEllipse(Brushes.Black, ArF);
                graphicsShape.FillEllipse(Brushes.Black, DrF);
                graphicsShape.FillEllipse(Brushes.Black, ErF);
                graphicsShape.FillEllipse(Brushes.Black, FrF);
                graphicsShape.FillEllipse(Brushes.Black, GrF);
                graphicsShape.FillEllipse(Brushes.Black, HrF);
                Font drawFontBold1 = new Font("Arial", 6, FontStyle.Italic);
                graphicsShape.DrawString("R=" + SetA_radius, drawFontBold1, Brushes.Green, ArF.Location, sf);
                graphicsShape.DrawString("R=" + SetB_radius, drawFontBold1, Brushes.Green, BrF.Location);
                graphicsShape.DrawString("R=" + SetC_radius, drawFontBold1, Brushes.Green, CrF.Location);
                graphicsShape.DrawString("R=" + SetD_radius, drawFontBold1, Brushes.Green, DrF.Location);
                graphicsShape.DrawString("R=" + SetE_radius, drawFontBold1, Brushes.Green, ErF.Location, sf);
                graphicsShape.DrawString("R=" + SetF_radius, drawFontBold1, Brushes.Green, FrF.Location, sf);
                graphicsShape.DrawString("R=" + SetG_radius, drawFontBold1, Brushes.Green, GrF.Location, sf);
                graphicsShape.DrawString("R=" + SetH_radius, drawFontBold1, Brushes.Green, HrF.Location, sf);
              
            }
           

            #endregion
        }
  
        private void MoveUpperTooth()
        {
            // throw new NotImplementedEPointXception();
        }


        /// <summary>
        /// Correct Arcs length
        /// </summary>
        /// <param name="firstPoint"></param>
        /// <param name="secondPoint"></param>
        /// <param name="thirdPoint"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        /// <ePointXception cref="NotImplementedEPointXception"></ePointXception>
        protected override double CorrectingRadiusForShapeAngles(Core.Entities.ShapePoint firstPoint, Core.Entities.ShapePoint secondPoint, Core.Entities.ShapePoint thirdPoint, double radius)
        {
            Line aL = new Line(firstPoint, secondPoint);
            Line bL = new Line(thirdPoint, secondPoint);

            if (aL.Length >= bL.Length && radius > bL.Length / 2)
            {

                if (Math.Round(radius, 0) == Math.Round(SetA_radius, 0)) { radius = bL.Length ; SetA_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetB_radius, 0)) { radius = bL.Length ; SetB_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetC_radius, 0)) { radius = bL.Length ; SetC_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetD_radius, 0)) { radius = bL.Length ; SetD_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetE_radius, 0)) { radius = bL.Length ; SetE_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetF_radius, 0)) { radius = bL.Length ; SetF_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetG_radius, 0)) { radius = bL.Length ; SetG_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetH_radius, 0)) { radius = bL.Length ; SetH_radius = (float)Math.Round(radius, 0); }
            }
            else if (bL.Length >= aL.Length && radius > aL.Length / 2)
            {

                if (Math.Round(radius, 0) == Math.Round(SetA_radius, 0)) { radius = aL.Length ; SetA_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetB_radius, 0)) { radius = aL.Length ; SetB_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetC_radius, 0)) { radius = aL.Length ; SetC_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetD_radius, 0)) { radius = aL.Length ; SetD_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetD_radius, 0)) { radius = aL.Length ; SetE_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetF_radius, 0)) { radius = aL.Length ; SetF_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetG_radius, 0)) { radius = aL.Length ; SetG_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetH_radius, 0)) { radius = aL.Length ; SetH_radius = (float)Math.Round(radius, 0); }
            }
            return radius;
        }
        /// <summary>
        /// AddEntity Advanced Points
        /// </summary>
        /// <param name="secondPoint"></param>
        /// <param name="rectPoint"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <ePointXception cref="NotImplementedEPointXception"></ePointXception>
        protected override void CreatingAdvancedPoints(Core.Entities.ShapePoint secondPoint, RectangleF rectPoint, PointF a, PointF b)
        {
            if (secondPoint == A)
            {//= GetNewPoint();
              
                A1 = b; A2 = a;
                ArF = rectPoint;
            }
            if (secondPoint == B)
            {
               
                B1 = b; B2 = a;
                BrF = rectPoint;
            }
            if (secondPoint == C)
            {
              
                C1 = a; C2 = b;
                CrF = rectPoint;
            }
            if (secondPoint == D)
            {
              
                D1 = a; D2 = b;
                DrF = rectPoint;
            }
            if (secondPoint == E)
            {
              
                E1 = a; E2 = b;
                ErF = rectPoint;
            }
            if (secondPoint == F)
            {
               
                F1 = a; F2 = b;
                FrF = rectPoint;
            }
            if (secondPoint == G)
            {
              
                G2 = a; G1 = b;
                GrF = rectPoint;
            }
            if (secondPoint == H)
            {
               
                H1 = a; H2 = b;
                HrF = rectPoint;
            }
        }

        /// <summary>
        /// Gets the ePointXtremum points.
        /// </summary>
        public override void GetExtremumPoints()
        {
            Core.Entities.ShapePoint APointX = GetNewPoint();
            Core.Entities.ShapePoint BPointX = GetNewPoint();
            Core.Entities.ShapePoint CPointX = GetNewPoint();
            Core.Entities.ShapePoint DPointX = GetNewPoint();
            Core.Entities.ShapePoint EPointX = GetNewPoint();
            Core.Entities.ShapePoint FPointX = GetNewPoint();
            Core.Entities.ShapePoint GPointX = GetNewPoint();
            Core.Entities.ShapePoint HPointX = GetNewPoint();
            APointX = GeTextremumPoint(A, ArF, SetA_radius);
            BPointX = GeTextremumPoint(B, BrF, SetB_radius);
            CPointX = GeTextremumPoint(C, CrF, SetC_radius);
            DPointX = GeTextremumPoint(D, DrF, SetD_radius);
            EPointX = GeTextremumPoint(E, ErF, SetE_radius);
            FPointX = GeTextremumPoint(F, FrF, SetF_radius);
            GPointX = GeTextremumPoint(G, GrF, SetG_radius);
            HPointX = GeTextremumPoint(H, HrF, SetH_radius);
            List<Core.Entities.ShapePoint> pointList = new List<Core.Entities.ShapePoint>() { A1, B1, C1, D1, E1, F1, G1,H1, A2, B2, C2, D2, E2, F2, G2,H2, APointX, BPointX, CPointX, DPointX, EPointX, FPointX, GPointX,HPointX };

            var xMax = pointList.Max(x => x.PointX);
            var yMax = pointList.Max(x => x.PointY);
            var xMin = pointList.Min(x => x.PointX);
            var yMin = pointList.Min(x => x.PointY);
            W_Base = new Core.Entities.ShapePoint(xMin, yMax);
            X_Base = new Core.Entities.ShapePoint(xMin, yMin);
            Y_Base = new Core.Entities.ShapePoint(xMax, yMin);
            Z_Base = new Core.Entities.ShapePoint(xMax, yMax);

        }

      

    }
}