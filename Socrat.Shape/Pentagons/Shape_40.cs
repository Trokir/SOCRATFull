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
    sealed class Shape_40 : Pentagon
    {
        public Shape_40(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
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
        protected override PointF[] GetBasePoints()
        {
            return new PointF[] { A, B, C, D, E };
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
                MoveBorderRight(Y_Base, Z_Base, SetB1);
                MoveBorderTop(X_Base, Y_Base, SetB3);
                MoveBorderBottom(W_Base, Z_Base, SetB2);
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
            using (Pen pen = new Pen(Color.Blue, 1))
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                sf.FormatFlags = StringFormatFlags.LineLimit;
                pen.StartCap = LineCap.ArrowAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                pen.DashStyle = DashStyle.Solid;

                ShapePoint hs = GetNewCustomPoint(Y_Base.PointX + 40 * LineBoundArgument, SetPointCurrentValueY(C));
                ShapePoint he = GetNewCustomPoint(Z_Base.PointX + 40 * LineBoundArgument, SetPointCurrentValueY(E));
                Line lh = GetNewLine(hs, he);
                ShapePoint hcenter = GetNewCustomPoint(Y_Base.PointX + 40 * LineBoundArgument, SetPointCurrentValueY(E) - lh.Length / 2);
                graphicsShape.DrawLine(pen, hs, he);
                    graphicsShape.DrawString("H=" + SetCurrentSize(SetH), drawFontBold, Brushes.Black, hcenter, sf);

                ShapePoint b2s = GetNewCustomPoint(Y_Base.PointX + 40 * LineBoundArgument, SetPointCurrentValueY(C));
                ShapePoint b2e = GetNewCustomPoint(Y_Base.PointX + 40 * LineBoundArgument, Y_Base.PointY);
                graphicsShape.DrawLine(pen, b2s, b2e);
                Line b2h = GetNewLine(b2s, b2e);
                ShapePoint b2scenter = GetNewCustomPoint(Y_Base.PointX + 40 * LineBoundArgument, Y_Base.PointY + b2h.Length / 2);
                graphicsShape.DrawString("B3=" + SetB3, drawFontBold, Brushes.Black, b2scenter, sf);


                ShapePoint l1s = GetNewCustomPoint(SetPointCurrentValueX(C), W_Base.PointY +10 * LineBoundArgument);
                ShapePoint l1e = GetNewCustomPoint(SetPointCurrentValueX(B), W_Base.PointY +10 * LineBoundArgument);
                graphicsShape.DrawLine(pen, l1s, l1e);
                Line l1h = GetNewLine(l1s, l1e);
                ShapePoint l1scenter = GetNewCustomPoint(SetPointCurrentValueX(C) - l1h.Length / 2, W_Base.PointY +10 * LineBoundArgument);
                graphicsShape.DrawString("L1=" + SetCurrentSize(SetL1), drawFontBold, Brushes.Black, l1scenter, sf);


                ShapePoint b2s1 = GetNewCustomPoint(Z_Base.PointX + 40 * LineBoundArgument, SetPointCurrentValueY(A));
                ShapePoint b2e1 = GetNewCustomPoint(Z_Base.PointX + 40 * LineBoundArgument, W_Base.PointY);
                graphicsShape.DrawLine(pen, b2s1, b2e1);
                Line b2h1 = GetNewLine(b2s1, b2e1);
                ShapePoint b21scenter = GetNewCustomPoint(Z_Base.PointX + 40 * LineBoundArgument, Z_Base.PointY - b2h1.Length / 2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b21scenter, sf);


                ShapePoint ls = GetNewCustomPoint(SetPointCurrentValueX(B), W_Base.PointY + 30 * LineBoundArgument);
                ShapePoint le = GetNewCustomPoint(SetPointCurrentValueX(D), W_Base.PointY + 30 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                ShapePoint lcenter = GetNewCustomPoint(B.PointX + (ll.Length / 2), W_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                    graphicsShape.DrawString("L=" + SetCurrentSize(SetL), drawFontBold, Brushes.Black, lcenter, sf);

                ShapePoint b3s = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 30 * LineBoundArgument);
                ShapePoint b3e = GetNewCustomPoint(SetPointCurrentValueX(B), W_Base.PointY + 30 * LineBoundArgument);
                Line lb3 = GetNewLine(b3s, b3e);
                ShapePoint b3center = GetNewCustomPoint(W_Base.PointX + (lb3.Length / 2), W_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b3s, b3e);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b3center, sf);


                ShapePoint b1s = GetNewCustomPoint(SetPointCurrentValueX(D), W_Base.PointY + 30 * LineBoundArgument);
                ShapePoint b1e = GetNewCustomPoint(Z_Base.PointX, W_Base.PointY + 30 * LineBoundArgument);
                Line lb1 = GetNewLine(b1s, b1e);
                ShapePoint b1center = GetNewCustomPoint(Z_Base.PointX - (lb1.Length / 2), W_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s, b1e);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b1center, sf);


                ShapePoint hs1 = GetNewCustomPoint(SetPointCurrentValueX(B) + 15 * LineBoundArgument, SetPointCurrentValueY(B));
                ShapePoint he1 = GetNewCustomPoint(SetPointCurrentValueX(A) +15 * LineBoundArgument, SetPointCurrentValueY(A));
                Line lh1 = GetNewLine(hs1, he1);
                ShapePoint h1center = GetNewCustomPoint(SetPointCurrentValueX(A) + 20 * LineBoundArgument, SetPointCurrentValueY(A) - lh1.Length / 2);
                
                sf.FormatFlags = StringFormatFlags.LineLimit;
                if (lh.Length > 8)
                {
                    graphicsShape.DrawString("H1=" + SetCurrentSize(SetH1), drawFontBold, Brushes.Black, h1center, sf);
                }


                ShapePoint h2s = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(D));
                ShapePoint h2e = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(E));
                Line lh2 = GetNewLine(h2s, h2e);
                ShapePoint h2center = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(E) - (lh2.Length / 2));
                graphicsShape.DrawLine(pen, h2s, h2e);
                    graphicsShape.DrawString("H2=" + SetCurrentSize(SetH2), drawFontBold, Brushes.Black, h2center, sf);

                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX + E.PointX) / 5), ((A.PointY + B.PointY + C.PointY + D.PointY + E.PointY) / 5));
                Font drawNumbertBold = new Font("Tahoma", 40+ThiknessFontArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("40", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }

                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {

                    ShapePoint wer1 = GetNewCustomPoint(X_Base.PointX, SetPointCurrentValueY(C));
                    ShapePoint wer2 = GetNewCustomPoint(SetPointCurrentValueX(B), Y_Base.PointY);
                    ShapePoint wer3 = GetNewCustomPoint(Y_Base.PointX, SetPointCurrentValueY(C));
                    ShapePoint wer4 = GetNewCustomPoint(SetPointCurrentValueX(D), Y_Base.PointY);
                    ShapePoint wer5 = GetNewCustomPoint(Y_Base.PointX, SetPointCurrentValueY(E));
                    ShapePoint wer6 = GetNewCustomPoint(SetPointCurrentValueX(E), Z_Base.PointY);
                    ShapePoint wer7 = GetNewCustomPoint(W_Base.PointX, SetPointCurrentValueY(A));
                    ShapePoint wer8 = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY);
                    using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        graphicsShape.DrawLine(pen1, wer1, SetPointCurrentType(C));
                        graphicsShape.DrawLine(pen1, wer2, SetPointCurrentType(B));
                        graphicsShape.DrawLine(pen1, wer3, SetPointCurrentType(C));
                        graphicsShape.DrawLine(pen1, wer4, SetPointCurrentType(D));
                        graphicsShape.DrawLine(pen1, wer5, SetPointCurrentType(E));
                        graphicsShape.DrawLine(pen1, wer6, SetPointCurrentType(E));
                        graphicsShape.DrawLine(pen1, wer7, SetPointCurrentType(A));
                        graphicsShape.DrawLine(pen1, wer8, SetPointCurrentType(A));
                    }
                    graphicsShape.DrawLine(pens, b2s, wer3);
                    graphicsShape.DrawLine(pens, b2e, Y_Base);
                    graphicsShape.DrawLine(pens, b2s1, wer5);
                    graphicsShape.DrawLine(pens, b2e1, Z_Base);
                    graphicsShape.DrawLine(pens, h2s, SetPointCurrentType(D));
                    graphicsShape.DrawLine(pens, ls, SetPointCurrentType(A));
                    graphicsShape.DrawLine(pens, b1s, wer6);
                    graphicsShape.DrawLine(pens, b1e, Z_Base);
                    graphicsShape.DrawLine(pens, b3s, W_Base);
                    using (Pen pens1 = new Pen(Color.Red, SizeLineBoundArgument / 2))
                    {
                        graphicsShape.DrawLine(pens1, l1s, SetPointCurrentType(C));
                        graphicsShape.DrawLine(pens1, hs1, he1);
                        graphicsShape.DrawLine(pens1, hs1, SetPointCurrentType(B));
                        //graphicsShape.DrawLine(pens1, hs, SetPointCurrentType(B));
                    }
                }

            }
            
            #endregion
        }
        public override double SetH { get => Math.Round(GetSomeLineLength(D.PointX, C.PointY, E), 0); set => base.SetH = value; }
        public override double SetH1 { get => Math.Round(A_line.Length, 0); set => base.SetH1 = value; }
        public override double SetH2 { get => Math.Round(D_line.Length, 0); set => base.SetH2 = value; }
        public override double SetL { get => Math.Round(E_line.Length, 0); set => base.SetL = value; }
        public override double SetL1 { get => Math.Round(GetSomeLineLength(B.PointX, C.PointY, C), 0); set => base.SetL1 = value; }
        public override double SetH_t { get => Math.Round(GetSomeLineLength(DCheck.PointX, CCheck.PointY, ECheck),0); }
        public override double SetH1_t { get => Math.Round(A_Check_Line.Length, 0); }
        public override double SetH2_t { get => Math.Round(D_Check_Line.Length, 0); }
        public override double SetL_t { get => Math.Round(E_Check_Line.Length, 0); }
        public override double SetL1_t { get => Math.Round(GetSomeLineLength(BCheck.PointX, CCheck.PointY, CCheck), 0); }
        protected override void SetHValue()
        {
            base.SetHValue();
            var pr = C.PointY;
            ShapePoint P = GetNewCustomPoint(C.PointX, A.PointY);
            C.PointX = SetCurrentLineLength(P, C, _SetH).PointX;
            C.PointY = SetCurrentLineLength(P, C, _SetH).PointY;
            var diff = pr - C.PointY;
            Move(y: diff);
            ValidValue = false;
        }
        protected override void SetLValue()
        {
            base.SetLValue();
            var pr = A.PointX;
            TempPoint.PointX = C.PointX;
            TempPoint.PointY = C.PointY;
            CenterPoint.PointX = A.PointX + E_line.Length / 2;
            CenterPoint.PointY = A.PointY;
            A.PointX = SetCurrentLineLength(CenterPoint, A, _SetL / 2).PointX;
            A.PointY = SetCurrentLineLength(CenterPoint, A, _SetL / 2).PointY;
            B.PointX = A.PointX;
            E.PointX = SetCurrentLineLength(CenterPoint, E, _SetL / 2).PointX;
            E.PointY = SetCurrentLineLength(CenterPoint, E, _SetL / 2).PointY;
            D.PointX = E.PointX;
            var diff = pr - A.PointX;
            Move(x: diff);
            ValidValue = false;
        }
        protected override void SetL1Value()
        {
            base.SetL1Value();
            TempPoint.PointX = B.PointX - 3;
            TempPoint.PointY = C.PointY;
            C.PointX = SetCurrentLineLength(TempPoint, C, _SetL1).PointX + 3;
            C.PointY = SetCurrentLineLength(TempPoint, C, _SetL1).PointY;

        }
        protected override void SetH1Value()
        {
            base.SetH1Value();
            B.PointX = SetCurrentLineLength(A, B, _SetH1).PointX;
            B.PointY = SetCurrentLineLength(A, B, _SetH1).PointY;
        }
        protected override void SetH2Value()
        {
            base.SetH2Value();
            D.PointX = SetCurrentLineLength(E, D, _SetH2).PointX;
            D.PointY = SetCurrentLineLength(E, D, _SetH2).PointY;
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
            double diag = 0;
            diag = (diag <= 90)
                ? CheckCut2 / Math.Sin(CalculateAngle(B, C, D) * Math.PI / 180)
                : (90 - ((180 - CheckCut2 / Math.Sin(CalculateAngle(B, C, D)) * Math.PI / 180)));
            diag = (IsToothVector == true) ? 0 : diag;
            var value1 = (IsToothVector==true) ? _CheckCut1 : 0;
            var value2 = (IsToothVector==true) ? _CheckCut2 : 0;
            var value3 = (IsToothVector==true) ? _CheckCut3 : 0;
            var value4 = (IsToothVector==true) ? _CheckCut4 : 0;
            var value5 = (IsToothVector == true) ? _CheckCut5 : 0;
            var width = _SetL + _SetB1*2 + value1 + value4;
            var height = _SetH + _SetB2+_SetB3 +diag +value5;

            if (_SetH < 0 || _SetH1 < 0 || _SetH2 < 0 || _SetL < 0 || _SetL1 < 0 ||
                _SetL2 < 0 || _SetB1 < 0 || _SetB2 < 0 || _SetB3 < 0)
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH2");
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH2_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL1_t");
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