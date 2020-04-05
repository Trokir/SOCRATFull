using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using DevExpress.XtraVerticalGrid.Events;
using Socrat.Core.Entities;

namespace Socrat.Shape.Rectangles
{
    sealed class Shape_58 : Rectangular
    {
       private ShapePoint Apogeus { get; set; }
        ShapePoint Perigeus { get; set; }
        ShapePoint ApogeusCheck { get; set; }
        ShapePoint PerigeusCheck { get; set; }
        private ShapePoint ACheck1 { get; set; }
        private ShapePoint ACheck2 { get; set; }
        private ShapePoint BCheck1 { get; set; }
        private ShapePoint BCheck2 { get; set; }
        private ShapePoint CCheck1 { get; set; }
        private ShapePoint CCheck2 { get; set; }
        private ShapePoint DCheck1 { get; set; }
        private ShapePoint DCheck2 { get; set; }
        private List<Point> pointsL { get; set; }
        private double PointX_average;
        private double Y_average;
        public Shape_58(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {
            Apogeus = GetNewPoint();
            Perigeus = GetNewPoint();
            ApogeusCheck = GetNewPoint();
            PerigeusCheck = GetNewPoint();
            ACheck1 = GetNewPoint();
            ACheck2 = GetNewPoint();
            BCheck1 = GetNewPoint();
            BCheck2 = GetNewPoint();
            CCheck1 = GetNewPoint();
            CCheck2 = GetNewPoint();
            DCheck1 = GetNewPoint();
            DCheck2 = GetNewPoint();
            SetRadius = (SetRadius == 0) ? 111 : SetRadius;
            pointsL = new List<Point>();
            var yDiff = (SetH > SetH1) ? B.PointY - 150 : C.PointY - 150;
            Move(y: -yDiff);
          
        }
        protected override void DrawMainLines()
        {
            var curvePoints = GetFigurePoints();
            if (IsToothVector == true)
            {
                using (pen1 = new Pen(Color.Red, ThiсknessArgument / 2))
                {
                    graphicsShape.DrawPath(pen1, MakeRoundCorner(A, B, C, SetB_radius));
                    graphicsShape.DrawPath(pen1, MakeRoundCorner(B, C, D, SetC_radius));
                    graphicsShape.DrawPath(pen1, MakeRoundCorner(C, D, A, SetD_radius));
                    graphicsShape.DrawPath(pen1, MakeRoundCorner(D, A, B, SetA_radius));
                    A.PointRadius = SetA_radius;
                    B.PointRadius = SetB_radius;
                    C.PointRadius = SetC_radius;
                    D.PointRadius = SetD_radius;
                }
                using (pen1 = new Pen(SelectMainLineColor1(), ThiсknessArgument / 2))
                {
                    pen1.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen1, A1, B);
                }
                using (pen2 = new Pen(SelectMainLineColor2(), ThiсknessArgument / 2))
                {
                    pen2.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawCurve(pen2, curvePoints, 0F);
                }
                using (pen3 = new Pen(SelectMainLineColor3(), ThiсknessArgument / 2))
                {
                    pen3.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen3, C, D1);
                }
                using (pen4 = new Pen(SelectMainLineColor4(), ThiсknessArgument / 2))
                {
                    pen4.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen4, D2, A2);
                }
                
              
                IsToothVector = true;
            }
            else
            {
             
                using (pen1 = new Pen(Color.Red, ThiсknessArgument ))
                {
                    graphicsShape.DrawPath(pen1, MakeRoundCorner(A, B, C, SetB_radius));
                    graphicsShape.DrawPath(pen1, MakeRoundCorner(B, C, D, SetC_radius));
                    graphicsShape.DrawPath(pen1, MakeRoundCorner(C, D, A, SetD_radius));
                    graphicsShape.DrawPath(pen1, MakeRoundCorner(D, A, B, SetA_radius));
                    A.PointRadius = SetA_radius;
                    B.PointRadius = SetB_radius;
                    C.PointRadius = SetC_radius;
                    D.PointRadius = SetD_radius;
                }
                using (pen1 = new Pen(SelectMainLineColor1(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen1, A1, B);
                }
                using (pen2 = new Pen(SelectMainLineColor2(), ThiсknessArgument))
                {
                    graphicsShape.DrawCurve(pen2, curvePoints, 0F);
                }
                using (pen3 = new Pen(SelectMainLineColor3(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen3, C, D1);
                }
                using (pen4 = new Pen(SelectMainLineColor4(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen4, D2, A2);
                }

                IsToothVector = false;
            }
            using (GraphicsPath myPath = new GraphicsPath())
            {
                myPath.AddLine(A1, B);
                myPath.AddPath(MakeRoundCorner(A, B, C, SetB_radius), true);
                myPath.AddCurve(curvePoints);
                myPath.AddPath(MakeRoundCorner(B, C, D, SetC_radius), true);
                myPath.AddLine(C, D1);
                myPath.AddPath(MakeRoundCorner(C, D, A, SetD_radius), true);
                myPath.AddLine(D2, A2);
                myPath.AddPath(MakeRoundCorner(D, A, B, SetA_radius), true);
                graphicsShape.FillPath(new SolidBrush(Color.FromArgb(30, Color.Blue)), myPath);
            }
            MoveLines();
        }
        protected override void CheckForeignBorders()
        {
            DrawMainLines();
            GetExtremumPoints();
        }

        private void MoveLines()
        {
            using (Pen pen = new Pen(Color.Black, SizeLineBoundArgument))
            {
               
                AllowanceProcessing();
                MoveBorderLeft(W_Base, X_Base, SetB1);
                MoveBorderTop(X_Base, Y_Base, SetB3);
                MoveBorderRight(Y_Base, Z_Base, SetB1);
                MoveBorderBottom(W_Base, Z_Base, SetB2);
            }
        }

        public override void GetShapeComponents()
        {
            #region BasePath
            using (Pen pen = new Pen(Color.Black, SizeLineBoundArgument))
            {
                pen.DashStyle = DashStyle.DashDot;
                graphicsShape.DrawLine(pen, W_Base, X_Base);
                graphicsShape.DrawLine(pen, X_Base, Y_Base);
                graphicsShape.DrawLine(pen, Y_Base, Z_Base);
                graphicsShape.DrawLine(pen, Z_Base, W_Base);
            }
            using (Pen pen = new Pen(Color.Blue, SizeLineBoundArgument))
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                pen.StartCap = LineCap.ArrowAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                pen.DashStyle = DashStyle.Solid;

                ShapePoint ls = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 20 * LineBoundArgument);
                ShapePoint le = GetNewCustomPoint(SetPointCurrentValueX(D), W_Base.PointY + 20 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                ShapePoint lcenter = GetNewCustomPoint(W_Base.PointX + (ll.Length / 2), W_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                    graphicsShape.DrawString("L=" + SetCurrentSize(SetL), drawFontBold, Brushes.Black, lcenter, sf);


                ShapePoint b12s11 = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 20 * LineBoundArgument);
                ShapePoint b12e11 = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b12s11, b12e11);
                Line b221h = GetNewLine(b12s11, b12e11);
                ShapePoint b221scenter = GetNewCustomPoint(W_Base.PointX + b221h.Length / 2, W_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b221scenter, sf);


                ShapePoint b1s1 = GetNewCustomPoint(SetPointCurrentValueX(D), Z_Base.PointY + 20 * LineBoundArgument);
                ShapePoint b1e1 = GetNewCustomPoint(Z_Base.PointX, Z_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s1, b1e1);
                Line b11h = GetNewLine(b1s1, b1e1);
                ShapePoint b11scenter = GetNewCustomPoint(Z_Base.PointX - b11h.Length / 2, Z_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b11scenter, sf);


                ShapePoint bsh = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(D));
                ShapePoint beh = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(C));
                Line blh = GetNewLine(bsh, beh);
                ShapePoint bhcenter = GetNewCustomPoint(Z_Base.PointX + 12 * LineBoundArgument, Z_Base.PointY - (blh.Length / 2));
                graphicsShape.DrawLine(pen, bsh, beh);
                graphicsShape.DrawString("H1=" + SetCurrentSize(SetH1), drawFontBold, Brushes.Black, bhcenter, sf);


                ShapePoint bsh1 = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, SetPointCurrentValueY(B));
                ShapePoint beh1 = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, SetPointCurrentValueY(A));
                Line blh1 = GetNewLine(bsh1, beh1);
                ShapePoint b1hcenter = GetNewCustomPoint(Z_Base.PointX +30 * LineBoundArgument, W_Base.PointY - (blh1.Length / 2));
                graphicsShape.DrawLine(pen, bsh1, beh1);
                graphicsShape.DrawString("H=" + SetCurrentSize(SetH), drawFontBold, Brushes.Black, b1hcenter, sf);


                ShapePoint b12s1 = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, SetPointCurrentValueY(A));
                ShapePoint b12e1 = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, W_Base.PointY);
                graphicsShape.DrawLine(pen, b12s1, b12e1);
                Line b22h = GetNewLine(b12s1, b12e1);
                ShapePoint b22scenter = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, W_Base.PointY - b22h.Length / 2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b22scenter, sf);


                using (Pen penr = new Pen(Color.Blue, ThiсknessArgument/2))
                {
                    Line l = GetNewLine(SetPointCurrentType(A), SetPointCurrentType(D));
                    penr.StartCap = LineCap.RoundAnchor;
                    penr.EndCap = LineCap.ArrowAnchor;
                    penr.DashStyle = DashStyle.Solid;
                    ShapePoint rs = GetNewCustomPoint(X_Base.PointX + l.Length / 4, X_Base.PointY - 40 * LineBoundArgument);
                    ShapePoint re = GetNewCustomPoint(PointX_average, Y_average+30 );
                    Line lr = GetNewLine(rs, re);
                    ShapePoint brcenter = GetNewCustomPoint((rs.PointX + re.PointX) / 2, (rs.PointY + re.PointY) / 2);
                    graphicsShape.DrawLine(penr, rs, re);
                    graphicsShape.DrawString("R=" + SetCurrentSize(SetRadius), drawFontBold, Brushes.Black, brcenter, sf);

                }

                ShapePoint b3s = GetNewCustomPoint(Z_Base.PointX +30 * LineBoundArgument, X_Base.PointY);
                ShapePoint b3e = GetNewCustomPoint(Z_Base.PointX +30 * LineBoundArgument, X_Base.PointY + SetB3);
                Line lb3 = GetNewLine(b3s, b3e);
                ShapePoint b3center = GetNewCustomPoint(Z_Base.PointX +30 * LineBoundArgument, X_Base.PointY + lb3.Length / 2);
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                graphicsShape.DrawLine(pen, b3s, b3e);
                graphicsShape.DrawString("B3=" + SetB3, drawFontBold, Brushes.Black, b3center, sf);

                graphicsShape.DrawString("R1=" + SetA_radius, drawFontBold, Brushes.Green, ArF.Location, sf);
                graphicsShape.DrawString("R2=" + SetD_radius, drawFontBold, Brushes.Green, DrF.Location, sf);

                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX) / 4), ((A.PointY + B.PointY + C.PointY + D.PointY) / 4));
                Font drawNumbertBold = new Font("Tahoma", 40+ThiknessFontArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("58", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }
                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {

                    var wer = GetNewCustomPoint(SetPointCurrentValueX(B), Y_Base.PointY);
                    var wer1 = GetNewCustomPoint(SetPointCurrentValueX(C), Y_Base.PointY);
                    var wer2 = GetNewCustomPoint(SetPointCurrentValueX(C), Y_Base.PointY+SetB3);
                    using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        graphicsShape.DrawLine(pen1, wer, SetPointCurrentType(B));
                        graphicsShape.DrawLine(pen1, wer1, SetPointCurrentType(C));
                    }
                    graphicsShape.DrawLine(pens, le, SetPointCurrentType(D));
                    graphicsShape.DrawLine(pens, ls, SetPointCurrentType(A));
                    graphicsShape.DrawLine(pens, b12e11, W_Base);
                    graphicsShape.DrawLine(pens, b1e1, Z_Base);
                    graphicsShape.DrawLine(pens, b3s, Y_Base);
                    graphicsShape.DrawLine(pens, b3e, wer2);
                    graphicsShape.DrawLine(pens, b12e1, Z_Base);
                    graphicsShape.DrawLine(pens, b12s1, SetPointCurrentType(D));
                    using (var pens1 = new Pen(Color.Red, SizeLineBoundArgument / 2))
                    {
                        graphicsShape.DrawLine(pens1, bsh1, SetPointCurrentType(B));
                    }
                }
            }
            #endregion
        }
        public override RectangleF GetShapeBorders()
        {
            using (GraphicsPath myPath = new GraphicsPath())
            {
                myPath.AddLine(A1, B);
                myPath.AddPath(MakeRoundCorner(A, B, C, SetB_radius), true);
                myPath.AddCurve(GetFigurePoints());
                myPath.AddPath(MakeRoundCorner(B, C, D, SetC_radius), true);
                myPath.AddLine(C, D1);
                myPath.AddPath(MakeRoundCorner(C, D, A, SetD_radius), true);
                myPath.AddLine(D2, A2);
                myPath.AddPath(MakeRoundCorner(D, A, B, SetA_radius), true);
                Region myRegion = new Region(myPath);
                RectangleF boundsRect = myRegion.GetBounds(graphicsShape);
                graphicsShape.DrawRectangle(Pens.Blue, new Rectangle((int)boundsRect.X,
              (int)boundsRect.Y, (int)boundsRect.Width, (int)boundsRect.Height));
                // graphicsShape.SetClip(myRegion, CombineMode.Replace);
                return boundsRect;
            }
        }
       
        public override void SelectClickedSide(int xCoord, int yCoord, bool flag)
        {
            Point point = new Point(xCoord, yCoord);
            if (ThicknessPath(A1, B).IsVisible(point))
            {
                if (flag) { ColorMarker1 = "rowCheckCut1"; SelectedSides.SetValue(1, 0); SelectedSidesLength += GetNewLine(A1, B).Length; }
                else { ColorMarker1 = ""; SelectedSides.SetValue(0, 0); SelectedSidesLength -= GetNewLine(A1, B).Length; }
            }
            if (CurvePath(GetFigurePoints()).IsVisible(point))
            {
                if (flag) { ColorMarker2 = "rowCheckCut2"; SelectedSides.SetValue(2, 1); SelectedSidesLength += arcLength; }
                else { ColorMarker2 = ""; SelectedSides.SetValue(0, 1); SelectedSidesLength -= arcLength; }
            }
            if (ThicknessPath(C, D1).IsVisible(point))
            {
                if (flag) { ColorMarker3 = "rowCheckCut3"; SelectedSides.SetValue(3, 2); SelectedSidesLength += GetNewLine(C, D1).Length; }
                else { ColorMarker3 = ""; SelectedSides.SetValue(0, 2); SelectedSidesLength -= GetNewLine(C, D1).Length; }
            }
            if (ThicknessPath(D2, A2).IsVisible(point))
            {
                if (flag) { ColorMarker4 = "rowCheckCut4"; SelectedSides.SetValue(4, 3); SelectedSidesLength += GetNewLine(D2, A2).Length; }
                else { ColorMarker4 = ""; SelectedSides.SetValue(0, 3); SelectedSidesLength -= GetNewLine(D2, A2).Length; }
            }
            else return;
        }
        protected override GraphicsPath GetShapeShprosBorders()
        {
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddLine(A1, B);
            myPath.AddPath(MakeRoundCorner(A, B, C, SetB_radius), true);
            myPath.AddCurve(GetFigurePoints());
            myPath.AddPath(MakeRoundCorner(B, C, D, SetC_radius), true);
            myPath.AddLine(C, D1);
            myPath.AddPath(MakeRoundCorner(C, D, A, SetD_radius), true);
            myPath.AddLine(D2, A2);
            myPath.AddPath(MakeRoundCorner(D, A, B, SetA_radius), true);
            return myPath;
        }
        /// <summary>
        /// Расчет периметра прямоугольника
        /// </summary>
        public override double Perimeter
        {
            get
            {
                Line l = GetNewLine(B, C);
                TempPoint.PointX = SetCurrentLineLength(B, C, l.Length / 2).PointX;
                TempPoint.PointY = SetCurrentLineLength(B, C, l.Length / 2).PointY;
                CenterPoint.PointX = (B.PointX - TempPoint.PointX) * Math.Cos(-1.5708) - (B.PointY - TempPoint.PointY) * Math.Sin(-1.5708) + TempPoint.PointX;
                CenterPoint.PointY = (B.PointX - TempPoint.PointX) * Math.Sin(-1.5708) + (B.PointY - TempPoint.PointY) * Math.Cos(-1.5708) + TempPoint.PointY;
                Line curLine = GetNewLine(TempPoint, CenterPoint); ;
                CenterPoint.PointX = SetCurrentLineLength(TempPoint, CenterPoint, curLine.Length - SetRadius).PointX;
                CenterPoint.PointY = SetCurrentLineLength(TempPoint, CenterPoint, curLine.Length - SetRadius).PointY;
                double angleBetween = CalculateAngle(B, CenterPoint, C);
                double radiuss = l.Length / 2 - SetRadius;
                 arcLength = (Math.PI * radiuss * angleBetween) / 180;
                double lowerLeftArc = SetA_radius * Math.PI * (CalculateAngle(D, A, B) <= 90 ? CalculateAngle(D, A, B) : 180 - CalculateAngle(D, A, B)) / 180;
                double lowerRighttArc = SetD_radius * Math.PI * (CalculateAngle(C, D, A) <= 90 ? CalculateAngle(C, D, A) : 180 - CalculateAngle(C, D, A)) / 180;
                Line a = GetNewLine(A1, B2);

                Line c = GetNewLine(C2, D1);
                Line d = GetNewLine(D2, A2);
                return Math.Round((lowerLeftArc + lowerRighttArc + a.Length + c.Length + d.Length + arcLength)/ 1000, 3) ;

            }

        }
        private double arcLength { get; set; }
        public override double Perimeter_t
        {
            get
            {
                Line l = GetNewLine(BCheck, CCheck);
                TempPoint.PointX = SetCurrentLineLength(BCheck, CCheck, l.Length / 2).PointX;
                TempPoint.PointY = SetCurrentLineLength(BCheck, CCheck, l.Length / 2).PointY;
                CenterPoint.PointX = (BCheck.PointX - TempPoint.PointX) * Math.Cos(-1.5708) - (BCheck.PointY - TempPoint.PointY) * Math.Sin(-1.5708) + TempPoint.PointX;
                CenterPoint.PointY = (BCheck.PointX - TempPoint.PointX) * Math.Sin(-1.5708) + (BCheck.PointY - TempPoint.PointY) * Math.Cos(-1.5708) + TempPoint.PointY;
                Line curLine = GetNewLine(TempPoint, CenterPoint);
                CenterPoint.PointX = SetCurrentLineLength(TempPoint, CenterPoint, curLine.Length - SetRadius).PointX;
                CenterPoint.PointY = SetCurrentLineLength(TempPoint, CenterPoint, curLine.Length - SetRadius).PointY;
                double angleBetween = CalculateAngle(BCheck, CenterPoint, CCheck);
                double radiuss = l.Length / 2 - SetRadius_t;
                double arcLength = (Math.PI * radiuss * angleBetween) / 180;
                double lowerLeftArc = (SetA_radius+CheckCut1) * Math.PI * (CalculateAngle(DCheck, ACheck, BCheck) <= 90 ? CalculateAngle(DCheck, ACheck, BCheck) : 180 - CalculateAngle(DCheck, ACheck, BCheck)) / 180;
                double lowerRighttArc = (SetD_radius + CheckCut1) * Math.PI * (CalculateAngle(CCheck, DCheck, ACheck) <= 90 ? CalculateAngle(CCheck, DCheck, ACheck) : 180 - CalculateAngle(CCheck, DCheck, ACheck)) / 180;
                Line a = GetNewLine(ACheck1, BCheck2);
                Line c = GetNewLine(CCheck2, DCheck1);
                Line d = GetNewLine(DCheck2, ACheck2);
                return Math.Round((lowerLeftArc + lowerRighttArc + a.Length + c.Length + d.Length + arcLength)/ 1000,3) ;
            }
        }
        /// <summary>
        /// Расчет площади прямоугольника
        /// </summary>
        public override double Area
        {
            get
            {
                Line lla = GetNewLine(A2, A);
                Line llb = GetNewLine(A1, A);
                Line llc = GetNewLine(A1, A2);
                double AAnglle = (CalculateAngle(D, A, B) <= 90 ? CalculateAngle(D, A, B) : 180 - CalculateAngle(D, A, B)) / 180;
                double llTriangle = Math.Round(Math.Sqrt(((lla.Length + llb.Length + llc.Length) / 2) *
                   (((lla.Length + llb.Length + llc.Length) / 2) - lla.Length) *
                   (((lla.Length + llb.Length + llc.Length) / 2) - llb.Length) *
                   (((lla.Length + llb.Length + llc.Length) / 2) - llc.Length)), 2) -
                  (Math.Pow(SetA_radius, 2) / 2) * (Math.PI * AAnglle * Math.PI / 180 - Math.Sin(AAnglle * Math.PI / 180));

                Line lra = GetNewLine(D2, D);
                Line lrb = GetNewLine(D1, D);
                Line lrc = GetNewLine(D1, D2);
                double DAngle = (CalculateAngle(C, D, A) <= 90 ? CalculateAngle(C, D, A) : 180 - CalculateAngle(C, D, A)) / 180;
                double lrTriangle = Math.Round(Math.Sqrt(((lra.Length + lrb.Length + lrc.Length) / 2) *
                   (((lra.Length + lrb.Length + lrc.Length) / 2) - lra.Length) *
                   (((lra.Length + lrb.Length + lrc.Length) / 2) - lrb.Length) *
                   (((lra.Length + lrb.Length + lrc.Length) / 2) - lrc.Length)), 2) -
                 (Math.Pow(SetD_radius, 2) / 2) * (Math.PI * DAngle * Math.PI / 180 - Math.Sin(DAngle * Math.PI / 180));
                double baseSquare = 0.5 * Math.Abs((A.PointX * B.PointY + B.PointX * C.PointY + C.PointX * D.PointY + D.PointX * A.PointY) - (B.PointX * A.PointY + C.PointX * B.PointY + D.PointX * C.PointY + A.PointX * D.PointY));
                double temtSq = Math.Ceiling(baseSquare - Math.Abs(llTriangle) - Math.Abs(lrTriangle));

                Line l = GetNewLine(B, C);
                TempPoint.PointX = SetCurrentLineLength(B, C, l.Length / 2).PointX;
                TempPoint.PointY = SetCurrentLineLength(B, C, l.Length / 2).PointY;
                double alpha = 2 * Math.Atan((2 * SetRadius) / l.Length);
                double payLength = l.Length * (alpha / Math.Sin(alpha));
                double radius = payLength / alpha / 2;
                double angleBetween = CalculateAngle(B, CenterPoint, C);
                double fullSquare = Math.PI * Math.Pow(radius, 2);
                double square;
                square = (0.5 * Math.Pow(radius, 2)) * (angleBetween * Math.PI / 180 - Math.Sin(angleBetween * Math.PI / 180));
                if (Double.IsNaN(square)) { square = 0; }

                return Math.Round((temtSq - square)/ 1000000, 3) ;
            }
        }
        public override double TrueArea
        {
            get
            {
                Line lla = GetNewLine(ACheck2, ACheck);
                Line llb = GetNewLine(ACheck1, ACheck);
                Line llc = GetNewLine(ACheck1, ACheck2);
                double AAnglle = (CalculateAngle(DCheck, ACheck, BCheck) <= 90 ? CalculateAngle(DCheck, ACheck, BCheck) : 180 -
                    CalculateAngle(DCheck, ACheck, BCheck)) / 180;
                double llTriangle = Math.Round(Math.Sqrt(((lla.Length + llb.Length + llc.Length) / 2) *
                   (((lla.Length + llb.Length + llc.Length) / 2) - lla.Length) *
                   (((lla.Length + llb.Length + llc.Length) / 2) - llb.Length) *
                   (((lla.Length + llb.Length + llc.Length) / 2) - llc.Length)), 2) -
                  (Math.Pow(SetA_radius, 2) / 2) * (Math.PI * AAnglle * Math.PI / 180 - Math.Sin(AAnglle * Math.PI / 180));

                Line lra = GetNewLine(DCheck2, DCheck);
                Line lrb = GetNewLine(DCheck1, DCheck);
                Line lrc = GetNewLine(DCheck1, DCheck2);
                double DAngle = (CalculateAngle(CCheck, DCheck, ACheck) <= 90 ? CalculateAngle(CCheck, DCheck, ACheck) : 180 -
                    CalculateAngle(CCheck, DCheck, ACheck)) / 180;
                double lrTriangle = Math.Round(Math.Sqrt(((lra.Length + lrb.Length + lrc.Length) / 2) *
                   (((lra.Length + lrb.Length + lrc.Length) / 2) - lra.Length) *
                   (((lra.Length + lrb.Length + lrc.Length) / 2) - lrb.Length) *
                   (((lra.Length + lrb.Length + lrc.Length) / 2) - lrc.Length)), 2) -
                 (Math.Pow(SetD_radius, 2) / 2) * (Math.PI * DAngle * Math.PI / 180 - Math.Sin(DAngle * Math.PI / 180));
                double baseSquare = 0.5 * Math.Abs((ACheck.PointX * BCheck.PointY + BCheck.PointX * CCheck.PointY + CCheck.PointX * DCheck.PointY + DCheck.PointX * ACheck.PointY) - 
                    (BCheck.PointX * ACheck.PointY + CCheck.PointX * BCheck.PointY + DCheck.PointX * CCheck.PointY + ACheck.PointX * DCheck.PointY));
                double temtSq = Math.Ceiling(baseSquare - Math.Abs(llTriangle) - Math.Abs(lrTriangle));

                Line l = GetNewLine(BCheck, CCheck);
                TempPoint.PointX = SetCurrentLineLength(BCheck, CCheck, l.Length / 2).PointX;
                TempPoint.PointY = SetCurrentLineLength(BCheck, CCheck, l.Length / 2).PointY;
                double alpha = 2 * Math.Atan((2 * SetRadius_t) / l.Length);
                double payLength = l.Length * (alpha / Math.Sin(alpha));
                double radius = payLength / alpha / 2;
                double angleBetween = CalculateAngle(BCheck, CenterPoint, CCheck);
                double fullSquare = Math.PI * Math.Pow(radius, 2);
                double square;
                square = (0.5 * Math.Pow(radius, 2)) * (angleBetween * Math.PI / 180 - Math.Sin(angleBetween * Math.PI / 180));
                if (Double.IsNaN(square)) { square = 0; }
                return Math.Round((temtSq - square)/ 1000000, 3) ;
            }
        }
        protected override double CorrectingRadiusForShapeAngles(ShapePoint firstPoint, ShapePoint secondPoint, ShapePoint thirdPoint, double radius)
        {
            Line aL = new Line(firstPoint, secondPoint);
            Line bL = new Line(thirdPoint, secondPoint);

            if (aL.Length >= bL.Length && radius > bL.Length / 2)
            {

                if (Math.Round(radius, 0) == Math.Round(SetA_radius, 0)) { radius = bL.Length / 2; SetA_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetB_radius, 0)) { radius = bL.Length / 2; SetB_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetC_radius, 0)) { radius = bL.Length / 2; SetC_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetD_radius, 0)) { radius = bL.Length; SetD_radius = (float)Math.Round(radius, 0); }

            }
            else if (bL.Length >= aL.Length && radius > aL.Length / 2)
            {

                if (Math.Round(radius, 0) == Math.Round(SetA_radius, 0)) { radius = aL.Length / 2; SetA_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetB_radius, 0)) { radius = aL.Length / 2; SetB_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetC_radius, 0)) { radius = aL.Length / 2; SetC_radius = (float)Math.Round(radius, 0); }
                if (Math.Round(radius, 0) == Math.Round(SetD_radius, 0)) { radius = aL.Length; SetD_radius = (float)Math.Round(radius, 0); }

            }
            return radius;
        }
        public override double SetH { get => Math.Round(A_line.Length, 0); set => base.SetH = value; }
        public override double SetL { get => Math.Round(D_line.Length, 0); set => base.SetL = value; }
        public override double SetH1 { get => Math.Round(C_line.Length, 0); set => base.SetH1 = value; }
        public override double SetRadius1 { get => SetA_radius; set => base.SetRadius1 = value; }
        public override double SetRadius2 { get => SetD_radius; set => base.SetRadius2 = value; }
        public override double SetH_t => Math.Round(A_Check_Line.Length, 0);
        public override double SetL_t => Math.Round(D_Check_Line.Length, 0);
        public override double SetH1_t => Math.Round(C_Check_Line.Length, 0);
        public override double SetRadius_t => SetRadius + CheckCut1;
        public override double SetRadius1_t => SetRadius1 + CheckCut1;
        public override double SetRadius2_t => SetRadius2 + CheckCut1;
        protected override void SetHValue()
        {
            base.SetHValue();
            var re = B.PointY;
        //  B.PointX = SetCurrentLineLength(A, B, _SetH).PointX;
            B.PointY = SetCurrentLineLength(A, B, _SetH).PointY;
            if (SetH>SetH1)
            {
                var diff = re - B.PointY;
               Move(y:diff);
            }
            ValidValue = false;
        }
        protected override void SetH1Value()
        {
            base.SetH1Value();
            //var p = GetNewPoint();
            // p.PointX= SetCurrentLineLength(C, D, _SetH1).PointX;
            //p.PointY = SetCurrentLineLength(C, D, _SetH1).PointY;
            //var diff = p.PointY - D.PointY;
            //B.PointY += diff;
            //D.PointX = p.PointX;
            //D.PointY = p.PointY;
            //A.PointY = D.PointY;
           
            var re = C.PointY;
            C.PointX = SetCurrentLineLength(D, C, _SetH1).PointX;
            C.PointY = SetCurrentLineLength(D, C, _SetH1).PointY;
            if (SetH1 > SetH)
            {
                var diffs = re - C.PointY;
                Move(y: diffs);
            }
            ValidValue = false;
        }
        protected override void SetLValue()
        {
            base.SetLValue();
            D.PointX = SetCurrentLineLength(A, D, _SetL).PointX;
            D.PointY = SetCurrentLineLength(A, D, _SetL).PointY;
            B.PointX = A.PointX;
            C.PointX = D.PointX;

            ValidValue = false;
        }
        protected override void SetRadiusValue()
        {
            ValidValue = false;
        }
        protected override void SetRadius1Value()
        {
            SetA_radius = (float)_SetRadius1;
            ValidValue = false;
        }
        protected override void SetRadius2Value()
        {
            SetD_radius = (float)_SetRadius2;
            ValidValue = false;
        }
        public override double SetB1
        {
            get => _SetB1;

            set
            {
                TempValue = SetB1;
                SetField(ref _SetB1, value, () => SetB1);
                if (!CheckValidSize())
                {
                    ValidValue = false;
                }
                else
                {
                    SetB1 = TempValue;
                    return;
                }
            }
        }
        public override double SetB2
        {
            get => _SetB2;
            set
            {
                TempValue = SetB2;
                SetField(ref _SetB2, value, () => SetB2);
                if (!CheckValidSize())
                {
                    ValidValue = false;
                }
                else
                {
                    SetB2 = TempValue;
                    return;
                }
            }
        }
        public override double SetB3
        {
            get => _SetB3;
            set
            {
                TempValue = SetB3;
                SetField(ref _SetB3, value, () => SetB3);
                if (!CheckValidSize())
                {
                    ValidValue = false;
                }
                else
                {
                    SetB3 = TempValue;
                    return;
                }
            }
        }
        public override double CheckCut1
        {
            get => _CheckCut1;

            set
            {
                TempValue = CheckCut1;
                SetField(ref _CheckCut1, value, () => CheckCut1);
                if (!CheckValidSize())
                {

                    if (IsToothVector== true)
                    {
                        Move(CheckCut1, 0);
                    }
                    ValidValue = false;
                }
                else
                {
                    CheckCut1 = TempValue;
                    return;
                }
            }
        }
        public override Point[] GetFigurePoints()
        {
            #region 
            Line l = GetNewLine(B, C);

            TempPoint.PointX = SetCurrentLineLength(B, C, l.Length / 2).PointX;
            TempPoint.PointY = SetCurrentLineLength(B, C, l.Length / 2).PointY;

            double height = SetRadius - Math.Sqrt(Math.Pow(SetRadius, 2) - ((Math.Pow(l.Length, 2)) / 4));
            double r = SetRadius - height;
            if (B.PointY == TempPoint.PointY)
            {
                CenterPoint.PointX = TempPoint.PointX;
                CenterPoint.PointY = TempPoint.PointY - r;
            }

            else
            {
                if (SetH1 >= SetH)
                {
                    double FirstKatet = (B.PointX - TempPoint.PointX) / (B.PointY - TempPoint.PointY);
                    double SecondKatet = FirstKatet * TempPoint.PointX + TempPoint.PointY;
                    double P = 2 * (Math.Pow(FirstKatet, 2) + 1);
                    double N = 2 * (TempPoint.PointY * FirstKatet - TempPoint.PointX - FirstKatet * SecondKatet);
                    double M = Math.Pow(TempPoint.PointX, 2) - 2 * TempPoint.PointY * SecondKatet + Math.Pow(TempPoint.PointY, 2) + Math.Pow(SecondKatet, 2) - Math.Pow(r, 2);
                    CenterPoint.PointX = (-N - r * Math.Sqrt(Math.Pow(N, 2) - 2 * P * M)) / P;
                    CenterPoint.PointY = SecondKatet - FirstKatet * CenterPoint.PointX;
                }
                else
                {
                    double FirstKatet = (C.PointX - TempPoint.PointX) / (C.PointY - TempPoint.PointY);
                    double SecondKatet = FirstKatet * TempPoint.PointX + TempPoint.PointY;
                    double P = 2 * (Math.Pow(FirstKatet, 2) + 1);
                    double N = 2 * (TempPoint.PointY * FirstKatet - TempPoint.PointX - FirstKatet * SecondKatet);
                    double M = Math.Pow(TempPoint.PointX, 2) - 2 * TempPoint.PointY * SecondKatet + Math.Pow(TempPoint.PointY, 2) + Math.Pow(SecondKatet, 2) - Math.Pow(r, 2);
                    CenterPoint.PointX = (-N + r * Math.Sqrt(Math.Pow(N, 2) - 2 * P * M)) / P;
                    CenterPoint.PointY = SecondKatet - FirstKatet * CenterPoint.PointX;
                }
            }

            CenterPoint = SetCurrentLineLength(TempPoint, CenterPoint, SetRadius - height);
            CenterPoint.PointX -= 1;
            double angleBetween = CalculateAngle(B, CenterPoint, C);

            #endregion
            List<Point> pointsList = new List<Point> { C };
            double degree = 0;
            //  angleBetween = (SetH > SetL / 2) ? 360 - angleBetween : angleBetween;
            while (degree <= angleBetween)
            {
                CurvePoint.PointX = (C.PointX - CenterPoint.PointX) * Math.Cos(degree * Math.PI / 180) - (C.PointY - CenterPoint.PointY) * Math.Sin(degree * Math.PI / 180) + CenterPoint.PointX;
                CurvePoint.PointY = (C.PointX - CenterPoint.PointX) * Math.Sin(degree * Math.PI / 180) + (C.PointY - CenterPoint.PointY) * Math.Cos(degree * Math.PI / 180) + CenterPoint.PointY;
                pointsList.Add(CurvePoint);
                pointsL.Add(CurvePoint);
                degree += 1;
            }
            pointsList.Add(B);
            Point[] points = new Point[pointsList.Count];
            Array.Copy(pointsList.ToArray(), points, pointsList.Count);
            pointsList.Clear();
            var PointXMax = points.Max(PointX => PointX.X);
            var yMax = points.Max(PointX => PointX.Y);
            var PointXMin = points.Min(PointX => PointX.X);
            var yMin = points.Min(PointX => PointX.Y);
            PointX_average = points.Average(PointX => PointX.X);
            Y_average = points.Average(PointX => PointX.Y);
            Apogeus.PointX = PointXMin;
            Apogeus.PointY = yMin;
            Perigeus.PointX = PointXMax;
            Perigeus.PointY = yMax;
            return points;
        }

        protected override void CreatingAdvancedPoints(ShapePoint secondPoint, RectangleF rectPoint, PointF a, PointF b)
        {
            base.CreatingAdvancedPoints(secondPoint, rectPoint, a, b);
            if (secondPoint == ACheck)
            {
                ACheck1 = b;
                ACheck2 = a;
                ArF = rectPoint;
            }
            if (secondPoint == BCheck)
            {
                BCheck1 = b;
                BCheck2 = a;
                BrF = rectPoint;
            }
            if (secondPoint == CCheck)
            {
                CCheck1 = a;
                CCheck2 = b;
                CrF = rectPoint;
            }

            if (secondPoint == DCheck)
            {
                DCheck1 = a;
                DCheck2 = b;
                DrF = rectPoint;
            }

        }
        public override Point[] GetFigureToothPoints()
        {
            #region

            Line l = GetNewLine(BCheck, CCheck);

            TempPoint.PointX = SetCurrentLineLength(BCheck, CCheck, l.Length / 2).PointX;
            TempPoint.PointY = SetCurrentLineLength(BCheck, CCheck, l.Length / 2).PointY;

            double height = SetRadius_t - Math.Sqrt(Math.Pow(SetRadius_t, 2) - ((Math.Pow(l.Length, 2)) / 4));

            double r = SetRadius_t - height;
            if (BCheck.PointY == TempPoint.PointY)
            {
                CenterPoint.PointX = TempPoint.PointX;
                CenterPoint.PointY = TempPoint.PointY + r;
            }
            else
            {
                if (SetH1 >= SetH)
                {
                    double FirstKatet = (BCheck.PointX - TempPoint.PointX) / (BCheck.PointY - TempPoint.PointY);
                    double SecondKatet = FirstKatet * TempPoint.PointX + TempPoint.PointY;
                    double P = 2 * (Math.Pow(FirstKatet, 2) + 1);
                    double N = 2 * (TempPoint.PointY * FirstKatet - TempPoint.PointX - FirstKatet * SecondKatet);
                    double M = Math.Pow(TempPoint.PointX, 2) - 2 * TempPoint.PointY * SecondKatet + Math.Pow(TempPoint.PointY, 2) + Math.Pow(SecondKatet, 2) - Math.Pow(r, 2);
                    CenterPoint.PointX = (-N - r * Math.Sqrt(Math.Pow(N, 2) - 2 * P * M)) / P;
                    CenterPoint.PointY = SecondKatet - FirstKatet * CenterPoint.PointX;
                }
                else
                {
                    double FirstKatet = (CCheck.PointX - TempPoint.PointX) / (CCheck.PointY - TempPoint.PointY);
                    double SecondKatet = FirstKatet * TempPoint.PointX + TempPoint.PointY;
                    double P = 2 * (Math.Pow(FirstKatet, 2) + 1);
                    double N = 2 * (TempPoint.PointY * FirstKatet - TempPoint.PointX - FirstKatet * SecondKatet);
                    double M = Math.Pow(TempPoint.PointX, 2) - 2 * TempPoint.PointY * SecondKatet + Math.Pow(TempPoint.PointY, 2) + Math.Pow(SecondKatet, 2) - Math.Pow(r, 2);
                    CenterPoint.PointX = (-N + r * Math.Sqrt(Math.Pow(N, 2) - 2 * P * M)) / P;
                    CenterPoint.PointY = SecondKatet - FirstKatet * CenterPoint.PointX;
                }
            }
            CenterPoint = SetCurrentLineLength(TempPoint, CenterPoint, SetRadius_t - height);
            CenterPoint.PointX -= 1;
            double angleBetween = CalculateAngle(BCheck, CenterPoint, CCheck);
            #endregion
            List<Point> pointsList = new List<Point> { CCheck };
            double degree = 0;
           
            while (degree <= angleBetween)
            {
                CurvePoint.PointX = (CCheck.PointX - CenterPoint.PointX) * Math.Cos(degree * Math.PI / 180) - (CCheck.PointY - CenterPoint.PointY) * Math.Sin(degree * Math.PI / 180) + CenterPoint.PointX;
                CurvePoint.PointY = (CCheck.PointX - CenterPoint.PointX) * Math.Sin(degree * Math.PI / 180) + (CCheck.PointY - CenterPoint.PointY) * Math.Cos(degree * Math.PI / 180) + CenterPoint.PointY;
                pointsList.Add(CurvePoint);
                degree += 1;
            }

            pointsList.Add(BCheck);
            Point[] points = new Point[pointsList.Count];
            Array.Copy(pointsList.ToArray(), points, pointsList.Count);
            pointsList.Clear();
            var PointXMax = points.Max(PointX => PointX.X);
            var yMax = points.Max(PointX => PointX.Y);
            var PointXMin = points.Min(PointX => PointX.X);
            var yMin = points.Min(PointX => PointX.Y);
            ApogeusCheck.PointX = PointXMin;
            ApogeusCheck.PointY = yMin;
            PerigeusCheck.PointX = PointXMax;
            PerigeusCheck.PointY = yMax;
            return points;
        }
        /// <summary>
        /// Allowances the processing.
        /// </summary>
        protected override void AllowanceProcessing()
        {
            ACheck.PointX = A.PointX;
            ACheck.PointY = A.PointY;
            BCheck.PointX = B.PointX;
            BCheck.PointY = B.PointY;
            CCheck.PointX = C.PointX;
            CCheck.PointY = C.PointY;
            DCheck.PointX = D.PointX;
            DCheck.PointY = D.PointY;
            double diag1 = 0;
            double diag11 = 0;
            double diag2 = 0;
            double diag21 = 0;
            double diag3 = 0;
            double diag31 = 0;
            double diag4 = 0;
            double diag41 = 0;

            _CheckCut1 = (IsToothVector == false && _CheckCut1 >= 0) ? _CheckCut1 * (-1) : _CheckCut1;
            _CheckCut1 = (IsToothVector == true && _CheckCut1 < 0) ? _CheckCut1 * (-1) : _CheckCut1;


            diag1 = (diag1 <= 90) ? _CheckCut1 / Math.Sin(CalculateAngle(D, A, B) * Math.PI / 180) :
                (90 - ((180 - _CheckCut1 / Math.Sin(CalculateAngle(D, A, B)) * Math.PI / 180)));
            diag11 = (diag11 <= 90) ? _CheckCut1 / Math.Sin(CalculateAngle(A, B, C) * Math.PI / 180) :
                (90 - ((180 - _CheckCut1 / Math.Sin(CalculateAngle(A, B, C)) * Math.PI / 180)));
            diag2 = (diag2 <= 90) ? _CheckCut1 / Math.Sin(CalculateAngle(A, B, C) * Math.PI / 180) :
                (90 - ((180 - _CheckCut1 / Math.Sin(CalculateAngle(A, B, C)) * Math.PI / 180)));
            diag21 = (diag21 <= 90) ? _CheckCut1 / Math.Sin(CalculateAngle(B, C, D) * Math.PI / 180) :
                (90 - ((180 - _CheckCut1 / Math.Sin(CalculateAngle(B, C, D)) * Math.PI / 180)));
            diag3 = (diag3 <= 90) ? _CheckCut1 / Math.Sin(CalculateAngle(B, C, D) * Math.PI / 180) :
                (90 - ((180 - _CheckCut1 / Math.Sin(CalculateAngle(B, C, D)) * Math.PI / 180)));
            diag31 = (diag31 <= 90) ? _CheckCut1 / Math.Sin(CalculateAngle(C, D, A) * Math.PI / 180) :
                (90 - ((180 - _CheckCut1 / Math.Sin(CalculateAngle(C, D, A)) * Math.PI / 180)));
            diag4 = (diag4 <= 90) ? _CheckCut1 / Math.Sin(CalculateAngle(C, D, A) * Math.PI / 180) :
                (90 - ((180 - _CheckCut1 / Math.Sin(CalculateAngle(C, D, A)) * Math.PI / 180)));
            diag41 = (diag41 <= 90) ? _CheckCut1 / Math.Sin(CalculateAngle(D, A, B) * Math.PI / 180) :
                (90 - ((180 - _CheckCut1 / Math.Sin(CalculateAngle(D, A, B)) * Math.PI / 180)));

            ACheck.PointY = SetCurrentLineLength(DCheck, ACheck, diag1 + D_Check_Line.Length).PointY;
            ACheck.PointX = SetCurrentLineLength(DCheck, ACheck, diag1 + D_Check_Line.Length).PointX;
            BCheck.PointY = SetCurrentLineLength(CCheck, BCheck, diag11 + B_Check_Line.Length).PointY;
            BCheck.PointX = SetCurrentLineLength(CCheck, BCheck, diag11 + B_Check_Line.Length).PointX;

            BCheck.PointY = SetCurrentLineLength(ACheck, BCheck, diag2 + A_Check_Line.Length).PointY;
            BCheck.PointX = SetCurrentLineLength(ACheck, BCheck, diag2 + A_Check_Line.Length).PointX;
            CCheck.PointY = SetCurrentLineLength(DCheck, CCheck, diag21 + C_Check_Line.Length).PointY;
            CCheck.PointX = SetCurrentLineLength(DCheck, CCheck, diag21 + C_Check_Line.Length).PointX;

            CCheck.PointY = SetCurrentLineLength(BCheck, CCheck, diag3 + B_Check_Line.Length).PointY;
            CCheck.PointX = SetCurrentLineLength(BCheck, CCheck, diag3 + B_Check_Line.Length).PointX;
            DCheck.PointY = SetCurrentLineLength(ACheck, DCheck, diag31 + D_Check_Line.Length).PointY;
            DCheck.PointX = SetCurrentLineLength(ACheck, DCheck, diag31 + D_Check_Line.Length).PointX;

            DCheck.PointY = SetCurrentLineLength(CCheck, DCheck, diag4 + C_Check_Line.Length).PointY;
            DCheck.PointX = SetCurrentLineLength(CCheck, DCheck, diag4 + C_Check_Line.Length).PointX;
            ACheck.PointY = SetCurrentLineLength(BCheck, ACheck, diag41 + A_Check_Line.Length).PointY;
            ACheck.PointX = SetCurrentLineLength(BCheck, ACheck, diag41 + A_Check_Line.Length).PointX;

            if (IsToothVector == true)
            {
                using (Pen penCut = new Pen(Color.Red, ThiсknessArgument))
                {
                    Point[] curvePoints = GetFigureToothPoints();
                    using (pen1 = new Pen(Color.Red, ThiсknessArgument / 2))
                    {
                        double r1 = 0;
                        double r2 = 0;
                        r1 = ((SetD_radius ) == 0) ? 1 : SetD_radius + _CheckCut1;
                        r2 = ((SetA_radius ) == 0) ? 1 : SetA_radius + _CheckCut1;
                        graphicsShape.DrawPath(penCut, MakeRoundCorner(CCheck, DCheck, ACheck, r1));
                        graphicsShape.DrawPath(penCut, MakeRoundCorner(DCheck, ACheck, BCheck, r2));
                        A.PointRadius = SetA_radius;
                        B.PointRadius = SetB_radius;
                        C.PointRadius = SetC_radius;
                        D.PointRadius = SetD_radius;
                        graphicsShape.DrawLine(penCut, ACheck1, BCheck);
                        graphicsShape.DrawLine(penCut, CCheck, DCheck1);
                        graphicsShape.DrawLine(penCut, DCheck2, ACheck2);
                        graphicsShape.DrawCurve(penCut, curvePoints, 0F);
                    }
                    IsToothVector = true;
                }
            }
            else
            {
                double r1 = 0;
                double r2 = 0;
                double r3 = 0;
                double r4 = 0;
                r1 = ((SetB_radius + _CheckCut1) < 0) ? 1 : SetB_radius + _CheckCut1;
                r2 = ((SetC_radius + _CheckCut1) < 0) ? 1 : SetC_radius + _CheckCut1;
                r3 = ((SetD_radius + _CheckCut1) < 0) ? 1 : SetD_radius + _CheckCut1;
                r4 = ((SetA_radius + _CheckCut1) < 0) ? 1 : SetA_radius + _CheckCut1;
                using (Pen penCut = new Pen(Color.Red, ThiсknessArgument / 2))
                {
                    Point[] curvePoints = GetFigureToothPoints();
                    penCut.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawPath(penCut, MakeRoundCorner(ACheck, BCheck, CCheck, SetB_radius));
                    graphicsShape.DrawPath(penCut, MakeRoundCorner(BCheck, CCheck, DCheck, SetC_radius));
                    graphicsShape.DrawPath(penCut, MakeRoundCorner(CCheck, DCheck, ACheck, SetD_radius));
                    graphicsShape.DrawPath(penCut, MakeRoundCorner(DCheck, ACheck, BCheck, SetA_radius));
                    A.PointRadius = SetA_radius;
                    B.PointRadius = SetB_radius;
                    C.PointRadius = SetC_radius;
                    D.PointRadius = SetD_radius;

                    graphicsShape.DrawLine(penCut, ACheck1, BCheck2);
                    graphicsShape.DrawLine(penCut, CCheck1, DCheck1);
                    graphicsShape.DrawLine(penCut, DCheck2, ACheck2);
                    graphicsShape.DrawCurve(penCut, curvePoints, 0F);
                    IsToothVector = false;
                }
            }
            GetExtremumPoints();
        }
        public override void GetExtremumPoints()
        {

            List<ShapePoint> pointList = new List<ShapePoint>() { A, B,C,  D,  ApogeusCheck,Apogeus,Perigeus,
                PerigeusCheck, ACheck, BCheck,  DCheck };

            double PointXMax = pointList.Max(PointX => PointX.PointX);
            var yMax = pointList.Max(PointX => PointX.PointY);
            var PointXMin = pointList.Min(PointX => PointX.PointX);
            var yMin = pointList.Min(PointX => PointX.PointY);
            W_Base = new ShapePoint(PointXMin, yMax);
            X_Base = new ShapePoint(PointXMin, yMin);
            Y_Base = new ShapePoint(PointXMax, yMin);
            Z_Base = new ShapePoint(PointXMax, yMax);

        }
        public override bool CheckValidSize()
        {

            var value1 = (IsToothVector == true) ? _CheckCut1 : 0;
            var width = _SetL + _SetB1 * 2 + value1 * 2;
            var height = _SetH + _SetB2 + _SetB3 + value1 * 2;

            if (_SetH < 0 || _SetH1 < 0 || _SetL < 0 || _SetB1 < 0 || _SetB2 < 0 || _SetB3 < 0 || _SetB4 < 0)
            {
                var message = $"Значение  не может быть отрицательным";
                ValidateSetSizeMessage(Text: message);
                ValidValue = true;
            }

            else if (width > 6000 || height > 6000)
            {
                var message2 = (width > 6000)
                    ? $"Габаритная ширина = {width} превышает 6000"
                    : $"Габаритная высота = {height} превышает 6000";
                ValidateSetSizeMessage(Text: message2);
                ValidValue = true;
            }
            else if (width > 3210 && height > 3210)
            {
                var message1 =
                    $"Габаритная ширина = {width} превышает 3210 и Габаритная высота = {height} превышает 3210";
                ValidateSetSizeMessage(Text: message1);
                ValidValue = true;
            }

            else if (_SetH1>0 && SetH > 0.0 + ((SetH + _SetH1) / 2.0 + Math.Sqrt(
                                       SetRadius * SetRadius - ((SetH - _SetH1) *
                                                                (SetH - _SetH1) + SetL * SetL) / 4.0)) *
                     Math.Cos(Math.Atan((SetH - _SetH1) / SetL)) && SetH > _SetH1)
            {
                ValidValue = true;
                ValidateSetSizeMessage("Значение 'Н1' за пределами допустимого диапазона.");
            }

            else if (_SetH1 > 0 && _SetH1 > 0.0 + ((_SetH1 + SetH) / 2.0 + Math.Sqrt(SetRadius * SetRadius -
                                                                       ((_SetH1 - SetH) * (_SetH1 - SetH) +
                                                                        SetL * SetL) / 4.0)) *
                     Math.Cos(Math.Atan((_SetH1 - SetH) / SetL)) && _SetH1 >= SetH)
            {
                ValidValue = true;
                ValidateSetSizeMessage("Значение 'Н1' за пределами допустимого диапазона.");
            }

            else if (_SetH1 > 0 && SetH > 0.0 + ((SetH + _SetH1) / 2.0 +
                                   Math.Sqrt(SetRadius * SetRadius - ((SetH - _SetH1) * (SetH - _SetH1) +
                                                                      SetL * SetL) / 4.0)) *
                     Math.Cos(Math.Atan((SetH - _SetH1) / SetL)) && SetH > _SetH1)
            {
                ValidValue = true;
                ValidateSetSizeMessage("Значение 'Н1' за пределами допустимого диапазона.");
            }

            else if (_SetH1 > 0 && _SetH1 > 0 && 1 > (_SetH1 + SetH) / 2.0 + Math.Sqrt(SetRadius * SetRadius -
                      ((_SetH1 - SetH) * (_SetH1 - SetH) +
                        SetL * SetL) / 4.0) *
                     Math.Cos(Math.Atan((_SetH1 - SetH) / SetL)) - SetRadius && SetL / 2.0 -
                     Math.Sqrt(SetRadius * SetRadius -
                               ((_SetH1 - SetH) * (_SetH1 - SetH) + SetL * SetL) / 4.0) *
                     Math.Sin(Math.Atan((_SetH1 - SetH) / SetL)) > 0.0 && SetL / 2.0 - Math.Sqrt(SetRadius * SetRadius -
                       ((_SetH1 - SetH) * (_SetH1 - SetH) +SetL * SetL) / 4.0) *
                     Math.Sin(Math.Atan((_SetH1 - SetH) / SetL)) < SetL)
            {
                ValidValue = true;
                ValidateSetSizeMessage("Значение 'Н1' за пределами допустимого диапазона.");
            }


            else if (_SetH > 0.0 && _SetH > 0.0 + ((_SetH + SetH1) / 2.0 + Math.Sqrt(SetRadius * SetRadius - ((_SetH - SetH1) *
                     (_SetH - SetH1) + SetL * SetL) / 4.0)) *
                     Math.Cos(Math.Atan((_SetH - SetH1) / SetL)) && _SetH > SetH1)
            {
                ValidValue = true;
                ValidateSetSizeMessage("Значение 'Н' за пределами допустимого диапазона.");
            }

            else if (_SetH > 0.0 && SetH1 > 0.0 + ((SetH1 + _SetH) / 2.0 + Math.Sqrt(SetRadius * SetRadius -
                    ((SetH1 - _SetH) * (SetH1 - _SetH) + SetL * SetL) / 4.0)) *
                     Math.Cos(Math.Atan((SetH1 - _SetH) / SetL)) && SetH1 >= _SetH)
            {
                ValidValue = true;
                ValidateSetSizeMessage("Значение 'Н' за пределами допустимого диапазона.");
            }

            else if (_SetH > 0.0 && _SetH > 0.0 + ((_SetH + SetH1) / 2.0 +
                    Math.Sqrt(SetRadius * SetRadius - ((_SetH - SetH1) * (_SetH - SetH1) +
                   SetL * SetL) / 4.0)) *
                     Math.Cos(Math.Atan((_SetH - SetH1) / SetL)) && _SetH > SetH1)
            {
                ValidValue = true;
                ValidateSetSizeMessage("Значение 'Н' за пределами допустимого диапазона.");
            }

            else if (_SetH > 0.0 && 1 > (SetH1 + _SetH) / 2.0 + Math.Sqrt(SetRadius * SetRadius -
                                                           ((SetH1 - _SetH) * (SetH1 - _SetH) + SetL * SetL) / 4.0) *
                     Math.Cos(Math.Atan((SetH1 - _SetH) / SetL)) - SetRadius && SetL / 2.0 -
                     Math.Sqrt(SetRadius * SetRadius - ((SetH1 - _SetH) * (SetH1 - _SetH) + SetL * SetL) / 4.0) *
                     Math.Sin(Math.Atan((SetH1 - _SetH) / SetL)) > 0.0 && SetL / 2.0 - Math.Sqrt(SetRadius * SetRadius -
                      ((SetH1 - _SetH) *(SetH1 - _SetH) +SetL * SetL) / 4.0) * Math.Sin(Math.Atan((SetH1 - _SetH) / SetL)) < SetL)
            {
                ValidValue = true;
                ValidateSetSizeMessage("Значение 'Н' за пределами допустимого диапазона.");
            }
            //else if (_SetRadius>0&&_SetRadius < B_line.Length / 2)
            //{
            //    ValidValue = true;
            //    ValidateSetSizeMessage("Значение 'R' за пределами допустимого диапазона");
            //}

            else if (_SetRadius > 0 && _SetRadius >= SetL / 2 && SetH == SetH1)
            {
                ValidValue = true;
                ValidateSetSizeMessage("Радиус  не может превышать 'L/2'");
            }
            else if (_SetRadius1 > 0 && (SetH < SetL) && (_SetRadius1 > SetL / 2))
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение R1 не может быть больше L/2");
            }
            else if (_SetRadius1 > 0 && (SetL < SetH) && (_SetRadius1 > SetH / 2))
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение R1 не может быть больше H/2");
            }
            else if (_SetRadius1 > 0 && (SetL == SetH) && (_SetRadius1 > SetH / 2))
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение R не может быть больше половины длины стороны");
            }

            else if (_SetRadius2 > 0 && (SetH < SetL) && (_SetRadius2 > SetL / 2))
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение R2 не может быть больше L/2");
            }
            else if (_SetRadius2 > 0 && (SetL < SetH) && (_SetRadius2 > SetH / 2))
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение R2 не может быть больше H/2");
            }
            else if (_SetRadius2 > 0 && (SetL == SetH) && (_SetRadius2 > SetH / 2))
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение R2 не может быть больше половины длины стороны");
            }


            else if (_SetRadius3 > 0 && (SetH < SetL) && (_SetRadius3 > SetL / 2))
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение R3 не может быть больше L/2");
            }
            else if (_SetRadius3 > 0 && (SetL < SetH) && (_SetRadius3 > SetH / 2))
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение R3 не может быть больше H/2");
            }
            else if (_SetRadius3 > 0 && (SetL == SetH) && (_SetRadius3 > SetH / 2))
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение R3 не может быть больше половины длины стороны");
            }

            else

            {
                ValidValue = false;
            }
            return ValidValue;
        }
        public override void AddCustomProperties(object sender, CustomPropertyDescriptorsEventArgs e)
        {
            if (e.Context.PropertyDescriptor == null)
            {
                PropertyDescriptorCollection filteredCollection = new PropertyDescriptorCollection(null);
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH1");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetRadius");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetRadius1");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetRadius2");
              
                AddIfPropertyExist(e.Properties, filteredCollection, "SetB1");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetB2");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetB3");
                AddIfPropertyExist(e.Properties, filteredCollection, "ShapeKis");
                AddIfPropertyExist(e.Properties, filteredCollection, "ShapeKisPersent");
                AddIfPropertyExist(e.Properties, filteredCollection, "Area");
                AddIfPropertyExist(e.Properties, filteredCollection, "TrueArea");
                AddIfPropertyExist(e.Properties, filteredCollection, "BaseArea");
                AddIfPropertyExist(e.Properties, filteredCollection, "Perimeter");
                AddIfPropertyExist(e.Properties, filteredCollection, "Perimeter_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "ShapeHeightValue");
                AddIfPropertyExist(e.Properties, filteredCollection, "ShapeWidthValue");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH1_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetRadius_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetRadius1_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetRadius2_t");
               
                AddIfPropertyExist(e.Properties, filteredCollection, "IsToothVector");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut1");
                if (!IsAddAdwansedParams)
                {
                    AddIfPropertyExist(e.Properties, filteredCollection, "IsCuttingGlass");
                    AddIfPropertyExist(e.Properties, filteredCollection, "IsBendingDistanceFrame");
                    AddIfPropertyExist(e.Properties, filteredCollection, "IsFormSealing");
                    AddIfPropertyExist(e.Properties, filteredCollection, "IsGasFillingForm");
                    AddIfPropertyExist(e.Properties, filteredCollection, "IsVertBendingMashineRobot");
                    AddIfPropertyExist(e.Properties, filteredCollection, "IsVertMashineEdgeMaking");
                }
                e.Properties = filteredCollection;
            }
        }
    }
}