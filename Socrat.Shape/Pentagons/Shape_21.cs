using DevExpress.XtraVerticalGrid.Events;
using Socrat.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;


namespace Socrat.Shape.Pentagons
{
    sealed class Shape_21 : Pentagon
    {
        public Shape_21(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {


        }
        public override double Perimeter
        {
            get
            {
                return Math.Round((A_line.Length + B_line.Length + C_line.Length + D_line.Length + E_line.Length) / 1000, 3);
            }
        }
        public override double Perimeter_t
        {
            get
            {
                return Math.Round((A_Check_Line.Length + B_Check_Line.Length + C_Check_Line.Length +
                    D_Check_Line.Length + E_Check_Line.Length) / 1000, 3);
            }
        }
        protected override void DrawMainLines()
        {

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
                    graphicsShape.DrawLine(pen2, B, C);
                }
                using (pen3 = new Pen(SelectMainLineColor3(), ThiсknessArgument / 2))
                {
                    pen3.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen3, C, D);
                }
                using (pen4 = new Pen(SelectMainLineColor4(), ThiсknessArgument / 2))
                {
                    pen4.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen4, D, E);
                }
                using (pen5 = new Pen(SelectMainLineColor5(), ThiсknessArgument / 2))
                {
                    pen5.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen5, E, A);
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
                    graphicsShape.DrawLine(pen2, B, C);
                }
                using (pen3 = new Pen(SelectMainLineColor3(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen3, C, D);
                }
                using (pen4 = new Pen(SelectMainLineColor4(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen4, D, E);
                }
                using (pen5 = new Pen(SelectMainLineColor5(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen5, E, A);
                }
                IsToothVector = false;
            }
            graphicsShape.FillPolygon(new SolidBrush(Color.FromArgb(30, Color.Blue)), GetBasePoints());
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
                MoveBorderLeft(W_Base, X_Base, SetB1);
                MoveBorderTop(X_Base, Y_Base, SetB1);
                MoveBorderRight(Y_Base, Z_Base, SetB1);
                MoveBorderBottom(W_Base, Z_Base, SetB1);
            }
        }
       
        protected override PointF[] GetBasePoints()
        {
            return new PointF[] { A, B, C, D, E };
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
                MoveInternalLineFromTop(graphicsShape, X_Base, Y_Base, First_B_Some_Size_Point, Second_B_Some_Size_Point, SetB1, SetB2);
                MoveInternalLineFromLeft(graphicsShape, W_Base, X_Base, First_B_Some_Size_Point, Second_B_Some_Size_Point, SetB1, SetB2);
                MoveInternalLineFromRight(graphicsShape, Y_Base, Z_Base, First_B_Some_Size_Point, Second_B_Some_Size_Point, SetB1, SetB2);
                FindPointDrawLine(SetPointCurrentType(B), SetPointCurrentType(C), SetB2, SetB1, 0);
                FindPointDrawLine1(SetPointCurrentType(C), SetPointCurrentType(B), SetB2, SetB1, 0);
                FindPointDrawLine2(SetPointCurrentType(C), SetPointCurrentType(D), SetB2, SetB1, 0);
            }
            using (Pen pen = new Pen(Color.Blue, SizeLineBoundArgument))
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                pen.StartCap = LineCap.ArrowAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                pen.DashStyle = DashStyle.Solid;
                ShapePoint ls = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 30 * LineBoundArgument);
                ShapePoint le = GetNewCustomPoint(SetPointCurrentValueX(E), W_Base.PointY + 30 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                ShapePoint lcenter = GetNewCustomPoint(SetPointCurrentValueX(A) + (ll.Length / 2), W_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                    graphicsShape.DrawString("L=" + SetCurrentSize(SetL), drawFontBold, Brushes.Black, lcenter, sf);

                ShapePoint bs1 = GetNewCustomPoint(SetPointCurrentValueX(B), W_Base.PointY + 30 * LineBoundArgument);
                ShapePoint be1 = GetNewCustomPoint(X_Base.PointX, W_Base.PointY + 30 * LineBoundArgument);
                Line bl1 = GetNewLine(bs1, be1);
                ShapePoint b1center = GetNewCustomPoint(X_Base.PointX + (bl1.Length / 2), W_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, bs1, be1);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b1center, sf);

                ShapePoint bs12 = GetNewCustomPoint(SetPointCurrentValueX(D), W_Base.PointY + 30 * LineBoundArgument);
                ShapePoint be12 = GetNewCustomPoint(Y_Base.PointX, W_Base.PointY + 30 * LineBoundArgument);
                Line bl12 = GetNewLine(bs12, be12);
                ShapePoint b12center = GetNewCustomPoint(SetPointCurrentValueX(D) + (bl12.Length / 2), Z_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, bs12, be12);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b12center, sf);


                ShapePoint b2s = GetNewCustomPoint(W_Base.PointX + SetB2, W_Base.PointY + 10 * LineBoundArgument);
                ShapePoint b2e = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 10 * LineBoundArgument);
                Line lb2 = GetNewLine(b2s, b2e);
                ShapePoint b2center = GetNewCustomPoint(W_Base.PointX + (lb2.Length / 2), W_Base.PointY + 15 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b2s, b2e);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b2center, sf);


                ShapePoint b2s1 = GetNewCustomPoint(Z_Base.PointX - SetB2, Z_Base.PointY + 10 * LineBoundArgument);
                ShapePoint b2e1 = GetNewCustomPoint(Z_Base.PointX, Z_Base.PointY + 10 * LineBoundArgument);
                Line lb21 = GetNewLine(b2s1, b2e1);
                ShapePoint b21center = GetNewCustomPoint(Z_Base.PointX - (lb21.Length / 2), Z_Base.PointY + 15 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b2s1, b2e1);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b21center, sf);


                ShapePoint b2s3 = GetNewCustomPoint(Y_Base.PointX + 10 * LineBoundArgument, X_Base.PointY);
                ShapePoint b2e3 = GetNewCustomPoint(Y_Base.PointX + 10 * LineBoundArgument, X_Base.PointY + SetB2);
                Line lb23 = GetNewLine(b2s3, b2e3);
                ShapePoint b23center = GetNewCustomPoint(Y_Base.PointX + 15 * LineBoundArgument, X_Base.PointY + (lb23.Length / 2));
                graphicsShape.DrawLine(pen, b2s3, b2e3);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b23center, sf);


                ShapePoint b1s1 = GetNewCustomPoint(Y_Base.PointX + 35 * LineBoundArgument, SetPointCurrentValueY(C));
                ShapePoint b1e1 = GetNewCustomPoint(Y_Base.PointX + 35 * LineBoundArgument, Y_Base.PointY);
                graphicsShape.DrawLine(pen, b1s1, b1e1);
                Line b12h = GetNewLine(b1s1, b1e1);
                ShapePoint b12scenter = GetNewCustomPoint(Z_Base.PointX + 40 * LineBoundArgument, Y_Base.PointY + b12h.Length / 2);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b12scenter, sf);


                ShapePoint b12s1 = GetNewCustomPoint(Z_Base.PointX + 35 * LineBoundArgument, SetPointCurrentValueY(E));
                ShapePoint b12e1 = GetNewCustomPoint(Z_Base.PointX + 35 * LineBoundArgument, Z_Base.PointY);
                graphicsShape.DrawLine(pen, b12s1, b12e1);
                Line b22h = GetNewLine(b12s1, b12e1);
                ShapePoint b22scenter = GetNewCustomPoint(Z_Base.PointX + 40 * LineBoundArgument, Z_Base.PointY - b22h.Length / 2);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b22scenter, sf);


                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX + E.PointX) / 5), ((A.PointY + B.PointY + C.PointY + D.PointY + E.PointY) / 5));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiknessFontArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("21", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }
                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {

                    ShapePoint wer = GetNewCustomPoint(W_Base.PointX, SetPointCurrentValueY(A));
                    ShapePoint wer1 = GetNewCustomPoint(Z_Base.PointX, SetPointCurrentValueY(E));
                    ShapePoint wer2 = GetNewCustomPoint(W_Base.PointX + SetB2, W_Base.PointY);
                    ShapePoint wer3 = GetNewCustomPoint(Z_Base.PointX, Y_Base.PointY + SetB2);
                    ShapePoint wer4 = GetNewCustomPoint(Z_Base.PointX - SetB2, Z_Base.PointY);
                    using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        graphicsShape.DrawLine(pen1, wer, SetPointCurrentType(A));
                        graphicsShape.DrawLine(pen1, wer1, SetPointCurrentType(E));
                    }
                    graphicsShape.DrawLine(pens, b12e1, Z_Base);
                    graphicsShape.DrawLine(pens, b12s1, wer1);
                    graphicsShape.DrawLine(pens, be1, W_Base);
                    graphicsShape.DrawLine(pens, bs1, SetPointCurrentType(B));
                    graphicsShape.DrawLine(pens, b2s, wer2);
                    graphicsShape.DrawLine(pens, bs12, SetPointCurrentType(D));
                    graphicsShape.DrawLine(pens, be12, Z_Base);
                    graphicsShape.DrawLine(pens, b1e1, Y_Base);
                    graphicsShape.DrawLine(pens, b1s1, SetPointCurrentType(C));
                    graphicsShape.DrawLine(pens, b2e3, wer3);
                    graphicsShape.DrawLine(pens, b2s1, wer4);
                    graphicsShape.DrawLine(pens, ls, SetPointCurrentType(A));
                    graphicsShape.DrawLine(pens, le, SetPointCurrentType(E));
                }
            }

            #endregion
        }
        protected override void FindPointDrawLine(ShapePoint firsrPoint, ShapePoint secondPoint, double factor = 0, double anotherFactor = 0, double thofactor = 0)
        {
            double length = 0;
            ShapePoint point = GetNewCustomPoint((firsrPoint.PointX), (firsrPoint.PointY - anotherFactor + factor));
            Line fdfLine = GetNewLine(point, firsrPoint);
            Line fdLine = GetNewLine(firsrPoint, secondPoint);
            double angle = CalculateAngle(B, C, D);
            double l = fdfLine.Length / Math.Sin(angle * Math.PI / 180);
            length = fdLine.Length + l;
            ShapePoint customPoint = GetNewPoint();
            customPoint = SetCurrentLineLength(firsrPoint, secondPoint, length);
            using (Pen pen = new Pen(Color.Black, ThiсknessArgument / 2))
            {
                graphicsShape.DrawLine(pen, secondPoint, customPoint);
            }
        }
        private void FindPointDrawLine1(ShapePoint firsrPoint, ShapePoint secondPoint, double factor = 0, double anotherFactor = 0, double thofactor = 0)
        {
            double length = 0;
            ShapePoint point = GetNewCustomPoint((firsrPoint.PointX - anotherFactor + factor), (firsrPoint.PointY));
            Line fdfLine = GetNewLine(point, firsrPoint);
            Line fdLine = GetNewLine(firsrPoint, secondPoint);
            double angle = 180 - CalculateAngle(B, C, D);
            double l = fdfLine.Length / Math.Sin(angle * Math.PI / 180);
            length = fdLine.Length + l;
            ShapePoint customPoint = GetNewPoint();
            customPoint = SetCurrentLineLength(firsrPoint, secondPoint, length);
            using (Pen pen = new Pen(Color.Black, ThiсknessArgument / 2))
            {
                graphicsShape.DrawLine(pen, secondPoint, customPoint);
            }

        }
        private void FindPointDrawLine2(ShapePoint firsrPoint, ShapePoint secondPoint, double factor = 0, double anotherFactor = 0, double thofactor = 0)
        {
            double length = 0;
            ShapePoint point = GetNewCustomPoint((firsrPoint.PointX), (firsrPoint.PointY + anotherFactor - factor));
            Line fdfLine = GetNewLine(point, firsrPoint);
            Line fdLine = GetNewLine(firsrPoint, secondPoint);
            double angle = 180 - CalculateAngle(B, C, D);
            double l = fdfLine.Length / Math.Sin(angle * Math.PI / 180);
            length = fdLine.Length + l;
            ShapePoint customPoint = GetNewPoint();
            customPoint = SetCurrentLineLength(firsrPoint, secondPoint, length);
            using (Pen pen = new Pen(Color.Black, ThiсknessArgument / 2))
            {
                graphicsShape.DrawLine(pen, secondPoint, customPoint);
            }

        }
        public override double SetL { get => Math.Round(E_line.Length, 0); set => base.SetL = value; }
        public override double SetL_t { get => Math.Round(E_Check_Line.Length, 0); }
        protected override void SetLValue()
        {
            base.SetLValue();
            var Xp = GetNewPoint();
            var Yp = GetNewPoint();
            TempPoint.PointX = SetCurrentLineLength(A, E, _SetL).PointX;
            TempPoint.PointY = SetCurrentLineLength(A, E, _SetL).PointY;
            E.PointX = TempPoint.PointX;
            E.PointY = A.PointY;
            Xp.PointX = B.PointX;
            Yp.PointX = B.PointY;
            Yp.PointX = C.PointX;
            Yp.PointY = C.PointY;
            B.PointX = (E.PointX - A.PointX) * Math.Cos(-1.88496) - (E.PointY - A.PointY) * Math.Sin(-1.88496) + A.PointX;
            B.PointY = (E.PointX - A.PointX) * Math.Sin(-1.88496) + (E.PointY - A.PointY) * Math.Cos(-1.88496) + A.PointY;
            C.PointX = (A.PointX - B.PointX) * Math.Cos(-1.88496) - (A.PointY - B.PointY) * Math.Sin(-1.88496) + B.PointX;
            C.PointY = (A.PointX - B.PointX) * Math.Sin(-1.88496) + (A.PointY - B.PointY) * Math.Cos(-1.88496) + B.PointY;
            D.PointX = (B.PointX - C.PointX) * Math.Cos(-1.88496) - (B.PointY - C.PointY) * Math.Sin(-1.88496) + C.PointX;
            D.PointY = (B.PointX - C.PointX) * Math.Sin(-1.88496) + (B.PointY - C.PointY) * Math.Cos(-1.88496) + C.PointY;
            var Xdiff = Xp.PointX - B.PointX;
            var Ydiff = Yp.PointY - C.PointY;
            Move(Xdiff, Ydiff);
            ValidValue = false;
        }
        public override void GetExtremumPoints()
        {

            List<ShapePoint> pointList = new List<ShapePoint>() { A, B, C, D, E, ACheck, BCheck, CCheck, DCheck, ECheck };

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
            double diag1 = 0;
            double diag2 = 0;
            double diag3 = 0;
            double diag4 = 0;
            diag1 = (diag1 <= 90) ? _CheckCut1 / Math.Sin(CalculateAngle(A, B, C) * Math.PI / 180) :
               _CheckCut1 / (90 - ((180 - Math.Sin(CalculateAngle(A, B, C)) * Math.PI / 180)));
            diag2 = (diag2 <= 90) ? _CheckCut2 / Math.Sin(CalculateAngle(A, B, C) * Math.PI / 180) :
               _CheckCut2 / (90 - ((180 - Math.Sin(CalculateAngle(A, B, C)) * Math.PI / 180)));
            diag3 = (diag3 <= 90) ? _CheckCut3 / Math.Sin(CalculateAngle(C, D, A) * Math.PI / 180) :
                  _CheckCut3 / (90 - ((180 - Math.Sin(CalculateAngle(C, D, A)) * Math.PI / 180)));
            diag4 = (diag4 <= 90) ? _CheckCut4 / Math.Sin(CalculateAngle(C, D, A) * Math.PI / 180) :
                _CheckCut4 / (90 - ((180 - Math.Sin(CalculateAngle(C, D, A)) * Math.PI / 180)));
            diag1 = (!IsToothVector==true) ? 0 : diag1;
            diag2 = (!IsToothVector==true) ? 0 : diag2;
            diag3 = (!IsToothVector==true) ? 0 : diag3;
            diag4 = (!IsToothVector == true) ? 0 : diag4;

            var width = (((1 + Math.Sqrt(5)) / 2) * _SetL) + _SetB1 + _SetB2 + diag1+ diag2+ diag3+ diag4;
            var height = width*1.5;

            if (_SetH < 0 || _SetH1 < 0 || _SetL < 0 || _SetL1 < 0 || _SetB1 < 0 || _SetB2 < 0)
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

                AddIfPropertyExist(e.Properties, filteredCollection, "SetB1");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetB2");
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
                AddIfPropertyExist(e.Properties, filteredCollection, "IsToothVector");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsSelectSameAllowance");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut1");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut2");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut3");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut4");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut5");
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