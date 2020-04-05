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

namespace Socrat.Shape.Octagons
{
    sealed class Shape_19 : Octagon
    {
        public Shape_19(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {

        }
        public override double Perimeter
        {
            get
            {
                return Math.Round((A_line.Length + B_line.Length + C_line.Length +
                    D_line.Length + E_line.Length + F_line.Length + G_line.Length + H_line.Length) / 1000, 3);
            }
        }
        public override double Perimeter_t
        {
            get
            {
                return Math.Round((A_Check_Line.Length + B_Check_Line.Length + C_Check_Line.Length + D_Check_Line.Length +
                    E_Check_Line.Length + F_Check_Line.Length + G_Check_Line.Length + H_Check_Line.Length) / 1000, 3);
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
                    graphicsShape.DrawLine(pen5, E, F);
                }
                using (pen6 = new Pen(SelectMainLineColor6(), ThiсknessArgument / 2))
                {
                    pen6.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen6, F, G);
                }
                using (pen7 = new Pen(SelectMainLineColor7(), ThiсknessArgument / 2))
                {
                    pen7.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen7, G, H);
                }
                using (pen8 = new Pen(SelectMainLineColor8(), ThiсknessArgument / 2))
                {
                    pen8.DashStyle = DashStyle.DashDot;
                    graphicsShape.DrawLine(pen8, H, A);
                }
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
                    graphicsShape.DrawLine(pen5, E, F);
                }
                using (pen6 = new Pen(SelectMainLineColor6(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen6, F, G);
                }
                using (pen7 = new Pen(SelectMainLineColor7(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen7, G, H);
                }
                using (pen8 = new Pen(SelectMainLineColor8(), ThiсknessArgument))
                {
                    graphicsShape.DrawLine(pen8, H, A);
                }
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

                MoveBorderRight(Z_Base, Y_Base, SetB1);
                MoveBorderLeft(W_Base, X_Base, SetB1);
                MoveBorderTop(X_Base, Y_Base, SetB2);
                MoveBorderBottom(W_Base, Z_Base, SetB2);
            }
        }

        protected override PointF[] GetBasePoints()
        {
            return new PointF[] { A, B, C, D, E, F, G, H };
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
                MoveInternalLineFromLeft(graphicsShape, W_Base, X_Base, First_B_Some_Size_Point,
        Second_B_Some_Size_Point, SetB1, SetB3);
            }
            using (Pen pen = new Pen(Color.Blue, SizeLineBoundArgument))
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                pen.StartCap = LineCap.ArrowAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                pen.DashStyle = DashStyle.Solid;

                ShapePoint b2s = GetNewCustomPoint(Y_Base.PointX + 30 * LineBoundArgument, X_Base.PointY);
                ShapePoint b2e = GetNewCustomPoint(Y_Base.PointX + 30 * LineBoundArgument, X_Base.PointY + SetB2);
                graphicsShape.DrawLine(pen, b2s, b2e);
                Line b2h = GetNewLine(b2s, b2e);
                ShapePoint b2scenter = GetNewCustomPoint(Y_Base.PointX + 32 * LineBoundArgument, X_Base.PointY + b2h.Length / 2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b2scenter, sf);


                ShapePoint b2s1 = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, W_Base.PointY);
                ShapePoint b2e1 = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, W_Base.PointY - SetB2);
                graphicsShape.DrawLine(pen, b2s1, b2e1);
                Line b2h1 = GetNewLine(b2s1, b2e1);
                ShapePoint b21scenter = GetNewCustomPoint(Z_Base.PointX + 32 * LineBoundArgument, W_Base.PointY - b2h1.Length / 2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b21scenter, sf);


                ShapePoint h1s = GetNewCustomPoint(Y_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(F));
                ShapePoint h1e = GetNewCustomPoint(Y_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(E));
                graphicsShape.DrawLine(pen, h1s, h1e);
                Line h1h = GetNewLine(h1s, h1e);
                ShapePoint h1scenter = GetNewCustomPoint(Y_Base.PointX + 12 * LineBoundArgument, SetPointCurrentValueY(E) + h1h.Length / 2);
                graphicsShape.DrawString("H1=" + SetCurrentSize(SetH1), drawFontBold, Brushes.Black, h1scenter, sf);

                ShapePoint h1s2 = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(G));
                ShapePoint h1e2 = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(H));
                graphicsShape.DrawLine(pen, h1s2, h1e2);
                Line h1h2 = GetNewLine(h1s2, h1e2);
                ShapePoint h12scenter = GetNewCustomPoint(Z_Base.PointX + 12 * LineBoundArgument, SetPointCurrentValueY(G) + h1h2.Length / 2);
                graphicsShape.DrawString("H1=" + SetCurrentSize(SetH1), drawFontBold, Brushes.Black, h12scenter, sf);

                ShapePoint b1s = GetNewCustomPoint(W_Base.PointX + SetB1, W_Base.PointY + 30 * LineBoundArgument);
                ShapePoint b1e = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 30 * LineBoundArgument);
                Line lb1 = GetNewLine(b1s, b1e);
                ShapePoint b1center = GetNewCustomPoint(W_Base.PointX + (lb1.Length / 2), W_Base.PointY + 32 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s, b1e);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b1center, sf);


                ShapePoint b1s1 = GetNewCustomPoint(Z_Base.PointX - SetB1, W_Base.PointY + 30 * LineBoundArgument);
                ShapePoint b1e1 = GetNewCustomPoint(Z_Base.PointX, Z_Base.PointY + 30 * LineBoundArgument);
                Line lb11 = GetNewLine(b1s1, b1e1);
                ShapePoint b11center = GetNewCustomPoint(Z_Base.PointX - (lb1.Length / 2), Z_Base.PointY + 32 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s1, b1e1);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b11center, sf);

                ShapePoint hs = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, SetPointCurrentValueY(D));
                ShapePoint he = GetNewCustomPoint(Z_Base.PointX + 30 * LineBoundArgument, SetPointCurrentValueY(A));
                Line lh = GetNewLine(hs, he);
                ShapePoint hcenter = GetNewCustomPoint(Z_Base.PointX + 32 * LineBoundArgument, W_Base.PointY - (lh.Length / 2));
                graphicsShape.DrawLine(pen, hs, he);
                graphicsShape.DrawString("H=" + SetCurrentSize(SetH), drawFontBold, Brushes.Black, hcenter, sf);

                ShapePoint ls = GetNewCustomPoint(SetPointCurrentValueX(B), W_Base.PointY + 30 * LineBoundArgument);
                ShapePoint le = GetNewCustomPoint(SetPointCurrentValueX(G), W_Base.PointY + 30 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                ShapePoint lcenter = GetNewCustomPoint(W_Base.PointX + (ll.Length / 2), W_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                graphicsShape.DrawString("L=" + SetCurrentSize(SetL), drawFontBold, Brushes.Black, lcenter, sf);

                ShapePoint ls1 = GetNewCustomPoint(SetPointCurrentValueX(C), W_Base.PointY + 15 * LineBoundArgument);
                ShapePoint le1 = GetNewCustomPoint(SetPointCurrentValueX(D), W_Base.PointY + 15 * LineBoundArgument);
                Line ll1 = GetNewLine(ls1, le1);
                ShapePoint l1center = GetNewCustomPoint(SetPointCurrentValueX(C) + (ll1.Length / 2), W_Base.PointY + 7 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls1, le1);
                if (ll1.Length > 8)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("L1=" + SetCurrentSize(SetL1), drawFontBold, Brushes.Black, l1center, sf);
                }

                ShapePoint ls12 = GetNewCustomPoint(SetPointCurrentValueX(E), W_Base.PointY + 15 * LineBoundArgument);
                ShapePoint le12 = GetNewCustomPoint(SetPointCurrentValueX(F), W_Base.PointY + 15 * LineBoundArgument);
                Line ll12 = GetNewLine(ls1, le1);
                ShapePoint l12center = GetNewCustomPoint(SetPointCurrentValueX(E) + (ll12.Length / 2), W_Base.PointY + 7 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls12, le12);
                graphicsShape.DrawString("L1=" + SetCurrentSize(SetL1), drawFontBold, Brushes.Black, l12center, sf);


                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX + E.PointX + F.PointX + G.PointX + H.PointX) / 8), ((A.PointY + B.PointY + C.PointY + D.PointY + E.PointY + F.PointY + G.PointY + H.PointY) / 8));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiknessFontArgument);
                if (Area > 0.012)
                {
                    graphicsShape.DrawString("19", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }

                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {

                    ShapePoint wer = GetNewCustomPoint(SetPointCurrentValueX(B), W_Base.PointY);
                    ShapePoint wer1 = GetNewCustomPoint(SetPointCurrentValueX(C), X_Base.PointY);
                    ShapePoint wer2 = GetNewCustomPoint(SetPointCurrentValueX(G), W_Base.PointY);
                    ShapePoint wer3 = GetNewCustomPoint(SetPointCurrentValueX(F), X_Base.PointY);
                    ShapePoint wer4 = GetNewCustomPoint(W_Base.PointX, SetPointCurrentValueY(A));
                    ShapePoint wer5 = GetNewCustomPoint(Z_Base.PointX, SetPointCurrentValueY(H));
                    ShapePoint wer6 = GetNewCustomPoint(W_Base.PointX, SetPointCurrentValueY(D));
                    ShapePoint wer7 = GetNewCustomPoint(Z_Base.PointX, SetPointCurrentValueY(E));
                    ShapePoint wer8 = GetNewCustomPoint(Z_Base.PointX, SetPointCurrentValueY(F));
                    ShapePoint wer9 = GetNewCustomPoint(Z_Base.PointX, SetPointCurrentValueY(G));
                    using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        graphicsShape.DrawLine(pen1, wer, SetPointCurrentType(B));
                        graphicsShape.DrawLine(pen1, wer1, SetPointCurrentType(C));
                        graphicsShape.DrawLine(pen1, wer2, SetPointCurrentType(G));
                        graphicsShape.DrawLine(pen1, wer3, SetPointCurrentType(F));
                        graphicsShape.DrawLine(pen1, wer4, SetPointCurrentType(A));
                        graphicsShape.DrawLine(pen1, wer5, SetPointCurrentType(H));
                        graphicsShape.DrawLine(pen1, wer6, SetPointCurrentType(D));
                        graphicsShape.DrawLine(pen1, wer7, SetPointCurrentType(E));
                        graphicsShape.DrawLine(pen1, wer8, SetPointCurrentType(F));
                        graphicsShape.DrawLine(pen1, wer9, SetPointCurrentType(G));
                    }
                    graphicsShape.DrawLine(pens, wer, ls);
                    graphicsShape.DrawLine(pens, wer2, le);
                    graphicsShape.DrawLine(pens, le1, SetPointCurrentType(A));
                    graphicsShape.DrawLine(pens, ls12, SetPointCurrentType(H));
                    graphicsShape.DrawLine(pens, b1e, W_Base);
                    graphicsShape.DrawLine(pens, b1e1, Z_Base);
                    graphicsShape.DrawLine(pens, hs, wer7);
                    graphicsShape.DrawLine(pens, he, wer5);
                    graphicsShape.DrawLine(pens, h1s, wer8);
                    graphicsShape.DrawLine(pens, h1s2, wer9);
                    graphicsShape.DrawLine(pens, b2s, Y_Base);
                    graphicsShape.DrawLine(pens, b2s1, Z_Base);
                }

            }
            #endregion
        }
        public override double SetH { get => Math.Round(GetNewLine(A, D).Length, 0); set => base.SetH = value; }
        public override double SetH1 { get => Math.Round(GetNewLine(GetNewCustomPoint(B.PointX, A.PointY), B).Length, 0); set => base.SetH1 = value; }
        public override double SetL { get => Math.Round(GetNewLine(B, G).Length, 0); set => base.SetL = value; }
        public override double SetL1 { get => Math.Round(GetNewLine(GetNewCustomPoint(G.PointX, H.PointY), H).Length, 0); set => base.SetL1 = value; }
        public override double SetH_t
        {
            get
            {
                Line l = GetNewLine(ACheck, DCheck);
                return Math.Round(l.Length, 0);
            }
        }
        public override double SetH1_t
        {
            get
            {
                ShapePoint d = GetNewCustomPoint(BCheck.PointX, ACheck.PointY);
                Line l = GetNewLine(d, BCheck);
                return Math.Round(l.Length, 0);
            }
        }
        public override double SetL_t
        {
            get
            {
                Line l = GetNewLine(BCheck, GCheck);
                return Math.Round(l.Length, 0);
            }
        }
        public override double SetL1_t
        {
            get
            {
                ShapePoint d = GetNewCustomPoint(GCheck.PointX, HCheck.PointY);
                Line l = GetNewLine(d, HCheck);
                return Math.Round(l.Length, 0);
            }
        }
        protected override void SetHValue()
        {
            base.SetHValue();
            CurvePoint.PointY = A.PointY;
            A.PointY = SetCurrentLineLength(D, A, _SetH).PointY;
            H.PointY = A.PointY;
            double diff = A.PointY - CurvePoint.PointY;
            B.PointY += diff;
            G.PointY = B.PointY;
            ValidValue = false;
        }
        protected override void SetLValue()
        {
            base.SetLValue();
            CurvePoint.PointX = G.PointX;
            G.PointX = SetCurrentLineLength(B, G, _SetL).PointX;
            F.PointX = G.PointX;
            var diff = G.PointX - CurvePoint.PointX;
            H.PointX += diff;
            E.PointX = H.PointX;
            ValidValue = false;
        }
        protected override void SetL1Value()
        {
            var d = GetNewCustomPoint(G.PointX, H.PointY);
            H.PointX = SetCurrentLineLength(d, H, _SetL1).PointX;
            E.PointX = H.PointX;
            ShapePoint d1 = GetNewCustomPoint(B.PointX, A.PointY);
            A.PointX = SetCurrentLineLength(d1, A, _SetL1).PointX;
            D.PointX = A.PointX;
            ValidValue = false;
        }
        protected override void SetH1Value()
        {
            base.SetH1Value();
            var d = GetNewCustomPoint(B.PointX, A.PointY);
            B.PointY = SetCurrentLineLength(d, B, _SetH1).PointY;
            G.PointY = B.PointY;
            var d1 = GetNewCustomPoint(C.PointX, D.PointY);
            C.PointY = SetCurrentLineLength(d1, C, _SetH1).PointY;
            F.PointY = C.PointY;
            ValidValue = false;
        }
        public override void GetExtremumPoints()
        {

            List<ShapePoint> pointList = new List<ShapePoint>() { A, B, C, D, E, F, G, H, ACheck, BCheck, CCheck, DCheck, ECheck, FCheck, GCheck, HCheck };

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

            var value1 = (IsToothVector == true) ? _CheckCut1 : 0;
            var value2 = (IsToothVector == true) ? _CheckCut2 : 0;
            var value3 = (IsToothVector == true) ? _CheckCut3 : 0;
            var value4 = (IsToothVector == true) ? _CheckCut4 : 0;
            var value5 = (IsToothVector == true) ? _CheckCut5 : 0;
            var value6 = (IsToothVector == true) ? _CheckCut6 : 0;
            var value7 = (IsToothVector == true) ? _CheckCut7 : 0;
            var value8 = (IsToothVector == true) ? _CheckCut8 : 0;

            var width = _SetL + _SetB1 * 2 + value2 + value6;
            var height = _SetH + _SetB2 * 2 + value4 + value8;

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
            else if ((_SetH > 0) && _SetH < SetH1 * 2)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение H не может быть меньше H1*2");
            }
            else if ((_SetH1 > 0) && _SetH1 > SetH / 2)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение H1 не может быть больше H/2");
            }
            else if ((_SetL > 0) && _SetL < SetL1 * 2)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение L не может быть меньше L1*2");
            }
            else if ((_SetL1 > 0) && _SetL1 > SetL / 2)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение L1 не может быть больше L/2");
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
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut5");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut6");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut7");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut8");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsCuttingGlass");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsBendingDistanceFrame");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsFormSealing");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsGasFillingForm");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsVertBendingMashineRobot");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsVertMashineEdgeMaking");
                e.Properties = filteredCollection;
            }
        }
    }
}
