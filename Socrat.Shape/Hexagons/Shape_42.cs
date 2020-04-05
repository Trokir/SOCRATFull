using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Events;
using Socrat.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Socrat.Shape.Pentagons
{
    sealed class Shape_42 : Hexagon
    {
        public Shape_42(List<ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {

        }
        public override double Perimeter
        {
            get
            {
                return Math.Round((A_line.Length + B_line.Length + C_line.Length + D_line.Length + E_line.Length + F_line.Length) / 1000, 3);
            }
        }
        public override double Perimeter_t
        {
            get => Math.Round((A_Check_Line.Length + B_Check_Line.Length + C_Check_Line.Length + D_Check_Line.Length +
                E_Check_Line.Length + F_Check_Line.Length) / 1000, 3);

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
                    graphicsShape.DrawLine(pen6, F, A);
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
                    graphicsShape.DrawLine(pen6, F, A);
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
                MoveBorderLeft(W_Base, X_Base, SetB1);
                MoveBorderTop(X_Base, Y_Base, SetB2);
                MoveBorderRight(Y_Base, Z_Base, SetB1);
                MoveBorderBottom(W_Base, Z_Base, SetB2);
                pen.DashStyle = DashStyle.DashDot;
            }
        }

        protected override PointF[] GetBasePoints()
        {
            return new PointF[] { A, B, C, D, E, F };
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
                ShapePoint ls = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 30 * LineBoundArgument);
                ShapePoint le = GetNewCustomPoint(SetPointCurrentValueX(E), W_Base.PointY + 30 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                ShapePoint lcenter = GetNewCustomPoint(SetPointCurrentValueX(A) + (ll.Length / 2), W_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                graphicsShape.DrawString("L=" + SetL, drawFontBold, Brushes.Black, lcenter, sf);


                ShapePoint b1s1 = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 30 * LineBoundArgument);
                ShapePoint b1e1 = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s1, b1e1);
                Line b12h = GetNewLine(b1s1, b1e1);
                ShapePoint b12scenter = GetNewCustomPoint(W_Base.PointX + b12h.Length / 2, W_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b12scenter, sf);


                ShapePoint bs12 = GetNewCustomPoint(SetPointCurrentValueX(E), Z_Base.PointY + 30 * LineBoundArgument);
                ShapePoint be12 = GetNewCustomPoint(Z_Base.PointX, Z_Base.PointY + 30 * LineBoundArgument);
                Line bl12 = GetNewLine(bs12, be12);
                ShapePoint b12center = GetNewCustomPoint(SetPointCurrentValueX(E) + (bl12.Length / 2), Z_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, bs12, be12);
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b12center, sf);


                ShapePoint l1s1 = GetNewCustomPoint(SetPointCurrentValueX(B), W_Base.PointY + 10 * LineBoundArgument);
                ShapePoint l1e1 = GetNewCustomPoint(SetPointCurrentValueX(C), W_Base.PointY + 10 * LineBoundArgument);
                graphicsShape.DrawLine(pen, l1s1, l1e1);
                Line l1h = GetNewLine(l1s1, l1e1);
                ShapePoint l12scenter = GetNewCustomPoint(SetPointCurrentValueX(B) + l1h.Length / 2, W_Base.PointY + 10 * LineBoundArgument);
                graphicsShape.DrawString("L1=" + SetL1, drawFontBold, Brushes.Black, l12scenter, sf);


                ShapePoint l2s1 = GetNewCustomPoint(SetPointCurrentValueX(E), Z_Base.PointY + 10 * LineBoundArgument);
                ShapePoint l2e1 = GetNewCustomPoint(SetPointCurrentValueX(F), Z_Base.PointY + 10 * LineBoundArgument);
                graphicsShape.DrawLine(pen, l2s1, l2e1);
                Line l2h = GetNewLine(l2s1, l2e1);
                ShapePoint l2scenter = GetNewCustomPoint(SetPointCurrentValueX(F) + l2h.Length / 2, Z_Base.PointY + 10);
                graphicsShape.DrawString("L2=" + SetL2, drawFontBold, Brushes.Black, l2scenter, sf);


                ShapePoint hs = GetNewCustomPoint(Y_Base.PointX + 35 * LineBoundArgument, SetPointCurrentValueY(D));
                ShapePoint he = GetNewCustomPoint(Y_Base.PointX + 35 * LineBoundArgument, SetPointCurrentValueY(F));
                graphicsShape.DrawLine(pen, hs, he);
                Line hh = GetNewLine(hs, he);
                ShapePoint hscenter = GetNewCustomPoint(Y_Base.PointX + 35 * LineBoundArgument, SetPointCurrentValueY(F) - hh.Length / 2);
                graphicsShape.DrawString("H=" + SetH, drawFontBold, Brushes.Black, hscenter, sf);


                ShapePoint b2s1 = GetNewCustomPoint(Y_Base.PointX + 35 * LineBoundArgument, SetPointCurrentValueY(D));
                ShapePoint b2e1 = GetNewCustomPoint(Y_Base.PointX + 35 * LineBoundArgument, Y_Base.PointY);
                graphicsShape.DrawLine(pen, b2s1, b2e1);
                Line b2h = GetNewLine(b2s1, b2e1);
                ShapePoint b2scenter = GetNewCustomPoint(Y_Base.PointX + 35 * LineBoundArgument, Y_Base.PointY + b2h.Length / 2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b2scenter, sf);

                ShapePoint b2s2 = GetNewCustomPoint(Z_Base.PointX + 35 * LineBoundArgument, SetPointCurrentValueY(F));
                ShapePoint b2e2 = GetNewCustomPoint(Z_Base.PointX + 35 * LineBoundArgument, Z_Base.PointY);
                graphicsShape.DrawLine(pen, b2s2, b2e2);
                Line b2h2 = GetNewLine(b2s2, b2e2);
                ShapePoint b22scenter = GetNewCustomPoint(Z_Base.PointX + 35 * LineBoundArgument, Z_Base.PointY - b2h2.Length / 2);
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b22scenter, sf);


                ShapePoint h1s1 = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(B));
                ShapePoint h1e1 = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(C));
                Line h1h = GetNewLine(h1s1, h1e1);
                ShapePoint h1scenter = GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(B) - h1h.Length / 2);
                graphicsShape.DrawString("H1=" + SetH1, drawFontBold, Brushes.Black, h1scenter, sf);

                ShapePoint h2s1 = GetNewCustomPoint(Z_Base.PointX + 15 * LineBoundArgument, SetPointCurrentValueY(E));
                ShapePoint h2e1 = GetNewCustomPoint(Z_Base.PointX + 15 * LineBoundArgument, SetPointCurrentValueY(F));
                graphicsShape.DrawLine(pen, h2s1, h2e1);
                Line h2h = GetNewLine(h2s1, h2e1);
                ShapePoint h2scenter = GetNewCustomPoint(Z_Base.PointX + 15 * LineBoundArgument, SetPointCurrentValueY(F) - h2h.Length / 2);
                graphicsShape.DrawString("H2=" + SetH2, drawFontBold, Brushes.Black, h2scenter, sf);

                ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX + E.PointX + F.PointX) / 6), ((A.PointY + B.PointY + C.PointY + D.PointY + E.PointY + F.PointY) / 6));
                Font drawNumbertBold = new Font("Tahoma", 40 + ThiknessFontArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("42", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }
                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {
                    ShapePoint wer1 = GetNewCustomPoint(X_Base.PointX, SetPointCurrentValueY(C));
                    ShapePoint wer2 = GetNewCustomPoint(SetPointCurrentValueX(B), Y_Base.PointY);
                    ShapePoint wer3 = GetNewCustomPoint(Y_Base.PointX, SetPointCurrentValueY(D));
                    ShapePoint wer4 = GetNewCustomPoint(SetPointCurrentValueX(D), Y_Base.PointY);
                    ShapePoint wer5 = GetNewCustomPoint(Z_Base.PointX, SetPointCurrentValueY(F));
                    ShapePoint wer6 = GetNewCustomPoint(SetPointCurrentValueX(E), Z_Base.PointY);
                    ShapePoint wer7 = GetNewCustomPoint(W_Base.PointX, SetPointCurrentValueY(A));
                    ShapePoint wer8 = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY);
                    using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        graphicsShape.DrawLine(pen1, wer1, SetPointCurrentType(C));
                        graphicsShape.DrawLine(pen1, wer2, SetPointCurrentType(B));
                        graphicsShape.DrawLine(pen1, wer3, SetPointCurrentType(D));
                        graphicsShape.DrawLine(pen1, wer4, SetPointCurrentType(D));
                        graphicsShape.DrawLine(pen1, wer5, SetPointCurrentType(F));
                        graphicsShape.DrawLine(pen1, wer6, SetPointCurrentType(E));
                        graphicsShape.DrawLine(pen1, wer7, SetPointCurrentType(A));
                        graphicsShape.DrawLine(pen1, wer8, SetPointCurrentType(A));
                    }
                    graphicsShape.DrawLine(pens, ls, wer8);
                    graphicsShape.DrawLine(pens, le, wer6);
                    graphicsShape.DrawLine(pens, b1s1, W_Base);
                    graphicsShape.DrawLine(pens, hs, wer3);
                    graphicsShape.DrawLine(pens, he, wer5);
                    graphicsShape.DrawLine(pens, h2s1, SetPointCurrentType(E));
                    graphicsShape.DrawLine(pens, l2e1, SetPointCurrentType(F));
                    graphicsShape.DrawLine(pens, b2e2, Z_Base);
                    graphicsShape.DrawLine(pens, b2e1, Y_Base);
                    graphicsShape.DrawLine(pens, be12, Z_Base);

                    using (Pen pens2 = new Pen(Color.Green, SizeLineBoundArgument / 2))
                    {
                        pens2.StartCap = LineCap.ArrowAnchor;
                        pens2.EndCap = LineCap.ArrowAnchor;
                        graphicsShape.DrawLine(pens2, h1s1, h1e1);
                        graphicsShape.DrawLine(pens2, h1s1, SetPointCurrentType(B));
                    }

                    using (Pen pens1 = new Pen(Color.Red, SizeLineBoundArgument / 2))
                    {

                        graphicsShape.DrawLine(pens1, l1e1, SetPointCurrentType(C));
                    }
                }
            }
            #endregion
        }
        public override double SetH { get => Math.Round(GetNewLine(A, GetNewCustomPoint(A.PointX, C.PointY)).Length, 0); set => base.SetH = value; }
        public override double SetL { get => Math.Round(GetNewLine(A, GetNewCustomPoint(E.PointX, A.PointY)).Length, 0); set => base.SetL = value; }
        public override double SetL1 { get => Math.Round(GetNewLine(C, GetNewCustomPoint(A.PointX, C.PointY)).Length, 0); set => base.SetL1 = value; }
        public override double SetL2 { get => Math.Round(GetNewLine(F, GetNewCustomPoint(E.PointX, F.PointY)).Length, 0); set => base.SetL2 = value; }
        public override double SetH1 { get => Math.Round(GetNewLine(B, GetNewCustomPoint(A.PointX, C.PointY)).Length, 0); set => base.SetH1 = value; }
        public override double SetH2 { get => Math.Round(GetNewLine(E, GetNewCustomPoint(E.PointX, F.PointY)).Length, 0); set => base.SetH2 = value; }
        public override double SetH_t
        {
            get
            {
                ShapePoint g = GetNewCustomPoint(ACheck.PointX, CCheck.PointY);
                Line line = GetNewLine(ACheck, g);
                return Math.Round(line.Length, 0);
            }
        }
        public override double SetL_t
        {
            get
            {
                ShapePoint g = GetNewCustomPoint(ECheck.PointX, ACheck.PointY);
                Line line = GetNewLine(ACheck, g);
                return Math.Round(line.Length, 0);
            }
        }
        public override double SetL1_t
        {
            get
            {
                ShapePoint g = GetNewCustomPoint(ACheck.PointX, CCheck.PointY);
                Line line = GetNewLine(CCheck, g);
                return Math.Round(line.Length, 0);
            }
        }
        public override double SetL2_t
        {
            get
            {
                ShapePoint g = GetNewCustomPoint(ECheck.PointX, FCheck.PointY);
                Line line = GetNewLine(FCheck, g);
                return Math.Round(line.Length, 0);
            }
        }
        public override double SetH1_t
        {
            get
            {
                ShapePoint g = GetNewCustomPoint(ACheck.PointX, CCheck.PointY);
                Line line = GetNewLine(BCheck, g);
                return Math.Round(line.Length, 0);
            }
        }
        public override double SetH2_t
        {
            get
            {
                ShapePoint g = GetNewCustomPoint(ECheck.PointX, FCheck.PointY);
                Line line = GetNewLine(ECheck, g);
                return Math.Round(line.Length, 0);
            }
        }
        protected override void SetHValue()
        {
            base.SetHValue();
            var p = C.PointY;
            var g = GetNewCustomPoint(A.PointX, C.PointY);
            var line = GetNewLine(A, g);
            var Ce = GetNewCustomPoint(A.PointX, C.PointY);
            TempPoint.PointX = SetCurrentLineLength(Ce, A, _SetH).PointX;
            TempPoint.PointY = SetCurrentLineLength(Ce, A, _SetH).PointY;
            var diff = A.PointY - TempPoint.PointY;
            A.PointY = TempPoint.PointY;
            F.PointY = A.PointY;
            E.PointY -= diff;
            var diffr = p - C.PointY;
            Move(y: diffr);
            ValidValue = false;
        }
        protected override void SetLValue()
        {
            var pr = A.PointX;
            base.SetLValue();
            var g = GetNewCustomPoint(E.PointX, A.PointY);
            var line = GetNewLine(A, g);
            var center = GetNewCustomPoint(A.PointX + line.Length / 2, A.PointY);
            var center1 = GetNewCustomPoint(D.PointX - line.Length / 2, D.PointY);
            TempPoint.PointX = SetCurrentLineLength(center, A, _SetL / 2).PointX;
            TempPoint.PointY = SetCurrentLineLength(center, A, _SetL / 2).PointY;
            var diff = A.PointX - TempPoint.PointX;
            C.PointX -= diff;
            A.PointX = TempPoint.PointX;
            B.PointX = A.PointX;
            CenterPoint.PointX = SetCurrentLineLength(center1, D, _SetL / 2).PointX;
            CenterPoint.PointY = SetCurrentLineLength(center1, D, _SetL / 2).PointY;
            var diff1 = D.PointX - CenterPoint.PointX;
            D.PointX = CenterPoint.PointX;
            F.PointX -= diff1;
            E.PointX = D.PointX;
            var diffr = pr - A.PointX;
            Move(x: diffr);
            ValidValue = false;
        }
        protected override void SetL2Value()
        {
            ShapePoint Dh = GetNewCustomPoint(E.PointX + 1, F.PointY);
            F.PointX = SetCurrentLineLength(Dh, F, _SetL2).PointX - 1;
            F.PointY = SetCurrentLineLength(Dh, F, _SetL2).PointY;
            ValidValue = false;
        }
        protected override void SetL1Value()
        {
            ShapePoint Dh = GetNewCustomPoint(A.PointX - 1, C.PointY);
            C.PointX = SetCurrentLineLength(Dh, C, _SetL1).PointX + 1;
            C.PointY = SetCurrentLineLength(Dh, C, _SetL1).PointY;
            ValidValue = false;
        }
        protected override void SetH1Value()
        {
            base.SetH1Value();
            ShapePoint Dh = GetNewCustomPoint(A.PointX, C.PointY - 1);
            B.PointX = SetCurrentLineLength(Dh, B, _SetH1).PointX;
            B.PointY = SetCurrentLineLength(Dh, B, _SetH1).PointY + 1;
            ValidValue = false;
        }
        protected override void SetH2Value()
        {
            base.SetH2Value();
            ShapePoint Dh = GetNewCustomPoint(E.PointX, F.PointY + 1);
            E.PointX = SetCurrentLineLength(Dh, E, _SetH2).PointX;
            E.PointY = SetCurrentLineLength(Dh, E, _SetH2).PointY - 1;
            ValidValue = false;
        }
        public override void GetExtremumPoints()
        {
            List<ShapePoint> pointList = new List<ShapePoint>() { A, B, C, D, E, F, ACheck, BCheck, CCheck, DCheck, ECheck, FCheck };
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
            var value4 = (IsToothVector==true) ? _CheckCut4 : 0;
            var value5 = (IsToothVector==true) ? _CheckCut5 : 0;
            var value6 = (IsToothVector == true) ? _CheckCut6 : 0;
            var width = _SetL + value1 + value4 + SetB1 * 2 + SetB3;
            var height = _SetH + SetB2 * 2 + value6 + value3;

            if (_SetH < 0 || _SetH1 < 0 || _SetH2 < 0 || _SetL < 0 || _SetL1 < 0 || _SetL2 < 0 || _SetB1 < 0 || _SetB2 < 0 || _SetB3 < 0)
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
            else if ((_SetH > 0) && _SetH < SetH1 + SetH2)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение H не может быть меньше H1+H2");
            }
            else if ((_SetH1 > 0) && _SetH1 > SetH)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение H1 не может быть больше H");
            }
            
            else if ((_SetH2 > 0) && _SetH2 > SetH)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение H2 не может быть больше H");
            }
            else if ((_SetL1 > 0) && _SetL1 > SetL)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение L1 не может быть больше L");
            }
            else if ((_SetL2 > 0) && _SetL2 > SetL)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение L2 не может быть больше L");
            }

            else if ((_SetL > 0) && _SetL < SetL2 + SetL1)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение L не может быть меньше L2+L1");
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH1");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH2");

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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL1_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL2_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH1_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH2_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsToothVector");
                AddIfPropertyExist(e.Properties, filteredCollection, "IsSelectSameAllowance");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut1");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut2");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut3");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut4");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut5");
                AddIfPropertyExist(e.Properties, filteredCollection, "CheckCut6");
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

