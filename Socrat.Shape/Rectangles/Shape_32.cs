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
    sealed class Shape_32 : Rectangular
    {
        public Shape_32(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {

        }
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
            AllowanceProcessing();
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
                sf.FormatFlags = StringFormatFlags.LineLimit;

                ShapePoint hs = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, BCheck.PointY);
                ShapePoint he = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, ACheck.PointY);
                Line lh = GetNewLine(hs, he);
                ShapePoint hcenter = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, ACheck.PointY - lh.Length / 2);
                graphicsShape.DrawLine(pen, hs, he);
                graphicsShape.DrawString("H=" + SetH, drawFontBold, Brushes.Black, hcenter, sf);

                ShapePoint b2s = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, BCheck.PointY);
                ShapePoint b2e = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, X_Base.PointY);
                graphicsShape.DrawLine(pen, b2s, b2e);
                Line b2h = GetNewLine(b2s, b2e);
                ShapePoint b2scenter = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, X_Base.PointY + b2h.Length / 2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b2scenter, sf);

                ShapePoint b2s1 = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, ACheck.PointY);
                ShapePoint b2e1 = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, W_Base.PointY);
                graphicsShape.DrawLine(pen, b2s1, b2e1);
                Line b2h1 = GetNewLine(b2s1, b2e1);
                ShapePoint b21scenter = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, W_Base.PointY - b2h1.Length / 2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b21scenter, sf);

                ShapePoint l1s = GetNewCustomPoint(ACheck.PointX, W_Base.PointY + 10 * LineBoundArgument);
                ShapePoint l1e = GetNewCustomPoint(BCheck.PointX, W_Base.PointY + 10 * LineBoundArgument);
                graphicsShape.DrawLine(pen, l1s, l1e);
                Line l1h = GetNewLine(l1s, l1e);
                ShapePoint l1scenter = GetNewCustomPoint(ACheck.PointX + l1h.Length / 2, W_Base.PointY + 15 * LineBoundArgument);
                graphicsShape.DrawString("L1=" + SetL1, drawFontBold, Brushes.Black, l1scenter, sf);

                ShapePoint l2s = GetNewCustomPoint(B_downFault.PointX, W_Base.PointY + 10 * LineBoundArgument);
                ShapePoint l2e = GetNewCustomPoint(A_downFault.PointX, W_Base.PointY + 10 * LineBoundArgument);
                graphicsShape.DrawLine(pen, l2s, l2e);
                Line l2h = GetNewLine(l2s, l2e);
                ShapePoint l2scenter = GetNewCustomPoint(B_downFault.PointX + l2h.Length / 2, W_Base.PointY + 15 * LineBoundArgument);
                graphicsShape.DrawString("L2=" + SetL2, drawFontBold, Brushes.Black, l2scenter, sf);

                ShapePoint ls = GetNewCustomPoint(ACheck.PointX, W_Base.PointY + 30 * LineBoundArgument);
                ShapePoint le = GetNewCustomPoint(CCheck.PointX, W_Base.PointY + 30 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                ShapePoint lcenter = GetNewCustomPoint(ACheck.PointX + (ll.Length / 2), W_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                graphicsShape.DrawString("L=" + SetL, drawFontBold, Brushes.Black, lcenter, sf);

                ShapePoint b1s1 = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 30 * LineBoundArgument);
                ShapePoint b1e1 = GetNewCustomPoint(ACheck.PointX, W_Base.PointY + 30 * LineBoundArgument);
                Line lb11 = GetNewLine(b1s1, b1e1);
                ShapePoint b11center = GetNewCustomPoint(W_Base.PointX + (lb11.Length / 2), W_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s1, b1e1);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b11center, sf);

                ShapePoint b1s = GetNewCustomPoint(CCheck.PointX, W_Base.PointY + 30 * LineBoundArgument);
                ShapePoint b1e = GetNewCustomPoint(Z_Base.PointX, W_Base.PointY + 30 * LineBoundArgument);
                Line lb1 = GetNewLine(b1s, b1e);
                ShapePoint b1center = GetNewCustomPoint(Z_Base.PointX - (lb1.Length / 2), W_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s, b1e);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b1center, sf);

                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX) / 4), ((A.PointY + B.PointY + C.PointY + D.PointY) / 4));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiсknessArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("32", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }
                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {

                    ShapePoint wer = GetNewCustomPoint(W_Base.PointX, BCheck.PointY);
                    ShapePoint wer1 = GetNewCustomPoint(Z_Base.PointX, CCheck.PointY);
                    ShapePoint wer2 = GetNewCustomPoint(Z_Base.PointX, DCheck.PointY);
                    ShapePoint wer3 = GetNewCustomPoint(W_Base.PointX, ACheck.PointY);
                    using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        graphicsShape.DrawLine(pen1, wer, BCheck);
                        graphicsShape.DrawLine(pen1, wer1, CCheck);
                        graphicsShape.DrawLine(pen1, wer2, DCheck);
                        graphicsShape.DrawLine(pen1, wer3, ACheck);
                    }
                    graphicsShape.DrawLine(pens, b1e1, l1s);
                    graphicsShape.DrawLine(pens, b1s1, W_Base);
                    graphicsShape.DrawLine(pens, b1e, Z_Base);
                    graphicsShape.DrawLine(pens, l1s, ACheck);
                    graphicsShape.DrawLine(pens, l2e, A_downFault);
                    graphicsShape.DrawLine(pens, le, CCheck);
                    graphicsShape.DrawLine(pens, b2s1, wer2);
                    graphicsShape.DrawLine(pens, b2e1, Z_Base);
                    graphicsShape.DrawLine(pens, hs, wer1);
                    graphicsShape.DrawLine(pens, b2e, Y_Base);
                    using (Pen pens1 = new Pen(Color.Red, SizeLineBoundArgument / 2))
                    {
                        graphicsShape.DrawLine(pens1, l1e, BCheck);
                        graphicsShape.DrawLine(pens1, l2s, B_downFault);
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
        public override double SetL2 { get => Math.Round(A_downFault.PointX - B_downFault.PointX, 0); set => base.SetL2 = value; }
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
        protected override void SetHValue()
        {
            base.SetHValue();
            CurvePoint.PointX = D.PointX;
            CurvePoint.PointY = D.PointY;
            var point = GetNewCustomPoint(A.PointX, B.PointY);
            A.PointY = SetCurrentLineLength(point, A, _SetH).PointY;
            D.PointY = A.PointY;
            var diff = D.PointY - CurvePoint.PointY;
            A_downFault.PointY += diff;
            A_upFault.PointX = A_downFault.PointX;
            A_upFault.PointY = A_downFault.PointY;
            ValidValue = false;
        }
        protected override void SetLValue()
        {
            base.SetLValue();
            var p = A.PointX;

            CurvePoint.PointX = A.PointX + D_line.Length / 2;
            CurvePoint.PointY = A.PointY;
            double size = _SetL - SetL1;
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
            ValidValue = false;
        }
        protected override void SetL2Value()
        {
            base.SetL2Value();
            var upLine = GetNewLine(C, B_upFault);
            B_downFault.PointX = SetCurrentLineLength(C, B_downFault, upLine.Length + _SetL2 / 2).PointX;
            var downLine = GetNewLine(A, A_upFault);
            A_downFault.PointX = SetCurrentLineLength(A, A_downFault, downLine.Length + _SetL2 / 2).PointX;
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
            double diag1 = 0;
            double diag2 = 0;


            diag1 = (diag1 <= 90) ? _CheckCut1 / Math.Sin(CalculateAngle(D, A, B) * Math.PI / 180) :
                (90 - ((180 - _CheckCut1 / Math.Sin(CalculateAngle(D, A, B)) * Math.PI / 180)));
            diag2 = (diag2 <= 90) ? _CheckCut2 / Math.Sin(CalculateAngle(B, C, D) * Math.PI / 180) :
                (90 - ((180 - _CheckCut2 / Math.Sin(CalculateAngle(B, C, D)) * Math.PI / 180)));
            diag1 = (IsToothVector == true) ? diag1 : 0;
            diag2 = (IsToothVector == true) ? diag2 : 0;
            var value2 = (IsToothVector == true) ? _CheckCut2 : 0;
            var value4 = (IsToothVector == true) ? _CheckCut4 : 0;
            var width = _SetL + _SetB1 * 2 + diag1 + diag2;
            var height = _SetH + SetB2 * 2 + value2 + value4;

            if (_SetH < 0 || _SetH1 < 0 || _SetL < 0 || _SetL1 < 0 || _SetL2 < 0 || _SetB1 < 0 || _SetB2 < 0 || _SetB3 < 0)
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
            else if (_SetL1 > 0 && (_SetL1 + SetL2 / 2 > SetL / 2))
            {
                ValidValue = true;
                ValidateSetSizeMessage($"Значение 'L1' некорректно по условию 'L1+L2/2 > L/2'");
            }
            else if (_SetL2 > 0 && (SetL1 + _SetL2 / 2 > SetL / 2))
            {
                ValidValue = true;
                ValidateSetSizeMessage($"Значение 'L1' некорректно по условию 'L1+L2/2 > L/2'");
            }
            else if (_SetL > 0 && (SetL1 + SetL2 / 2 > _SetL / 2))
            {
                ValidValue = true;
                ValidateSetSizeMessage($"Значение 'L' некорректно по условию 'L1+L2/2 > L/2'");
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL2");
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