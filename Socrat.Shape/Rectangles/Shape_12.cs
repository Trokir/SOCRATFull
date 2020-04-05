using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Events;
using Socrat.Core.Entities;

namespace Socrat.Shape.Rectangles
{
    sealed class Shape_12 : Rectangular
    {
        public Shape_12(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {

        }
        public override double Perimeter
        {
            get
            {
                return Math.Round((A_line.Length + B_line.Length + C_line.Length + D_line.Length) / 1000, 3);
            }
        }
        public override double Perimeter_t
        {
            get
            {
                return Math.Round((A_Check_Line.Length + B_Check_Line.Length + C_Check_Line.Length + D_Check_Line.Length) / 1000, 3);
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
                    graphicsShape.DrawLine(pen4, D, A);
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
                    graphicsShape.DrawLine(pen4, D, A);
                }
                IsToothVector = false;
            }

            graphicsShape.FillPolygon(new SolidBrush(Color.FromArgb(30, Color.Blue)), GetBasePoints());
MoveLines();
        }
        protected override PointF[] GetBasePoints()
        {
            return new PointF[] { A, B, C, D };
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
                MoveBorderRight(Z_Base, Y_Base, SetB1);
                MoveBorderLeft(W_Base, X_Base, SetB3);
                MoveBorderTop(X_Base, Y_Base, SetB2);
                MoveBorderBottom(W_Base, Z_Base, SetB4);
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
                MoveInternalLineFromTop(graphicsShape, X_Base, Y_Base, First_B_Some_Size_Point, Second_B_Some_Size_Point, SetB2, SetB4);
                MoveInternalLineFromRight(graphicsShape, Z_Base, Y_Base, First_B_Some_Size_Point, Second_B_Some_Size_Point, SetB1, SetB4);
                FindPointDrawLine(SetPointCurrentType(C), SetPointCurrentType(B), SetB4, SetB1, SetB2);
            }
            using (Pen pen = new Pen(Color.Blue, SizeLineBoundArgument))
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                pen.StartCap = LineCap.ArrowAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                pen.DashStyle = DashStyle.Solid;
                sf.FormatFlags = StringFormatFlags.LineLimit;

                ShapePoint hs = GetNewCustomPoint(Y_Base.PointX + 30 * LineBoundArgument, SetPointCurrentValueY(C));
                ShapePoint he = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, SetPointCurrentValueY(D));
                Line lh = GetNewLine(hs, he);
                ShapePoint hcenter = GetNewCustomPoint(Y_Base.PointX + 30 * LineBoundArgument, SetPointCurrentValueY(D) - lh.Length / 2);
                graphicsShape.DrawLine(pen, hs, he);
                graphicsShape.DrawString("H=" + SetCurrentSize(SetH), drawFontBold, Brushes.Black, hcenter, sf);

                ShapePoint b4s = GetNewCustomPoint(Y_Base.PointX + 10 * LineBoundArgument, X_Base.PointY);
                ShapePoint b4e = GetNewCustomPoint(Y_Base.PointX + 10 * LineBoundArgument, X_Base.PointY + SetB4);
                graphicsShape.DrawLine(pen, b4s, b4e);
                Line b4h = GetNewLine(b4s, b4e);
                ShapePoint b4scenter = GetNewCustomPoint(Y_Base.PointX + 10 * LineBoundArgument, X_Base.PointY + b4h.Length / 2);
                graphicsShape.DrawString("B4=" + SetB4, drawFontBold, Brushes.Black, b4scenter, sf);

                ShapePoint b4s2 = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, W_Base.PointY);
                ShapePoint b4e2 = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, W_Base.PointY - SetB4);
                graphicsShape.DrawLine(pen, b4s2, b4e2);
                Line b4h2 = GetNewLine(b4s2, b4e2);
                ShapePoint b42scenter = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, Z_Base.PointY - b4h2.Length / 2);
                graphicsShape.DrawString("B4=" + SetB4, drawFontBold, Brushes.Black, b42scenter, sf);

                ShapePoint b4s1 = GetNewCustomPoint(Z_Base.PointX, Z_Base.PointY + 20 * LineBoundArgument);
                ShapePoint b4e1 = GetNewCustomPoint(Z_Base.PointX - SetB4, Z_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b4s1, b4e1);
                Line b4h1 = GetNewLine(b4s1, b4e1);
                ShapePoint b41scenter = GetNewCustomPoint(Z_Base.PointX, Z_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawString("B4=" + SetB4, drawFontBold, Brushes.Black, b41scenter, sf);

                ShapePoint b2s = GetNewCustomPoint(Y_Base.PointX + 40 * LineBoundArgument, SetPointCurrentValueY(C));
                ShapePoint b2e = GetNewCustomPoint(Y_Base.PointX + 40 * LineBoundArgument, Y_Base.PointY);
                graphicsShape.DrawLine(pen, b2s, b2e);
                Line b2h = GetNewLine(b2s, b2e);
                ShapePoint b2scenter = GetNewCustomPoint(Y_Base.PointX + 40 * LineBoundArgument, Y_Base.PointY + b2h.Length / 2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b2scenter, sf);

                ShapePoint b3s = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 40 * LineBoundArgument);
                ShapePoint b3e = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 40 * LineBoundArgument);
                Line lb3 = GetNewLine(b3s, b3e);
                ShapePoint b3center = GetNewCustomPoint(W_Base.PointX + (lb3.Length / 2), W_Base.PointY + 40 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b3s, b3e);
                graphicsShape.DrawString("B3=" + SetB3, drawFontBold, Brushes.Black, b3center, sf);

                ShapePoint h1s = GetNewCustomPoint(Y_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(B));
                ShapePoint h1e = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(A));
                Line lh1 = GetNewLine(h1s, h1e);
                ShapePoint h1center = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(D) - (lh1.Length / 2));
                graphicsShape.DrawLine(pen, h1s, h1e);
                graphicsShape.DrawString("H1=" + SetCurrentSize(SetH1), drawFontBold, Brushes.Black, h1center, sf);

                ShapePoint b1s = GetNewCustomPoint(SetPointCurrentValueX(C), Z_Base.PointY + 40 * LineBoundArgument);
                ShapePoint b1e = GetNewCustomPoint(Z_Base.PointX, Z_Base.PointY + 40 * LineBoundArgument);
                Line lb1 = GetNewLine(b1s, b1e);
                ShapePoint b1center = GetNewCustomPoint(Z_Base.PointX + (lb1.Length / 2), Z_Base.PointY + 60 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s, b1e);
                sf.Alignment = StringAlignment.Far;
                sf.LineAlignment = StringAlignment.Far;
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b1center, sf);

                ShapePoint ls = GetNewCustomPoint(SetPointCurrentValueX(C), Z_Base.PointY + 40 * LineBoundArgument);
                ShapePoint le = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 40 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                ShapePoint lcenter = GetNewCustomPoint(SetPointCurrentValueX(A) + (ll.Length / 2), W_Base.PointY + 40 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                graphicsShape.DrawString("L=" + SetCurrentSize(SetL), drawFontBold, Brushes.Black, lcenter, sf);

                ShapePoint ls1 = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 20 * LineBoundArgument);
                ShapePoint le1 = GetNewCustomPoint(SetPointCurrentValueX(D), W_Base.PointY + 20 * LineBoundArgument);
                Line ll1 = GetNewLine(ls1, le1);
                ShapePoint l1center = GetNewCustomPoint(SetPointCurrentValueX(A) + (ll1.Length / 2), W_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls1, le1);
                graphicsShape.DrawString("L1=" + SetCurrentSize(SetL1), drawFontBold, Brushes.Black, l1center, sf);

                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX) / 4), ((A.PointY + B.PointY + C.PointY + D.PointY) / 4));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiknessFontArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("12", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }
                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {

                    ShapePoint wer = GetNewCustomPoint(W_Base.PointX, SetPointCurrentValueY(A));
                    ShapePoint wer1 = GetNewCustomPoint(Z_Base.PointX, SetPointCurrentValueY(A));
                    ShapePoint wer2 = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY);
                    ShapePoint wer3 = GetNewCustomPoint(SetPointCurrentValueX(B), X_Base.PointY);
                    ShapePoint wer4 = GetNewCustomPoint(Y_Base.PointX - SetB4, Z_Base.PointY);
                    using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        graphicsShape.DrawLine(pen1, wer, SetPointCurrentType(A));
                        graphicsShape.DrawLine(pen1, wer1, SetPointCurrentType(D));
                        graphicsShape.DrawLine(pen1, wer2, SetPointCurrentType(A));
                        graphicsShape.DrawLine(pen1, wer3, SetPointCurrentType(B));
                    }
                    graphicsShape.DrawLine(pens, wer1, he);
                    graphicsShape.DrawLine(pens, hs, SetPointCurrentType(C));
                    graphicsShape.DrawLine(pens, b2e, Y_Base);
                    graphicsShape.DrawLine(pens, b2s, SetPointCurrentType(C));
                    graphicsShape.DrawLine(pens, le, SetPointCurrentType(A));
                    graphicsShape.DrawLine(pens, ls, SetPointCurrentType(C));
                    graphicsShape.DrawLine(pens, le1, SetPointCurrentType(D));
                    graphicsShape.DrawLine(pens, b3e, W_Base);
                    graphicsShape.DrawLine(pens, b1e, Z_Base);
                    using (Pen pens1 = new Pen(Color.Red, SizeLineBoundArgument / 2))
                    {
                        graphicsShape.DrawLine(pens1, h1s, SetPointCurrentType(B));
                    }
                    graphicsShape.DrawLine(pens, b4e1, wer4);

                }

            }

            #endregion
        }
        protected override void FindPointDrawLine(ShapePoint firsrPoint, ShapePoint secondPoint, double factor = 0, double anotherFactor = 0, double thofactor = 0)
        {
            double length = 0;


            ShapePoint point = GetNewCustomPoint((firsrPoint.PointX + anotherFactor - factor), (firsrPoint.PointY));
            Line fdfLine = GetNewLine(point, firsrPoint);

            ShapePoint twoPoint = GetNewCustomPoint((firsrPoint.PointX), (firsrPoint.PointY + thofactor - factor));
            Line tLine = GetNewLine(firsrPoint, twoPoint);
            Line oLine = GetNewLine(firsrPoint, secondPoint);
            if (fdfLine.Length != 0 && tLine.Length != 0)
            {
                length = Math.Sqrt((Math.Pow(fdfLine.Length, 2) + Math.Pow(tLine.Length, 2))) + oLine.Length;
                double length1 = Math.Sqrt((Math.Pow(fdfLine.Length, 2) + Math.Pow(tLine.Length, 2)));
            }
            else
            {
                length = +oLine.Length;
            }
            ShapePoint bnP = GetNewPoint();
            bnP.PointX = point.PointX;
            bnP.PointY = secondPoint.PointY + (firsrPoint.PointY - secondPoint.PointY) *
                (length / Math.Sqrt(Math.Pow((firsrPoint.PointX - secondPoint.PointX), 2) +
                Math.Pow((firsrPoint.PointY - secondPoint.PointY), 2)));
            if (SetB4 > SetB1 || SetB4 > SetB2) { ValidateSetSizeMessage("Значение 'B4' не может быть больше 'B1' или 'B2'"); SetB4 = 0; }
            else
            {
                if (fdfLine.Length != 0 && tLine.Length != 0 && SetB4 < SetB1 && SetB4 < SetB2)
                {
                    using (Pen pen = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        graphicsShape.DrawLine(pen, firsrPoint, bnP);
                    }
                }
            }
        }
        public override double SetH { get => Math.Round(GetNewLine(GetNewCustomPoint(C.PointX, D.PointY), C).Length, 0); set => base.SetH = value; }
        public override double SetH1 { get => Math.Round(A_line.Length, 0); set => base.SetH1 = value; }
        public override double SetL { get => Math.Round(GetNewLine(GetNewCustomPoint(C.PointX, D.PointY), A).Length, 0); set => base.SetL = value; }
        public override double SetL1 { get => Math.Round(D_line.Length, 0); set => base.SetL1 = value; }
        public override double SetH_t
        {
            get
            {
                ShapePoint d = GetNewCustomPoint(CCheck.PointX, DCheck.PointY);
                Line l = GetNewLine(d, CCheck);
                return l.Length;
            }
        }
        public override double SetH1_t { get => Math.Round(A_Check_Line.Length, 0); }
        public override double SetL_t
        {
            get
            {
                ShapePoint sp = GetNewCustomPoint(CCheck.PointX, DCheck.PointY);
                Line l = GetNewLine(sp, ACheck);
                return Math.Round(l.Length, 0);
            }
        }
        public override double SetL1_t { get => Math.Round(D_line.Length, 0); }
        protected override void SetHValue()
        {
            base.SetHValue();
            Move(0, CheckCut2 * 10);
            Move(0, CheckCut3 * 10);
            CurvePoint.PointX = D.PointX;
            CurvePoint.PointY = C.PointY;
            TempPoint.PointX = SetCurrentLineLength(CurvePoint, D, _SetH).PointX;
            TempPoint.PointY = SetCurrentLineLength(CurvePoint, D, _SetH).PointY;
            double diff = D.PointY - TempPoint.PointY;
            B.PointY -= diff;
            D.PointX = TempPoint.PointX;
            D.PointY = TempPoint.PointY;
            A.PointY = D.PointY;
            ValidValue = false;
        }
        protected override void SetLValue()
        {
            base.SetLValue();
            ShapePoint Sp = GetNewCustomPoint(C.PointX, D.PointY);
            C.PointX = SetCurrentLineLength(A, Sp, _SetL).PointX;
            ValidValue = false;
        }
        protected override void SetL1Value()
        {
            D.PointX = SetCurrentLineLength(A, D, _SetL1).PointX;
            ValidValue = false;
        }
        protected override void SetH1Value()
        {
            base.SetH1Value();
            B.PointX = A.PointX;
            B.PointY = SetCurrentLineLength(A, B, _SetH1).PointY;
            ValidValue = false;
        }
        public override void GetExtremumPoints()
        {

            List<ShapePoint> pointList = new List<ShapePoint>() { A, B, C, D, ACheck, BCheck, CCheck, DCheck };

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
            var value1 = (IsToothVector==true) ? _CheckCut1 : 0;
            var value2 = (IsToothVector==true) ? _CheckCut2 : 0;
            var value3 = (IsToothVector==true) ? _CheckCut3 : 0;
            var value4 = (IsToothVector == true) ? _CheckCut4 : 0;
            var width = _SetL + _SetB1 + _SetB3 + value1 + value3;
            var height = _SetH + diag + _SetB4 + SetB2 + value4;

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
            else if ((_SetL > 0) && _SetL < SetL1)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение L не может быть меньше L1");
            }
            else if ((_SetL1 > 0) && _SetL1 > SetL)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение L1 не может быть больше L");
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH1");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL1");

                AddIfPropertyExist(e.Properties, filteredCollection, "SetB1");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetB2");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetB3");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetB4");
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH1_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL1_t");
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
