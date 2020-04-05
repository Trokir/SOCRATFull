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
    public sealed class Shape_27 : Rectangular
    {
        private ShapePoint Apogeus { get; set; }
        private ShapePoint Perigeus { get; set; }
        private ShapePoint ApogeusCheck { get; set; }
        private ShapePoint PerigeusCheck { get; set; }
        private ShapePoint Temp { get; set; }
        private double CurRadius { get; set; }
        private double ControlRadius { get; set; }
        private Rectangle Rect { get; set; }
        private Pen blackPen { get; set; }
        public Shape_27(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {
            Apogeus = GetNewPoint();
            Perigeus = GetNewPoint();
            ApogeusCheck = GetNewPoint();
            PerigeusCheck = GetNewPoint();
            SetChord = (SetChord == 0) ? 22 : SetChord;
            pen4 = new Pen(SelectMainLineColor4(), ThiсknessArgument / 2);
            Temp = GetNewPoint();
            blackPen = new Pen(Color.Green, 1);
        }
        protected override void DrawMainLines()
        {

            Point[] curvePoints = GetFigurePoints();
            if (IsToothVector == true)
            {
                pen4.Width = ThiсknessArgument / 2;
                using (pen1 = new Pen(SelectMainLineColor1(), ThiсknessArgument / 2))
                {
                    pen1.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen1, A, B);
                }
                using (pen2 = new Pen(SelectMainLineColor2(), ThiсknessArgument / 2))
                {
                    pen2.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen2, C, D);
                }
                using (pen3 = new Pen(SelectMainLineColor3(), ThiсknessArgument / 2))
                {
                    pen3.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen3, D, A);
                }
                //using (pen4)
                //{
                pen4.Width = ThiсknessArgument / 2;
                pen4.DashStyle = DashStyle.DashDot;
                graphicsShape.DrawCurve(pen4, curvePoints, 0F);
                // }



                using (Pen pen1 = new Pen(Color.Black, 1))
                {
                    pen1.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen1, B, C);
                }
                IsToothVector = true;
            }
            else
            {
                pen4.Width = ThiсknessArgument;
                pen4.DashStyle = DashStyle.Solid;
                using (pen1 = new Pen(SelectMainLineColor1(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen1, A, B);
                }
                pen4.Width = ThiсknessArgument;
                pen4.Color = SelectMainLineColor2();
                graphicsShape.DrawCurve(pen4, curvePoints, 0F);

                using (pen2 = new Pen(SelectMainLineColor3(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen2, C, D);
                }
                using (pen3 = new Pen(SelectMainLineColor4(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen3, D, A);
                }
                using (Pen pen1 = new Pen(Color.Black, 1))
                {
                    graphicsShape.DrawLine(pen1, B, C);
                }
                IsToothVector = false;
            }

            using (GraphicsPath myPath = new GraphicsPath())
            {
                myPath.AddLine(A, B);
                myPath.AddCurve(curvePoints);
                myPath.AddLine(C, D);
                myPath.AddLine(A, D);
                graphicsShape.FillPath(new SolidBrush(Color.FromArgb(30, Color.Blue)), myPath);
            }
            MoveLines();
        }
        protected override void CheckForeignBorders()
        {
            GetExtremumPoints();
            AllowanceProcessing();
        }
        private void MoveLines()
        {
            using (Pen pen = new Pen(Color.Black, SizeLineBoundArgument))
            {
                MoveBorderLeft(W_Base, X_Base, SetB2);
                MoveBorderTop(X_Base, Y_Base, SetB3);
                MoveBorderRight(Y_Base, Z_Base, SetB1);
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
                if (flag) { ColorMarker2 = "rowCheckCut2"; SelectedSides.SetValue(2, 1); SelectedSidesLength += ArcLength(); }
                else { ColorMarker2 = ""; SelectedSides.SetValue(0, 1); SelectedSidesLength -= ArcLength(); }
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
        public override RectangleF GetShapeBorders()
        {
            using (GraphicsPath myPath = new GraphicsPath())
            {
                myPath.AddLine(A, B);
                myPath.AddCurve(GetFigurePoints());
                myPath.AddLine(C, D);
                myPath.AddLine(A, D);
                Region myRegion = new Region(myPath);
                RectangleF boundsRect = myRegion.GetBounds(graphicsShape);
                graphicsShape.DrawRectangle(Pens.Blue, new Rectangle((int)boundsRect.X,
                  (int)boundsRect.Y, (int)boundsRect.Width, (int)boundsRect.Height));
                //  graphicsShape.SetClip(myRegion, CombineMode.Replace);
                return boundsRect;
            }
        }
        protected override GraphicsPath GetShapeShprosBorders()
        {
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddLine(A, B);
            myPath.AddCurve(GetFigurePoints());
            myPath.AddLine(C, D);
            myPath.AddLine(A, D);
            return myPath;
        }
        protected override PointF[] GetBasePoints()
        {
            return new PointF[] { A, B, C, D };
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

                ShapePoint ls = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 30 * LineBoundArgument);
                ShapePoint le = GetNewCustomPoint(SetPointCurrentValueX(D), W_Base.PointY + 30 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                ShapePoint lcenter = GetNewCustomPoint(W_Base.PointX + (ll.Length / 2), W_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                graphicsShape.DrawString("L=" + SetCurrentSize(SetL), drawFontBold, Brushes.Black, lcenter, sf);

                ShapePoint b12s11 = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 30 * LineBoundArgument);
                ShapePoint b12e11 = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b12s11, b12e11);
                Line b221h = GetNewLine(b12s11, b12e11);
                ShapePoint b221scenter = GetNewCustomPoint(W_Base.PointX + b221h.Length / 2, W_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b221scenter, sf);


                ShapePoint b12s1 = GetNewCustomPoint(SetPointCurrentValueX(D), Z_Base.PointY + 30 * LineBoundArgument);
                ShapePoint b12e1 = GetNewCustomPoint(Z_Base.PointX, Z_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b12s1, b12e1);
                Line b22h = GetNewLine(b12s1, b12e1);
                ShapePoint b22scenter = GetNewCustomPoint(Z_Base.PointX - b22h.Length / 2, Z_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b22scenter, sf);

                ShapePoint bsh = GetNewCustomPoint(Z_Base.PointX + 40 * LineBoundArgument, SetPointCurrentValueY(D));
                ShapePoint beh = GetNewCustomPoint(Z_Base.PointX + 40 * LineBoundArgument, SetPointCurrentValueY(C));
                Line blh = GetNewLine(bsh, beh);
                ShapePoint bhcenter = GetNewCustomPoint(Z_Base.PointX + 40 * LineBoundArgument, Z_Base.PointY - (blh.Length / 2));
                graphicsShape.DrawLine(pen, bsh, beh);
                graphicsShape.DrawString("H=" + SetH, drawFontBold, Brushes.Black, bhcenter, sf);


                ShapePoint bsh1 = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(B));
                ShapePoint beh1 = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(A));
                Line blh1 = GetNewLine(bsh1, beh1);
                ShapePoint b1hcenter = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, W_Base.PointY - (blh1.Length / 2));
                graphicsShape.DrawLine(pen, bsh1, beh1);
                graphicsShape.DrawString("H1=" + SetH1, drawFontBold, Brushes.Black, b1hcenter, sf);

                ShapePoint b3s = GetNewCustomPoint(Y_Base.PointX + 40 * LineBoundArgument, Y_Base.PointY);
                ShapePoint b3e = GetNewCustomPoint(Y_Base.PointX + 40 * LineBoundArgument, Y_Base.PointY + SetB3);
                Line lb3 = GetNewLine(b3s, b3e);
                ShapePoint b3center = GetNewCustomPoint(Y_Base.PointX + 40 * LineBoundArgument, Y_Base.PointY + lb3.Length / 2);
                graphicsShape.DrawLine(pen, b3s, b3e);
                graphicsShape.DrawString("B3=" + SetB3, drawFontBold, Brushes.Black, b3center, sf);


                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX) / 4), ((A.PointY + B.PointY + C.PointY + D.PointY) / 4));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiknessFontArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("27", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }
                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {
                    ShapePoint wer = GetNewCustomPoint(SetPointCurrentValueX(B), Y_Base.PointY);
                    ShapePoint wer1 = GetNewCustomPoint(SetPointCurrentValueX(C), Y_Base.PointY);
                    ShapePoint wer2 = GetNewCustomPoint(Z_Base.PointX, SetPointCurrentValueY(D));
                    ShapePoint wer3 = GetNewCustomPoint(W_Base.PointX, SetPointCurrentValueY(A));
                    ShapePoint wer4 = GetNewCustomPoint(Z_Base.PointX, Y_Base.PointY + SetB3);
                    using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        graphicsShape.DrawLine(pen1, wer, SetPointCurrentType(B));
                        graphicsShape.DrawLine(pen1, wer1, SetPointCurrentType(C));
                        graphicsShape.DrawLine(pen1, wer2, SetPointCurrentType(D));
                        graphicsShape.DrawLine(pen1, wer3, SetPointCurrentType(A));
                    }
                    graphicsShape.DrawLine(pens, le, SetPointCurrentType(D));
                    graphicsShape.DrawLine(pens, ls, SetPointCurrentType(A));
                    graphicsShape.DrawLine(pens, bsh, wer2);
                    graphicsShape.DrawLine(pens, beh, SetPointCurrentType(C));
                    graphicsShape.DrawLine(pens, b12e11, W_Base);
                    if (IsToothVector == true)
                    {
                        ShapePoint wer311 = GetNewCustomPoint(PerigeusCheck.PointX, ApogeusCheck.PointY);
                        graphicsShape.DrawLine(pens, b3e, wer311);
                    }
                    else
                    {
                        ShapePoint wer311 = GetNewCustomPoint(Perigeus.PointX, Apogeus.PointY);
                        graphicsShape.DrawLine(pens, b3e, wer311);
                    }
                    graphicsShape.DrawLine(pens, b12e1, Z_Base);
                    graphicsShape.DrawLine(pens, b3s, Y_Base);
                    using (Pen pens1 = new Pen(Color.Red, SizeLineBoundArgument / 2))
                    {
                        graphicsShape.DrawLine(pens1, bsh1, SetPointCurrentType(B));
                    }
                }
            }
            #endregion
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
                CenterPoint.PointX = SetCurrentLineLength(TempPoint, CenterPoint, curLine.Length - SetChord).PointX;
                CenterPoint.PointY = SetCurrentLineLength(TempPoint, CenterPoint, curLine.Length - SetChord).PointY;
                double angleBetween = CalculateAngle(B, CenterPoint, C);
                double radiuss = l.Length / 2 - SetChord;
                double arcLength = (Math.PI * radiuss * angleBetween) / 180;

                return Math.Round((A_line.Length + C_line.Length + D_line.Length + arcLength) / 1000, 3);
            }

        }
        private double ArcLength() => Perimeter*1000 - A_line.Length - C_line.Length - D_line.Length;
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
                CenterPoint.PointX = SetCurrentLineLength(TempPoint, CenterPoint, curLine.Length - SetChord).PointX;
                CenterPoint.PointY = SetCurrentLineLength(TempPoint, CenterPoint, curLine.Length - SetChord).PointY;
                double angleBetween = CalculateAngle(BCheck, CenterPoint, CCheck);
                double radiuss = l.Length / 2 - SetChord;
                double arcLength = (Math.PI * radiuss * angleBetween) / 180;

                return Math.Round((A_Check_Line.Length + C_Check_Line.Length + D_Check_Line.Length + arcLength) / 1000, 3);
            }

        }
        public override double Area
        {
            get
            {
                Line l = GetNewLine(B, C);
                TempPoint.PointX = SetCurrentLineLength(B, C, l.Length / 2).PointX;
                TempPoint.PointY = SetCurrentLineLength(B, C, l.Length / 2).PointY;
                CenterPoint.PointX = (B.PointX - TempPoint.PointX) * Math.Cos(-1.5708) - (B.PointY - TempPoint.PointY) * Math.Sin(-1.5708) + TempPoint.PointX;
                CenterPoint.PointY = (B.PointX - TempPoint.PointX) * Math.Sin(-1.5708) + (B.PointY - TempPoint.PointY) * Math.Cos(-1.5708) + TempPoint.PointY;
                Line curLine = GetNewLine(TempPoint, CenterPoint);
                CenterPoint.PointX = SetCurrentLineLength(TempPoint, CenterPoint, curLine.Length - SetChord).PointX;
                CenterPoint.PointY = SetCurrentLineLength(TempPoint, CenterPoint, curLine.Length - SetChord).PointY;
                double angleBetween = CalculateAngle(B, CenterPoint, C);
                double radiuss = l.Length / 2 - SetChord;
                double segmentArea = (Math.Pow(radiuss, 2) / 2) * (angleBetween * Math.PI / 180 - Math.Sin(angleBetween * Math.PI / 180));

                double baseSquare = 0.5 * Math.Abs((A.PointX * B.PointY + B.PointX * C.PointY + C.PointX * D.PointY + D.PointX * A.PointY) - (B.PointX * A.PointY + C.PointX * B.PointY + D.PointX * C.PointY + A.PointX * D.PointY));
                return Math.Round((baseSquare + segmentArea) / 1000000, 3);
            }
        }
        public override double TrueArea
        {
            get
            {
                Line l = GetNewLine(BCheck, CCheck);
                TempPoint.PointX = SetCurrentLineLength(BCheck, CCheck, l.Length / 2).PointX;
                TempPoint.PointY = SetCurrentLineLength(BCheck, CCheck, l.Length / 2).PointY;
                CenterPoint.PointX = (BCheck.PointX - TempPoint.PointX) * Math.Cos(-1.5708) - (BCheck.PointY - TempPoint.PointY) * Math.Sin(-1.5708) + TempPoint.PointX;
                CenterPoint.PointY = (BCheck.PointX - TempPoint.PointX) * Math.Sin(-1.5708) + (BCheck.PointY - TempPoint.PointY) * Math.Cos(-1.5708) + TempPoint.PointY;
                Line curLine = GetNewLine(TempPoint, CenterPoint);
                CenterPoint.PointX = SetCurrentLineLength(TempPoint, CenterPoint, curLine.Length - SetChord + CheckCut2).PointX;
                CenterPoint.PointY = SetCurrentLineLength(TempPoint, CenterPoint, curLine.Length - SetChord + CheckCut2).PointY;
                double angleBetween = CalculateAngle(BCheck, CenterPoint, CCheck);
                double radiuss = l.Length / 2 - SetChord + CheckCut2;
                double segmentArea = (Math.Pow(radiuss, 2) / 2) * (angleBetween * Math.PI / 180 - Math.Sin(angleBetween * Math.PI / 180));

                double baseSquare = 0.5 * Math.Abs((ACheck.PointX * BCheck.PointY + BCheck.PointX * CCheck.PointY + CCheck.PointX * DCheck.PointY + DCheck.PointX * ACheck.PointY) -
                    (BCheck.PointX * ACheck.PointY + CCheck.PointX * BCheck.PointY + DCheck.PointX * CCheck.PointY + ACheck.PointX * DCheck.PointY));
                return Math.Round((baseSquare + segmentArea) / 1000000, 3);
            }
        }
        public override double SetL { get => Math.Round(D_line.Length, 0); set => base.SetL = value; }
        public override double SetH { get => Math.Round(C_line.Length, 0); set => base.SetH = value; }
        public override double SetH1 { get => Math.Round(A_line.Length, 0); set => base.SetH1 = value; }
        public override double SetL_t { get => Math.Round(D_Check_Line.Length, 0); }
        public override double SetH_t { get => Math.Round(C_Check_Line.Length, 0); }
        public override double SetH1_t { get => Math.Round(A_Check_Line.Length, 0); }
        public override double SetChord_t { get => SetChord + CheckCut2; }
        protected override void SetHValue()
        {
            base.SetHValue();
          //  Move(0, SetChord + CheckCut2 + SetB3);
            TempPoint.PointX = SetCurrentLineLength(C, D, _SetH).PointX;
            TempPoint.PointY = SetCurrentLineLength(C, D, _SetH).PointY;
            double diff = D.PointY - TempPoint.PointY;
            B.PointY -= diff;
            D.PointX = TempPoint.PointX;
            D.PointY = TempPoint.PointY;
            A.PointY = D.PointY;
            ValidValue = false;
        }
        protected override void SetH1Value()
        {
            base.SetH1Value();
            B.PointX = SetCurrentLineLength(A, B, _SetH1).PointX;
            B.PointY = SetCurrentLineLength(A, B, _SetH1).PointY;
            ValidValue = false;
        }
        protected override void SetLValue()
        {
            base.SetLValue();

            D.PointX = SetCurrentLineLength(A, D, _SetL).PointX;
            D.PointY = SetCurrentLineLength(A, D, _SetL).PointY;
            C.PointX = D.PointX;
            ValidValue = false;
        }
        public override Point[] GetFigurePoints()
        {
            // Move(0, SetChord);
            #region Получаем угол ВСА для определения длины дуги скругления стороны АВ и уравниваем AC и BC
            Line l = GetNewLine(B, C);
            TempPoint.PointX = SetCurrentLineLength(B, C, l.Length / 2).PointX;
            TempPoint.PointY = SetCurrentLineLength(B, C, l.Length / 2).PointY;
            double alpha = 2 * Math.Atan((2 * SetChord) / l.Length);
            double payLength = l.Length * (alpha / Math.Sin(alpha));
            double radius = payLength / alpha / 2;
            radius = (radius == 0) ? 1 : radius;
            double r = radius - SetChord;
            ControlRadius = radius;
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
                var M = Math.Pow(TempPoint.PointX, 2) - 2 * TempPoint.PointY * SecondKatet + Math.Pow(TempPoint.PointY, 2) + Math.Pow(SecondKatet, 2) - Math.Pow(r, 2);
                CenterPoint.PointX = (-N + r * Math.Sqrt(Math.Pow(N, 2) - 2 * P * M)) / P;
                CenterPoint.PointY = SecondKatet - FirstKatet * CenterPoint.PointX;

            }

            CenterPoint = SetCurrentLineLength(TempPoint, CenterPoint, r);
            Temp.PointX = CenterPoint.PointX;
            Temp.PointY = CenterPoint.PointY;
            double angleBetween = CalculateAngle(B, CenterPoint, C);
            #endregion
            List<Point> pointsList = new List<Point> { B };

            double degree = 0;
            while (degree <= angleBetween)
            {

                CurvePoint.PointX = (B.PointX - CenterPoint.PointX) * Math.Cos(degree * Math.PI / 180) -
                                    (B.PointY - CenterPoint.PointY) * Math.Sin(degree * Math.PI / 180) + CenterPoint.PointX;
                CurvePoint.PointY = (B.PointX - CenterPoint.PointX) * Math.Sin(degree * Math.PI / 180) +
                                    (B.PointY - CenterPoint.PointY) * Math.Cos(degree * Math.PI / 180) + CenterPoint.PointY;
                pointsList.Add(CurvePoint);
                degree += 1;
            }
            pointsList.Add(C);

            Point[] points = new Point[pointsList.Count];
            Array.Copy(pointsList.ToArray(), points, pointsList.Count);
            pointsList.Clear();
            var PointXMax = points.Max(PointX => PointX.X);
            var yMax = points.Max(PointX => PointX.Y);
            var PointXMin = points.Min(PointX => PointX.X);
            var yMin = points.Min(PointX => PointX.Y);
            Apogeus.PointX = PointXMin;
            Apogeus.PointY = yMin;
            Perigeus.PointX = PointXMax;
            Perigeus.PointY = yMax;
            Point[] origin_points = points.Distinct().ToArray();
            return origin_points;
        }
        private Point[] GetFigureCheckPoints()
        {
            #region 
            var r = ControlRadius + CheckCut2;
            if (BCheck.PointY == TempPoint.PointY)
            {
                CenterPoint.PointX = TempPoint.PointX;
                CenterPoint.PointY = TempPoint.PointY + r;
            }
            else
            {
                CenterPoint.PointX = Temp.PointX;
                CenterPoint.PointY = Temp.PointY;

            }

            using (GraphicsPath graphicsPath = new GraphicsPath())
            {

                blackPen.DashStyle = DashStyle.DashDot;
                Rect = new Rectangle((int)(CenterPoint.PointX - r), (int)(CenterPoint.PointY - r), (int)r * 2, (int)r * 2);
                //  graphicsShape.DrawEllipse(blackPen, rect);
                double i = DCheck.PointY - A_Check_Line.Length / 2;
                double i1 = DCheck.PointY - A_Check_Line.Length / 2;
                graphicsPath.AddEllipse(Rect);
                while (true)
                {
                    i -= 1;
                    if (graphicsPath.IsOutlineVisible((float)BCheck.PointX, (float)BCheck.PointY, blackPen)) { i = 0; break; }
                    BCheck.PointY = i;
                }
                while (true)
                {
                    i1 -= 1;
                    if (graphicsPath.IsOutlineVisible((float)CCheck.PointX, (float)CCheck.PointY, blackPen)) { i1 = 0; break; }
                    CCheck.PointY = i1;
                }
            }

            double angleBetween = CalculateAngle(BCheck, CenterPoint, CCheck);
            #endregion
            List<Point> pointsList = new List<Point> { BCheck };

            double degree = 0;
            while (degree <= angleBetween)
            {
                /*degree * Math.PI / 180*/

                CurvePoint.PointX = (BCheck.PointX - CenterPoint.PointX) * Math.Cos(degree * Math.PI / 180) -
                    (BCheck.PointY - CenterPoint.PointY) * Math.Sin(degree * Math.PI / 180) + CenterPoint.PointX;
                CurvePoint.PointY = (BCheck.PointX - CenterPoint.PointX) * Math.Sin(degree * Math.PI / 180) +
                    (BCheck.PointY - CenterPoint.PointY) * Math.Cos(degree * Math.PI / 180) + CenterPoint.PointY;
                pointsList.Add(CurvePoint);
                degree += 1;
            }
            pointsList.Add(CCheck);
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
            Point[] origin_points = points.Distinct().ToArray();
            return origin_points;
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
            var i = C.PointY - 300;
            var curvePoints = GetFigurePoints();
            _CheckCut1 = (IsToothVector == false && _CheckCut1 >= 0) ? _CheckCut1 * (-1) : _CheckCut1;
            _CheckCut2 = (IsToothVector == false && _CheckCut2 >= 0) ? _CheckCut2 * (-1) : _CheckCut2;
            _CheckCut3 = (IsToothVector == false && _CheckCut3 >= 0) ? _CheckCut3 * (-1) : _CheckCut3;
            _CheckCut4 = (IsToothVector == false && _CheckCut4 >= 0) ? _CheckCut4 * (-1) : _CheckCut4;
            _CheckCut1 = (IsToothVector == true && _CheckCut1 < 0) ? _CheckCut1 * (-1) : _CheckCut1;
            _CheckCut2 = (IsToothVector == true && _CheckCut2 < 0) ? _CheckCut2 * (-1) : _CheckCut2;
            _CheckCut3 = (IsToothVector == true && _CheckCut3 < 0) ? _CheckCut3 * (-1) : _CheckCut3;
            _CheckCut4 = (IsToothVector == true && _CheckCut4 < 0) ? _CheckCut4 * (-1) : _CheckCut4;
            diag1 = (diag1 <= 90) ? _CheckCut1 / Math.Sin(CalculateAngle(D, A, B) * Math.PI / 180) :
                (90 - ((180 - _CheckCut1 / Math.Sin(CalculateAngle(D, A, B)) * Math.PI / 180)));
            diag11 = (diag11 <= 90) ? _CheckCut1 / Math.Sin(CalculateAngle(A, B, C) * Math.PI / 180) :
                (90 - ((180 - _CheckCut1 / Math.Sin(CalculateAngle(A, B, C)) * Math.PI / 180)));
            diag2 = (diag2 <= 90) ? _CheckCut2 / Math.Sin(CalculateAngle(A, B, C) * Math.PI / 180) :
                (90 - ((180 - _CheckCut2 / Math.Sin(CalculateAngle(A, B, C)) * Math.PI / 180)));
            diag21 = (diag21 <= 90) ? _CheckCut2 / Math.Sin(CalculateAngle(B, C, D) * Math.PI / 180) :
                (90 - ((180 - _CheckCut2 / Math.Sin(CalculateAngle(B, C, D)) * Math.PI / 180)));
            diag3 = (diag3 <= 90) ? _CheckCut3 / Math.Sin(CalculateAngle(B, C, D) * Math.PI / 180) :
                (90 - ((180 - _CheckCut3 / Math.Sin(CalculateAngle(B, C, D)) * Math.PI / 180)));
            diag31 = (diag31 <= 90) ? _CheckCut3 / Math.Sin(CalculateAngle(C, D, A) * Math.PI / 180) :
                (90 - ((180 - _CheckCut3 / Math.Sin(CalculateAngle(C, D, A)) * Math.PI / 180)));
            diag4 = (diag4 <= 90) ? _CheckCut4 / Math.Sin(CalculateAngle(C, D, A) * Math.PI / 180) :
                (90 - ((180 - _CheckCut4 / Math.Sin(CalculateAngle(C, D, A)) * Math.PI / 180)));
            diag41 = (diag41 <= 90) ? _CheckCut4 / Math.Sin(CalculateAngle(D, A, B) * Math.PI / 180) :
                (90 - ((180 - _CheckCut4 / Math.Sin(CalculateAngle(D, A, B)) * Math.PI / 180)));
            if (IsToothVector == true)
            {
                ACheck.PointY = SetCurrentLineLength(DCheck, ACheck, diag1 + D_Check_Line.Length).PointY;
                ACheck.PointX = SetCurrentLineLength(DCheck, ACheck, diag1 + D_Check_Line.Length).PointX;
                BCheck.PointY = SetCurrentLineLength(CCheck, BCheck, diag11 + B_Check_Line.Length).PointY;
                BCheck.PointX = SetCurrentLineLength(CCheck, BCheck, diag11 + B_Check_Line.Length).PointX;

                CCheck.PointX = SetCurrentLineLength(BCheck, CCheck, diag3 + B_Check_Line.Length).PointX;
                CCheck.PointY = SetCurrentLineLength(BCheck, CCheck, diag3 + B_Check_Line.Length).PointY;
                DCheck.PointX = SetCurrentLineLength(ACheck, DCheck, diag31 + D_Check_Line.Length).PointX;
                DCheck.PointY = SetCurrentLineLength(ACheck, DCheck, diag31 + D_Check_Line.Length).PointY;

                DCheck.PointY = SetCurrentLineLength(CCheck, DCheck, diag4 + C_Check_Line.Length).PointY;
                DCheck.PointX = SetCurrentLineLength(CCheck, DCheck, diag4 + C_Check_Line.Length).PointX;
                ACheck.PointY = SetCurrentLineLength(BCheck, ACheck, diag41 + A_Check_Line.Length).PointY;
                ACheck.PointX = SetCurrentLineLength(BCheck, ACheck, diag41 + A_Check_Line.Length).PointX;

                using (Pen penCut = new Pen(Color.Red, ThiсknessArgument))
                {
                    graphicsShape.DrawCurve(penCut, GetFigureCheckPoints(), 0F);
                    graphicsShape.DrawLine(penCut, ACheck, BCheck);
                    graphicsShape.DrawLine(penCut, CCheck, DCheck);
                    graphicsShape.DrawLine(penCut, DCheck, ACheck);
                    IsToothVector = true;
                }
            }
            else
            {
                DCheck.PointX = SetCurrentLineLength(ACheck, DCheck, diag31 + D_Check_Line.Length).PointX;
                DCheck.PointY = SetCurrentLineLength(ACheck, DCheck, diag31 + D_Check_Line.Length).PointY;
                CCheck.PointX = SetCurrentLineLength(BCheck, CCheck, diag3 + B_Check_Line.Length).PointX;
                using (GraphicsPath graphicsPath = new GraphicsPath())
                {
                    graphicsPath.AddCurve(curvePoints);
                    while (i < B.PointY)
                    {
                        i += 1;
                        if (graphicsPath.IsOutlineVisible((float)CCheck.PointX, (float)CCheck.PointY, pen4)) { i = 0; break; }
                        CCheck.PointY = i;
                    }
                }
                ACheck.PointX = SetCurrentLineLength(DCheck, ACheck, diag1 + D_Check_Line.Length).PointX;
                ACheck.PointY = SetCurrentLineLength(DCheck, ACheck, diag1 + D_Check_Line.Length).PointY;
                BCheck.PointX = SetCurrentLineLength(CCheck, BCheck, diag11 + B_Check_Line.Length).PointX;
                using (GraphicsPath graphicsPath1 = new GraphicsPath())
                {
                    graphicsPath1.AddCurve(curvePoints);
                    while (i < B.PointY)
                    {
                        i += 1;
                        if (graphicsPath1.IsVisible(BCheck)) { i = 0; break; }
                        BCheck.PointY = i;
                    }
                }
                DCheck.PointY = SetCurrentLineLength(CCheck, DCheck, diag4 + C_Check_Line.Length).PointY;
                DCheck.PointX = SetCurrentLineLength(CCheck, DCheck, diag4 + C_Check_Line.Length).PointX;
                ACheck.PointY = SetCurrentLineLength(BCheck, ACheck, diag41 + A_Check_Line.Length).PointY;
                ACheck.PointX = SetCurrentLineLength(BCheck, ACheck, diag41 + A_Check_Line.Length).PointX;
                using (Pen penCut = new Pen(Color.Red, ThiсknessArgument / 2))
                {
                    penCut.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawCurve(penCut, GetFigureCheckPoints(), 0F);
                    graphicsShape.DrawLine(penCut, ACheck, BCheck);
                    graphicsShape.DrawLine(penCut, CCheck, DCheck);
                    graphicsShape.DrawLine(penCut, DCheck, ACheck);
                    IsToothVector = false;
                }
            }
            GetExtremumPoints();
        }
        public override void GetExtremumPoints()
        {

            List<ShapePoint> pointList = new List<ShapePoint>() { A, B, C, D, Apogeus, Perigeus, ACheck, BCheck, CCheck, DCheck, ApogeusCheck, PerigeusCheck };

            var PointXMax = pointList.Max(PointX => PointX.PointX);
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
            double diag = 0;
            diag = (diag <= 90)
                ? CheckCut2 / Math.Sin(CalculateAngle(A, B, C) * Math.PI / 180)
                : (90 - ((180 - CheckCut2 / Math.Sin(CalculateAngle(A, B, C)) * Math.PI / 180)));
            diag = (!IsToothVector == true) ? 0 : diag;
            var value1 = (IsToothVector == true) ? _CheckCut1 : 0;
            var value2 = (IsToothVector == true) ? _CheckCut2 : 0;
            var value3 = (IsToothVector == true) ? _CheckCut3 : 0;
            var value4 = (IsToothVector == true) ? _CheckCut4 : 0;
            var width = _SetL + _SetB2 + SetB1 + value1 + value3;
            var height = _SetH + _SetChord + value2 + value4 + SetB3;

            if (_SetH < 0 || _SetH1 < 0 || _SetL < 0 || _SetB1 < 0 || _SetB2 < 0 || _SetB3 < 0)
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
            else if (SetH1 < (((_SetH + SetH1) / 2.0) - (((((SetL * SetL) + ((SetH1 - _SetH)
                * (SetH1 - SetH))) / (8.0 * SetChord)) - (SetChord / 2)) * (SetL / (Math.Sqrt((SetL * SetL) + ((SetH1 - _SetH) * (_SetH1 - _SetH))))))))
            {
                ValidValue = true;
                ValidateSetSizeMessage($"Значение 'Н' за пределами допустимого диапазона.");
            }
            else if (SetH1 < (((SetH + SetH1) / 2.0) - (((((SetL * SetL) + ((SetH1 - SetH)
                * (SetH1 - SetH))) / (8.0 * _SetChord)) - (_SetChord / 2)) *
                (SetL / (Math.Sqrt((SetL * SetL) + ((SetH1 - SetH) * (SetH1 - SetH))))))))
            {
                ValidValue = true;
                ValidateSetSizeMessage($"Значение '*R' за пределами допустимого диапазона.");
            }
            else if (_SetH1 < (((SetH + _SetH1) / 2.0) - (((((SetL * SetL) + ((_SetH1 - SetH)
               * (_SetH1 - SetH))) / (8.0 * SetChord)) - (SetChord / 2)) *
               (SetL / (Math.Sqrt((SetL * SetL) + ((_SetH1 - SetH) * (_SetH1 - SetH))))))))
            {
                ValidValue = true;
                ValidateSetSizeMessage($"Значение 'Н1' за пределами допустимого диапазона.");
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetChord");
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetChord_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsToothVector");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsSelectSameAllowance");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut1");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut2");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut3");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut4");
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