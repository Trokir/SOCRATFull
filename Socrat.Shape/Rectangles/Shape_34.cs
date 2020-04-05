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
    public sealed class Shape_34 : Rectangular
    {
        public Shape_34(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {

        }
        protected override void DrawMainLines()
        {
            using (pen1 = new Pen(SelectMainLineColor1(), ThiсknessArgument))
            {
                graphicsShape.DrawLine(pen1, A_upFault, B);
            }
            using (pen2 = new Pen(SelectMainLineColor2(), ThiсknessArgument))
            {
                graphicsShape.DrawLine(pen2, B, B_upFault);
            }
            using (pen3 = new Pen(SelectMainLineColor3(), ThiсknessArgument))
            {
                graphicsShape.DrawLine(pen3, A_downFault, D);
            }
            using (pen4 = new Pen(SelectMainLineColor4(), ThiсknessArgument))
            {
                graphicsShape.DrawLine(pen4, B_downFault, D);
            }
            graphicsShape.FillPolygon(new SolidBrush(Color.FromArgb(30, Color.Blue)), GetBasePoints());
            graphicsShape.FillPolygon(new SolidBrush(Color.FromArgb(30, Color.Blue)), GetBasePoints1());
            MoveLines();
        }
        protected override PointF[] GetBasePoints()
        {
            return new PointF[] { D, A_downFault, B_downFault };
        }
        private PointF[] GetBasePoints1()
        {
            return new PointF[] { A_upFault, B, B_upFault };
        }
        protected override void CheckForeignBorders()
        {
            GetExtremumPoints();
        }

        private void MoveLines()
        {
            using (Pen pen = new Pen(Color.Black, SizeLineBoundArgument))
            {
               
                MoveBorderRight(Z_Base, Y_Base, SetB2);
                MoveBorderLeft(W_Base, X_Base, SetB2);
                MoveBorderBottom(W_Base, Z_Base, SetB2);
                MoveBorderTop(X_Base, Y_Base, SetB2);
            }
        }
        protected override void AllowanceProcessing()
        {
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
                using (Pen pen3 = new Pen(Color.Black, ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen3, A_downFault, B_downFault);
                    graphicsShape.DrawLine(pen3, A_upFault, B_upFault);
                }
            }
            using (Pen pen = new Pen(Color.Blue, SizeLineBoundArgument))
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                pen.StartCap = LineCap.ArrowAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                pen.DashStyle = DashStyle.Solid;
                ShapePoint hs = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, B_downFault.PointY);
                ShapePoint he = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, D.PointY);
                Line lh = GetNewLine(hs, he);
                ShapePoint hcenter = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, D.PointY - lh.Length / 2);
                graphicsShape.DrawLine(pen, hs, he);
                sf.FormatFlags = StringFormatFlags.LineLimit;
                graphicsShape.DrawString("H=" + SetH, drawFontBold, Brushes.Black, hcenter, sf);

                ShapePoint ls = GetNewCustomPoint(A_downFault.PointX, Z_Base.PointY + 10 * LineBoundArgument);
                ShapePoint le = GetNewCustomPoint(B_downFault.PointX, Z_Base.PointY + 10 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                ShapePoint lcenter = GetNewCustomPoint(A.PointX + (ll.Length / 2), Z_Base.PointY + 10 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                graphicsShape.DrawString("L=" + SetL, drawFontBold, Brushes.Black, lcenter, sf);

                ShapePoint b2s = GetNewCustomPoint(X_Base.PointX, W_Base.PointY + 10 * LineBoundArgument);
                ShapePoint b2e = GetNewCustomPoint(A_upFault.PointX, W_Base.PointY + 10 * LineBoundArgument);
                Line lb2 = GetNewLine(b2s, b2e);
                ShapePoint b2center = GetNewCustomPoint(X_Base.PointX + (lb2.Length / 2), W_Base.PointY + 10 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b2s, b2e);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b2center, sf);

                ShapePoint b2s1 = GetNewCustomPoint(B_upFault.PointX, Z_Base.PointY + 10 * LineBoundArgument);
                ShapePoint b2e1 = GetNewCustomPoint(Y_Base.PointX, Z_Base.PointY + 10 * LineBoundArgument);
                Line lb21 = GetNewLine(b2s1, b2e1);
                ShapePoint b21center = GetNewCustomPoint(Y_Base.PointX - (lb21.Length / 2), W_Base.PointY + 10 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b2s1, b2e1);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b21center, sf);

                ShapePoint b2s2 = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, Y_Base.PointY);
                ShapePoint b2e2 = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, B_upFault.PointY);
                Line lb22 = GetNewLine(b2s2, b2e2);
                ShapePoint b22center = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, Y_Base.PointY + (lb22.Length / 2));
                graphicsShape.DrawLine(pen, b2s2, b2e2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b22center, sf);

                ShapePoint b2s3 = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, Z_Base.PointY);
                ShapePoint b2e3 = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, D.PointY);
                Line lb23 = GetNewLine(b2s3, b2e3);
                ShapePoint b23center = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, Z_Base.PointY - (lb23.Length / 2));
                graphicsShape.DrawLine(pen, b2s3, b2e3);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b23center, sf);


                ShapePoint b1s = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, B_upFault.PointY);
                ShapePoint b1e = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, B_downFault.PointY);
                Line lb1 = GetNewLine(b1s, b1e);
                ShapePoint b1center = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, B_downFault.PointY - (lb1.Length / 2));
                graphicsShape.DrawLine(pen, b1s, b1e);
                Line lwe = GetNewLine(A_downFault, A_upFault);
                Line B_up = GetNewLine(D, B_upFault);
                graphicsShape.DrawString("B1=" + (lwe.Length), drawFontBold, Brushes.Black, b1center, sf);

                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX) / 4), ((A.PointY + B.PointY + C.PointY + D.PointY) / 4));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiknessFontArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("34", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }
                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {
                    ShapePoint wer = GetNewCustomPoint(W_Base.PointX, B.PointY);
                    ShapePoint wer1 = GetNewCustomPoint(B.PointX, X_Base.PointY);
                    ShapePoint wer2 = GetNewCustomPoint(B_upFault.PointX, Y_Base.PointY);
                    ShapePoint wer3 = GetNewCustomPoint(Z_Base.PointX, B_upFault.PointY);
                    ShapePoint wer4 = GetNewCustomPoint(Z_Base.PointX, D.PointY);
                    ShapePoint wer5 = GetNewCustomPoint(D.PointX, Z_Base.PointY);
                    ShapePoint wer6 = GetNewCustomPoint(W_Base.PointX, A_downFault.PointY);
                    ShapePoint wer7 = GetNewCustomPoint(A_downFault.PointX, Z_Base.PointY);
                    using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        graphicsShape.DrawLine(pen1, wer, B);
                        graphicsShape.DrawLine(pen1, wer1, B);
                        graphicsShape.DrawLine(pen1, wer2, B_downFault);
                        graphicsShape.DrawLine(pen1, wer3, B_upFault);
                        graphicsShape.DrawLine(pen1, wer4, D);
                        graphicsShape.DrawLine(pen1, wer5, D);
                        graphicsShape.DrawLine(pen1, wer6, A_downFault);
                        graphicsShape.DrawLine(pen1, wer7, A_upFault);
                    }

                    graphicsShape.DrawLine(pens, he, D);
                    graphicsShape.DrawLine(pens, hs, B_downFault);
                    graphicsShape.DrawLine(pens, ls, wer7);
                    graphicsShape.DrawLine(pens, le, wer5);
                    graphicsShape.DrawLine(pens, b1s, wer3);
                    using (Pen pens1 = new Pen(Color.Red, SizeLineBoundArgument / 2))
                    {
                        // graphicsShape.DrawLine(pens1, hs, A_downFault);
                    }
                }

            }

            #endregion
        }
        public override double Area
        {
            get
            {
                double baseSquare = 0.5 * Math.Abs((A_upFault.PointX * B_upFault.PointY + B_upFault.PointX * B.PointY + B.PointX * A_upFault.PointY) - (B_upFault.PointX * A_upFault.PointY + B.PointX * B_upFault.PointY + A_upFault.PointX * B.PointY));
                double baseSquare1 = 0.5 * Math.Abs((A_downFault.PointX * B_downFault.PointY + B_downFault.PointX * D.PointY + D.PointX * A_downFault.PointY) - (B_downFault.PointX * A_downFault.PointY + D.PointX * B_downFault.PointY + A_downFault.PointX * D.PointY));
                return Math.Round((baseSquare1 + baseSquare1) / 1000000, 3);
            }
        }
        public override double Perimeter
        {

            //TODO: Уточнить
            get
            {
                Line a = GetNewLine(D, A_downFault);
                Line b = GetNewLine(B_downFault, D);
                Line c = GetNewLine(A_upFault, B);
                Line d = GetNewLine(B, B_upFault);
                Line e = GetNewLine(A_downFault, B_downFault);
                Line f = GetNewLine(A_upFault, B_upFault);
                return Math.Round((a.Length + b.Length + c.Length + d.Length + e.Length + f.Length) / 1000, 3);
            }
        }
        public override double SetH { get => Math.Round(GetNewLine(D, B_downFault).Length, 0); set => base.SetH = value; }
        public override double SetL { get => Math.Round(GetNewLine(A_downFault, D).Length, 0); set => base.SetL = value; }
        public override double SetB1
        {
            get => Math.Round(GetNewLine(A_downFault, A_upFault).Length, 0);
            set
            {
                TempValue = SetB1;
                SetField(ref _SetB1, value, () => SetB1);
                if (!CheckValidSize()) SetB1Value();
                else
                {
                    _SetB1 = TempValue;
                    return;
                }
            }
        }
        protected override void SetHValue()
        {
            base.SetHValue();
            Move(0, _SetH);
            B_downFault.PointX = SetCurrentLineLength(D, B_downFault, _SetH).PointX;
            B_downFault.PointY = SetCurrentLineLength(D, B_downFault, _SetH).PointY;
            B_upFault.PointX = B_downFault.PointX;
            B_upFault.PointY = B_downFault.PointY - _SetB1;
            B.PointY = B_upFault.PointY;
            ValidValue = false;
        }
        protected override void SetLValue()
        {
            base.SetLValue();
            Move(_SetL / 2, 0);
            var line = GetNewLine(A_downFault, D);
            CurvePoint.PointX = D.PointX - line.Length / 2;
            CurvePoint.PointY = D.PointY;
            A_downFault.PointX = SetCurrentLineLength(CurvePoint, A_downFault, _SetL / 2).PointX;
            A_downFault.PointY = SetCurrentLineLength(CurvePoint, A_downFault, _SetL / 2).PointY;
            A_upFault.PointX = A_downFault.PointX;
            B.PointX = A_downFault.PointX;
            D.PointX = SetCurrentLineLength(CurvePoint, D, _SetL / 2).PointX;
            D.PointY = SetCurrentLineLength(CurvePoint, D, _SetL / 2).PointY;
            B_downFault.PointX = D.PointX;
            B_upFault.PointX = B_downFault.PointX;
            ValidValue = false;
        }
        protected override void SetB1Value()
        {
            base.SetB1Value();
            Move(0, _SetB1);
            A_downFault.PointY += 0.0001;
            TempPoint.PointX = SetCurrentLineLength(A_downFault, A_upFault, _SetB1).PointX;
            TempPoint.PointY = SetCurrentLineLength(A_downFault, A_upFault, _SetB1).PointY;
            A_upFault.PointX = TempPoint.PointX;
            A_upFault.PointY = TempPoint.PointY - 0.0001;
            B_downFault.PointY += 0.0001;
            TempPoint.PointX = SetCurrentLineLength(B_downFault, B_upFault, _SetB1).PointX;
            TempPoint.PointY = SetCurrentLineLength(B_downFault, B_upFault, _SetB1).PointY;
            B_upFault.PointX = TempPoint.PointX;
            B_upFault.PointY = TempPoint.PointY - 0.0001;
            B.PointY = B_upFault.PointY;
            ValidValue = false;
        }
        public override void GetExtremumPoints()
        {

            List<ShapePoint> pointList = new List<ShapePoint>() { B, D, A_downFault, A_upFault, B_downFault, B_upFault };

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
            var value1 = (IsToothVector==true) ? _CheckCut1 : 0;
            var value2 = (IsToothVector==true) ? _CheckCut2 : 0;
            var value3 = (IsToothVector==true) ? _CheckCut3 : 0;
            var value4 = (IsToothVector == true) ? _CheckCut4 : 0;
            var width = _SetL + _SetB2 * 2 + value1 + value3;
            var height = _SetH + _SetB2 * 2 + _SetB1 + value2 + value4;

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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetB1");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetB2");
                AddIfPropertyExist(e.Properties, filteredCollection, "Area");
                AddIfPropertyExist(e.Properties, filteredCollection, "BaseArea");
                AddIfPropertyExist(e.Properties, filteredCollection, "ShapeKis");
                AddIfPropertyExist(e.Properties, filteredCollection, "ShapeKisPersent");
                AddIfPropertyExist(e.Properties, filteredCollection, "Perimeter");
                AddIfPropertyExist(e.Properties, filteredCollection, "ShapeHeightValue");
                AddIfPropertyExist(e.Properties, filteredCollection, "ShapeWidthValue");
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
