using DevExpress.XtraVerticalGrid.Events;
using Socrat.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Socrat.Shape.Rectangles
{
    sealed class Shape_2 : Rectangular
    {
        public Shape_2(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
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
            using (pen1 = new Pen(Color.Black, SizeLineBoundArgument))
            {
                MoveBorderRight(Z_Base, Y_Base, SetB3);
                MoveBorderLeft(W_Base, X_Base, SetB1);
                MoveBorderTop(X_Base, Y_Base, SetB2);
            }
        }

        public override void GetShapeComponents()
        {
            #region BasePath
            using (pen1 = new Pen(Color.Black, SizeLineBoundArgument))
            {
                pen1.DashStyle = DashStyle.DashDot;
                graphicsShape.DrawLine(pen1, W_Base, X_Base);
                graphicsShape.DrawLine(pen1, X_Base, Y_Base);
                graphicsShape.DrawLine(pen1, Y_Base, Z_Base);
                graphicsShape.DrawLine(pen1, Z_Base, W_Base);
            }
            using (Pen pen = new Pen(Color.Blue, SizeLineBoundArgument))
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                pen.StartCap = LineCap.ArrowAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                pen.DashStyle = DashStyle.Solid;

                ShapePoint hs = new ShapePoint(Y_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(B));
                ShapePoint he = new ShapePoint(Z_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(A));
                Line lh = GetNewLine(hs, he);
                ShapePoint hcenter = GetNewCustomPoint(Y_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(A) - lh.Length / 2);
                graphicsShape.DrawLine(pen, hs, he);
                sf.FormatFlags = StringFormatFlags.LineLimit;
                graphicsShape.DrawString("H1=" + SetCurrentSize(SetH1), drawFontBold, Brushes.Black, hcenter, sf);

                ShapePoint b2s = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(C));
                ShapePoint b2e = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, Y_Base.PointY);
                graphicsShape.DrawLine(pen, b2s, b2e);
                Line b2h = GetNewLine(b2s, b2e);
                ShapePoint b2scenter = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, Y_Base.PointY + b2h.Length / 2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b2scenter, sf);

                ShapePoint h1s = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(C));
                ShapePoint h1e = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(D));
                Line lh1 = GetNewLine(h1s, h1e);
                ShapePoint h1center = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, DCheck.PointY - (lh1.Length / 2));
                graphicsShape.DrawLine(pen, h1s, h1e);
                graphicsShape.DrawString("H=" + SetCurrentSize(SetH), drawFontBold, Brushes.Black, h1center, sf);

                ShapePoint ls = GetNewCustomPoint(SetPointCurrentValueX(A), SetPointCurrentValueY(A) + 20 * LineBoundArgument);
                ShapePoint le = GetNewCustomPoint(SetPointCurrentValueX(D), SetPointCurrentValueY(D) + 20 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                ShapePoint lcenter = GetNewCustomPoint(SetPointCurrentValueX(A) + (ll.Length / 2), ACheck.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                graphicsShape.DrawString("L=" + SetCurrentSize(SetL), drawFontBold, Brushes.Black, lcenter, sf);

                ShapePoint b3s = GetNewCustomPoint(W_Base.PointX, SetPointCurrentValueY(A) + 20 * LineBoundArgument);
                ShapePoint b3e = GetNewCustomPoint(SetPointCurrentValueX(A), SetPointCurrentValueY(A) + 20 * LineBoundArgument);
                Line lb3 = GetNewLine(b3s, b3e);
                ShapePoint b3center = GetNewCustomPoint(W_Base.PointX + (lb3.Length / 2), SetPointCurrentValueY(A) + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b3s, b3e);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b3center, sf);

                ShapePoint b1s = GetNewCustomPoint(SetPointCurrentValueX(D), SetPointCurrentValueY(D) + 20 * LineBoundArgument);
                ShapePoint b1e = GetNewCustomPoint(Z_Base.PointX, SetPointCurrentValueY(A) + 20 * LineBoundArgument);
                Line lb1 = GetNewLine(b1s, b1e);
                ShapePoint b1center = GetNewCustomPoint(Z_Base.PointX - (lb1.Length / 2), SetPointCurrentValueY(A) + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s, b1e);
                graphicsShape.DrawString("B3=" + SetB3, drawFontBold, Brushes.Black, b1center, sf);

                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX) / 4), ((A.PointY + B.PointY + C.PointY + D.PointY) / 4));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiknessFontArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("2", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }
                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {
                    graphicsShape.DrawLine(pens, SetPointCurrentType(C), b2s);
                    ShapePoint wer = GetNewCustomPoint(SetPointCurrentValueX(C), Y_Base.PointY);
                    ShapePoint wer1 = GetNewCustomPoint(SetPointCurrentValueX(B), Y_Base.PointY);
                    graphicsShape.DrawLine(pens, wer, b2e);
                    using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        graphicsShape.DrawLine(pen1, wer, SetPointCurrentType(C));
                        graphicsShape.DrawLine(pen1, wer1, SetPointCurrentType(B));
                    }
                    graphicsShape.DrawLine(pens, le, SetPointCurrentType(D));
                    graphicsShape.DrawLine(pens, h1e, SetPointCurrentType(D));
                    graphicsShape.DrawLine(pens, ls, SetPointCurrentType(A));
                    graphicsShape.DrawLine(pens, b3e, SetPointCurrentType(A));
                    graphicsShape.DrawLine(pens, b3s, W_Base);
                    graphicsShape.DrawLine(pens, b1s, SetPointCurrentType(D));
                    graphicsShape.DrawLine(pens, b1e, Z_Base);
                    using (Pen pens1 = new Pen(Color.Red, SizeLineBoundArgument / 2))
                    {
                        graphicsShape.DrawLine(pens1, SetPointCurrentType(B), hs);
                    }
                }
            }

            #endregion
        }
        public override double SetH { get => Math.Round(C_line.Length, 0); set => base.SetH = value; }
        public override double SetL { get => Math.Round(D_line.Length, 0); set => base.SetL = value; }
        public override double SetH1 { get => Math.Round(A_line.Length, 0); set => base.SetH1 = value; }
        public override double SetH_t { get => Math.Round(C_Check_Line.Length, 0); }
        public override double SetH1_t { get => Math.Round(A_Check_Line.Length, 0); }
        public override double SetL_t { get => Math.Round(D_Check_Line.Length, 0); }
        protected override void SetHValue()
        {
            base.SetHValue();
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
            B.PointX = A.PointX;
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
        public override bool CheckValidSize()
        {
            double diag = 0;
            diag = (diag <= 90)
                ? CheckCut2 / Math.Sin(CalculateAngle(A, B, C) * Math.PI / 180)
                : (90 - ((180 - CheckCut2 / Math.Sin(CalculateAngle(A, B, C)) * Math.PI / 180)));
            var value1 = (IsToothVector == true) ? _CheckCut1 : 0;
            var value2 = (IsToothVector == true) ? _CheckCut2 : 0;
            var value3 = (IsToothVector == true) ? _CheckCut3 : 0;
            var value4 = (IsToothVector == true) ? _CheckCut4 : 0;
            var width = _SetL + _SetB1 + _SetB3 + value1 + value3;
            var height = _SetH + diag + _SetB2 + value4;

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

            else

            {
                ValidValue = false;
            }
            return ValidValue;
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
        public override void AddCustomProperties(object sender, CustomPropertyDescriptorsEventArgs e)
        {
            if (e.Context.PropertyDescriptor == null)
            {
                PropertyDescriptorCollection filteredCollection = new PropertyDescriptorCollection(null);
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH1");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL");

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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH1_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL_t");
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
