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
    sealed class Shape_51 : Rectangular
    {
        private ShapePoint Apogeus { get; set; }
        private ShapePoint Perigeus { get; set; }
        private ShapePoint ApogeusCheck { get; set; }
        private ShapePoint PerigeusCheck { get; set; }
        private ShapePoint ACheck_adw { get; set; }
        private ShapePoint DCheck_adw { get; set; }
        private double curRadius { get; set; }
        private ShapePoint Temp { get; }
        private ShapePoint Tempt { get; set; }
        private Pen BlackPen { get; }
        private double Angle { get; set; }
        private bool StartAllow { get; set; }
        public Shape_51(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {
            Apogeus = GetNewPoint();
            Perigeus = GetNewPoint();
            ACheck_adw = GetNewPoint();
            DCheck_adw = GetNewPoint();
            ApogeusCheck = GetNewPoint();
            PerigeusCheck = GetNewPoint();
            Temp = GetNewPoint();
            Tempt = GetNewPoint();
            BlackPen = new Pen(Color.Green, 1);
            D.PointX = SetCurrentLineLength(C, D, CurrentHeight).PointX;
            D.PointY = SetCurrentLineLength(C, D, CurrentHeight).PointY;
            A.PointX = SetCurrentLineLength(B, A, CurrentHeight).PointX;
            A.PointY = SetCurrentLineLength(B, A, CurrentHeight).PointY;
            StartAllow = true;
        }
        public override double Area
        {
            get
            {

                var angleBetween = CalculateAngle(A, CenterPoint, D);
                var square = (0.5 * Math.Pow(SetRadius, 2)) * (angleBetween * Math.PI / 180 - Math.Sin(angleBetween * Math.PI / 180));
                return Math.Round(square / 1000000, 3);
            }
        }
        public override double TrueArea
        {
            get
            {

                var angleBetween = CalculateAngle(A, CenterPoint, D);
                double square = 0;
                if (!IsToothVector == true)
                {
                    square = (0.5 * Math.Pow((SetRadius_t + CheckCut1), 2)) * (angleBetween * Math.PI / 180 - Math.Sin(angleBetween * Math.PI / 180));
                }
                else
                {
                    var baseSquare = 0.5 * Math.Abs((ACheck_adw.PointX * ACheck.PointY + ACheck.PointX * DCheck.PointY + DCheck.PointX * DCheck_adw.PointY + DCheck_adw.PointX * ACheck_adw.PointY) -
                        (ACheck.PointX * ACheck.PointY + DCheck.PointX * ACheck.PointY + DCheck_adw.PointX * DCheck.PointY + ACheck_adw.PointX * DCheck_adw.PointY));

                    square = (0.5 * Math.Pow(SetRadius_t, 2)) * (angleBetween * Math.PI / 180 - Math.Sin(angleBetween * Math.PI / 180)) + baseSquare;
                }

                return Math.Round(square / 1000000, 3);
            }
        }
        public override double Perimeter
        {
            get
            {

                var angleBetween = CalculateAngle(A, CenterPoint, D);
                var arcLength = (Math.PI * angleBetween * SetRadius) / 180 + D_line.Length;
                return Math.Round(arcLength / 1000, 3);
            }
        }
        public double arcLength { get; set; }
        public override double Perimeter_t
        {
            get
            {
                var angleBetween = CalculateAngle(ACheck, CenterPoint, DCheck);
                var one = GetNewLine(ACheck_adw, ACheck);
                var two = GetNewLine(DCheck_adw, DCheck);
                var three = GetNewLine(ACheck_adw, DCheck_adw);
                double perimeter = 0;
                if (!IsToothVector == true)
                {
                    perimeter = (Math.PI * angleBetween * (SetRadius_t + CheckCut1)) / 180 + D_Check_Line.Length;
                }
                else { perimeter = (Math.PI * angleBetween * SetRadius_t) / 180 + three.Length + one.Length + two.Length; }

                return Math.Round(perimeter / 1000, 3);
            }

        }
        protected override void DrawMainLines()
        {
            var curvePoints = GetFigurePoints();
            if (IsToothVector == true)
            {

                using (pen1 = new Pen(SelectMainLineColor2(), ThiсknessArgument / 2))
                {
                    pen1.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen1, D, A);
                }
                using (pen2 = new Pen(SelectMainLineColor1(), ThiсknessArgument / 2))
                {
                    pen2.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawCurve(pen2, curvePoints, 0F);
                }
                IsToothVector = true;
            }
            else
            {
                // System.Drawing.Point[] curvePoints = GetFigurePoints();
                using (pen1 = new Pen(SelectMainLineColor2(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen1, D, A);
                }
                using (pen2 = new Pen(SelectMainLineColor1(), ThiсknessArgument))
                {
                    graphicsShape.DrawCurve(pen2, curvePoints, 0F);
                }
                IsToothVector = false;

            }
            graphicsShape.FillClosedCurve(new SolidBrush(Color.FromArgb(30, Color.Blue)), curvePoints);
            MoveLines();
        }
        public override RectangleF GetShapeBorders()
        {
            Point[] curvePoints = GetFigurePoints();
            using (GraphicsPath myPath = new GraphicsPath())
            {
                myPath.AddLine(D, A);
                myPath.AddCurve(curvePoints);
                Region myRegion = new Region(myPath);
                RectangleF boundsRect = myRegion.GetBounds(graphicsShape);
                // graphicsShape.SetClip(myRegion, CombineMode.Replace);
                graphicsShape.DrawRectangle(Pens.Blue, new Rectangle((int)boundsRect.X,
                (int)boundsRect.Y, (int)boundsRect.Width, (int)boundsRect.Height));
                return boundsRect;
            }
        }
        protected override GraphicsPath GetShapeShprosBorders()
        {
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddLine(D, A);
            myPath.AddCurve(GetFigurePoints());
            return myPath;
        }
        public override void SelectClickedSide(int xCoord, int yCoord, bool flag)
        {
            Point point = new Point(xCoord, yCoord);
            if (ThicknessPath(D, A).IsVisible(point))
            {
                if (flag) { ColorMarker2 = "rowCheckCut2"; SelectedSides.SetValue(2, 1); SelectedSidesLength += D_line.Length; }
                else { ColorMarker2 = ""; SelectedSides.SetValue(0, 3); SelectedSidesLength -= D_line.Length; }
            }
            if (CurvePath(GetFigurePoints().ToArray()).IsVisible(point))
            {
                if (flag) { ColorMarker1 = "rowCheckCut1"; SelectedSides.SetValue(1, 0); SelectedSidesLength += arcLength; }
                else { ColorMarker1 = ""; SelectedSides.SetValue(0, 0); SelectedSidesLength -= arcLength; }
            }
            else return;
        }
        protected override void CheckForeignBorders()
        {
            GetExtremumPoints();
            AllowanceProcessing();
        }

        private void MoveLines()
        {
            var curvePoints = GetFigurePoints();
            using (var pen = new Pen(Color.Black, SizeLineBoundArgument))
            {
                MoveBorderLeft(W_Base, X_Base, SetB1);
                MoveBorderTop(X_Base, Y_Base, SetB3);
                MoveBorderRight(Y_Base, Z_Base, SetB1);
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

                ShapePoint b2s = (IsToothVector == true) ? GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, ACheck_adw.PointY) :
                    GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(A));
                ShapePoint b2e = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, W_Base.PointY);
                graphicsShape.DrawLine(pen, b2s, b2e);
                Line b2h = GetNewLine(b2s, b2e);
                ShapePoint b2scenter = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, W_Base.PointY - b2h.Length / 2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b2scenter, sf);
                if (b2h.Length > 0)
                {
                    graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b2scenter, sf);
                }


                ShapePoint b3s1 = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, X_Base.PointY + SetB3);
                ShapePoint b3e1 = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, X_Base.PointY);
                Line lb31 = GetNewLine(b3s1, b3e1);
                ShapePoint b31center = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, X_Base.PointY + (lb31.Length / 2));
                graphicsShape.DrawLine(pen, b3s1, b3e1);
                graphicsShape.DrawString("B3=" + SetB3, drawFontBold, Brushes.Black, b31center, sf);


                ShapePoint b1s = GetNewCustomPoint(W_Base.PointX + SetB1, W_Base.PointY + 20 * LineBoundArgument);
                ShapePoint b1e = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 20 * LineBoundArgument);
                Line lb1 = GetNewLine(b1s, b1e);
                ShapePoint b1center = GetNewCustomPoint(W_Base.PointX + (lb1.Length / 2), W_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s, b1e);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b1center, sf);



                ShapePoint b1s1 = GetNewCustomPoint(Z_Base.PointX - SetB1, Z_Base.PointY + 20 * LineBoundArgument);
                ShapePoint b1e1 = GetNewCustomPoint(Z_Base.PointX, Z_Base.PointY + 20 * LineBoundArgument);
                Line lb11 = GetNewLine(b1s1, b1e1);
                ShapePoint b11center = GetNewCustomPoint(Z_Base.PointX - (lb1.Length / 2), Z_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s1, b1e1);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b11center, sf);

                ShapePoint ls = (IsToothVector == true) ? GetNewCustomPoint(ACheck_adw.PointX, W_Base.PointY + 20) : GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 20);
                ShapePoint le = (IsToothVector == true) ? GetNewCustomPoint(DCheck_adw.PointX, W_Base.PointY + 20) : GetNewCustomPoint(SetPointCurrentValueX(D), W_Base.PointY + 20);
                Line ll = GetNewLine(ls, le);
                ShapePoint lcenter = GetNewCustomPoint(W_Base.PointX + (ll.Length / 2), W_Base.PointY + 20);
                graphicsShape.DrawLine(pen, ls, le);
                graphicsShape.DrawString("L=" + SetCurrentSize(SetL), drawFontBold, Brushes.Black, lcenter, sf);

                using (var penr = new Pen(Color.Blue, 1))
                {
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Far;
                    penr.StartCap = LineCap.RoundAnchor;
                    penr.EndCap = LineCap.ArrowAnchor;
                    penr.DashStyle = DashStyle.Solid;
                    ShapePoint rs = GetNewCustomPoint(W_Base.PointX + D_line.Length / 2 - 10, Z_Base.PointY + 20);
                    ShapePoint re = GetNewCustomPoint(X_Base.PointX + D_line.Length / 2 + 10, Apogeus.PointY);
                    Line lr = GetNewLine(rs, re);
                    ShapePoint brcenter = GetNewCustomPoint(W_Base.PointX + D_line.Length / 2, Z_Base.PointY - (lr.Length / 2));
                    graphicsShape.DrawLine(penr, rs, re);

                    graphicsShape.DrawString("R=" + SetCurrentSize(SetRadius), drawFontBold, Brushes.Black, brcenter, sf);

                }



                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX) / 4), ((A.PointY + B.PointY + C.PointY + D.PointY) / 4));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiknessFontArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("51", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }

                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {

                    using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        if (IsToothVector == true)
                        {
                            ShapePoint wer1 = GetNewCustomPoint(W_Base.PointX, ACheck_adw.PointY);
                            ShapePoint wer2 = GetNewCustomPoint(Z_Base.PointX, DCheck_adw.PointY);
                            graphicsShape.DrawLine(pen1, wer1, ACheck_adw);
                            graphicsShape.DrawLine(pen1, wer2, DCheck_adw);
                            graphicsShape.DrawLine(pens, b2s, wer2);

                        }
                        else
                        {
                            ShapePoint wer1 = GetNewCustomPoint(W_Base.PointX, SetPointCurrentValueY(A));
                            ShapePoint wer2 = GetNewCustomPoint(Z_Base.PointX, SetPointCurrentValueY(D));
                            graphicsShape.DrawLine(pen1, wer1, SetPointCurrentType(A));
                            graphicsShape.DrawLine(pen1, wer2, SetPointCurrentType(D));
                            graphicsShape.DrawLine(pens, b2s, wer2);
                        }


                    }
                    if (IsToothVector == true)
                    {
                        Line l = GetNewLine(Z_Base, W_Base);
                        ShapePoint point = GetNewCustomPoint(W_Base.PointX + l.Length / 2, ApogeusCheck.PointY);
                        graphicsShape.DrawLine(pens, b3s1, point);
                        graphicsShape.DrawLine(pens, le, DCheck_adw);
                        graphicsShape.DrawLine(pens, ls, ACheck_adw);
                    }
                    else
                    {
                        Line l = GetNewLine(Z_Base, W_Base);
                        ShapePoint point = GetNewCustomPoint(W_Base.PointX + l.Length / 2, Apogeus.PointY);
                        graphicsShape.DrawLine(pens, b3s1, point);
                        graphicsShape.DrawLine(pens, le, SetPointCurrentType(D));
                        graphicsShape.DrawLine(pens, ls, SetPointCurrentType(A));
                    }

                    graphicsShape.DrawLine(pens, b1e, W_Base);
                    graphicsShape.DrawLine(pens, b1e1, Z_Base);
                    graphicsShape.DrawLine(pens, b3e1, Y_Base);

                    graphicsShape.DrawLine(pens, b2e, Z_Base);
                    graphicsShape.DrawLine(pens, ls, b1s);
                    graphicsShape.DrawLine(pens, le, b1s1);
                    using (Pen pens1 = new Pen(Color.Red, SizeLineBoundArgument / 2))
                    {
                        // graphicsShape.DrawLine(pens1, bsh1, SetPointCurrentType(B));
                    }
                }
            }
            #endregion
        }
        public override double SetL { get => Math.Round(D_line.Length, 0); set => base.SetL = value; }
        public override double SetRadius { get => _SetRadius = (_SetRadius == 0) ? 1111 : _SetRadius; set => base.SetRadius = value; }
        public override double SetL_t
        {
            get
            {
                double length = 0;
                if (SetL == SetRadius * 2)
                {
                    length = Math.Round(D_Check_Line.Length, 0);
                }
                else
                {
                    Line line = GetNewLine(DCheck_adw, ACheck_adw);
                    length = Math.Round(line.Length, 0);
                }

                return length;
            }
        }
        public override double SetRadius_t { get => _SetRadius + CheckCut2; }
       
        protected override void SetLValue()
        {
            base.SetLValue();

            D.PointX = SetCurrentLineLength(A, D, _SetL).PointX;
            D.PointY = SetCurrentLineLength(A, D, _SetL).PointY;
            B.PointX = A.PointX;
            C.PointX = D.PointX;
            ValidValue = false;
          // SetRadius = _SetL / 2;
        }

        protected override void SetRadiusValue()
        {
            base.SetRadiusValue();
            double height = SetRadius - Math.Sqrt(Math.Pow(SetRadius, 2) - ((Math.Pow(GetNewLine(A, D).Length, 2)) / 4));
            CurrentHeight = height;
            D.PointX = SetCurrentLineLength(C, D, CurrentHeight).PointX;
            D.PointY = SetCurrentLineLength(C, D, CurrentHeight).PointY;
            A.PointX = SetCurrentLineLength(B, A, CurrentHeight).PointX;
            A.PointY = SetCurrentLineLength(B, A, CurrentHeight).PointY;
            ValidValue = false;
        }

        private double _CurrentHeight;
        public double CurrentHeight
        {
            get { return _CurrentHeight; }
            set { SetField(ref _CurrentHeight, value, () => CurrentHeight); }
        } 

        public override Point[] GetFigurePoints()
        {
            #region Получаем угол ВСА для определения длины дуги скругления стороны АВ и уравниваем AC и BC
            Line l = GetNewLine(A, D);
            TempPoint.PointX = SetCurrentLineLength(A, D, l.Length / 2).PointX;
            TempPoint.PointY = SetCurrentLineLength(A, D, l.Length / 2).PointY;
            double height = SetRadius - Math.Sqrt(Math.Pow(SetRadius, 2) - ((Math.Pow(l.Length, 2)) / 4));
          //  CurrentHeight = height;
            double r = SetRadius - height;
            curRadius = SetRadius;

            CenterPoint.PointX = TempPoint.PointX + 1;
            // CenterPoint.Y = TempPoint.Y - r;
            CenterPoint.PointY = TempPoint.PointY + r;


            CenterPoint = SetCurrentLineLength(TempPoint, CenterPoint, SetRadius - height);
            CenterPoint.PointX -= 1;
            Temp.PointX = CenterPoint.PointX;
            Temp.PointY = CenterPoint.PointY;

            double angleBetween = CalculateAngle(A, CenterPoint, D);
            Tempt = CenterPoint;
            Angle = angleBetween;
            #endregion
            List<Point> pointsList = new List<Point> { A };
            double degree = 0;
            //  angleBetween = (SetH > SetL / 2) ? 360 - angleBetween : angleBetween;
            while (degree <= angleBetween)
            {
                CurvePoint.PointX = (A.PointX - CenterPoint.PointX) * Math.Cos(degree * Math.PI / 180) - (A.PointY - CenterPoint.PointY) * Math.Sin(degree * Math.PI / 180) + CenterPoint.PointX;
                CurvePoint.PointY = (A.PointX - CenterPoint.PointX) * Math.Sin(degree * Math.PI / 180) + (A.PointY - CenterPoint.PointY) * Math.Cos(degree * Math.PI / 180) + CenterPoint.PointY;
                pointsList.Add(CurvePoint);
                degree += 1;
            }
            pointsList.Add(D);
            Point[] points = new Point[pointsList.Count];
            Array.Copy(pointsList.ToArray(), points, pointsList.Count);
            pointsList.Clear();
            var xMax = points.Max(x => x.X);
            var yMax = points.Max(PointX => PointX.Y);
            var xMin = points.Min(PointX => PointX.X);
            var yMin = points.Min(PointX => PointX.Y);
            Apogeus.PointX = xMin;
            Apogeus.PointY = yMin;
            Perigeus.PointX = xMax;
            Perigeus.PointY = yMax;
            return points;
        }
        private Point[] GetFigureCheckPoints()
        {
            var angleBetween = CalculateAngle(ACheck, Tempt, DCheck);
            List<Point> pointsList = new List<Point> { ACheck };
            double degree = 0;
            while (degree <=Angle-10)
            {
                CurvePoint.PointX = (ACheck.PointX - Temp.PointX) * Math.Cos(degree * Math.PI / 180) -
                                    (ACheck.PointY - Temp.PointY) * Math.Sin(degree * Math.PI / 180) + Temp.PointX;
                CurvePoint.PointY = (ACheck.PointX - Temp.PointX) * Math.Sin(degree * Math.PI / 180) +
                                    (ACheck.PointY - Temp.PointY) * Math.Cos(degree * Math.PI / 180) + Temp.PointY;
                pointsList.Add(CurvePoint);
                degree += 1;
            }
            pointsList.Add(DCheck);
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
            ACheck_adw.PointX = A.PointX;
            ACheck_adw.PointY = A.PointY;
            DCheck_adw.PointX = D.PointX;
            DCheck_adw.PointY = D.PointY;

            double diag1 = 0;
            double diag11 = 0;
            double diag2 = 0;
            double diag21 = 0;

            _CheckCut1 = (IsToothVector == false && _CheckCut1 >= 0) ? _CheckCut1 * (-1) : _CheckCut1;
            _CheckCut2 = (IsToothVector == false && _CheckCut2 >= 0) ? _CheckCut2 * (-1) : _CheckCut2;
            _CheckCut1 = (IsToothVector == true && _CheckCut1 < 0) ? _CheckCut1 * (-1) : _CheckCut1;
            _CheckCut2 = (IsToothVector == true && _CheckCut2 < 0) ? _CheckCut2 * (-1) : _CheckCut2;

            diag1 = (diag1 <= 90) ? _CheckCut1 / Math.Sin(CalculateAngle(D, A, B) * Math.PI / 180) :
                (90 - ((180 - _CheckCut1 / Math.Sin(CalculateAngle(D, A, B)) * Math.PI / 180)));
            diag11 = (diag11 <= 90) ? _CheckCut1 / Math.Sin(CalculateAngle(A, B, C) * Math.PI / 180) :
                (90 - ((180 - _CheckCut1 / Math.Sin(CalculateAngle(A, B, C)) * Math.PI / 180)));

            diag2 = (diag2 <= 90) ? _CheckCut2 / Math.Sin(CalculateAngle(A, B, C) * Math.PI / 180) :
                (90 - ((180 - _CheckCut2 / Math.Sin(CalculateAngle(A, B, C)) * Math.PI / 180)));
            diag21 = (diag21 <= 90) ? _CheckCut2 / Math.Sin(CalculateAngle(B, C, D) * Math.PI / 180) :
                (90 - ((180 - _CheckCut2 / Math.Sin(CalculateAngle(B, C, D)) * Math.PI / 180)));




            if (IsToothVector == true)
            {
                using (Pen penCut = new Pen(Color.Red, ThiсknessArgument))
                {
                    var height1 = SetRadius - Math.Sqrt(Math.Pow(SetRadius, 2) - ((Math.Pow(D_line.Length, 2)) / 4));
                    var currentHeight1 = height1 + CheckCut2;
                    var katet1 = SetRadius_t - currentHeight1;
                    var newLength1 = Math.Sqrt(Math.Pow(SetRadius_t, 2) - Math.Pow(katet1, 2));
                    CenterPoint.PointX = ACheck.PointX + D_Check_Line.Length / 2;
                    CenterPoint.PointY = ACheck.PointY;

                    ACheck.PointY = SetCurrentLineLength(DCheck, ACheck, diag2 + D_Check_Line.Length).PointY;
                    ACheck.PointX = SetCurrentLineLength(CenterPoint, ACheck, newLength1).PointX;
                    BCheck.PointY = SetCurrentLineLength(CCheck, BCheck, diag21 + B_Check_Line.Length).PointY;
                    BCheck.PointX = SetCurrentLineLength(CenterPoint, BCheck, newLength1).PointX;

                    CCheck.PointY = SetCurrentLineLength(BCheck, CCheck, diag2 + B_Check_Line.Length).PointY;
                    CCheck.PointX = SetCurrentLineLength(CenterPoint, CCheck, newLength1).PointX;
                    DCheck.PointY = SetCurrentLineLength(ACheck, DCheck, diag21 + D_Check_Line.Length).PointY;
                    DCheck.PointX = SetCurrentLineLength(CenterPoint, DCheck, newLength1).PointX;

                    DCheck_adw.PointX = DCheck.PointX;
                    ACheck_adw.PointX = ACheck.PointX;
                    DCheck_adw.PointY = DCheck.PointY;
                    ACheck_adw.PointY = ACheck.PointY;

                    var height = SetRadius_t - Math.Sqrt(Math.Pow(SetRadius_t, 2) - ((Math.Pow(D_Check_Line.Length, 2)) / 4));
                    var currentHeight = height + CheckCut1;
                    var katet = SetRadius_t - currentHeight;
                    var newLength = Math.Sqrt(Math.Pow(SetRadius_t, 2) - Math.Pow(katet, 2));
                    CenterPoint.PointX = ACheck_adw.PointX + D_Check_Line.Length / 2;
                    CenterPoint.PointY = ACheck_adw.PointY;

                    DCheck_adw.PointX = SetCurrentLineLength(CenterPoint, DCheck_adw, newLength).PointX;
                    ACheck_adw.PointX = SetCurrentLineLength(CenterPoint, ACheck_adw, newLength).PointX;
                    DCheck_adw.PointY = SetCurrentLineLength(CCheck, DCheck, diag1 + C_Check_Line.Length).PointY;
                    ACheck_adw.PointY = SetCurrentLineLength(BCheck, ACheck, diag11 + A_Check_Line.Length).PointY;


                    var curveCheckPoints = GetFigureCheckPoints();
                    graphicsShape.DrawLine(penCut, ACheck_adw, DCheck_adw);
                    graphicsShape.DrawLine(penCut, ACheck, ACheck_adw);
                    graphicsShape.DrawLine(penCut, DCheck, DCheck_adw);
                    graphicsShape.DrawCurve(penCut, curveCheckPoints, 0F);
                    IsToothVector = true;
                }
            }
            else
            {
                using (Pen penCut = new Pen(Color.Red, ThiсknessArgument / 2))
                {

                    double height1 = SetRadius - Math.Sqrt(Math.Pow(SetRadius, 2) - ((Math.Pow(D_line.Length, 2)) / 4));
                    double currentHeight1 = height1 + CheckCut2;
                    double katet1 = SetRadius_t - currentHeight1;
                    double newLength1 = Math.Sqrt(Math.Pow(SetRadius_t, 2) - Math.Pow(katet1, 2));
                    CenterPoint.PointX = ACheck.PointX + D_Check_Line.Length / 2;
                    CenterPoint.PointY = ACheck.PointY;

                    ACheck.PointY = SetCurrentLineLength(DCheck, ACheck, diag2 + D_Check_Line.Length).PointY;
                    ACheck.PointX = SetCurrentLineLength(CenterPoint, ACheck, newLength1).PointX;
                    BCheck.PointY = SetCurrentLineLength(CCheck, BCheck, diag21 + B_Check_Line.Length).PointY;
                    BCheck.PointX = SetCurrentLineLength(CenterPoint, BCheck, newLength1).PointX;

                    CCheck.PointY = SetCurrentLineLength(BCheck, CCheck, diag2 + B_Check_Line.Length).PointY;
                    CCheck.PointX = SetCurrentLineLength(CenterPoint, CCheck, newLength1).PointX;
                    DCheck.PointY = SetCurrentLineLength(ACheck, DCheck, diag21 + D_Check_Line.Length).PointY;
                    DCheck.PointX = SetCurrentLineLength(CenterPoint, DCheck, newLength1).PointX;

                    DCheck_adw.PointX = DCheck.PointX;
                    ACheck_adw.PointX = ACheck.PointX;
                    DCheck_adw.PointY = DCheck.PointY;
                    ACheck_adw.PointY = ACheck.PointY;

                    double height = SetRadius_t - Math.Sqrt(Math.Pow(SetRadius_t, 2) - ((Math.Pow(D_Check_Line.Length, 2)) / 4));
                    double currentHeight = height + CheckCut1;
                    double katet = SetRadius_t - currentHeight;
                    double newLength = Math.Sqrt(Math.Pow(SetRadius_t, 2) - Math.Pow(katet, 2));
                    CenterPoint.PointX = ACheck.PointX + D_Check_Line.Length / 2;
                    CenterPoint.PointY = ACheck.PointY;

                    DCheck.PointX = SetCurrentLineLength(CenterPoint, DCheck, newLength).PointX;
                    ACheck.PointX = SetCurrentLineLength(CenterPoint, ACheck, newLength).PointX;
                    DCheck.PointY = SetCurrentLineLength(CCheck, DCheck, diag1 + C_Check_Line.Length).PointY;
                    ACheck.PointY = SetCurrentLineLength(BCheck, ACheck, diag11 + A_Check_Line.Length).PointY;

                    Point[] curveCheckPoints = GetFigureCheckPoints();
                    penCut.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(penCut, ACheck, DCheck);
                    graphicsShape.DrawCurve(penCut, curveCheckPoints, 0F);
                    IsToothVector = false;
                }
            }
            GetExtremumPoints();
        }
        public override void GetExtremumPoints()
        {

            List<ShapePoint> pointList = new List<ShapePoint>() { A, D, Apogeus, Perigeus,
                ApogeusCheck, PerigeusCheck, ACheck_adw,DCheck_adw };

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
            var value1 = (IsToothVector == true) ? _CheckCut1 : 0;
            var value2 = (IsToothVector == true) ? _CheckCut2 : 0;
            var width = _SetL + _SetB1 + _SetB1 + value1 * 2;
            var height = _SetH + _SetB2 + _SetB3 + _SetB2 + value1 + value2;

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

            if (_SetRadius > 0 && _SetRadius < SetL / 2)
            {
                ValidValue = true;
                ValidateSetSizeMessage("Радиус  не может быть меньше 'L/2'");
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetRadius_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsToothVector");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsSelectSameAllowance");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut1");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut2");
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
