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
    sealed class Shape_35 : Rectangular
    {
        public Shape_35(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList) { }
        protected override void DrawMainLines()
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
        }

        private void MoveLines()
        {
            using (Pen pen = new Pen(Color.Black, SizeLineBoundArgument))
            {
               
                MoveBorderRight(Z_Base, Y_Base, SetB1);
                MoveBorderLeft(W_Base, X_Base, SetB1);
                MoveBorderTop(X_Base, Y_Base, SetB2);
                MoveBorderBottom(W_Base, Z_Base, SetB2);
            }
            using (Pen pen3 = new Pen(Color.Black, ThiсknessArgument))
            {
                graphicsShape.DrawLine(pen3, A_downFault, B_downFault);
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

                ShapePoint hs = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, B.PointY);
                ShapePoint he = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, A.PointY);
                Line lh = GetNewLine(hs, he);
                ShapePoint hcenter = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, A.PointY - lh.Length / 2);
                graphicsShape.DrawLine(pen, hs, he);
                sf.FormatFlags = StringFormatFlags.LineLimit;
                graphicsShape.DrawString("H=" + SetH, drawFontBold, Brushes.Black, hcenter, sf);

                ShapePoint b2s = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, B.PointY);
                ShapePoint b2e = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, X_Base.PointY);
                graphicsShape.DrawLine(pen, b2s, b2e);
                Line b2h = GetNewLine(b2s, b2e);
                ShapePoint b2scenter = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, X_Base.PointY + b2h.Length / 2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b2scenter, sf);


                ShapePoint l1s = GetNewCustomPoint(A.PointX, W_Base.PointY + 10 * LineBoundArgument);
                ShapePoint l1e = GetNewCustomPoint(B.PointX, W_Base.PointY + 10 * LineBoundArgument);
                graphicsShape.DrawLine(pen, l1s, l1e);
                Line l1h = GetNewLine(l1s, l1e);
                ShapePoint l1scenter = GetNewCustomPoint(A.PointX + l1h.Length / 2, Z_Base.PointY + 10 * LineBoundArgument);
                graphicsShape.DrawString("L1=" + SetL1, drawFontBold, Brushes.Black, l1scenter, sf);

                ShapePoint b2s1 = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, A.PointY);
                ShapePoint b2e1 = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, W_Base.PointY);
                graphicsShape.DrawLine(pen, b2s1, b2e1);
                Line b2h1 = GetNewLine(b2s1, b2e1);
                ShapePoint b21scenter = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, W_Base.PointY - b2h1.Length / 2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b21scenter, sf);

                ShapePoint ls = GetNewCustomPoint(A.PointX, W_Base.PointY + 30 * LineBoundArgument);
                ShapePoint le = GetNewCustomPoint(C.PointX, W_Base.PointY + 30 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                ShapePoint lcenter = GetNewCustomPoint(A.PointX + (ll.Length / 2), W_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                graphicsShape.DrawString("L=" + SetL, drawFontBold, Brushes.Black, lcenter, sf);

                ShapePoint b3s = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 30 * LineBoundArgument);
                ShapePoint b3e = GetNewCustomPoint(A.PointX, W_Base.PointY + 30 * LineBoundArgument);
                Line lb3 = GetNewLine(b3s, b3e);
                ShapePoint b3center = GetNewCustomPoint(W_Base.PointX + (lb3.Length / 2), W_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b3s, b3e);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b3center, sf);

                ShapePoint b1s = GetNewCustomPoint(C.PointX, W_Base.PointY + 30 * LineBoundArgument);
                ShapePoint b1e = GetNewCustomPoint(Z_Base.PointX, W_Base.PointY + 30 * LineBoundArgument);
                Line lb1 = GetNewLine(b1s, b1e);
                ShapePoint b1center = GetNewCustomPoint(Z_Base.PointX - (lb1.Length / 2), W_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s, b1e);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b1center, sf);

                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX) / 4), ((A.PointY + B.PointY + C.PointY + D.PointY) / 4));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiknessFontArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("35", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }
                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {
                    ShapePoint wer1 = GetNewCustomPoint(W_Base.PointX, B.PointY);
                    ShapePoint wer2 = GetNewCustomPoint(Z_Base.PointX, C.PointY);
                    ShapePoint wer3 = GetNewCustomPoint(Z_Base.PointX, D.PointY);
                    ShapePoint wer4 = GetNewCustomPoint(W_Base.PointX, A.PointY);

                    using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        graphicsShape.DrawLine(pen1, wer1, B);
                        graphicsShape.DrawLine(pen1, wer2, C);
                        graphicsShape.DrawLine(pen1, wer3, D);
                        graphicsShape.DrawLine(pen1, wer4, A);
                    }
                    graphicsShape.DrawLine(pens, ls, A);
                    graphicsShape.DrawLine(pens, b1e, Z_Base);
                    graphicsShape.DrawLine(pens, b3s, W_Base);
                    graphicsShape.DrawLine(pens, hs, wer2);
                    graphicsShape.DrawLine(pens, he, wer3);
                    graphicsShape.DrawLine(pens, b2e1, Z_Base);
                    graphicsShape.DrawLine(pens, b2e, Y_Base);
                    using (Pen pens1 = new Pen(Color.Red, SizeLineBoundArgument / 2))
                    {
                        graphicsShape.DrawLine(pens1, l1e, B);
                    }
                }
            }
            #endregion
        }
        public override double Perimeter
        {
            get
            {
                return Math.Round((A_line.Length + B_line.Length + C_line.Length + D_line.Length) / 1000, 3);
            }
        }
        public override double SetH { get => Math.Round(GetNewLine(GetNewCustomPoint(C.PointX, D.PointY), C).Length, 0); set => base.SetH = value; }
        public override double SetL { get => Math.Round(GetNewLine(GetNewCustomPoint(C.PointX, D.PointY), A).Length, 0); set => base.SetL = value; }
        public override double SetL1 { get => Math.Round(GetNewLine(GetNewCustomPoint(A.PointX, B.PointY), B).Length, 0); set => base.SetL1 = value; }
        protected override void SetHValue()
        {
            base.SetHValue();
            // Move(0, _SetH);
            var p = B.PointY;
            CurvePoint.PointX = C.PointX;
            CurvePoint.PointY = C.PointY;
            B.PointY = SetCurrentLineLength(A, B, _SetH).PointY;
            C.PointY = B.PointY;
            var diff = C.PointY - CurvePoint.PointY;
            B_downFault.PointY += diff;
            B_upFault.PointX = B_downFault.PointX;
            B_upFault.PointY = B_downFault.PointY;
            var diffr = p - B.PointY;
            Move(y: diffr);
            ValidValue = false;
        }
        protected override void SetLValue()
        {
            base.SetLValue();
            var p = A.PointX;
            CurvePoint.PointX = A.PointX + D_line.Length / 2;
            CurvePoint.PointY = A.PointY;
            var size = _SetL - SetL1;
            D.PointX = SetCurrentLineLength(CurvePoint, D, size / 2).PointX;
            A.PointX = SetCurrentLineLength(CurvePoint, A, size / 2).PointX;
            CurvePoint.PointX = B.PointX + B_line.Length / 2;
            CurvePoint.PointY = B.PointY;
            C.PointX = SetCurrentLineLength(CurvePoint, C, size / 2).PointX;
            B.PointX = SetCurrentLineLength(CurvePoint, B, size / 2).PointX;
            var diff = p - A.PointX;
            Move(x: diff);
            ValidValue = false;
        }
        protected override void SetL1Value()
        {
            base.SetL1Value();
            TempPoint.PointX = A.PointX - 1;
            TempPoint.PointY = B.PointY;
            B.PointX = SetCurrentLineLength(TempPoint, B, _SetL1).PointX + 1;
            TempPoint.PointX = C.PointX + 1;
            TempPoint.PointY = D.PointY;
            D.PointX = SetCurrentLineLength(TempPoint, D, _SetL1).PointX - 1;
            var upLine = GetNewLine(B, C);
            B_downFault.PointX = SetCurrentLineLength(C, B_downFault, upLine.Length / 2).PointX;
            var downLine = GetNewLine(D, A);
            A_downFault.PointX = SetCurrentLineLength(A, A_downFault, downLine.Length / 2).PointX;
            ValidValue = false;
        }
        public override bool IsVerticalFaultLine
        {
            get { return _IsVerticalFaultLine; }
            set
            {
                SetField(ref _IsVerticalFaultLine, value, () => IsVerticalFaultLine);
                // IsDrawFaultLine = false;
                IsHasFaultLine = true;
                A_upFault = null;
                A_downFault = null;
                B_upFault = null;
                B_downFault = null;
                A_upFault = GetNewPoint();
                A_downFault = GetNewPoint();
                B_upFault = GetNewPoint();
                B_downFault = GetNewPoint();
                A_upFault.PointX = A.PointX + D_line.Length / 2;
                A_upFault.PointY = A.PointY;
                A_downFault.PointX = A_upFault.PointX;
                A_downFault.PointY = A_upFault.PointY;
                B_upFault.PointX = B.PointX + D_line.Length / 2;
                B_upFault.PointY = B.PointY;
                B_downFault.PointX = B_upFault.PointX;
                B_downFault.PointY = B_upFault.PointY;
            }
        }
        public override void GetExtremumPoints()
        {

            List<ShapePoint> pointList = new List<ShapePoint>() { A, B, C, D };

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
            double diag3 = 0;
            diag1 = (diag1 <= 90) ? _CheckCut1 / Math.Sin(CalculateAngle(D, A, B) * Math.PI / 180) :
                (90 - ((180 - _CheckCut1 / Math.Sin(CalculateAngle(D, A, B)) * Math.PI / 180)));
            diag3 = (diag3 <= 90) ? _CheckCut3 / Math.Sin(CalculateAngle(B, C, D) * Math.PI / 180) :
                (90 - ((180 - _CheckCut3 / Math.Sin(CalculateAngle(B, C, D)) * Math.PI / 180)));
            diag1 = (IsToothVector == true) ? 0 : diag1;
            diag3 = (IsToothVector == true) ? 0 : diag3;
            var value2 = (IsToothVector == true) ? _CheckCut2 : 0;
            var value4 = (IsToothVector == true) ? _CheckCut4 : 0;

            var width = _SetL + _SetB1 * 2 + diag1 + diag3;
            var height = _SetH + _SetB2 * 2 + value2 + value4;

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
            else if ((_SetL > 0) && _SetL < SetL1)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение H не может быть меньше H1");
            }
            else if ((_SetL1 > 0) && _SetL1 > SetL)
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
        public override void AddCustomProperties(object sender, CustomPropertyDescriptorsEventArgs e)
        {

            if (e.Context.PropertyDescriptor == null)
            {
                PropertyDescriptorCollection filteredCollection = new PropertyDescriptorCollection(null);
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL1");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetB1");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetB2");
                AddIfPropertyExist(e.Properties, filteredCollection, "ShapeKis");
                AddIfPropertyExist(e.Properties, filteredCollection, "ShapeKisPersent");
                AddIfPropertyExist(e.Properties, filteredCollection, "Area");
                AddIfPropertyExist(e.Properties, filteredCollection, "TrueArea");
                AddIfPropertyExist(e.Properties, filteredCollection, "BaseArea");
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