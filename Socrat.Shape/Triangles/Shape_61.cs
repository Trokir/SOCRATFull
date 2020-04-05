using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using DevExpress.XtraVerticalGrid.Events;
using Socrat.Core.Entities;

namespace Socrat.Shape.Triangles
{
    sealed class Shape_61 : Triangle
    {
        private ShapePoint Apogeus { get; set; }
        private ShapePoint Perigeus { get; set; }
        private ShapePoint ApogeusCheck { get; set; }
        private ShapePoint PerigeusCheck { get; set; }
        private double curRadius { get; set; }
        private double controlRadius { get; set; }
        private ShapePoint Temp { get; }
        private ShapePoint Tempt { get; }
        private Pen BlackPen { get; }
        private double angle { get; set; }
        private bool StartAllow { get; set; }
        public Shape_61(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {
            Apogeus = GetNewPoint();
            Perigeus = GetNewPoint();
            ApogeusCheck = GetNewPoint();
            PerigeusCheck = GetNewPoint();
            Temp = GetNewPoint();
            Tempt = GetNewPoint();
            BlackPen = new Pen(Color.Green, 1);
            StartAllow = true;
        }
        protected override PointF[] GetBasePoints()
        {
            return new PointF[] { A, B, C };
        }
        protected override void DrawMainLines()
        {
            var curvePoints = GetFigurePoints();
            if (IsToothVector == true)
            {
                using (pen1 = new Pen(SelectMainLineColor1(), ThiсknessArgument / 2))
                {
                    pen1.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen1, A, B);
                }
                using (pen2 = new Pen(SelectMainLineColor2(), ThiсknessArgument / 2))
                {
                    pen2.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawCurve(pen2, curvePoints, 0F);
                }
                using (pen3 = new Pen(SelectMainLineColor3(), ThiсknessArgument / 2))
                {
                    pen3.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen3, A, C);
                }

                IsToothVector = true;
            }
            else
            {
                using (pen1 = new Pen(SelectMainLineColor1(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen1, A, B);
                }
                using (pen2 = new Pen(SelectMainLineColor2(), ThiсknessArgument))
                {
                    graphicsShape.DrawCurve(pen2, curvePoints, 0F);
                }
                using (pen3 = new Pen(SelectMainLineColor3(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen3, A, C);
                }

                IsToothVector = false;
            }
            using (GraphicsPath myPath = new GraphicsPath())
            {
                myPath.AddLine(A, B);
                myPath.AddCurve(curvePoints);
                myPath.AddLine(A, C);
                graphicsShape.FillPath(new SolidBrush(Color.FromArgb(30, Color.Blue)), myPath);
            }
            MoveLines();
        }
        protected override void CheckForeignBorders()
        {
            DrawMainLines();
            GetExtremumPoints();
            AllowanceProcessing();
        }

        private void MoveLines()
        {
            using (var pen = new Pen(Color.Black, SizeLineBoundArgument))
            {
               
                MoveBorderLeft(W_Base, X_Base, SetB1);
                MoveBorderTop(X_Base, Y_Base, SetB3);
                MoveBorderRight(Y_Base, Z_Base, SetB3);
                MoveBorderBottom(W_Base, Z_Base, SetB2);
            }
        }

        public override void GetShapeComponents()
        {
            #region BasePath
            using (var pen = new Pen(Color.Black, SizeLineBoundArgument))
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

                ShapePoint b1s = GetNewCustomPoint(W_Base.PointX + SetB1, W_Base.PointY + 20 * LineBoundArgument);
                ShapePoint b1e = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 20 * LineBoundArgument);
                Line lb1 = GetNewLine(b1s, b1e);
                ShapePoint b1center = GetNewCustomPoint(W_Base.PointX + (lb1.Length / 2), W_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s, b1e);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b1center, sf);

                ShapePoint b1s1 = GetNewCustomPoint(Z_Base.PointX - SetB3, W_Base.PointY + 20 * LineBoundArgument);
                ShapePoint b1e1 = GetNewCustomPoint(Z_Base.PointX, Z_Base.PointY + 20 * LineBoundArgument);
                Line lb11 = GetNewLine(b1s1, b1e1);
                ShapePoint b11center = GetNewCustomPoint(Z_Base.PointX - (lb1.Length / 2), Z_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s1, b1e1);
                graphicsShape.DrawString("B3=" + SetB3, drawFontBold, Brushes.Black, b11center, sf);

                ShapePoint b1s2 = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, W_Base.PointY);
                ShapePoint b1e2 = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, W_Base.PointY - SetB2);
                Line lb12 = GetNewLine(b1s2, b1e2);
                ShapePoint b12center = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, Z_Base.PointY - (lb12.Length / 2));
                graphicsShape.DrawLine(pen, b1s2, b1e2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b12center, sf);


                ShapePoint b2s = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, X_Base.PointY);
                ShapePoint b2e = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, X_Base.PointY + SetB3);
                graphicsShape.DrawLine(pen, b2s, b2e);
                Line b2h = GetNewLine(b2s, b2e);
                ShapePoint b2scenter = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, X_Base.PointY + b2h.Length / 2);
                graphicsShape.DrawString("B3=" + SetB3, drawFontBold, Brushes.Black, b2scenter, sf);


                ShapePoint ls = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 20 * LineBoundArgument);
                ShapePoint le = GetNewCustomPoint(SetPointCurrentValueX(C), W_Base.PointY + 20 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                ShapePoint lcenter = GetNewCustomPoint(SetPointCurrentValueX(A) + (ll.Length / 2), W_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);

                graphicsShape.DrawString("L=" + SetCurrentSize(SetL), drawFontBold, Brushes.Black, lcenter, sf);


                ShapePoint hs = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(A));
                ShapePoint he = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(B));
                Line hl = GetNewLine(hs, he);
                ShapePoint hlcenter = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, W_Base.PointY - (hl.Length / 2));
                graphicsShape.DrawLine(pen, hs, he);
                if (hl.Length > 8)
                {
                    graphicsShape.DrawString("H=" + SetCurrentSize(SetH), drawFontBold, Brushes.Black, hlcenter, sf);
                }

                using (Pen penr = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Far;

                    penr.StartCap = LineCap.RoundAnchor;
                    penr.EndCap = LineCap.ArrowAnchor;
                    penr.DashStyle = DashStyle.Solid;
                    ShapePoint rs = GetNewCustomPoint(W_Base.PointX + C_line.Length / 4, Z_Base.PointY - 40 * LineBoundArgument);
                    ShapePoint re = SetCurrentLineLength(SetPointCurrentType(B), SetPointCurrentType(C), C_line.Length / 2);
                    Line lr = GetNewLine(rs, re);
                    ShapePoint brcenter = GetNewCustomPoint(W_Base.PointX + C_line.Length / 4, Z_Base.PointY - (lr.Length / 1.3));
                    graphicsShape.DrawLine(penr, rs, re);
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Far;
                    graphicsShape.DrawString("R=" + SetCurrentSize(SetRadius), drawFontBold, Brushes.Black, brcenter, sf);

                }



                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX) / 3), ((A.PointY + B.PointY + C.PointY) / 3));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiknessFontArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("61", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }



                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {

                    ShapePoint wer1 = GetNewCustomPoint(SetPointCurrentValueX(B), X_Base.PointY);
                    ShapePoint wer2 = GetNewCustomPoint(Z_Base.PointX, SetPointCurrentValueY(C));

                    using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        graphicsShape.DrawLine(pen1, wer1, SetPointCurrentType(B));
                        graphicsShape.DrawLine(pen1, wer2, SetPointCurrentType(C));
                    }

                    graphicsShape.DrawLine(pens, b2s, Y_Base);

                    using (Pen pens1 = new Pen(Color.Red, SizeLineBoundArgument / 2))
                    {
                        graphicsShape.DrawLine(pens1, he, SetPointCurrentType(B));

                    }
                    graphicsShape.DrawLine(pens, ls, SetPointCurrentType(A));
                    graphicsShape.DrawLine(pens, le, SetPointCurrentType(C));
                    graphicsShape.DrawLine(pens, hs, SetPointCurrentType(C));
                    graphicsShape.DrawLine(pens, b1e, W_Base);
                    graphicsShape.DrawLine(pens, b1e1, Z_Base);
                    graphicsShape.DrawLine(pens, b1s2, Z_Base);


                }
            }

            #endregion
        }
        public override RectangleF GetShapeBorders()
        {
            using (GraphicsPath myPath = new GraphicsPath())
            {
                myPath.AddLine(A, B);
                myPath.AddCurve(GetFigurePoints());
                myPath.AddLine(A, C);

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
            if (ThicknessPath(A, C).IsVisible(point))
            {
                if (flag) { ColorMarker3 = "rowCheckCut3"; SelectedSides.SetValue(3, 2); SelectedSidesLength += C_line.Length; }
                else { ColorMarker3 = ""; SelectedSides.SetValue(0, 2); SelectedSidesLength -= C_line.Length; }
            }

            else return;
        }

        protected override GraphicsPath GetShapeShprosBorders()
        {
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddLine(A, B);
            myPath.AddCurve(GetFigurePoints());
            myPath.AddLine(A, C);
            return myPath;
        }
        public override double Area => Math.Round((Math.PI * Math.Pow(A_line.Length, 2) / 4) / 1000000, 3);
        public override double TrueArea => Math.Round((Math.PI * Math.Pow(A_Check_Line.Length, 2) / 4) / 1000000, 3);
        public override double Perimeter
        {
            get
            {
                var arc = (2 * Math.PI * A_line.Length) / 4;

                return Math.Round((A_line.Length + C_line.Length + arc) / 1000, 3);
            }
        }
        private double ArcLength() => Perimeter * 1000 - A_line.Length - C_line.Length;
        public override double Perimeter_t
        {
            get
            {
                var arc = (2 * Math.PI * A_line.Length) / 4;

                return Math.Round((A_Check_Line.Length + C_Check_Line.Length + arc) / 1000, 3);
            }
        }
        public override double SetH { get => Math.Round(A_line.Length, 0); set => base.SetH = value; }
        public override double SetL { get => Math.Round(C_line.Length, 0); set => base.SetL = value; }
        protected override void SetRadiusValue()
        {
            base.SetRadiusValue();
            StartAllow = true;
            ValidValue = false;
        }
        public override double SetH_t => Math.Round(A_Check_Line.Length, 0);
        public override double SetL_t => Math.Round(C_Check_Line.Length, 0);
        public override double SetRadius_t => Math.Round(SetRadius + CheckCut2, 0);
        protected override void SetHValue()
        {
            base.SetHValue();
            B.PointX = A.PointX;
            A.PointX = SetCurrentLineLength(B, A, _SetH).PointX;
            A.PointY = SetCurrentLineLength(B, A, _SetH).PointY;
            C.PointY = A.PointY;
            ValidValue = false;
            StartAllow = true;

        }
        protected override void SetLValue()
        {
            base.SetLValue();
            C.PointX = SetCurrentLineLength(A, C, _SetL).PointX;
            ValidValue = false;
            StartAllow = true;
        }
        public override Point[] GetFigurePoints()
        {
            #region Получаем угол ВСА для определения длины дуги скругления стороны АВ и уравниваем AC и BC
            var l = GetNewLine(B, C);

            TempPoint.PointX = SetCurrentLineLength(B, C, l.Length / 2).PointX;
            TempPoint.PointY = SetCurrentLineLength(B, C, l.Length / 2).PointY;

            var height = SetRadius - Math.Sqrt(Math.Pow(SetRadius, 2) - ((Math.Pow(l.Length, 2)) / 4));
            var r = SetRadius - height;
            controlRadius = r;
            var FirstKatet = (B.PointX - TempPoint.PointX) / (B.PointY - TempPoint.PointY);
            var SecondKatet = FirstKatet * TempPoint.PointX + TempPoint.PointY;
            var P = 2 * (Math.Pow(FirstKatet, 2) + 1);
            var N = 2 * (TempPoint.PointY * FirstKatet - TempPoint.PointX - FirstKatet * SecondKatet);
            var M = Math.Pow(TempPoint.PointX, 2) - 2 * TempPoint.PointY * SecondKatet + Math.Pow(TempPoint.PointY, 2) + Math.Pow(SecondKatet, 2) - Math.Pow(r, 2);
            #endregion
            curRadius = SetRadius;

            CenterPoint.PointX = (-N - r * Math.Sqrt(Math.Pow(N, 2) - 2 * P * M)) / P;
            CenterPoint.PointY = SecondKatet - FirstKatet * CenterPoint.PointX;
            CenterPoint = SetCurrentLineLength(TempPoint, CenterPoint, r);
            Temp.PointX = CenterPoint.PointX;
            Temp.PointY = CenterPoint.PointY;
            var angleBetween = CalculateAngle(B, CenterPoint, C);
            angle = angleBetween;


            var pointsList = new List<Point> { B };
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




            var points = new Point[pointsList.Count];
            Array.Copy(pointsList.ToArray(), points, pointsList.Count);
            pointsList.Clear();
            var PointXMax = points.Max(PointX => PointX.X);
            var yMax = points.Max(PointX => PointX.Y);
            var xMin = points.Min(PointX => PointX.X);
            var yMin = points.Min(PointX => PointX.Y);
            Apogeus.PointX = xMin;
            Apogeus.PointY = yMin;
            Perigeus.PointX = PointXMax;
            Perigeus.PointY = yMax;
            var diff = Apogeus.PointY - 150;
            if (Apogeus.PointY < B.PointY)
            {
                Move(y: -diff);
            }
            return points;
        }
        public override Point[] GetFigureToothPoints()
        {
            List<Point> pointsList = null;
            pointsList = new List<Point> { BCheck };
            double degree = 0;
            var angleBetween = CalculateAngle(BCheck, Temp, CCheck);
            while (degree <= angleBetween)
            {
                CurvePoint.PointX = (BCheck.PointX - Temp.PointX) * Math.Cos(degree * Math.PI / 180) -
                                    (BCheck.PointY - Temp.PointY) * Math.Sin(degree * Math.PI / 180) + Temp.PointX;
                CurvePoint.PointY = (BCheck.PointX - Temp.PointX) * Math.Sin(degree * Math.PI / 180) +
                                    (BCheck.PointY - Temp.PointY) * Math.Cos(degree * Math.PI / 180) + Temp.PointY;
                if (CurvePoint.PointX > 0 && CurvePoint.PointY > 0)
                {
                    pointsList.Add(CurvePoint);
                }

                degree += 1;
            }
            if (CCheck.PointX > 0 && CCheck.PointY > 0)
            {
                pointsList.Add(CCheck);
            }

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
            Point[] origin_points = points.Distinct().ToArray();
            return origin_points;

        }
        public override void GetExtremumPoints()
        {

            List<ShapePoint> pointList = new List<ShapePoint>() { A, B, C, Apogeus, Perigeus, ApogeusCheck, PerigeusCheck };

            var PointXMax = pointList.Max(PointX => PointX.PointX);
            var yMax = pointList.Max(PointX => PointX.PointY);
            var PointXMin = pointList.Min(PointX => PointX.PointX);
            var yMin = pointList.Min(PointX => PointX.PointY);
            W_Base = new ShapePoint(PointXMin, yMax);
            X_Base = new ShapePoint(PointXMin, yMin);
            Y_Base = new ShapePoint(PointXMax, yMin);
            Z_Base = new ShapePoint(PointXMax, yMax);

        }
        protected override void AllowanceProcessing()
        {

            ACheck.PointX = A.PointX;
            ACheck.PointY = A.PointY;
            BCheck.PointX = B.PointX;
            BCheck.PointY = B.PointY;
            CCheck.PointX = C.PointX;
            CCheck.PointY = C.PointY;
            _CheckCut1 = (IsToothVector == false && _CheckCut1 >= 0) ? _CheckCut1 * (-1) : _CheckCut1;
            _CheckCut2 = (IsToothVector == false && _CheckCut2 >= 0) ? _CheckCut2 * (-1) : _CheckCut2;
            _CheckCut3 = (IsToothVector == false && _CheckCut3 >= 0) ? _CheckCut3 * (-1) : _CheckCut3;
            _CheckCut1 = (IsToothVector == true && _CheckCut1 < 0) ? _CheckCut1 * (-1) : _CheckCut1;
            _CheckCut2 = (IsToothVector == true && _CheckCut2 < 0) ? _CheckCut2 * (-1) : _CheckCut2;
            _CheckCut3 = (IsToothVector == true && _CheckCut3 < 0) ? _CheckCut3 * (-1) : _CheckCut3;
            MoveCurve();

            MoveLeftSide();

            MoveBottomSide();
            using (var penCut = new Pen(Color.Red))
            {
                if (IsToothVector == true)
                {
                    penCut.Width = ThiсknessArgument;
                    IsToothVector = true;
                }
                else
                {
                    penCut.Width = ThiсknessArgument / 2;
                    penCut.DashStyle = DashStyle.DashDot;
                    IsToothVector = false;

                }

                graphicsShape.DrawCurve(penCut, GetFigureToothPoints(), 0F);
                graphicsShape.DrawLine(penCut, ACheck, BCheck);
                graphicsShape.DrawLine(penCut, ACheck, CCheck);
            }
            GetExtremumPoints();
        }
        private void MoveCurve()
        {
            if (StartAllow)
            {
                BCheck.PointY = SetCurrentLineLength(ACheck, BCheck, _CheckCut2 + A_Check_Line.Length).PointY;
                BCheck.PointX = SetCurrentLineLength(ACheck, BCheck, _CheckCut2 + A_Check_Line.Length).PointX;
                CCheck.PointY = SetCurrentLineLength(ACheck, CCheck, _CheckCut2 + C_Check_Line.Length).PointY;
                CCheck.PointX = SetCurrentLineLength(ACheck, CCheck, _CheckCut2 + C_Check_Line.Length).PointX;
            }

        }
        private void MoveBottomSide()
        {
            if (StartAllow)
            {
                ACheck.PointY = SetCurrentLineLength(BCheck, ACheck, _CheckCut3 + A_Check_Line.Length).PointY;
                ACheck.PointX = SetCurrentLineLength(BCheck, ACheck, _CheckCut3 + A_Check_Line.Length).PointX;
                CCheck.PointY = ACheck.PointY;
                using (var graphicsPath = new GraphicsPath())
                {
                    var r = curRadius + _CheckCut2;
                    BlackPen.DashStyle = DashStyle.DashDot;
                    var rect = new Rectangle((int)(Temp.PointX - r),
                        (int)(Temp.PointY - r), (int)r * 2, (int)r * 2);
                    var point1 = GetNewCustomPoint(0, ACheck.PointY);
                    graphicsPath.AddEllipse(rect);

                    for (point1.PointX = CCheck.PointX - 200; point1.PointX < 7000; point1.PointX += 1)
                    {
                        if (graphicsPath.IsOutlineVisible((float)point1.PointX, (float)point1.PointY, BlackPen))
                        {
                            //  i = 0;
                            CCheck.PointX = point1.PointX;
                            break;
                        }
                        else Debug.WriteLine($"{point1.PointX} -bottom");
                    }

                    //while (i > ACheck.PointX-3000)
                    //{
                    //    i -= 1;
                    //    if (graphicsPath.IsOutlineVisible((float)CCheck.PointX, (float)CCheck.PointY, BlackPen))
                    //    {
                    //       // i = 0;

                    //        break;

                    //    }


                    //     CCheck.PointX = i;
                    //}
                }

            }
            else return;
        }
        private void MoveLeftSide()
        {
            if (StartAllow)
            {
                ACheck.PointY = SetCurrentLineLength(CCheck, ACheck, _CheckCut1 + C_Check_Line.Length).PointY;
                ACheck.PointX = SetCurrentLineLength(CCheck, ACheck, _CheckCut1 + C_Check_Line.Length).PointX;
                BCheck.PointX = ACheck.PointX;
                using (var graphicsPath = new GraphicsPath())
                {
                    var r = curRadius + _CheckCut2;
                    BlackPen.DashStyle = DashStyle.DashDot;
                    var rect = new Rectangle((int)(Temp.PointX - r),
                        (int)(Temp.PointY - r), (int)r * 2, (int)r * 2);
                    var point = GetNewCustomPoint(ACheck.PointX, 0);
                    //  var i = ACheck.PointY;
                    graphicsPath.AddEllipse(rect);
                    var dsdsd = graphicsPath.PathPoints.Where(x => Math.Round(Math.Abs(x.X), 0) == Math.Round(Math.Abs(BCheck.PointX), 0));
                    for (point.PointY = BCheck.PointY - 200; point.PointY < 7000; point.PointY += 1)
                    {
                        if (graphicsPath.IsOutlineVisible((float)point.PointX, (float)point.PointY, BlackPen))
                        {
                            //  i = 0;
                            BCheck.PointY = point.PointY;
                            break;
                        }
                        else Debug.WriteLine($"{point.PointY} -left");
                    }
                    //while (i > BCheck.PointY - 3300)
                    //{
                    //    i -= 1;

                    //}
                }
            }
            else return;
        }
        public override bool CheckValidSize()
        {
            double diag = 0;
            diag = (diag <= 90)
                ? CheckCut1 / Math.Sin(CalculateAngle(C, A, B) * Math.PI / 180)
                : (90 - ((180 - CheckCut1 / Math.Sin(CalculateAngle(C, A, B)) * Math.PI / 180)));
            diag = (!IsToothVector == true) ? 0 : diag;
            double diag1 = 0;
            diag1 = (diag1 <= 90)
                ? CheckCut2 / Math.Sin(CalculateAngle(B, C, A) * Math.PI / 180)
                : (90 - ((180 - CheckCut2 / Math.Sin(CalculateAngle(B, C, A)) * Math.PI / 180)));
            diag = (!IsToothVector == true) ? 0 : diag;
            double diag2 = 0;
            diag2 = (diag2 <= 90)
                ? CheckCut1 / Math.Sin(CalculateAngle(A, B, C) * Math.PI / 180)
                : (90 - ((180 - CheckCut1 / Math.Sin(CalculateAngle(A, B, C)) * Math.PI / 180)));
            diag = (!IsToothVector == true) ? 0 : diag;
            diag1 = (!IsToothVector == true) ? 0 : diag1;
            diag2 = (!IsToothVector == true) ? 0 : diag2;

            var value3 = (IsToothVector == true) ? _CheckCut3 : 0;
            var li = (IsToothVector == true) ? A_Check_Line.Length : A_line.Length;
            var width = _SetL + _SetB1 + _SetB3 + diag1 + diag;
            var height = _SetH + SetB2 + _SetB3 + value3 + diag2;

            if (_SetL < 0 || _SetB1 < 0 || _SetB2 < 0)
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

            if (_SetRadius > 0 && 4 * (Math.Pow(_SetRadius, 2)) < Math.Pow(SetL, 2) + Math.Pow(SetH, 2))
            {
                StartAllow = false;
                ValidateSetSizeMessage("Радиус  за пределами допустимых значений '4*R*R < L*L + H*H'");
                ValidValue = false;

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
                var filteredCollection = new PropertyDescriptorCollection(null);
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetRadius");
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetRadius_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsToothVector");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsSelectSameAllowance");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut1");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut2");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut3");
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