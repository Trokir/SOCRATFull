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
    sealed class Shape_45 : Rectangular
    {
        public Shape_45(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
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
            using (var pen = new Pen(Color.Black, SizeLineBoundArgument))
            {
                MoveBorderRight(Z_Base, Y_Base, SetB3);
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
                FindPointDrawLine(SetPointCurrentType(B), SetPointCurrentType(C), SetB3, SetB1, 0);
            }
            using (Pen pen = new Pen(Color.Blue, SizeLineBoundArgument))
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                pen.StartCap = LineCap.ArrowAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                pen.DashStyle = DashStyle.Solid;

                ShapePoint hs = GetNewCustomPoint(Z_Base.PointX +30 * LineBoundArgument, SetPointCurrentValueY(A));
                ShapePoint he = GetNewCustomPoint(Z_Base.PointX +30 * LineBoundArgument, SetPointCurrentValueY(B));
                Line lh = GetNewLine(hs, he);
                ShapePoint hcenter = GetNewCustomPoint(Z_Base.PointX +30 * LineBoundArgument, SetPointCurrentValueY(B) + lh.Length / 2);
                graphicsShape.DrawLine(pen, hs, he);
                sf.FormatFlags = StringFormatFlags.LineLimit;
                    graphicsShape.DrawString("H=" + SetCurrentSize(SetH), drawFontBold, Brushes.Black, hcenter, sf);


                ShapePoint ls = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 20 * LineBoundArgument);
                ShapePoint le = GetNewCustomPoint(SetPointCurrentValueX(D), W_Base.PointY + 20 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                ShapePoint lcenter = GetNewCustomPoint(W_Base.PointX + (ll.Length / 2), W_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                    graphicsShape.DrawString("L=" + SetCurrentSize(SetL), drawFontBold, Brushes.Black, lcenter, sf);


                ShapePoint b1s = GetNewCustomPoint(SetPointCurrentValueX(A), Z_Base.PointY + 20 * LineBoundArgument);
                ShapePoint b1e = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 20 * LineBoundArgument);
                Line lb1 = GetNewLine(b1s, b1e);
                ShapePoint b1center = GetNewCustomPoint(W_Base.PointX + (lb1.Length / 2), W_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s, b1e);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b1center, sf);


                ShapePoint b3s = GetNewCustomPoint(SetPointCurrentValueX(D), Z_Base.PointY + 20 * LineBoundArgument);
                ShapePoint b3e = GetNewCustomPoint(Z_Base.PointX, Z_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b3s, b3e);
                Line b3h = GetNewLine(b3s, b3e);
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                ShapePoint b3scenter = GetNewCustomPoint(SetPointCurrentValueX(D) + b3h.Length / 2, W_Base.PointY + 20 * LineBoundArgument);
                graphicsShape.DrawString("B3=" + SetB3, drawFontBold, Brushes.Black, b3scenter, sf);



                ShapePoint b3s1 = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, SetPointCurrentValueY(B));
                ShapePoint b3e1 = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, X_Base.PointY);
                graphicsShape.DrawLine(pen, b3s1, b3e1);
                Line b31h = GetNewLine(b3s1, b3e1);
                ShapePoint b31scenter = GetNewCustomPoint(Z_Base.PointX +30 * LineBoundArgument, X_Base.PointY + b31h.Length / 2);
                graphicsShape.DrawString("B3=" + SetB3, drawFontBold, Brushes.Black, b31scenter, sf);



                ShapePoint b2s = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, SetPointCurrentValueY(A));
                ShapePoint b2e = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, W_Base.PointY);
                graphicsShape.DrawLine(pen, b2s, b2e);
                Line b2h = GetNewLine(b2s, b2e);
                ShapePoint b2scenter = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, W_Base.PointY - b2h.Length / 2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b2scenter, sf);


                ShapePoint l1s = GetNewCustomPoint(SetPointCurrentValueX(B) + 10 * LineBoundArgument, SetPointCurrentValueY(B) - 20 * LineBoundArgument);
                ShapePoint l1e = GetNewCustomPoint(SetPointCurrentValueX(C) + 10 * LineBoundArgument, SetPointCurrentValueY(C) - 20 * LineBoundArgument);
                Line ll1 = GetNewLine(l1s, l1e);
                ShapePoint l1center = GetNewCustomPoint(l1s.PointX + 120 * LineBoundArgument, l1s.PointY + (ll1.Length / 2) - 40 * LineBoundArgument);
                graphicsShape.DrawLine(pen, l1s, l1e);
                sf.Alignment = StringAlignment.Far;
                sf.LineAlignment = StringAlignment.Far;
                graphicsShape.DrawString("L1=" + SetCurrentSize(SetL1), drawFontBold, Brushes.Black, l1center, sf);


                ShapePoint l2s = GetNewCustomPoint(SetPointCurrentValueX(C) + 20 * LineBoundArgument, SetPointCurrentValueY(C));
                ShapePoint l2e = GetNewCustomPoint(SetPointCurrentValueX(D) + 20 * LineBoundArgument, SetPointCurrentValueY(D));
                Line ll2 = GetNewLine(l2s, l2e);
                ShapePoint l2center = GetNewCustomPoint(l2s.PointX + 50 * LineBoundArgument, l2s.PointY + ll2.Length / 2);
                graphicsShape.DrawLine(pen, l2s, l2e);
                sf.Alignment = StringAlignment.Far;
                sf.LineAlignment = StringAlignment.Far;
                graphicsShape.DrawString("L2=" + SetCurrentSize(SetL2), drawFontBold, Brushes.Black, l2center, sf);



                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX) / 4), ((A.PointY + B.PointY + C.PointY + D.PointY) / 4));
                Font drawNumbertBold = new Font("Tahoma", 40+ThiknessFontArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("45", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }

                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {
                    ShapePoint wer1 = GetNewCustomPoint(SetPointCurrentValueX(B), X_Base.PointY);
                    ShapePoint wer2 = GetNewCustomPoint(Z_Base.PointX,SetPointCurrentValueY(D));
                    ShapePoint wer3 = GetNewCustomPoint(W_Base.PointX, SetPointCurrentValueY(A));
                    using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        graphicsShape.DrawLine(pen1, wer1, SetPointCurrentType(B));
                        graphicsShape.DrawLine(pen1, wer2, SetPointCurrentType(D));
                        graphicsShape.DrawLine(pen1, wer3, SetPointCurrentType(A));
                    }
                    graphicsShape.DrawLine(pens, ls, SetPointCurrentType(A));
                    graphicsShape.DrawLine(pens, le, SetPointCurrentType(D));
                   graphicsShape.DrawLine(pens, b3e1, Y_Base);
                   graphicsShape.DrawLine(pens, b3s1, SetPointCurrentType(B));
                    graphicsShape.DrawLine(pens, b3e, Z_Base);
                    graphicsShape.DrawLine(pens, b1e, W_Base);
                    graphicsShape.DrawLine(pens, b2e, Z_Base);
                    graphicsShape.DrawLine(pens, b2s, wer2);

                    using (Pen pens1 = new Pen(Color.Red, SizeLineBoundArgument / 2))
                    {
                       // graphicsShape.DrawLine(pens1, le1, SetPointCurrentType(C));
                    }
                }

            }

            #endregion
        }
        protected override void FindPointDrawLine(ShapePoint firsrPoint, ShapePoint secondPoint,
            double factor = 0, double anotherFactor = 0, double thofactor = 0)
        {
            double length = 0;

            ShapePoint point = GetNewPoint();
            point.PointX = D.PointX + factor;
            point.PointY = secondPoint.PointY;
            Line fdfLine = GetNewLine(point, secondPoint);
            Line fdLine = GetNewLine(firsrPoint, secondPoint);
            double angle = CalculateAngle(A, B, C);
            double l = fdfLine.Length / Math.Sin(angle * Math.PI / 180);
            length = fdLine.Length + l;
            ShapePoint Point = GetNewPoint();
            Point = SetCurrentLineLength(firsrPoint, secondPoint, length);

            using (Pen pen = new Pen(Color.Black, ThiсknessArgument / 2))
            {
                graphicsShape.DrawLine(pen, secondPoint, Point);
            }

        }
        public override double SetH { get => Math.Round(A_line.Length, 0); set => base.SetH = value; }
        public override double SetL { get => Math.Round(D_line.Length, 0); set => base.SetL = value; }
        public override double SetL1 { get => Math.Round(B_line.Length, 0); set => base.SetL1 = value; }
        public override double SetL2 { get => Math.Round(C_line.Length, 0); set => base.SetL2 = value; }
        public override double SetH_t { get => Math.Round(A_Check_Line.Length, 0); }
        public override double SetL_t {get => Math.Round(D_Check_Line.Length, 0); }
        public override double SetL1_t {get => Math.Round(B_Check_Line.Length, 0); }
        public override double SetL2_t { get => Math.Round(C_Check_Line.Length, 0); }
        protected override void SetHValue()
        {
            base.SetHValue();
            A.PointY = SetCurrentLineLength(B, A, _SetH).PointY;
            D.PointY = A.PointY;
            ValidValue = false;
        }
        protected override void SetLValue()
        {
            base.SetLValue();
            TempPoint.PointX = D.PointX;
            TempPoint.PointY = D.PointY;
            TempPoint.PointX = SetCurrentLineLength(A, D, _SetL).PointX;
            var diff = TempPoint.PointX - D.PointX;
            C.PointX += diff;
            D.PointX = TempPoint.PointX;
            D.PointY = TempPoint.PointY;
            ValidValue = false;
        }
        protected override void SetL1Value()
        {
            var oneLine = GetNewLine(B, D);
            var a = Math.Pow(_SetL1, 2);
            var c = Math.Pow(oneLine.Length, 2);
            var b = Math.Pow(C_line.Length, 2);
            var re = 2 * _SetL1 * oneLine.Length;
            var alpha = Math.Acos((a + c - b) / re);

            C.PointX = (D.PointX - B.PointX) * Math.Cos(-alpha) - (D.PointY - B.PointY) * Math.Sin(-alpha) + B.PointX;
            C.PointY = (D.PointX - B.PointX) * Math.Sin(-alpha) + (D.PointY - B.PointY) * Math.Cos(-alpha) + B.PointY;
            TempPoint.PointX = SetCurrentLineLength(B, C, _SetL1).PointX;
            TempPoint.PointY = SetCurrentLineLength(B, C, _SetL1).PointY;
            C.PointX = TempPoint.PointX;
            C.PointY = TempPoint.PointY;
            ValidValue = false;
        }
        protected override void SetL2Value()
        {
            base.SetL2Value();
            var oneLine = GetNewLine(B, D);
            var a = Math.Pow(B_line.Length, 2);
            var c = Math.Pow(oneLine.Length, 2);
            var b = Math.Pow(_SetL2, 2);
            var re = 2 * _SetL2 * oneLine.Length;
            var alpha = Math.Acos((b + c - a) / re);
            C.PointX = (B.PointX - D.PointX) * Math.Cos(alpha) - (B.PointY - D.PointY) * Math.Sin(alpha) + D.PointX;
            C.PointY = (B.PointX - D.PointX) * Math.Sin(alpha) + (B.PointY - D.PointY) * Math.Cos(alpha) + D.PointY;
            TempPoint.PointX = SetCurrentLineLength(D, C, _SetL2).PointX;
            TempPoint.PointY = SetCurrentLineLength(D, C, _SetL2).PointY;
            C.PointX = TempPoint.PointX;
            C.PointY = TempPoint.PointY;
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
                ? CheckCut3 / Math.Sin(CalculateAngle(C, D, A) * Math.PI / 180)
                : (90 - ((180 - CheckCut3 / Math.Sin(CalculateAngle(C, D, A)) * Math.PI / 180)));
            diag = (!IsToothVector == true) ? 0 : diag;
            double diag1 = 0;
            diag1 = (diag1 <= 90)
                ? CheckCut2 / Math.Sin(CalculateAngle(A, B, C) * Math.PI / 180)
                : (90 - ((180 - CheckCut2 / Math.Sin(CalculateAngle(A, B, C)) * Math.PI / 180)));
            diag1 = (!IsToothVector == true) ? 0 : diag1;
            var value1 = (IsToothVector==true) ? _CheckCut1 : 0;
            var value4 = (IsToothVector == true) ? _CheckCut4 : 0;
            var width = _SetL + _SetB2 + _SetB3 + value1 + diag;
            var height = _SetH + diag1 + _SetB1 + _SetB3 + value4;

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
            else if (_SetH>0&&_SetH + SetB3 <= _SetH - SetL1 * Math.Cos(Math.Acos(_SetH / Math.Sqrt(SetL * SetL +
               _SetH * _SetH)) + Math.Acos((SetL * SetL + _SetH * _SetH +
                SetL1 * SetL1 - SetL2 * SetL2) /  (2.0 * (SetL1 * Math.Sqrt((_SetH * _SetH) + SetL * SetL))))))
            {
                ValidValue = true;
                ValidateSetSizeMessage("Значение 'H' лежит за пределами допустимых значений");
            }
            else if (_SetL > 0 && _SetL + SetB3 <= SetL1 * Math.Sin(Math.Acos(SetH / Math.Sqrt(_SetL * _SetL
             + SetH * SetH)) + Math.Acos((_SetL * _SetL + SetH * SetH + SetL1 * SetL1 -
              SetL2 * SetL2) /(2.0 * (SetL1 * Math.Sqrt(SetH * SetH + _SetL * _SetL)) ))))
            {
                ValidValue = true;
                ValidateSetSizeMessage("Значение 'L' лежит за пределами допустимых значений");
            }
            else if (_SetL2 > 0 && Math.Sqrt(Math.Pow(SetH, 2) + Math.Pow(SetL, 2)) >= SetL1 + _SetL2)
            {
                ValidValue = true;
                ValidateSetSizeMessage("Значение 'L2' лежит за пределами допустимых значений 'sqrt(H*H+L*L) <= (L2-L1)'");
            }
            else if (_SetL2 > 0 && SetH + SetB3 <= SetH - SetL1 * Math.Cos(Math.Acos(SetH / Math.Sqrt(SetL * SetL + 
            SetH * SetH))+ Math.Acos( (SetL * SetL + SetH * SetH + SetL1 * SetL1 - _SetL2 * _SetL2) / (2.0 *
             (SetL1 * Math.Sqrt( SetH * SetH + SetL * SetL))))))
            {
                ValidValue = true;
                ValidateSetSizeMessage("Значение 'L2' лежит за пределами допустимых значений ");
            }
            else if (_SetL1 > 0 && Math.Sqrt(Math.Pow(SetH, 2) + Math.Pow(SetL, 2)) >= _SetL1 + SetL2)
            {
                ValidValue = true;
                ValidateSetSizeMessage("Значение 'L1' не  лежит за пределами допустимых значений  'sqrt(H*H+L*L) <= (L2-L1)'");
            }
            else if (_SetL1 > 0 && SetL + SetB3 <= _SetL1 * Math.Sin(Math.Acos(SetH / Math.Sqrt(SetL * SetL +
                                                                                  SetH * SetH)) +
                                                       Math.Acos((SetL * SetL + SetH * SetH + _SetL1 * _SetL1 -
                                                                  SetL2 * SetL2) /
                                                                 (2.0 * (_SetL1 * Math.Sqrt(
                                                                             SetH * SetH + SetL * SetL))))))
            {
                ValidValue = true;
                ValidateSetSizeMessage("Значение 'L1'  лежит за пределами допустимых значений  ");
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
