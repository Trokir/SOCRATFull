using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

using DevExpress.XtraVerticalGrid.Events;
using Socrat.Core.Entities;

namespace Socrat.Shape.Rectangles
{
    sealed class Shape_49 : Rectangular
    {
        public Shape_49(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {

        }
        public override double Perimeter => Math.Round((A_line.Length + B_line.Length + C_line.Length + D_line.Length) / 1000, 3);
        public override double Perimeter_t => Math.Round((A_Check_Line.Length + B_Check_Line.Length + C_Check_Line.Length + D_Check_Line.Length) / 1000, 3);
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
            using (var pen = new Pen(Color.Black, SizeLineBoundArgument))
            {
               
                MoveBorderRight(Z_Base, Y_Base, SetB1);
                MoveBorderLeft(W_Base, X_Base, SetB1);
                MoveBorderTop(X_Base, Y_Base, SetB3);
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
                FindPointDrawLine(A, B, SetB3, SetB3, 0);
                FindPointDrawLine(B, C, SetB1, SetB3, 0);
                FindPointDrawLine(SetPointCurrentType(B), SetPointCurrentType(C), SetB1, SetB3, 0);
                FindPointDrawLine(SetPointCurrentType(A), SetPointCurrentType(B), SetB3, SetB3, 0);
            }

            using (var pen = new Pen(Color.Blue, SizeLineBoundArgument))
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                pen.StartCap = LineCap.ArrowAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                pen.DashStyle = DashStyle.Solid;

                ShapePoint hs = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, SetPointCurrentValueY(B));
                ShapePoint he = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, SetPointCurrentValueY(D));
                Line lh = GetNewLine(hs, he);
                ShapePoint hcenter = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, SetPointCurrentValueY(B) + lh.Length / 2);
                graphicsShape.DrawLine(pen, hs, he);
                sf.FormatFlags = StringFormatFlags.LineLimit;
                    graphicsShape.DrawString("H=" + SetCurrentSize(SetH), drawFontBold, Brushes.Black, hcenter, sf);

                ShapePoint h1s = GetNewCustomPoint(Y_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(C));
                ShapePoint h1e = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(D));
                Line lh1 = GetNewLine(h1s, h1e);
                ShapePoint h1center = GetNewCustomPoint(Y_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(C) + (lh1.Length / 2));
                graphicsShape.DrawLine(pen, h1s, h1e);
                    graphicsShape.DrawString("H1=" + SetCurrentSize(SetH1), drawFontBold, Brushes.Black, h1center, sf);

                ShapePoint b2s = GetNewCustomPoint(Z_Base.PointX +30 * LineBoundArgument, SetPointCurrentValueY(A));
                ShapePoint b2e = GetNewCustomPoint(Z_Base.PointX +30 * LineBoundArgument, W_Base.PointY);
                graphicsShape.DrawLine(pen, b2s, b2e);
                Line b2h = GetNewLine(b2s, b2e);
                ShapePoint b2scenter = GetNewCustomPoint(Z_Base.PointX +30 * LineBoundArgument, W_Base.PointY - b2h.Length / 2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b2scenter, sf);



                ShapePoint b3s1 = GetNewCustomPoint(Z_Base.PointX +30 * LineBoundArgument, SetPointCurrentValueY(B));
                ShapePoint b3e1 = GetNewCustomPoint(Z_Base.PointX +30 * LineBoundArgument, X_Base.PointY);
                Line lb31 = GetNewLine(b3s1, b3e1);
                ShapePoint b31center = GetNewCustomPoint(Z_Base.PointX +30 * LineBoundArgument, X_Base.PointY + (lb31.Length / 2));
                graphicsShape.DrawLine(pen, b3s1, b3e1);
                graphicsShape.DrawString("B3=" + SetB3, drawFontBold, Brushes.Black, b31center, sf);




                ShapePoint b1s = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 40 * LineBoundArgument);
                ShapePoint b1e = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 40 * LineBoundArgument);
                Line lb1 = GetNewLine(b1s, b1e);
                ShapePoint b1center = GetNewCustomPoint(W_Base.PointX + (lb1.Length / 2), W_Base.PointY + 40 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s, b1e);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b1center, sf);


                ShapePoint b1s1 = GetNewCustomPoint(SetPointCurrentValueX(C), Z_Base.PointY + 40 * LineBoundArgument);
                ShapePoint b1e1 = GetNewCustomPoint(Z_Base.PointX, Z_Base.PointY + 40 * LineBoundArgument);
                Line lb11 = GetNewLine(b1s1, b1e1);
                ShapePoint b11center = GetNewCustomPoint(Z_Base.PointX - (lb1.Length / 2), Z_Base.PointY + 40 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s1, b1e1);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b11center, sf);


                ShapePoint ls = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 40 * LineBoundArgument);
                ShapePoint le = GetNewCustomPoint(SetPointCurrentValueX(C), W_Base.PointY + 40 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                ShapePoint lcenter = GetNewCustomPoint(W_Base.PointX + (ll.Length / 2), W_Base.PointY + 40 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                    graphicsShape.DrawString("L=" + SetCurrentSize(SetL), drawFontBold, Brushes.Black, lcenter, sf);

                ShapePoint ls1 = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 20 * LineBoundArgument);
                ShapePoint le1 = GetNewCustomPoint(SetPointCurrentValueX(B), W_Base.PointY + 20 * LineBoundArgument);
                Line ll1 = GetNewLine(ls1, le1);
                ShapePoint l1center = GetNewCustomPoint(SetPointCurrentValueX(A) + (ll1.Length / 2), W_Base.PointY + 10 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls1, le1);

                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                graphicsShape.DrawString("L1=" + SetCurrentSize(SetL1), drawFontBold, Brushes.Black, l1center, sf);


                ShapePoint ls2 = GetNewCustomPoint(SetPointCurrentValueX(D), W_Base.PointY + 20 * LineBoundArgument);
                ShapePoint le2 = GetNewCustomPoint(SetPointCurrentValueX(C), W_Base.PointY + 20 * LineBoundArgument);
                Line ll2 = GetNewLine(ls2, le2);
                ShapePoint l2center = GetNewCustomPoint(SetPointCurrentValueX(D) + (ll2.Length / 2), W_Base.PointY + 10 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls2, le2);
                graphicsShape.DrawString("L2=" + SetCurrentSize(SetL2), drawFontBold, Brushes.Black, l2center, sf);


                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX) / 4), ((A.PointY + B.PointY + C.PointY + D.PointY) / 4));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiknessFontArgument);
                if (Area > 0.012)
                {
                    graphicsShape.DrawString("49", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }
                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {
                    ShapePoint wer1 = GetNewCustomPoint(W_Base.PointX,SetPointCurrentValueY(A));
                    ShapePoint wer2 = GetNewCustomPoint(Z_Base.PointX, SetPointCurrentValueY(D));
                 
                    using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        graphicsShape.DrawLine(pen1, wer1, SetPointCurrentType(A));
                        graphicsShape.DrawLine(pen1, wer2, SetPointCurrentType(D));
                    }

                    graphicsShape.DrawLine(pens, ls, SetPointCurrentType(A));
                    graphicsShape.DrawLine(pens, le, SetPointCurrentType(C));
                    graphicsShape.DrawLine(pens, b3e1, Y_Base);
                    graphicsShape.DrawLine(pens, b1e, W_Base);
                    graphicsShape.DrawLine(pens, b1e1, Z_Base);
                   graphicsShape.DrawLine(pens, b2e, Z_Base);
                    graphicsShape.DrawLine(pens, hs, SetPointCurrentType(B));
                    graphicsShape.DrawLine(pens, he, wer2);
                    graphicsShape.DrawLine(pens, h1s, SetPointCurrentType(C));
                    graphicsShape.DrawLine(pens, ls2, SetPointCurrentType(D));
                    using (Pen pens1 = new Pen(Color.Red, SizeLineBoundArgument / 2))
                    {
                        graphicsShape.DrawLine(pens1, le1, SetPointCurrentType(B));
                    }
                }
            }

            #endregion
        }
        protected override void FindPointDrawLine(ShapePoint firsrPoint, ShapePoint secondPoint, double factor = 0, double anotherFactor = 0, double thofactor = 0)
        {
            double length = 0;
            ShapePoint point = GetNewCustomPoint((firsrPoint.PointX), (firsrPoint.PointY - factor));
            Line fdfLine = GetNewLine(point, firsrPoint);
            Line fdLine = GetNewLine(firsrPoint, secondPoint);
            double angle = CalculateAngle(D, A, B);
            double l = fdfLine.Length / Math.Sin(angle * Math.PI / 180);
            length = fdLine.Length + l;
            ShapePoint ePoint = GetNewPoint();
            ePoint = SetCurrentLineLength(firsrPoint, secondPoint, length);
            using (Pen pen = new Pen(Color.Black, ThiсknessArgument / 2))
            {
                graphicsShape.DrawLine(pen, secondPoint, ePoint);
            }

        }
        public override double SetH { get => Math.Round(GetNewLine(GetNewCustomPoint(B.PointX, A.PointY), B).Length, 0); set => base.SetH = value; }
        public override double SetL { get => Math.Round(GetNewLine(GetNewCustomPoint(C.PointX, D.PointY), A).Length, 0); set => base.SetL = value; }
        public override double SetH1 { get => Math.Round(GetNewLine(GetNewCustomPoint(C.PointX, D.PointY), C).Length, 0); set => base.SetH1 = value; }
        public override double SetL1 { get => Math.Round(GetNewLine(GetNewCustomPoint(A.PointX, B.PointY), B).Length, 0); set => base.SetL1 = value; }
        public override double SetL2 { get => Math.Round(GetNewLine(GetNewCustomPoint(C.PointX, D.PointY), D).Length, 0); set => base.SetL2 = value; }
        public override double SetH_t
        {
            get
            {
                ShapePoint d = GetNewCustomPoint(BCheck.PointX, ACheck.PointY);
                Line l = GetNewLine(d, BCheck);
                return Math.Round(l.Length,0);
            }
        }
        public override double SetL_t
        {
            get
            {
                ShapePoint d = GetNewCustomPoint(CCheck.PointX, DCheck.PointY);
                Line l = GetNewLine(d, ACheck);
                return Math.Round(l.Length, 0);
            }
        }
        public override double SetH1_t
        {
            get
            {
                ShapePoint d = GetNewCustomPoint(CCheck.PointX, DCheck.PointY);
                Line l = GetNewLine(d, CCheck);
                return Math.Round(l.Length, 0);
            }
        }
        public override double SetL1_t
        {
            get
            {
                ShapePoint Sa = GetNewCustomPoint(ACheck.PointX, BCheck.PointY);
                Line l = GetNewLine(Sa, BCheck);
                return Math.Round(l.Length, 0);
            }
        }
        public override double SetL2_t
        {
            get
            {
                ShapePoint Sa = GetNewCustomPoint(CCheck.PointX, DCheck.PointY);
                Line l = GetNewLine(Sa, DCheck);
                return Math.Round(l.Length, 0);
            }
        }
        protected override void SetHValue()
        {
            base.SetHValue();
           var p=B.PointY;
            var d = GetNewCustomPoint(B.PointX, A.PointY);
            B.PointY = SetCurrentLineLength(d, B, _SetH).PointY;
            var diff = p - B.PointY;
            Move(y: diff);
            ValidValue = false;
        }
        protected override void SetLValue()
        {
            base.SetLValue();

            CurvePoint.PointX = C.PointX;
            ShapePoint d = GetNewCustomPoint(C.PointX, D.PointY);
            d.PointX = SetCurrentLineLength(A, d, _SetL).PointX;
            C.PointX = d.PointX;
            var diff = C.PointX - CurvePoint.PointX;
            D.PointX += diff;
            ValidValue = false;
        }
        protected override void SetH1Value()
        {
            base.SetH1Value();
            ShapePoint d = GetNewCustomPoint(C.PointX, D.PointY);
            C.PointY = SetCurrentLineLength(d, C, _SetH1).PointY;
            ValidValue = false;
        }
        protected override void SetL1Value()
        {
            ShapePoint Sa = GetNewCustomPoint(A.PointX, B.PointY);
            B.PointX = SetCurrentLineLength(Sa, B, _SetL1).PointX;
            ValidValue = false;
        }
        protected override void SetL2Value()
        {
            base.SetL2Value();
            ShapePoint Sa = GetNewCustomPoint(C.PointX, D.PointY);
            D.PointX = SetCurrentLineLength(Sa, D, _SetL2).PointX;
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
                ? CheckCut1 / Math.Sin(CalculateAngle(D, A, B) * Math.PI / 180)
                : (90 - ((180 - CheckCut1 / Math.Sin(CalculateAngle(D, A, B)) * Math.PI / 180)));
            diag = (!IsToothVector == true) ? 0 : diag;
            double diag1 = 0;
            diag1 = (diag1 <= 90)
                ? CheckCut2 / Math.Sin(CalculateAngle(A, B, C) * Math.PI / 180)
                : (90 - ((180 - CheckCut2 / Math.Sin(CalculateAngle(A, B, C)) * Math.PI / 180)));
            diag1 = (!IsToothVector == true) ? 0 : diag1;
            double diag2 = 0;
            diag2 = (diag2 <= 90)
                ? CheckCut3 / Math.Sin(CalculateAngle(B, C, D) * Math.PI / 180)
                : (90 - ((180 - CheckCut3 / Math.Sin(CalculateAngle(B, C, D)) * Math.PI / 180)));
            diag2 = (!IsToothVector == true) ? 0 : diag2;
            var value4 = (IsToothVector == true) ? _CheckCut4 : 0;
            var width = _SetL+(_SetL2=(_SetL2==0.0)?SetL2:_SetL2) + _SetB1 + _SetB3 + diag + diag2;
            var height = (_SetH*Math.Cos(180-CalculateAngle(D,A,B) * Math.PI / 180)) + diag1 +value4+ _SetB2+SetB3;

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
                ValidateSetSizeMessage("Значение 'L' не может быть меньше 'L1'");
            }
            else if ((_SetL2 > 0) && _SetL2 > SetL)
            {
                ValidateSetSizeMessage("Значение 'L2' не может быть больше 'L'");
            }
            else if ((_SetL1 > 0) && _SetL1 > SetL)
            {
                ValidateSetSizeMessage("Значение 'L1' не может быть больше 'L'");
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL1");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL2");
              
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL1_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL2_t");
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