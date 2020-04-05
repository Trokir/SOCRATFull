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
    sealed class Shape_16 : Rectangular
    {
        public Shape_16(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
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
        protected override void CheckForeignBorders()
        {
            GetExtremumPoints();
            AllowanceProcessing();
        }
        private void MoveLines()
        {
            using (Pen pen = new Pen(Color.Black, SizeLineBoundArgument))
            {
                MoveBorderRight(Z_Base, Y_Base, SetB3);
                MoveBorderLeft(W_Base, X_Base, SetB1);
                MoveBorderTop(X_Base, Y_Base, SetB2);
                MoveBorderBottom(W_Base, Z_Base, SetB3);
            }
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
                MoveInternalLineFromTop(graphicsShape, X_Base, Y_Base, First_B_Some_Size_Point, Second_B_Some_Size_Point, SetB2, SetB3);
                FindPointDrawLine(SetPointCurrentType(A), SetPointCurrentType(B), SetB3, SetB2, 0);
            }
            using (Pen pen = new Pen(Color.Blue, SizeLineBoundArgument))
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                sf.FormatFlags = StringFormatFlags.LineLimit;
                pen.StartCap = LineCap.ArrowAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                pen.DashStyle = DashStyle.Solid;

                ShapePoint hs = GetNewCustomPoint(Y_Base.PointX + 40 * LineBoundArgument, SetPointCurrentValueY(B));
                ShapePoint he = GetNewCustomPoint(Z_Base.PointX + 40 * LineBoundArgument, SetPointCurrentValueY(D));
                Line lh = GetNewLine(hs, he);
                ShapePoint hcenter = GetNewCustomPoint(Y_Base.PointX + 40 * LineBoundArgument, SetPointCurrentValueY(B) + lh.Length / 2);
                graphicsShape.DrawLine(pen, hs, he);
                graphicsShape.DrawString("H=" + SetCurrentSize(SetH), drawFontBold, Brushes.Black, hcenter, sf);

                ShapePoint b3s1 = GetNewCustomPoint(Z_Base.PointX - SetB3, Z_Base.PointY + 40 * LineBoundArgument);
                ShapePoint b3e1 = GetNewCustomPoint(Z_Base.PointX, Z_Base.PointY + 40 * LineBoundArgument);
                Line lb31 = GetNewLine(b3s1, b3e1);
                ShapePoint b31center = GetNewCustomPoint(Z_Base.PointX - (lb31.Length / 2), Z_Base.PointY + 40 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b3s1, b3e1);
                graphicsShape.DrawString("B3=" + SetB3, drawFontBold, Brushes.Black, b31center, sf);

                ShapePoint b1s = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 40 * LineBoundArgument);
                ShapePoint b1e = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 40 * LineBoundArgument);
                Line lb1 = GetNewLine(b1s, b1e);
                ShapePoint b1center = GetNewCustomPoint(W_Base.PointX + (lb1.Length / 2), W_Base.PointY + 40 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s, b1e);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b1center, sf);

                ShapePoint b2s = GetNewCustomPoint(Y_Base.PointX + 40 * LineBoundArgument, SetPointCurrentValueY(B));
                ShapePoint b2e = GetNewCustomPoint(Y_Base.PointX + 40 * LineBoundArgument, Y_Base.PointY);
                graphicsShape.DrawLine(pen, b2s, b2e);
                Line b2h = GetNewLine(b2s, b2e);
                ShapePoint b2scenter = GetNewCustomPoint(Y_Base.PointX + 40 * LineBoundArgument, Y_Base.PointY + b2h.Length / 2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b2scenter, sf);


                ShapePoint b3s2 = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(D));
                ShapePoint b3e2 = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, Z_Base.PointY);
                Line lb32 = GetNewLine(b3s2, b3e2);
                ShapePoint b32center = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, Z_Base.PointY - (lb32.Length / 2));
                graphicsShape.DrawLine(pen, b3s2, b3e2);
                graphicsShape.DrawString("B3=" + SetB3, drawFontBold, Brushes.Black, b32center, sf);

                ShapePoint ls = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 40 * LineBoundArgument);
                ShapePoint le = GetNewCustomPoint(SetPointCurrentValueX(D), W_Base.PointY + 40 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                ShapePoint lcenter = GetNewCustomPoint(W_Base.PointX + (ll.Length / 2), W_Base.PointY + 40 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                graphicsShape.DrawString("L=" + SetCurrentSize(SetL), drawFontBold, Brushes.Black, lcenter, sf);

                ShapePoint b3s = GetNewCustomPoint(Y_Base.PointX + 10 * LineBoundArgument, Y_Base.PointY);
                ShapePoint b3e = GetNewCustomPoint(Y_Base.PointX + 10 * LineBoundArgument, Y_Base.PointY + SetB3);
                Line lb3 = GetNewLine(b3s, b3e);
                ShapePoint b3center = GetNewCustomPoint(Y_Base.PointX + 12 * LineBoundArgument, Y_Base.PointY + (lb3.Length / 2));
                graphicsShape.DrawLine(pen, b3s, b3e);
                graphicsShape.DrawString("B3=" + SetB3, drawFontBold, Brushes.Black, b3center, sf);

                ShapePoint ls1 = GetNewCustomPoint(SetPointCurrentValueX(B), W_Base.PointY + 15 * LineBoundArgument);
                ShapePoint le1 = GetNewCustomPoint(SetPointCurrentValueX(C), W_Base.PointY + 15 * LineBoundArgument);
                Line ll1 = GetNewLine(ls1, le1);
                ShapePoint l1center = GetNewCustomPoint(SetPointCurrentValueX(B) + (ll1.Length / 2), W_Base.PointY + 15 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls1, le1);
                if (ll1.Length > 8)
                {
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Far;
                    graphicsShape.DrawString("L1=" + SetCurrentSize(SetL1), drawFontBold, Brushes.Black, l1center, sf);
                }

                ShapePoint h1s = GetNewCustomPoint(Y_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(C));
                ShapePoint h1e = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(D));
                Line lh1 = GetNewLine(h1s, h1e);
                ShapePoint h1center = GetNewCustomPoint(Y_Base.PointX + 30 * LineBoundArgument, SetPointCurrentValueY(C) + (lh1.Length / 2));
                graphicsShape.DrawLine(pen, h1s, h1e);
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                graphicsShape.DrawString("H1=" + SetCurrentSize(SetH1), drawFontBold, Brushes.Black, h1center, sf);

                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX) / 4), ((A.PointY + B.PointY + C.PointY + D.PointY) / 4));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiсknessArgument);
                if (Area > 0.012)
                {
                    graphicsShape.DrawString("16", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }

                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {
                    ShapePoint wer = GetNewCustomPoint(SetPointCurrentValueX(C), Y_Base.PointY);
                    ShapePoint wer1 = GetNewCustomPoint(Z_Base.PointX, SetPointCurrentValueY(A));
                    ShapePoint wer2 = GetNewCustomPoint(SetPointCurrentValueX(D), Z_Base.PointY);
                    ShapePoint wer3 = GetNewCustomPoint(W_Base.PointX, SetPointCurrentValueY(A));
                    ShapePoint wer4 = GetNewCustomPoint(W_Base.PointX + SetB3, W_Base.PointY);
                    using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        graphicsShape.DrawLine(pen1, wer, SetPointCurrentType(C));
                        graphicsShape.DrawLine(pen1, wer1, SetPointCurrentType(D));
                        graphicsShape.DrawLine(pen1, wer2, SetPointCurrentType(D));
                        graphicsShape.DrawLine(pen1, wer3, SetPointCurrentType(A));
                    }
                    graphicsShape.DrawLine(pens, ls, SetPointCurrentType(A));
                    graphicsShape.DrawLine(pens, le, SetPointCurrentType(D));
                    graphicsShape.DrawLine(pens, ls1, SetPointCurrentType(B));
                    graphicsShape.DrawLine(pens, he, wer1);
                    graphicsShape.DrawLine(pens, h1s, SetPointCurrentType(C));
                    graphicsShape.DrawLine(pens, b2s, SetPointCurrentType(B));
                    graphicsShape.DrawLine(pens, b2e, Y_Base);
                    graphicsShape.DrawLine(pens, b1e, W_Base);
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
            double angle = CalculateAngle(D, A, B);
            double l = fdfLine.Length / Math.Sin(angle * Math.PI / 180);
            length = fdLine.Length + l;
            ShapePoint pointd = GetNewPoint();
            pointd = SetCurrentLineLength(firsrPoint, secondPoint, length);
            using (Pen pen = new Pen(Color.Black, ThiсknessArgument / 2))
            {
                graphicsShape.DrawLine(pen, secondPoint, pointd);
            }

        }
        public override double SetH { get => Math.Round(GetNewLine(GetNewCustomPoint(C.PointX, B.PointY), D).Length, 0); set => base.SetH = value; }
        public override double SetL { get => Math.Round(D_line.Length, 0); set => base.SetL = value; }
        public override double SetH1 { get => Math.Round(C_line.Length, 0); set => base.SetH1 = value; }
        public override double SetL1 { get => Math.Round(GetNewLine(GetNewCustomPoint(C.PointX, B.PointY), B).Length, 0); set => base.SetL1 = value; }
        public override double SetH_t
        {
            get
            {
                ShapePoint d = GetNewCustomPoint(CCheck.PointX, BCheck.PointY);
                Line l = GetNewLine(d, DCheck);
                return Math.Round(l.Length, 0);
            }
        }
        public override double SetH1_t
        {
            get => Math.Round(C_line.Length, 0);
        }
        public override double SetL_t
        {
            get => Math.Round(D_line.Length, 0);
        }
        public override double SetL1_t
        {
            get
            {
                ShapePoint Sa = GetNewCustomPoint(CCheck.PointX, BCheck.PointY);
                Line l = GetNewLine(Sa, BCheck);
                return Math.Round(l.Length, 0);
            }
        }
        protected override void SetHValue()
        {
            base.SetHValue();
            CurvePoint.PointX = B.PointX;
            CurvePoint.PointY = A.PointY;
            TempPoint.PointX = SetCurrentLineLength(B, CurvePoint, _SetH).PointX;
            TempPoint.PointY = SetCurrentLineLength(B, CurvePoint, _SetH).PointY;
            var diff = D.PointY - TempPoint.PointY;
            C.PointY -= diff;
            D.PointY = TempPoint.PointY;
            A.PointY = D.PointY;
            ValidValue = false;
        }
        protected override void SetLValue()
        {
            base.SetLValue();
            var p = GetNewPoint();
            p.PointX = D.PointX;
            p.PointY = D.PointY;
            p.PointX = SetCurrentLineLength(A, D, _SetL).PointX;
            C.PointX = p.PointX;
            var diff = p.PointX - D.PointX;
           // B.PointY -= diff;
            D.PointX = p.PointX;
            D.PointY = p.PointY;
            ValidValue = false;
        }
        protected override void SetL1Value()
        {
            var diff = D_line.Length;
            var Sa = GetNewCustomPoint(C.PointX, B.PointY);
            B.PointX = SetCurrentLineLength(Sa, B, _SetL1).PointX;
            ValidValue = false;
        }
        protected override void SetH1Value()
        {
            base.SetH1Value();
            C.PointY = SetCurrentLineLength(D, C, _SetH1).PointY;
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
                ? CheckCut3 / Math.Sin(CalculateAngle(A, B, C) * Math.PI / 180)
                : (90 - ((180 - CheckCut3 / Math.Sin(CalculateAngle(A, B, C)) * Math.PI / 180)));
            diag = (!IsToothVector == true) ? 0 : diag;

            double diag1 = 0;
            diag1 = (diag1 <= 90)
                ? CheckCut2 / Math.Sin(CalculateAngle(B, C, D) * Math.PI / 180)
                : (90 - ((180 - CheckCut2 / Math.Sin(CalculateAngle(B, C, D)) * Math.PI / 180)));
            diag1 = (!IsToothVector == true) ? 0 : diag1;

            var value1 = (IsToothVector==true) ? _CheckCut1 : 0;
            var value2 = (IsToothVector==true) ? _CheckCut2 : 0;
            var value3 = (IsToothVector==true) ? _CheckCut3 : 0;
            var value4 = (IsToothVector == true) ? _CheckCut4 : 0;
            var width = _SetL + _SetB1 + _SetB3 + value3 + diag;
            var height = _SetH + diag1 + _SetB2 + value4 + SetB3;

            if (_SetH < 0 || _SetH1 < 0 || _SetL < 0 || _SetL1 < 0 || _SetB1 < 0 || _SetB2 < 0 || _SetB3 < 0 || _SetB4 < 0)
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH1");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL1");

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