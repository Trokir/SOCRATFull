using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Socrat.Shape.Pentagons
{
     sealed class Shape_10 : Hexagon
    {
        public Shape_10(List<Core.Entities.ShapePoint> ShapePoints, List<dynamic> currentShapeParametersList) : base(ShapePoints, currentShapeParametersList)
        {

        }
        public override double Perimeter
        {
            get
            {
                return Math.Round ((A_line.Length + B_line.Length + C_line.Length + D_line.Length + E_line.Length + F_line.Length) / 1000, 3);
            }
        }
        public override double Perimeter_t
        {
            get => Math.Round((A_Check_Line.Length + B_Check_Line.Length + C_Check_Line.Length + D_Check_Line.Length +
                E_Check_Line.Length + F_Check_Line.Length)/1000, 3);

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
                GetExtremumPoints();
                AllowanceProcessing();
                MoveBorderLeft(W_Base, X_Base, SetB1);
                MoveBorderTop(X_Base, Y_Base, SetB2);
                MoveBorderRight(Y_Base, Z_Base, SetB3);
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
                sf.Alignment = StringAlignment.Far;
                sf.LineAlignment = StringAlignment.Far;
                pen.StartCap = LineCap.ArrowAnchor;
                pen.EndCap = LineCap.ArrowAnchor;
                pen.DashStyle = DashStyle.Solid;


                Core.Entities.ShapePoint h2s = GetNewCustomPoint(SetPointCurrentValueX(A) + 10 * LineBoundArgument, SetPointCurrentValueY(B));
                Core.Entities.ShapePoint h2e = GetNewCustomPoint(SetPointCurrentValueX(A) + 10 * LineBoundArgument, SetPointCurrentValueY(A));
                Line l2h = GetNewLine(h2s, h2e);
                Core.Entities.ShapePoint h2center = GetNewCustomPoint(ACheck.PointX +10 * LineBoundArgument, SetPointCurrentValueY(A) - l2h.Length / 2);
                graphicsShape.DrawLine(pen, h2s, h2e);
                sf.FormatFlags = StringFormatFlags.LineLimit;
                if (l2h.Length > 8)
                {
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Near;
                    graphicsShape.DrawString("H2=" + SetCurrentSize(SetH2), drawFontBold, Brushes.Black, h2center, sf);
                }

                Core.Entities.ShapePoint ls = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 40 * LineBoundArgument);
                Core.Entities.ShapePoint le = GetNewCustomPoint(SetPointCurrentValueX(E), Z_Base.PointY + 40 * LineBoundArgument);
                Line ll = GetNewLine(ls, le);
                Core.Entities.ShapePoint lcenter = GetNewCustomPoint(SetPointCurrentValueX(A) + (ll.Length / 2), Z_Base.PointY + 30 * LineBoundArgument);
                graphicsShape.DrawLine(pen, ls, le);
                if (ll.Length > 8)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("L=" + SetCurrentSize(SetL), drawFontBold, Brushes.Black, lcenter, sf);
                }

                Core.Entities.ShapePoint l1s = GetNewCustomPoint(SetPointCurrentValueX(C), W_Base.PointY +10 * LineBoundArgument);
                Core.Entities.ShapePoint l1e = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY +10 * LineBoundArgument);
                Line ll1 = GetNewLine(l1s, l1e);
                Core.Entities.ShapePoint l1center = GetNewCustomPoint(SetPointCurrentValueX(A) + ll1.Length/2, W_Base.PointY +15 * LineBoundArgument);
                graphicsShape.DrawLine(pen, l1s, l1e);
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                graphicsShape.DrawString("L1=" + SetCurrentSize(SetL1), drawFontBold, Brushes.Black, l1center, sf);

                Core.Entities.ShapePoint l2s = GetNewCustomPoint(SetPointCurrentValueX(D), W_Base.PointY +10 * LineBoundArgument);
                Core.Entities.ShapePoint l2e = GetNewCustomPoint(SetPointCurrentValueX(F), W_Base.PointY + 10 * LineBoundArgument);
                Line ll2 = GetNewLine(l2s, l2e);
                Core.Entities.ShapePoint l2center = GetNewCustomPoint(SetPointCurrentValueX(D) + ll2.Length / 2, W_Base.PointY + 15 * LineBoundArgument);
                graphicsShape.DrawLine(pen, l2s, l2e);
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                graphicsShape.DrawString("L2=" + SetCurrentSize(SetL2), drawFontBold, Brushes.Black, l2center, sf);


                Core.Entities.ShapePoint b2s = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(C));
                Core.Entities.ShapePoint b2e = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, X_Base.PointY);
                graphicsShape.DrawLine(pen, b2s, b2e);
                Line b2h = GetNewLine(b2s, b2e);
                Core.Entities.ShapePoint b2scenter = GetNewCustomPoint(Y_Base.PointX +20 * LineBoundArgument, X_Base.PointY + b2h.Length / 2);
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                graphicsShape.DrawString("B2=" + SetB2, drawFontBold, Brushes.Black, b2scenter, sf);

                Core.Entities.ShapePoint b1s = GetNewCustomPoint(SetPointCurrentValueX(A), W_Base.PointY + 40 * LineBoundArgument);
                Core.Entities.ShapePoint b1e = GetNewCustomPoint(W_Base.PointX, W_Base.PointY + 40 * LineBoundArgument);
                Line lb1 = GetNewLine(b1s, b1e);
                Core.Entities.ShapePoint b1center = GetNewCustomPoint(W_Base.PointX + (lb1.Length / 2), W_Base.PointY + 40 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b1s, b1e);
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                graphicsShape.DrawString("B1=" + SetB1, drawFontBold, Brushes.Black, b1center, sf);

                Core.Entities.ShapePoint b3s = GetNewCustomPoint(SetPointCurrentValueX(E), Z_Base.PointY + 40 * LineBoundArgument);
                Core.Entities.ShapePoint b3e = GetNewCustomPoint(Z_Base.PointX, Z_Base.PointY + 40 * LineBoundArgument);
                Line lb3 = GetNewLine(b3s, b3e);
                Core.Entities.ShapePoint b3center = GetNewCustomPoint(SetPointCurrentValueX(E) + (lb3.Length / 2), Z_Base.PointY + 40 * LineBoundArgument);
                graphicsShape.DrawLine(pen, b3s, b3e);
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                graphicsShape.DrawString("B3=" + SetB3, drawFontBold, Brushes.Black, b3center, sf);

                Core.Entities.ShapePoint hs = GetNewCustomPoint(Y_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(D));
                Core.Entities.ShapePoint he = GetNewCustomPoint(Z_Base.PointX + 20 * LineBoundArgument, SetPointCurrentValueY(F));
                Line lh = GetNewLine(hs, he);
                Core.Entities.ShapePoint hcenter = GetNewCustomPoint(Y_Base.PointX + 22 * LineBoundArgument, SetPointCurrentValueY(F) - lh.Length / 2);
                graphicsShape.DrawLine(pen, hs, he);
                sf.FormatFlags = StringFormatFlags.LineLimit;
                if (lh.Length > 8)
                {
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Near;
                    graphicsShape.DrawString("H=" + SetCurrentSize(SetH), drawFontBold, Brushes.Black, hcenter, sf);
                }

                Core.Entities.ShapePoint h1s = GetNewCustomPoint(Y_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(E));
                Core.Entities.ShapePoint h1e= GetNewCustomPoint(Z_Base.PointX + 10 * LineBoundArgument, SetPointCurrentValueY(F));
                Line lh1 = GetNewLine(h1s, h1e);
                Core.Entities.ShapePoint h1center = GetNewCustomPoint(Y_Base.PointX + 12 * LineBoundArgument, SetPointCurrentValueY(F) - lh1.Length / 2);
                graphicsShape.DrawLine(pen, h1s, h1e);
                sf.FormatFlags = StringFormatFlags.LineLimit;
                if (lh.Length > 8)
                {
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Near;
                    graphicsShape.DrawString("H1=" + SetCurrentSize(SetH1), drawFontBold, Brushes.Black, h1center, sf);
                }

                Core.Entities.ShapePoint mCustCenter = GetNewCustomPoint(((A.PointX + B.PointX + C.PointX + D.PointX + E.PointX + F.PointX) / 6), ((A.PointY + B.PointY + C.PointY + D.PointY + E.PointY + F.PointY) / 6));
                Font drawNumbertBold = new Font("Tahoma", 40+ThiknessFontArgument);
                if (Area > 0.012)
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    graphicsShape.DrawString("10", drawNumbertBold, Brushes.Black, mCustCenter, sf);
                }
                using (Pen pens = new Pen(Color.Blue, SizeLineBoundArgument / 2))
                {

                    Core.Entities.ShapePoint wer = GetNewCustomPoint(Y_Base.PointX, SetPointCurrentValueY(D));
                    Core.Entities.ShapePoint wer1 = GetNewCustomPoint(W_Base.PointX, SetPointCurrentValueY(C));
                    using (pen1 = new Pen(Color.Black, ThiсknessArgument / 2))
                    {
                        graphicsShape.DrawLine(pen1, wer1, SetPointCurrentType(C));
                        graphicsShape.DrawLine(pen1, wer, SetPointCurrentType(D));
                    }
                    graphicsShape.DrawLine(pens, b2e, Y_Base);
                    graphicsShape.DrawLine(pens, b2s, wer);
                    graphicsShape.DrawLine(pens, b3e, Z_Base);
                    graphicsShape.DrawLine(pens, b3s, SetPointCurrentType(F));
                    graphicsShape.DrawLine(pens, b1e, W_Base);
                    graphicsShape.DrawLine(pens, b1s, SetPointCurrentType(A));
                    graphicsShape.DrawLine(pens, he, SetPointCurrentType(F));
                    graphicsShape.DrawLine(pens, h1s, SetPointCurrentType(E));
                    using (Pen pens1 = new Pen(Color.Red, SizeLineBoundArgument / 2))
                    {
                        graphicsShape.DrawLine(pens1, h2s, SetPointCurrentType(B));
                        graphicsShape.DrawLine(pens1, l1s, SetPointCurrentType(C));
                        graphicsShape.DrawLine(pens1, l2s, SetPointCurrentType(D));
                    }
                    graphicsShape.DrawLine(pens, l1e, SetPointCurrentType(A));
                    graphicsShape.DrawLine(pens, l2e, SetPointCurrentType(F));
                }
            }
            #endregion
        }
        public override double SetH { get => Math.Round(GetNewLine(A, GetNewCustomPoint(A.PointX, C.PointY)).Length, 0); set => base.SetH = value; }
        public override double SetH1 { get => Math.Round(E_line.Length, 0); set => base.SetH1 = value; }
        public override double SetH2 { get => Math.Round(A_line.Length, 0); set => base.SetH2 = value; }
        public override double SetL { get => Math.Round(F_line.Length, 0); set => base.SetL = value; }
        public override double SetL1 { get => Math.Round(GetNewLine(GetNewCustomPoint(B.PointX, C.PointY), C).Length, 0); set => base.SetL1 = value; }
        public override double SetL2 { get => Math.Round(GetNewLine(GetNewCustomPoint(E.PointX, D.PointY), D).Length, 0); set => base.SetL2 = value; }
        public override double SetH_t
        {
            get
            {
                Core.Entities.ShapePoint Sh = GetNewCustomPoint(ACheck.PointX, CCheck.PointY);
                Line l = GetNewLine(ACheck, Sh);
                return l.Length;
            }
        }
        public override double SetH2_t
        {
            get => Math.Round( A_Check_Line.Length, 0);
        }
        public override double SetH1_t
        {
            get => Math.Round(A_Check_Line.Length, 0);
        }
        public override double SetL_t { get => Math.Round(F_line.Length, 0); }
        public override double SetL1_t
        {
            get
            {
                CurvePoint.PointX = BCheck.PointX;
                CurvePoint.PointY = CCheck.PointY;
                Line l = new Line(CurvePoint, CCheck);
                return l.Length;
            }
        }
        public override double SetL2_t
        {
            get
            {
                CurvePoint.PointX = ECheck.PointX;
                CurvePoint.PointY = DCheck.PointY;
                Line l = new Line(CurvePoint, DCheck);

                return l.Length;
            }
        }
        protected override void SetHValue()
        {
            base.SetHValue();
            CurvePoint.PointX = A.PointX;
            CurvePoint.PointY = C.PointY;
            TempPoint.PointX = SetCurrentLineLength(CurvePoint, A, _SetH).PointX;
            TempPoint.PointY = SetCurrentLineLength(CurvePoint, A, _SetH).PointY;
            var diff = A.PointY - TempPoint.PointY;
            B.PointY -= diff;
            E.PointY -= diff;
            A.PointX = TempPoint.PointX;
            A.PointY = TempPoint.PointY;
            F.PointY = A.PointY;
            ValidValue = false;
        }
        protected override void SetLValue()
        {
            base.SetLValue();
            TempPoint.PointX = A.PointX + (F.PointX - A.PointX) * (_SetL / Math.Sqrt(Math.Pow((F.PointX - A.PointX), 2) + Math.Pow((F.PointY - A.PointY), 2)));
            TempPoint.PointY = A.PointY + (F.PointY - A.PointY) * (_SetL / Math.Sqrt(Math.Pow((F.PointX - A.PointX), 2) + Math.Pow((F.PointY - A.PointY), 2)));
            var diff = F.PointX - TempPoint.PointX;
            D.PointX -= diff;
            F.PointX = TempPoint.PointX;
            E.PointX = F.PointX;
            ValidValue = false;
        }
        protected override void SetL1Value()
        {
            CurvePoint.PointX = B.PointX;
            CurvePoint.PointY = C.PointY;
            C.PointX = SetCurrentLineLength(CurvePoint, C, _SetL1).PointX;
            C.PointY = SetCurrentLineLength(CurvePoint, C, _SetL1).PointY;
            D.PointY = C.PointY;
            if (B.PointX >= C.PointX)
            {
                B.PointX = C.PointX - 2;
            }
            ValidValue = false;
        }
        protected override void SetL2Value()
        {
            CurvePoint.PointX = E.PointX;
            CurvePoint.PointY = D.PointY;
            D.PointX = SetCurrentLineLength(CurvePoint, D, _SetL2).PointX;
            D.PointY = SetCurrentLineLength(CurvePoint, D, _SetL2).PointY;

            if (D.PointX <= C.PointX)
            {
                D.PointX = C.PointX + 1;
            }
            ValidValue = false;
        }
        protected override void SetH1Value()
        {
            base.SetH1Value();
            E.PointY = SetCurrentLineLength(F, E, _SetH1).PointY;
            ValidValue = false;
        }
        protected override void SetH2Value()
        {
            base.SetH2Value();
            B.PointX = A.PointX;
            B.PointX = SetCurrentLineLength(A, B, _SetH2).PointX;
            B.PointY = SetCurrentLineLength(A, B, _SetH2).PointY;
            ValidValue = false;
        }
        public override void GetExtremumPoints()
        {

            List<Core.Entities.ShapePoint> pointList = new List<Core.Entities.ShapePoint>() { A, B, C, D, E, F, ACheck, BCheck, CCheck, DCheck, ECheck, FCheck };

            var PointXMax = pointList.Max(PointX => PointX.PointX);
            var yMax = pointList.Max(PointX => PointX.PointY);
            var PointXMin = pointList.Min(PointX => PointX.PointX);
            var yMin = pointList.Min(PointX => PointX.PointY);
            W_Base = new Core.Entities.ShapePoint(PointXMin, yMax);
            X_Base = new Core.Entities.ShapePoint(PointXMin, yMin);
            Y_Base = new Core.Entities.ShapePoint(PointXMax, yMin);
            Z_Base = new Core.Entities.ShapePoint(PointXMax, yMax);

        }
        public override bool CheckValidSize()
        {
            double diag = 0;
            diag = (diag <= 90)
                ? CheckCut2 / Math.Sin(CalculateAngle(E, A, B) * Math.PI / 180)
                : (90 - ((180 - CheckCut2 / Math.Sin(CalculateAngle(E, A, B)) * Math.PI / 180)));
            diag = (!IsToothVector == true) ? 0 : diag;
            var value1 = (IsToothVector==true) ? _CheckCut1 : 0;
            var value2 = (IsToothVector==true) ? _CheckCut2 : 0;
            var value3 = (IsToothVector==true) ? _CheckCut3 : 0;
            var value4 = (IsToothVector==true) ? _CheckCut4 : 0;
            var value5 = (IsToothVector==true) ? _CheckCut5 : 0;
            var value6 = (IsToothVector == true) ? _CheckCut6 : 0;
            var width = _SetL + value1 + value5 + SetB1 + SetB3;
            var height = _SetH + SetB2 + value6 + value3;

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
            else if ((_SetH > 0) && _SetH < SetH2)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение H не может быть меньше H2");
            }
            else if ((_SetH2 > 0) && _SetH2 > SetH)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение H2 не может быть больше H");
            }
            else if ((_SetL1 > 0) && _SetL1 > SetL - SetL2)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение L не может быть меньше L-L2");
            }
            else if ((_SetL2 > 0) && _SetL2 > SetL - SetL1)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение L не может быть меньше L-L2");
            }
            else if ((_SetL > 0) && _SetL < SetL1 + SetL2)
            {
                ValidValue = true;
                ValidateSetSizeMessage(Text: "Значение L не может быть меньше L1+L2");
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
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH1_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetH2_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL1_t");
                AddIfPropertyExist(e.Properties, filteredCollection, "SetL2_t");
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
