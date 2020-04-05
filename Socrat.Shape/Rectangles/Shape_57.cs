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
    sealed class Shape_57 : Rectangular
    {
        private ShapePoint Apogeus { get; set; }
        private ShapePoint Perigeus { get; set; }
        private ShapePoint ApogeusCheck { get; set; }
        private ShapePoint PerigeusCheck { get; set; }
        private ShapePoint ACheck1 { get; set; }
        private ShapePoint ACheck2 { get; set; }
        private ShapePoint BCheck1 { get; set; }
        private ShapePoint BCheck2 { get; set; }
        private ShapePoint CCheck1 { get; set; }
        private ShapePoint CCheck2 { get; set; }
        private ShapePoint DCheck1 { get; set; }
        private ShapePoint DCheck2 { get; set; }
        private double PointX_average;
        private double Y_average;
        private double curRadius { get; set; }
        private ShapePoint Temp { get; set; }
        private Pen BlackPen { get; }
        private double angle { get; set; }
        public Shape_57(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
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
            Temp = GetNewPoint();
            BlackPen = new Pen(Color.Green, 1);
        }
        protected override void DrawMainLines()
        {
            Point[] curvePoints = GetFigurePoints();
            if (IsToothVector == true)
            {

                using (pen1 = new Pen(Color.Red, ThiсknessArgument / 2))
                {
                    pen1.DashStyle = DashStyle.DashDot;
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

                using (pen1 = new Pen(Color.Red, ThiсknessArgument))
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
            using (var pen = new Pen(Color.Blue, SizeLineBoundArgument))
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
                ShapePoint b1hcenter = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, W_Base.PointY - (blh1.Length / 2));
                graphicsShape.DrawLine(pen, bsh1, beh1);
                graphicsShape.DrawString("H=" + SetH, drawFontBold, Brushes.Black, b1hcenter, sf);


                ShapePoint b12s1 = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, SetPointCurrentValueY(A));
                ShapePoint b12e1 = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, W_Base.PointY);
                graphicsShape.DrawLine(pen, b12s1, b12e1);
                Line b22h = GetNewLine(b12s1, b12e1);
                ShapePoint b22scenter = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, W_Base.PointY - b22h.Length / 2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b22scenter, sf);

                ShapePoint b3s = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, X_Base.PointY);
                ShapePoint b3e = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, X_Base.PointY + SetB3);
                Line lb3 = GetNewLine(b3s, b3e);
                ShapePoint b3center = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, X_Base.PointY + lb3.Length / 2);
                graphicsShape.DrawLine(pen, b3s, b3e);
                graphicsShape.DrawString("B3=" + SetB3, drawFontBold, Brushes.Black, b3center, sf);

                using (Pen penr = new Pen(Color.Blue, ThiсknessArgument / 2))
                {
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Far;
                    penr.StartCap = LineCap.RoundAnchor;
                    penr.EndCap = LineCap.ArrowAnchor;
                    penr.DashStyle = DashStyle.Solid;
                    ShapePoint rs = GetNewCustomPoint(W_Base.PointX + D_line.Length / 4, Z_Base.PointY - 40 * LineBoundArgument);
                    ShapePoint re = GetNewCustomPoint(PointX_average, Y_average - 30);
                    Line lr = GetNewLine(rs, re);
                    ShapePoint brcenter = GetNewCustomPoint((rs.PointX + re.PointX) / 2, (rs.PointY + re.PointY) / 2);
                    graphicsShape.DrawLine(penr, rs, re);
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Near;
                    graphicsShape.DrawString("R=" + SetCurrentSize(SetRadius), drawFontBold, Brushes.Black, brcenter, sf);
                }

                graphicsShape.DrawString("R1=" + SetA_radius, drawFontBold, Brushes.Green, ArF.Location);
                graphicsShape.DrawString("R2=" + SetD_radius, drawFontBold, Brushes.Green, DrF.Location, sf);

                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX) / 4), ((A.PointY + B.PointY + C.PointY + D.PointY) / 4));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiknessFontArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("57", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }

                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {

                    ShapePoint wer = GetNewCustomPoint(SetPointCurrentValueX(B), Y_Base.PointY);
                    ShapePoint wer1 = GetNewCustomPoint(SetPointCurrentValueX(C), Y_Base.PointY);
                    using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        graphicsShape.DrawLine(pen1, wer, SetPointCurrentType(B));
                        graphicsShape.DrawLine(pen1, wer1, SetPointCurrentType(C));
                    }
                    graphicsShape.DrawLine(pens, le, SetPointCurrentType(D));
                    graphicsShape.DrawLine(pens, ls, SetPointCurrentType(A));
                    graphicsShape.DrawLine(pens, beh1, SetPointCurrentType(D));
                    graphicsShape.DrawLine(pens, beh, SetPointCurrentType(C));
                    graphicsShape.DrawLine(pens, b12e11, W_Base);
                    graphicsShape.DrawLine(pens, b1e1, Z_Base);
                    graphicsShape.DrawLine(pens, b3s, Y_Base);
                    graphicsShape.DrawLine(pens, b12e1, Z_Base);

                    using (var pens1 = new Pen(Color.Red, SizeLineBoundArgument / 2))
                    {
                        graphicsShape.DrawLine(pens1, bsh1, SetPointCurrentType(B));
                    }
                }
                #endregion
            }
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
                //graphicsShape.SetClip(myRegion, CombineMode.Replace);
                return boundsRect;
            }
        }
        public override void SelectClickedSide(int xCoord, int yCoord, bool flag)
        {
            Point point = new Point(xCoord, yCoord);
            if (ThicknessPath(A, B).IsVisible(point))
            {
                if (flag) { ColorMarker1 = "rowCheckCut1"; SelectedSides.SetValue(1, 0); SelectedSidesLength += A_line.Length; }
                else { ColorMarker1 = ""; SelectedSides.SetValue(0, 0); SelectedSidesLength -= A_line.Length; }
            }
            if (CurvePath(GetFigurePoints()).IsVisible(point))
            {
                if (flag) { ColorMarker2 = "rowCheckCut2"; SelectedSides.SetValue(2, 1); SelectedSidesLength += arcLength; }
                else { ColorMarker2 = ""; SelectedSides.SetValue(0, 1); SelectedSidesLength -= arcLength; }
            }
            if (ThicknessPath(C, D).IsVisible(point))
            {
                if (flag) { ColorMarker3 = "rowCheckCut3"; SelectedSides.SetValue(3, 2); SelectedSidesLength += C_line.Length; }
                else { ColorMarker3 = ""; SelectedSides.SetValue(0, 2); SelectedSidesLength -= C_line.Length; }
            }
            if (ThicknessPath(D, A).IsVisible(point))
            {
                if (flag) { ColorMarker4 = "rowCheckCut4"; SelectedSides.SetValue(4, 3); SelectedSidesLength += D_line.Length; }
                else { ColorMarker4 = ""; SelectedSides.SetValue(0, 3); SelectedSidesLength -= D_line.Length; }
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
                return Math.Round((lowerLeftArc + lowerRighttArc + a.Length + c.Length + d.Length + arcLength) / 1000, 3);

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
                Line curLine = GetNewLine(TempPoint, CenterPoint); ;
                CenterPoint.PointX = SetCurrentLineLength(TempPoint, CenterPoint, curLine.Length - SetRadius_t).PointX;
                CenterPoint.PointY = SetCurrentLineLength(TempPoint, CenterPoint, curLine.Length - SetRadius_t).PointY;
                double angleBetween = CalculateAngle(BCheck, CenterPoint, CCheck);
                double radiuss = l.Length / 2 - SetRadius_t;
                double arcLength = (Math.PI * radiuss * angleBetween) / 180;
                double lowerLeftArc = SetA_radius + CheckCut1 * Math.PI * (CalculateAngle(D, A, B) <= 90 ? CalculateAngle(D, A, B) : 180 - CalculateAngle(D, A, B)) / 180;
                double lowerRighttArc = SetD_radius + CheckCut1 * Math.PI * (CalculateAngle(C, D, A) <= 90 ? CalculateAngle(C, D, A) : 180 - CalculateAngle(C, D, A)) / 180;
                Line a = GetNewLine(ACheck1, BCheck2);

                Line c = GetNewLine(CCheck2, DCheck1);
                Line d = GetNewLine(DCheck2, ACheck2);
                return Math.Round((lowerLeftArc + lowerRighttArc + a.Length + c.Length + d.Length + arcLength) / 1000, 3);

            }

        }
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

                return Math.Round((temtSq + square) / 1000000, 3);
            }
        }
        public override double TrueArea
        {
            get
            {
                Line lla = GetNewLine(ACheck2, ACheck);
                Line llb = GetNewLine(ACheck1, ACheck);
                Line llc = GetNewLine(ACheck1, ACheck2);
                double AAnglle = (CalculateAngle(DCheck, ACheck, BCheck) <= 90 ? CalculateAngle(DCheck, ACheck, BCheck) : 180 - CalculateAngle(DCheck, ACheck, BCheck)) / 180;
                double llTriangle = Math.Round(Math.Sqrt(((lla.Length + llb.Length + llc.Length) / 2) *
                   (((lla.Length + llb.Length + llc.Length) / 2) - lla.Length) *
                   (((lla.Length + llb.Length + llc.Length) / 2) - llb.Length) *
                   (((lla.Length + llb.Length + llc.Length) / 2) - llc.Length)), 2) -
                  (Math.Pow(SetA_radius + CheckCut1, 2) / 2) * (Math.PI * AAnglle * Math.PI / 180 - Math.Sin(AAnglle * Math.PI / 180));



                Line lra = GetNewLine(DCheck2, DCheck);
                Line lrb = GetNewLine(DCheck1, DCheck);
                Line lrc = GetNewLine(DCheck1, DCheck2);
                double DAngle = (CalculateAngle(C, D, A) <= 90 ? CalculateAngle(C, D, A) : 180 - CalculateAngle(C, D, A)) / 180;
                double lrTriangle = Math.Round(Math.Sqrt(((lra.Length + lrb.Length + lrc.Length) / 2) *
                   (((lra.Length + lrb.Length + lrc.Length) / 2) - lra.Length) *
                   (((lra.Length + lrb.Length + lrc.Length) / 2) - lrb.Length) *
                   (((lra.Length + lrb.Length + lrc.Length) / 2) - lrc.Length)), 2) -
                 (Math.Pow(SetD_radius + CheckCut1, 2) / 2) * (Math.PI * DAngle * Math.PI / 180 - Math.Sin(DAngle * Math.PI / 180));
                double baseSquare = 0.5 * Math.Abs((ACheck.PointX * BCheck.PointY + BCheck.PointX * CCheck.PointY + CCheck.PointX * DCheck.PointY + DCheck.PointX * ACheck.PointY) -
                    (BCheck.PointX * ACheck.PointY + CCheck.PointX * BCheck.PointY + DCheck.PointX * CCheck.PointY + ACheck.PointX * DCheck.PointY));
                double temtSq = Math.Ceiling(baseSquare - Math.Abs(llTriangle) - Math.Abs(lrTriangle));



                Line l = GetNewLine(BCheck, CCheck);
                TempPoint.PointX = SetCurrentLineLength(BCheck, CCheck, l.Length / 2).PointX;
                TempPoint.PointY = SetCurrentLineLength(BCheck, CCheck, l.Length / 2).PointY;
                double alpha = 2 * Math.Atan((2 * SetRadius) / l.Length);
                double payLength = l.Length * (alpha / Math.Sin(alpha));
                double radius = payLength / alpha / 2;
                double angleBetween = CalculateAngle(BCheck, CenterPoint, CCheck);
                double fullSquare = Math.PI * Math.Pow(radius, 2);
                double square;
                square = (0.5 * Math.Pow(radius, 2)) * (angleBetween * Math.PI / 180 - Math.Sin(angleBetween * Math.PI / 180));
                if (Double.IsNaN(square)) { square = 0; }

                return Math.Round((temtSq + square) / 1000000, 3);
            }
        }
        protected override double CorrectingRadiusForShapeAngles(ShapePoint firstPoint, ShapePoint secondPoint, ShapePoint thirdPoint, double radius)
        {
            var aL = new Line(firstPoint, secondPoint);
            var bL = new Line(thirdPoint, secondPoint);
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
        public override double SetRadius_t => SetRadius;
        public override double SetRadius1_t => SetRadius1 + CheckCut1;
        public override double SetRadius2_t => SetRadius2 + CheckCut1;
        protected override void SetHValue()
        {
            base.SetHValue();
            TempPoint.PointX = A.PointX;
            TempPoint.PointY = A.PointY;
            TempPoint.PointX = SetCurrentLineLength(B, A, _SetH).PointX;
            TempPoint.PointY = SetCurrentLineLength(B, A, _SetH).PointY;
            var diff = TempPoint.PointY - A.PointY;
            C.PointY += diff;
            A.PointX = TempPoint.PointX;
            A.PointY = TempPoint.PointY;
            D.PointY = A.PointY;
            ValidValue = false;
        }
        protected override void SetH1Value()
        {
            base.SetH1Value();
            C.PointX = SetCurrentLineLength(D, C, _SetH1).PointX;
            C.PointY = SetCurrentLineLength(D, C, _SetH1).PointY;
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
            base.SetRadiusValue();
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
        public override Point[] GetFigurePoints()
        {
            #region Получаем угол ВСА для определения длины дуги скругления стороны АВ и уравниваем AC и BC
            var l = GetNewLine(B, C);
            TempPoint.PointX = SetCurrentLineLength(B, C, l.Length / 2).PointX;
            TempPoint.PointY = SetCurrentLineLength(B, C, l.Length / 2).PointY;
            var height = SetRadius - Math.Sqrt(Math.Pow(SetRadius, 2) - ((Math.Pow(l.Length, 2)) / 4));
            var r = SetRadius - height;
            curRadius = SetRadius;
            if (B.PointY == TempPoint.PointY)
            {
                CenterPoint.PointX = TempPoint.PointX;
                CenterPoint.PointY = TempPoint.PointY + r;
            }
            else
            {
                var FirstKatet = (B.PointX - TempPoint.PointX) / (B.PointY - TempPoint.PointY);
                var SecondKatet = FirstKatet * TempPoint.PointX + TempPoint.PointY;
                var P = 2 * (Math.Pow(FirstKatet, 2) + 1);
                var N = 2 * (TempPoint.PointY * FirstKatet - TempPoint.PointX - FirstKatet * SecondKatet);
                var M = Math.Pow(TempPoint.PointX, 2) - 2 * TempPoint.PointY * SecondKatet +
                    Math.Pow(TempPoint.PointY, 2) + Math.Pow(SecondKatet, 2) - Math.Pow(r, 2);
                CenterPoint.PointX = (-N - r * Math.Sqrt(Math.Pow(N, 2) - 2 * P * M)) / P;
                CenterPoint.PointY = SecondKatet - FirstKatet * CenterPoint.PointX;
            }
            CenterPoint = SetCurrentLineLength(TempPoint, CenterPoint, SetRadius - height);
            CenterPoint.PointX -= 1;
            Temp.PointX = CenterPoint.PointX;
            Temp.PointY = CenterPoint.PointY;
            var angleBetween = CalculateAngle(B, CenterPoint, C);
            #endregion
            var pointsList = new List<Point> { B };
            double degree = 0;
            while (degree <= angleBetween)
            {
                CurvePoint.PointX = (B.PointX - CenterPoint.PointX) * Math.Cos(degree * Math.PI / 180)
                    - (B.PointY - CenterPoint.PointY) * Math.Sin(degree * Math.PI / 180) + CenterPoint.PointX;
                CurvePoint.PointY = (B.PointX - CenterPoint.PointX) * Math.Sin(degree * Math.PI / 180)
                    + (B.PointY - CenterPoint.PointY) * Math.Cos(degree * Math.PI / 180) + CenterPoint.PointY;
                pointsList.Add(CurvePoint);
                degree += 1;
            }
            pointsList.Add(C);
            var points = new Point[pointsList.Count];
            Array.Copy(pointsList.ToArray(), points, pointsList.Count);
            pointsList.Clear();
            var xMax = points.Max(PointX => PointX.X);
            var yMax = points.Max(PointX => PointX.Y);
            var xMin = points.Min(PointX => PointX.X);
            var yMin = points.Min(PointX => PointX.Y);
            PointX_average = points.Average(PointX => PointX.X);
            Y_average = points.Average(PointX => PointX.Y);
            Apogeus.PointX = xMin;
            Apogeus.PointY = yMin;
            Perigeus.PointX = xMax;
            Perigeus.PointY = yMax;
            var diff = Apogeus.PointY - 150;
            Move(y: -diff);
            return points;
        }
        public override Point[] GetFigureToothPoints()
        {
            #region
            var angleBetween = CalculateAngle(BCheck, CenterPoint, CCheck);
            #endregion
            var pointsList = new List<Point> { BCheck };
            double degree = 0;
            //  angleBetween = (SetH > SetL / 2) ? 360 - angleBetween : angleBetween;
            while (degree <= angleBetween)
            {
                CurvePoint.PointX = (BCheck.PointX - Temp.PointX) * Math.Cos(degree * Math.PI / 180) -
                                    (BCheck.PointY - Temp.PointY) * Math.Sin(degree * Math.PI / 180) + Temp.PointX;
                CurvePoint.PointY = (BCheck.PointX - Temp.PointX) * Math.Sin(degree * Math.PI / 180) +
                                    (BCheck.PointY - Temp.PointY) * Math.Cos(degree * Math.PI / 180) + Temp.PointY;
                pointsList.Add(CurvePoint);
                degree += 1;
            }

            pointsList.Add(CCheck);
            var points = new Point[pointsList.Count];
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



            BCheck.PointY = SetCurrentLineLength(ACheck, BCheck, _CheckCut1 + A_Check_Line.Length).PointY;
            // BCheck.PointX = SetCurrentLineLength(ACheck, BCheck, diag2 + A_Check_Line.Length).PointX;
            CCheck.PointY = SetCurrentLineLength(DCheck, CCheck, _CheckCut1 + C_Check_Line.Length).PointY;
            // CCheck.PointX = SetCurrentLineLength(DCheck, CCheck, diag21 + C_Check_Line.Length).PointX;




            // CCheck.PointY = SetCurrentLineLength(BCheck, CCheck, diag3 + B_Check_Line.Length).PointY;
            CCheck.PointX = SetCurrentLineLength(BCheck, CCheck, _CheckCut1 + B_Check_Line.Length).PointX;
            // DCheck.PointY = SetCurrentLineLength(ACheck, DCheck, diag31 + D_Check_Line.Length).PointY;
            DCheck.PointX = SetCurrentLineLength(ACheck, DCheck, _CheckCut1 + D_Check_Line.Length).PointX;

            DCheck.PointY = SetCurrentLineLength(CCheck, DCheck, _CheckCut1 + C_Check_Line.Length).PointY;
            DCheck.PointX = SetCurrentLineLength(CCheck, DCheck, _CheckCut1 + C_Check_Line.Length).PointX;
            ACheck.PointY = SetCurrentLineLength(BCheck, ACheck, _CheckCut1 + A_Check_Line.Length).PointY;
            ACheck.PointX = SetCurrentLineLength(BCheck, ACheck, _CheckCut1 + A_Check_Line.Length).PointX;

            //ACheck.PointY = SetCurrentLineLength(DCheck, ACheck, diag1 + D_Check_Line.Length).PointY;
            ACheck.PointX = SetCurrentLineLength(DCheck, ACheck, _CheckCut1 + D_Check_Line.Length).PointX;
            //BCheck.PointY = SetCurrentLineLength(CCheck, BCheck, diag11 + B_Check_Line.Length).PointY;
            BCheck.PointX = SetCurrentLineLength(CCheck, BCheck, _CheckCut1 + B_Check_Line.Length).PointX;

            if (IsToothVector == true)
            {
                using (Pen penCut = new Pen(Color.Red, ThiсknessArgument))
                {
                    Point[] curvePoints = GetFigureToothPoints();
                    using (pen1 = new Pen(Color.Red, ThiсknessArgument / 2))
                    {
                        graphicsShape.DrawPath(penCut, MakeRoundCorner(CCheck, DCheck, ACheck, SetRadius2 + CheckCut1));
                        graphicsShape.DrawPath(penCut, MakeRoundCorner(DCheck, ACheck, BCheck, SetRadius1 + CheckCut1));
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
                using (var penCut = new Pen(Color.Red, ThiсknessArgument / 2))
                {
                    var curvePoints = GetFigureToothPoints();
                    penCut.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawPath(penCut, MakeRoundCorner(ACheck, BCheck, CCheck, r1));
                    graphicsShape.DrawPath(penCut, MakeRoundCorner(BCheck, CCheck, DCheck, r2));
                    graphicsShape.DrawPath(penCut, MakeRoundCorner(CCheck, DCheck, ACheck, r3));
                    graphicsShape.DrawPath(penCut, MakeRoundCorner(DCheck, ACheck, BCheck, r4));
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

            List<ShapePoint> pointList = new List<ShapePoint>() { A, B,C,D,  ApogeusCheck,Apogeus,Perigeus,
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
            else if ((_SetH > 0) && _SetH < SetH1)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение H не может быть меньше H1");
            }
            else if ((_SetH1 > 0) && _SetH1 > SetH)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение H1 не может быть больше H");
            }

            //else if (_SetH1 > 0 && _SetH1 < (SetH + _SetH1) / 2.0 - ((SetL * SetL + (_SetH1 - SetH)
            //         * (_SetH1 - SetH)) / (8.0 * height) - height / 2) *
            //         (SetL / Math.Sqrt(SetL * SetL + (_SetH1 - SetH) * (_SetH1 - SetH))))
            //{
            //    ValidValue = true;
            //    ValidateSetSizeMessage($"Значение 'Н1' за пределами допустимого диапазона.");
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